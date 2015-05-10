using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using hackathon.droid.Services.DAL.Interface;
using hackathon.droid.Services.DAL.Model.ApiModels;
using hackathon.droid.Services.DAL.Utilities;
using Newtonsoft.Json;

namespace hackathon.droid.Services.DAL.Factory
{
	public class HttpFactory : IHttpFactory
	{

        /// <summary>
		/// Get with a response
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="url"></param>
		/// <param name="authorisationToken"></param>
		/// <returns></returns>
        public async Task<ApiResponseModel<T>> GetWithResponse<T>(string url, string authorisationToken)
        {
            using (var client = new HttpClient())
            {
                HttpFactoryUtility.SetRequestHeaders(client, authorisationToken);
                using (var response = await client.GetAsync(FormatUrl(url)))
                {
                    var apiResponse = await ProcessContentResult<T>(response);
                    return apiResponse;
                }
            }
        }

	    /// <summary>
	    /// Post that doesn't expect a response
	    /// </summary>
	    /// <typeparam name="T"></typeparam>
	    /// <param name="url"></param>
	    /// <param name="postData"></param>
	    /// <param name="token"></param>
	    /// <returns></returns>
	    public async Task<ApiResponseModel> PostWithoutResponse<T>(string url, T postData, string token)
	    {
            using (var client = new HttpClient())
            {
                HttpFactoryUtility.SetRequestHeaders(client, token);

                using (var response = await client.PostAsync(FormatUrl(url), new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json") ))
                {
                    var apiResponse = await ProcessNoResponse(response);
                    return apiResponse;
                }
            }
	    }

        /// <summary>
        /// Post that expects a response
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TU"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="authorisationToken"></param>
        /// <returns></returns>
        public async Task<ApiResponseModel<T>> PostWithResponse<T, TU>(string url, TU data, string authorisationToken)
        {
            using (var client = new HttpClient())
            {
                HttpFactoryUtility.SetRequestHeaders(client, authorisationToken);

                using (var response = await client.PostAsync(FormatUrl(url), new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json")))
                {
                    var apiResponse = await ProcessContentResult<T>(response);
                    return apiResponse;
                }
            }
        }

	    /// <summary>
	    /// Post data form url encoded
	    /// </summary>
	    /// <typeparam name="T"></typeparam>
	    /// <param name="url"></param>
	    /// <param name="postData"></param>
	    /// <param name="token"></param>
	    /// <returns></returns>
        public async Task<ApiResponseModel> PostFormUrlEncodedWithNoResponse<T>(string url, T postData, string token)
	    {
            using (var client = new HttpClient())
            {
                HttpFactoryUtility.SetRequestHeaders(client, token);

                using (var response = await client.PostAsync(FormatUrl(url), new FormUrlEncodedContent(JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonConvert.SerializeObject(postData)))))
                {
                    var apiResponse = await ProcessNoResponse(response);
                    return apiResponse;

                }
            }
	    }

        public async Task<ApiResponseModel> PostMultipartDataNoResponse<T>(string url, T data, List<MultiPartDataModel> multiPartData, string authorisationToken)
        {
            using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(10) })
            {
                HttpFactoryUtility.SetRequestHeaders(client, authorisationToken);

                var multipartFormDataContent = new MultipartFormDataContent();

                foreach (var mp in multiPartData)
                {
                    multipartFormDataContent.Add(new StreamContent(new MemoryStream(mp.Data)), mp.FileName, mp.FileName);
                }

                multipartFormDataContent.Add(new StringContent(JsonConvert.SerializeObject(data)), "FormData");

                using (var response = await client.PostAsync(FormatUrl(url), multipartFormDataContent))
                {
                    // ensure the response is successful or throw exception
                    
                    var apiResult = await ProcessNoResponse(response);
                    return apiResult;
                }

            }
        }

        /// <summary>
        /// PUT: Put request with no response
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="authorisationToken"></param>
        /// <returns></returns>
        public async Task<ApiResponseModel> PutWithoutResponse<T>(string url, T data, string authorisationToken)
        {
            using (var client = new HttpClient())
            {
                // add the authorisation token into header if present
                HttpFactoryUtility.SetRequestHeaders(client, authorisationToken);
                using (var response = await client.PutAsync(FormatUrl(url), new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json")))
                {
                    var apiResponse = await ProcessNoResponse(response);
                    return apiResponse;
                }
            }
        }

        /// <summary>
        /// Sends a put request to the server and expects response
        /// </summary>
        /// <typeparam name="T">The expected return type</typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="authorisationToken"></param>
        /// <returns></returns>
        public async Task<ApiResponseModel<T>> PutWithResponse<T>(string url, T data, string authorisationToken)
        {
            using (var client = new HttpClient())
            {
                HttpFactoryUtility.SetRequestHeaders(client, authorisationToken);
                using (var response = await client.PutAsync(FormatUrl(url), new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json")))
                {
                    var apiResult =  await ProcessContentResult<T>(response);
                    return apiResult;
                }
            }
        }

        #region private methods

        private static string FormatUrl(string url)
        {
            return string.Format("{0}{1}", ApiEndPoints.WebApiUrl, url);
        }


	    private static async Task<ApiResponseModel<T>> ProcessContentResult<T>(HttpResponseMessage response)
	    {
	        var result = new ApiResponseModel<T>();
	        try
	        {
                response.EnsureSuccessStatusCode();
                // read the content
                
                var responseContent = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<ApiResponseModel<T>>(responseContent);
                // deserialize result to type and return
                result.StatusCode = response.StatusCode;
                
	        }
            catch (HttpRequestException ex)
            {
                result.StatusCode = ex.ProcessRequestException();
                result.ErrorCode = "Api Error";
                result.ErrorMessage = "An error has occurred on the server";
            }
	        return result;
	    }

        private static async Task<ApiResponseModel> ProcessNoResponse(HttpResponseMessage response)
        {
            var result = new ApiResponseModel();
            try
            {

                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<ApiResponseModel>(responseContent);
                result.StatusCode = response.StatusCode;
            }
            catch (HttpRequestException ex)
            {
                result.StatusCode = ex.ProcessRequestException();
            }
            return result;
        }


        #endregion
    }
}
