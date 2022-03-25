using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TokenJwtEstudo.Model;

namespace TokenJwtEstudo.Service
{
    public static class TokenService
    {
        public static string GenerateToken(User user)
        {
            var tokeHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(Settings.Secret); // encriptando chave

            var tokenDescription = new SecurityTokenDescriptor // definições do token
            {
                Expires = DateTime.UtcNow.AddHours(8),

                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role)
                }),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokeHandler.CreateToken(tokenDescription);

            return tokeHandler.WriteToken(token);
        }
    }
}
