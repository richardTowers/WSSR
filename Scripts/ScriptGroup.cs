using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scripts
{
	public class ScriptGroup
	{
		private readonly string _title;
		private readonly IList<ScriptFile> _scripts;

		public ScriptGroup(string title, IList<ScriptFile> scripts)
		{
			this._title = title;
			this._scripts = scripts;
		}

		public string Title
		{
			get { return this._title; }
		}

		public IList<ScriptFile> Scripts
		{
			get { return this._scripts; }
		}
	}
}
