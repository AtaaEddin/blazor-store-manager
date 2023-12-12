using HyOPT.Identity;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HyOPT.Web.App
{
    public class IdentityService : ServiceClient
    {
        public IdentityService(HttpClient client, JsonSerializerOptions jsonOptions)
            : base(client, jsonOptions) { }

        public async Task<LoginResponse?> Login(LoginRequest request)
        {
            HttpResponseMessage httpResponse = await PostAsJsonAsync("login", request);
            LoginResponse? response = await ReadFromJsonAsync<LoginResponse>(httpResponse);

            return response;
        }
    }
}
