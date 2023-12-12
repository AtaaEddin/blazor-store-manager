using HyOPT.Identity;

using Microsoft.AspNetCore.Components.Authorization;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using System.Threading.Tasks;

namespace HyOPT.Web.App
{
    public class IdentityStateProvider : AuthenticationStateProvider
    {
        private readonly LocalStorage _storage;

        public IdentityStateProvider(LocalStorage storage)
        {
            _storage = storage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            ClaimsIdentity identity;
            string? tokenText = await _storage.GetAccessToken();

            if (!string.IsNullOrEmpty(tokenText))
            {
                JwtSecurityToken token = TokenSerializer.Deserialize(tokenText);
                identity = token.IsExpired()
                    ? new ClaimsIdentity()
                    : new ClaimsIdentity(token.Claims, "jwt", Claims.UniqueName, Claims.Role);
            }
            else
            {
                identity = new ClaimsIdentity();
            }

            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            AuthenticationState state = new AuthenticationState(principal);
            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }
    }
}
