using Backend_Api.Services.Interfaces;
using Domian.Entities.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend_Api.Services.Implementation
{
    public class TokenService : ITokenService
    {
        #region Consractore

        private readonly SymmetricSecurityKey _key;

        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        }

        #endregion

        public string CreateToken(User user)
        {
            var claims = new List<Claim>()
            {
                //new Claim("UserId", user.Id.ToString()),
                //new Claim(JwtRegisteredClaimNames.NameId, user.Username.ToString()),

                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
