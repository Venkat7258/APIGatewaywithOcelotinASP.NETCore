using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthMicroservice.Model
{
    public class AuthManager : IAuthManager
    {
        private readonly string _key;

        public AuthManager(string key)
        {
            _key = key;
        }
        // This in-memory is just for test. This should come from db.
        private readonly IDictionary<string, string> users = new Dictionary<string, string>()
            {{"admin", "Password@1"}, {"Venkat", "Venkat@7258"}};
        public AuthToken Authenticate(string username, string password)
        {
            if (!users.Any(u => u.Key == username && u.Value == password))
            {
                return null;
            }
            // Create JWT Token, if it matches
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var expirationDate = DateTime.UtcNow.AddHours(2);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(audience: "productsAudience",
                                             issuer: "productsIssuer",
                                             claims: claims,
                                             expires: expirationDate,
                                             signingCredentials: credentials);

            var authToken = new AuthToken();
            authToken.Token = new JwtSecurityTokenHandler().WriteToken(token);
            authToken.ExpirationDate = expirationDate;

            return authToken;
        }
    }
}
