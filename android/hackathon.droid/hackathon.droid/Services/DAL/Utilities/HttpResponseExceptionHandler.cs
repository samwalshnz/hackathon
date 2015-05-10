using System.Net;
using System.Net.Http;

namespace hackathon.droid.Services.DAL.Utilities
{
    public static class HttpResponseExceptionHandler
    {
        public static HttpStatusCode ProcessRequestException(this HttpRequestException ex)
        {
            if (ex.Message.Contains("400"))
            {
                return HttpStatusCode.BadRequest;
            }

            if (ex.Message.Contains("401"))
            {
                return HttpStatusCode.Unauthorized;
            }
             
            if (ex.Message.Contains("403"))
            {
                return HttpStatusCode.Forbidden;
            }

            return HttpStatusCode.InternalServerError;
        }
    }
}
