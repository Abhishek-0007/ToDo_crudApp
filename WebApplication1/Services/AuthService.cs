using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WebApplication1.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        public AuthService(IServiceProvider serviceProvider)
        {
            _config = serviceProvider.GetRequiredService<IConfiguration>();
        }

        public String GetJwtToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["JWT:ValidIssuer"],
              _config["JWT:ValidIssuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token); 
        }
    }
}
