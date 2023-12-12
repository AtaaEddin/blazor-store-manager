using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using mudblazor.Common.Identity;
using mudblazor.Identity;
using System.Security.Claims;

namespace OnlineStoresManager.API
{
    public class IdentityService
    {
        private readonly IdentityConfiguration _configuration;

        public IdentityService(IdentityConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();
            IdentityUser? user = await FindUser(request.UserName, request.Password);

            if (user != null)
            {
                response.Token = TokenSerializer.Serialize(
                    new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(
                            new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, user.UserName),
                                new Claim(ClaimTypes.Role, user.Role)
                            }),
                        Expires = DateTime.UtcNow.Add(_configuration.TokenLifetime),
                        Issuer = _configuration.Issuer,
                        Audience = _configuration.Audience,
                        SigningCredentials = new SigningCredentials(_configuration.SigningKey, SecurityAlgorithms.HmacSha512Signature)
                    });
            }

            return response;
        }

        private async Task<IdentityUser?> FindUser(string? userName, string? password)
        {
            if (!File.Exists(_configuration.Storage))
            {
                return null;
            }

            string usersJson = await File.ReadAllTextAsync(_configuration.Storage);
            List<IdentityUser>? users = JsonSerializer.Deserialize<List<IdentityUser>>(usersJson);
            IdentityUser? user = users?.SingleOrDefault(u => u.UserName == userName && u.Password == password);

            return user;
        }
    }
}
