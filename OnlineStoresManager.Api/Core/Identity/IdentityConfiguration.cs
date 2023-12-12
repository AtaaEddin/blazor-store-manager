using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace OnlineStoresManager.API
{
    public class IdentityConfiguration
    {
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string Key { get; set; } = null!;
        public TimeSpan TokenLifetime { get; set; }
        public string Storage { get; set; } = null!;

        private SecurityKey? _signingKey;
        public SecurityKey SigningKey => _signingKey ??= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
    }
}
