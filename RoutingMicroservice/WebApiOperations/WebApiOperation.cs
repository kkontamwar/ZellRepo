using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace RoutingMicroservice.WebApiOperations
{
	public static class WebApiOperation
	{
		public static string ExecutivePutAPI(string ApiUri, HttpContent content)
		{

			using (var client = new HttpClient())
			{
				try
				{
					client.BaseAddress = new Uri(ApiUri);
				
					var responseTask = client.PutAsync(ApiUri, content);
					responseTask.Wait();
					var result = responseTask.Result;
					if (result.IsSuccessStatusCode)
					{
						string reslt = result.Content.ReadAsStringAsync().Result;
						return reslt;
					}
					return string.Empty;
				}
				catch (HttpRequestException e)
				{
					Console.WriteLine(e.InnerException.Message);
				}
				return string.Empty;
			}
		}


		public static void ExecutivePutAPI2(string ApiUri, string content)
		{
			HttpClient client = new HttpClient();
			var inputMessage = new HttpRequestMessage
			{
				Content = new StringContent(content, Encoding.UTF8, "application/xml")
			};
			inputMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
			HttpResponseMessage message = client.PutAsync(ApiUri, inputMessage.Content).Result;
			if (message.IsSuccessStatusCode)
			{
			}
		}
	}
}