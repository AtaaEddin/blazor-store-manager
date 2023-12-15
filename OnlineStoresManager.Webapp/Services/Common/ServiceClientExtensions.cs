using System.Net;
using System.Net.Http;

namespace OnlineStoresManager.WebApp
{
    public static class ServiceClientExtensions
    {
        public static void ValidateStatusCode(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.Unauthorized:
                        throw new ServiceClientUnauthorizedException(response);
                    case HttpStatusCode.Forbidden:
                        throw new ServiceClientForbiddenException(response);
                    default:
                        throw new ServiceClientException($"{response.StatusCode} ({response.ReasonPhrase})", response);
                }
            }
        }
    }
}
