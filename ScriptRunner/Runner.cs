using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml;
using System.Xml.XPath;
using System.Text;
using Scripts;
using RazorEngine;

namespace ScriptRunner
{
	public interface IRunner
	{
		object RunScript(ScriptFile script);
	}

	class Runner : IRunner
	{
		private readonly Func<string, Script> _loadScript;

		public Runner(Func<string, Script> loadScript)
		{
			this._loadScript = loadScript;
		}

		public object RunScript(ScriptFile scriptFile)
		{
			var script = this._loadScript(scriptFile.FilePath);

			var executer = new FakeWebServiceCallExecuter();

			var model = new Dictionary<string, XElement>();

			foreach (var call in script.Calls)
			{
				// Transform the call:
				var request = this.TransformCall(call, model);

				// Execute it:
				var response = executer.Execute(request);

				model.Add(call.Id, response);
			}

			return script;
		}

		private XElement TransformCall(Call call, Dictionary<string, XElement> model)
		{
			var sb = new StringBuilder();

			// Create variables for each of the calls that have been made so far:
			foreach (var response in model)
			{
				sb.AppendLine("@{ var " + response.Key + " = @Model[\"" + response.Key + "\"]; }");
			}

			// Add the call template
			sb.Append(call.Contents.ToString());

			// Replace backticks with double quotes
			// (this is so we can put quotes in attributes and still have well-formed XML)
			sb.Replace("`", "\"");

			// Transform the call
			var rawCall = sb.ToString();
			var transformedCall = Razor.Parse(rawCall, model);

			// Parse the string back into XML
			var xdoc = XDocument.Parse(transformedCall);
			return xdoc.Root;
		}
	}
}
