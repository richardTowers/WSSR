using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scripts;

namespace ScriptRunner
{
	public interface IScriptGetter
	{
		ScriptGroup[] GetScripts();
	}

    class ScriptGetter : IScriptGetter
    {
		public ScriptGroup[] GetScripts()
		{
			var i = 0;
			return new[] {
				new ScriptGroup(
					title: "My fake client",
					scripts: new [] {
						new ScriptFile(
							id: i++,
							name: "AddContact",
							filePath: "data")
					}),
			};
		}
    }
}
