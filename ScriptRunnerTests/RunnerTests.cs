using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ScriptRunner;
using Scripts;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Reflection;
using System.Diagnostics;

namespace ScriptRunnerTests
{
	[TestClass]
	public class RunnerTests
	{
		[TestMethod]
		public void TestRunScript()
		{
			var assembly = Assembly.GetExecutingAssembly();
			var stream = assembly.GetManifestResourceStream("ScriptRunnerTests.ExampleXml.xml");

			var serializer = new XmlSerializer(typeof(Script));

			var script = (Script)serializer.Deserialize(stream);
			
			var runner = new Runner(x => script);

			var result = runner.RunScript(new ScriptFile(0, "Name", "filename"));

			Assert.IsNotNull(result);
		}
	}
}
