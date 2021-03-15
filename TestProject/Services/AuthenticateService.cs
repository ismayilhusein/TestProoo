using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TestProject.Model;

namespace TestProject.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly AppSettings _appsettings;
        public AuthenticateService(IOptions<AppSettings>appsettings)
        {
        
            _appsettings = appsettings.Value;
        }
        private List<User> users = new List<User>()
        {
            new User {Id = 1 , FisrtName = "Ismayil" , LastName = "Huseynov" , UserName = "IsiHuseyn" , Password = "Ismayil335" }
        };
        public User Authenticate(string UserName , string Password)
        {
            var user = users.SingleOrDefault(x => x.UserName == UserName && x.Password == Password );

            if (user == null)
             return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appsettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {

                    new Claim (ClaimTypes.Name , user.Id.ToString()),
                    new Claim(ClaimTypes.Role , "Admin"),
                    new Claim(ClaimTypes.Version , "V3.1")
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            user.Password = null;

            return user;
        }
    }
}
