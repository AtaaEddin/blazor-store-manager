using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;

namespace OnlineStoresManager.Identity
{
    public static class TokenSerializer
    {
        public static JwtSecurityToken Deserialize(string tokenText)
        {
            return new JwtSecurityTokenHandler().ReadJwtToken(tokenText);
        }

        public static string Serialize(SecurityTokenDescriptor tokenDescriptor)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityToken token = handler.CreateToken(tokenDescriptor);
            string tokenText = handler.WriteToken(token);

            return tokenText;
        }
    }
}
