using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace OnlineStoresManager.Identity
{
    public static class TokenExtensions
    {
        public static bool IsExpired(this JwtSecurityToken token)
        {
            Claim? expClaim = token.Claims.FirstOrDefault(c => c.Type == Claims.Exp);
            DateTimeOffset? expiresAt = long.TryParse(expClaim?.Value, out long seconds) ? DateTimeOffset.FromUnixTimeSeconds(seconds) : null;

            return expiresAt == null || expiresAt <= DateTimeOffset.UtcNow;
        }
    }
}
