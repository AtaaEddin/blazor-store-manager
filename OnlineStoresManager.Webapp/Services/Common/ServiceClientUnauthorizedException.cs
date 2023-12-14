using System.Net.Http;

namespace OnlineStoresManager.Web.App
{
    public class ServiceClientUnauthorizedException : ServiceClientException
    {
        public ServiceClientUnauthorizedException(HttpResponseMessage response)
            : base("Unauthorized", response) { }
    }
}
