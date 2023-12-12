using System.Net.Http;

namespace HyOPT.Web.App
{
    public class ServiceClientUnauthorizedException : ServiceClientException
    {
        public ServiceClientUnauthorizedException(HttpResponseMessage response)
            : base("Unauthorized", response) { }
    }
}
