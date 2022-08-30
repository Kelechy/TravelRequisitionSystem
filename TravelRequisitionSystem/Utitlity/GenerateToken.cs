using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TravelRequisitionSystem.Utitlity
{
    public static class GenerateToken
    {
        public static string GenerateJwtToken(IConfiguration config)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
                 {
                new Claim(JwtRegisteredClaimNames.NameId, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, config.GetValue<string>("Jwt:Key"))
            };

            var token = new JwtSecurityToken(config["Jwt:Issuer"],
              config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var userToken = new JwtSecurityTokenHandler().WriteToken(token);
            return userToken;
        }
    }
}
