using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStoresManager.Web.App
{
    public class ServiceClientAuthenticator : DelegatingHandler
    {
        private readonly LocalStorage _localStorage;

        public ServiceClientAuthenticator(LocalStorage localStorage)
        {
            _localStorage = localStorage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string? accessToken = await _localStorage.GetAccessToken();
            if (!string.IsNullOrEmpty(accessToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            return response;
        }
    }
}
