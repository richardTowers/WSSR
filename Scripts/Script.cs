using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Text;

namespace Scripts
{
	public class Script
	{
		[XmlElement("Authorisation")]
		public Authorisation Authorisation;

		[XmlArray("Requests")]
		[XmlArrayItem("Call")]
		public List<Call> Calls;
	}

	public class Authorisation
	{
		[XmlAttribute("Username")]
		public string Username;
		[XmlAttribute("Password")]
		public string Password;
	}

	public class Call
	{
		[XmlAttribute("Id")]
		public string Id;

		[XmlAnyElement]
		public XElement Contents;
	}

}
