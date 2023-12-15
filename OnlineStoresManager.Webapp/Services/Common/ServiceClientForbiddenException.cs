using System.Net.Http;

namespace OnlineStoresManager.WebApp
{
    public class ServiceClientForbiddenException : ServiceClientException
    {
        public ServiceClientForbiddenException(HttpResponseMessage response)
            : base("Forbidden", response) { }
    }
}
