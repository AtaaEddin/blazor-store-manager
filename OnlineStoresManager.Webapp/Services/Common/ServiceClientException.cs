using System;
using System.Net.Http;

namespace HyOPT.Web.App
{
    public class ServiceClientException : Exception
    {
        public HttpResponseMessage Response { get; }

        public ServiceClientException(string message, HttpResponseMessage response) : base(message)
        {
            Response = response;
        }
    }
}
