using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ScriptRunner
{
	interface IWebServiceCallExecuter
	{
		XElement Execute(XElement request);
	}

	class FakeWebServiceCallExecuter
	{
		public XElement Execute(XElement request)
		{
			return request;
		}
	}
}
