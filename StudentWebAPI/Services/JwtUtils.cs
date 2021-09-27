using Microsoft.IdentityModel.Tokens;
using StudentWebAPI.Models;
using StudentWebAPI.ViewModel;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace StudentWebAPI.Services
{
    public class JwtUtils : IJwtUtils
    {
        /*private readonly AppSettings _appSettings;

        public JwtUtils(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }*/
        private static string Secret = "8Zz5tw0Ionm3XPlsfN0NOml3z9FMfmQpgXwovRAfp6ryDIoGRM8EPHAB6iHsc0fb";

        public string GenerateToken(Admin user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Convert.FromBase64String(Secret);
            // var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("id", user.Id.ToString()),
                    new Claim("role", user.Role.ToString())} 
                ),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
            // generate token that is valid for 7 days
            
        }

        public Encoded ValidateToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Convert.FromBase64String(Secret);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x => x.Type == "id").Value;
                var role = jwtToken.Claims.First(x => x.Type == "role").Value;

                Encoded en = new Encoded(int.Parse(role), int.Parse(userId));
                return en;
            }
            catch (Exception e)
            {
                // return null if validation fails
                return null;
            }
        }
    }
}