using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using Scripts;

namespace ScriptRunner
{
	public class Factory
	{
		private readonly Lazy<IScriptGetter> _scriptGetter = new Lazy<IScriptGetter>(() => new ScriptGetter());
		private readonly Lazy<IRunner> _runner = new Lazy<IRunner>(() => new Runner(x => new Script()));

		public IScriptGetter ScriptGetter
		{
			get { return this._scriptGetter.Value; }
		}

		public IRunner Runner
		{
			get { return this._runner.Value; }
		}
	}
}
