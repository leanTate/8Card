using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using BE.entites;
using System.IdentityModel.Tokens.Jwt;

namespace Services
{
    public class JWT
    {
        public static string CreateToken(User user ) {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name,user.userName)
            };
            DotNetEnv.Env.TraversePath().Load();
            var SecretWord = Environment.GetEnvironmentVariable("TokenKey");

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(SecretWord));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: creds,
                expires: DateTime.Now.AddDays(1)
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
