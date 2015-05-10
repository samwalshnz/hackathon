using System.Collections.Generic;
using System.Net;

namespace hackathon.droid.Services.DAL.Model.ApiModels
{
    public class ApiResponseModel<T>
    {
        public string ErrorMessage { get; set; }
        public Dictionary<string, string> ValidationErrors { get; set; }
        public T ReturnData { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorCode { get; set; }

        public bool Success
        {
            get { return ValidationErrors == null && string.IsNullOrEmpty(ErrorMessage) && string.IsNullOrEmpty(ErrorCode); }
        }
    }

    public class ApiResponseModel : ApiResponseModel<object>{ }
}
