using DateVoyage.Entity;
using DateVoyage.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DateVoyage.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            //_key = new SymmetricSecurityKey(Convert.FromBase64String(config["TokenKey"]));
          
        }
        public string CreateToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId,user.UserName)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };

           var tokenHandler = new JwtSecurityTokenHandler();

           var token = tokenHandler.CreateToken(tokenDescriptor);

           return tokenHandler.WriteToken(token);
        }

        //public string GenerateToken(IEnumerable<Claim> claims, int expirationSeconds = 120)
        //{
        //    if (string.IsNullOrEmpty(_tokenConfigurations.Key))
        //    {
        //        throw new InvalidOperationException("Token key is null or empty.");
        //    }

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfigurations.Key));
        //    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(
        //        issuer: _tokenConfigurations.Issuer,
        //        audience: _tokenConfigurations.Audience,
        //        claims: claims,
        //        expires: DateTime.UtcNow.AddSeconds(expirationSeconds),
        //        signingCredentials: credentials
        //    );

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    return tokenHandler.WriteToken(token);
        //}
    }
}
