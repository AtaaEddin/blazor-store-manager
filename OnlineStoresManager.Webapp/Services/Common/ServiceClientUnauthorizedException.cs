using System.Net.Http;

namespace OnlineStoresManager.WebApp
{
    public class ServiceClientUnauthorizedException : ServiceClientException
    {
        public ServiceClientUnauthorizedException(HttpResponseMessage response)
            : base("Unauthorized", response) { }
    }
}
