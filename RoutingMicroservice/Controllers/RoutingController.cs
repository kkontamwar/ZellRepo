using RoutingMicroservice.BuisnessLayer;
using RoutingMicroservice.Constants;
using RoutingMicroservice.Utility;
using RoutingMicroservice.WebApiOperations;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Xml;

namespace RoutingMicroservice.Controllers
{
	public class RoutingController : ApiController
	{
		// GET api/values
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/values/5
		public string Get(int id)
		{
			return "value";
		}

		// POST api/values
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		public HttpResponseMessage Put(HttpRequestMessage request)
		{
			HttpContent httpcontent = request.Content;
			string stringCotent = httpcontent.ReadAsStringAsync().Result;
			//var newContent = stringCotent.Replace(ConstantValues.xmlNameSpace, string.Empty);
			XmlDocument inputDoc = XMLOperations.GenerateXML(stringCotent);
			string fisName = XMLOperations.GetValueByXpath(inputDoc, ConstantValues.xpathVendorIdent);
			string fiURL = FIDetails.GetFIURIByName(fisName);
			string rst = WebApiOperation.ExecutivePutAPI(fiURL, httpcontent);
			//WebApiOperation.ExecutivePutAPI2(fiURL, stringCotent);

			return new HttpResponseMessage() { Content = new StringContent(rst, Encoding.UTF8,"application/xml") };
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}
