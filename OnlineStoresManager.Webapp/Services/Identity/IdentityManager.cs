using HyOPT.Identity;

using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;

namespace HyOPT.Web.App
{
    public class IdentityManager
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly IdentityService _identityService;
        private readonly LocalStorage _localStorage;

        public IdentityManager(AuthenticationStateProvider authenticationStateProvider, IdentityService identityService, LocalStorage localStorage)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _identityService = identityService;
            _localStorage = localStorage;
        }

        public async Task<bool> Login(LoginRequest request)
        {
            LoginResponse? response = await _identityService.Login(request);
            bool success = response?.IsSuccess == true;

            if (success)
            {
                await _localStorage.SetAccessToken(response!.Token!);
                await _authenticationStateProvider.GetAuthenticationStateAsync();
            }

            return success;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveAccessToken();
            await _authenticationStateProvider.GetAuthenticationStateAsync();
        }
    }
}
