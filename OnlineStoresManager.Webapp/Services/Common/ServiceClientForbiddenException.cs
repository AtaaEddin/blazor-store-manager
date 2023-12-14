using System.Net.Http;

namespace OnlineStoresManager.Web.App
{
    public class ServiceClientForbiddenException : ServiceClientException
    {
        public ServiceClientForbiddenException(HttpResponseMessage response)
            : base("Forbidden", response) { }
    }
}
