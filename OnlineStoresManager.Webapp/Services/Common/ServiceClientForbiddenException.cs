using System.Net.Http;

namespace HyOPT.Web.App
{
    public class ServiceClientForbiddenException : ServiceClientException
    {
        public ServiceClientForbiddenException(HttpResponseMessage response)
            : base("Forbidden", response) { }
    }
}
