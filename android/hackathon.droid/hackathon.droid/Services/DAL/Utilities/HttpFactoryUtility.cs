using System.Net.Http;
using System.Net.Http.Headers;

namespace hackathon.droid.Services.DAL.Utilities
{
	public class HttpFactoryUtility
	{
		public static void SetRequestHeaders(HttpClient client, string authorisationToken)
		{
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		    if (!string.IsNullOrEmpty(authorisationToken))
		    {
		        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorisationToken);
		    }
		}
	}
}

