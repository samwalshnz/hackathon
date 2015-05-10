using System.Collections.Generic;
using System.Threading.Tasks;
using hackathon.droid.Services.DAL.Model.ApiModels;

namespace hackathon.droid.Services.DAL.Interface
{
	public interface IHttpFactory
    {

        #region v1
        Task<ApiResponseModel<T>> GetWithResponse<T>(string url, string authorisationToken);
        Task<ApiResponseModel> PostWithoutResponse<T>(string url, T data, string authorisationToken);
        Task<ApiResponseModel<T>> PostWithResponse<T, TU>(string url, TU data, string authorisationToken);
        Task<ApiResponseModel> PostFormUrlEncodedWithNoResponse<T>(string url, T data, string authorisationToken);

	    Task<ApiResponseModel> PostMultipartDataNoResponse<T>(string url, T data, List<MultiPartDataModel> multiPartData, string authorisationToken);
        Task<ApiResponseModel> PutWithoutResponse<T>(string url, T data, string authorisationToken);
        Task<ApiResponseModel<T>> PutWithResponse<T>(string url, T data, string authorisationToken);
        #endregion
    }
}

