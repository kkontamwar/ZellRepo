using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace RoutingMicroservice.WebApiOperations
{
	public static class WebApiOperation
	{
		public static string ExecutivePutAPI(string ApiUri , HttpContent content)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(ApiUri);
				var responseTask = client.PutAsync(ApiUri, content);
				responseTask.Wait();
				var result = responseTask.Result;
				if (true)
				{
					string reslt = result.Content.ReadAsStringAsync().Result;
				}
				return string.Empty;
			}
		}
	}
}