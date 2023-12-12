using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace HyOPT.Web.App
{
    public abstract class ServiceClient
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _jsonOptions;

        public ServiceClient(HttpClient client, JsonSerializerOptions jsonOptions)
        {
            _client = client;
            _jsonOptions = jsonOptions;
        }

        protected async Task<HttpResponseMessage> DeleteAsync(string requestUri)
        {
            HttpResponseMessage response = await _client.DeleteAsync(requestUri);
            response.ValidateStatusCode();

            return response;
        }

        protected async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            HttpResponseMessage response = await _client.GetAsync(requestUri);
            response.ValidateStatusCode();

            return response;
        }

        protected async Task<HttpResponseMessage> PostAsJsonAsync<TValue>(string requestUri, TValue value)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync(requestUri, value, _jsonOptions);
            response.ValidateStatusCode();

            return response;
        }

        protected async Task<HttpResponseMessage> PostAsJsonAsync<TValue>(string requestUri, TValue value, string accept)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUri);
            request.Content = JsonContent.Create(value, options: _jsonOptions);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(accept));

            HttpResponseMessage response = await _client.SendAsync(request);
            response.ValidateStatusCode();

            return response;
        }

        protected async Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
        {
            HttpResponseMessage response = await _client.PostAsync(requestUri, content);
            response.ValidateStatusCode();

            return response;
        }

        protected async Task<HttpResponseMessage> PutAsJsonAsync<TValue>(string requestUri, TValue value)
        {
            HttpResponseMessage response = await _client.PutAsJsonAsync(requestUri, value, _jsonOptions);
            response.ValidateStatusCode();

            return response;
        }

        protected async Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content)
        {
            HttpResponseMessage response = await _client.PutAsync(requestUri, content);
            response.ValidateStatusCode();

            return response;
        }

        protected Task<T?> ReadFromJsonAsync<T>(HttpResponseMessage response)
        {
            return response.StatusCode != System.Net.HttpStatusCode.NoContent
                ? response.Content.ReadFromJsonAsync<T>(_jsonOptions)
                : Task.FromResult(default(T));
        }
    }
}
