using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace RoutingMicroservice.Utility
{
	public static class XMLOperations
	{
		public static XmlDocument GenerateXML(string requestData)
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(requestData);
			return doc;
		}

		public static string GetValueByXpath(XmlDocument doc, string xpath)
		{
			string companyName = doc.DocumentElement.SelectSingleNode(xpath).InnerText;
			return companyName;
		}

	}
}