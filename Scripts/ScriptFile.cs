using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scripts
{
	public class ScriptFile
	{
		private readonly long _id;
		private readonly string _name;
		private readonly string _filePath;

		public ScriptFile(long id, string name, string filePath)
		{
			this._id = id;
			this._name = name;
			this._filePath = filePath;
		}

		public long Id
		{
			get { return this._id; }
		}

		public string Name
		{
			get { return this._name; }
		}

		public string FilePath
		{
			get { return this._filePath; }
		}
	}
}
