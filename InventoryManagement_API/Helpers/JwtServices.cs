using InventoryManagement_API.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InventoryManagement_API.Helpers
{
    public class JwtServices
    {

        private readonly IConfiguration _configuration;

        public JwtServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> GenerateTokenAsync(User user)
        {
            var jwt = _configuration.GetSection("Jwt");
            var key = Encoding.UTF8.GetBytes(jwt["Key"]);

            var claims = new[]
            {
               new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
               new Claim(ClaimTypes.Role, user.Role),
               new Claim(ClaimTypes.Name, user.Username)
            };
            var token = new JwtSecurityToken(
                issuer: jwt["Issuer"],
                audience: jwt["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(50),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256
                )
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
