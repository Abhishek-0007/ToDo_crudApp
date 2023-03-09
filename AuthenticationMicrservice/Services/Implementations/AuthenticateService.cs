using AuthenticationMicrservice.DAL.Repository.Interfaces;
using AuthenticationMicrservice.Models;
using AuthenticationMicrservice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc; 
using AuthenticationMicrservice.DAL.Entities;
using System.Text; 
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;

namespace AuthenticationMicrservice.Services.Implementations
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IAuthenticateRepository _repository;
        private readonly IConfiguration _config;
        public AuthenticateService(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IAuthenticateRepository>();
            _config = serviceProvider.GetRequiredService<IConfiguration>(); 
        }

        public async Task<IActionResult> LoginAsync(AuthenticateRequestModel login)
        {
            var response =  await _repository.Login(ModelConverter(login));

            try
            {
                var statusCode = response.GetType().GetProperty("StatusCode").GetValue(response, null);

                if (Convert.ToInt64(statusCode) == 200)
                {
                    Console.WriteLine(GetJwtToken());
                }
            }
            catch (Exception ex) { Console.WriteLine("400"); }

            return response;
            
        }

        public async Task<IActionResult> RegisterAsync(AuthenticateRequestModel register)
        {
            return await _repository.Register(ModelConverter(register));
        }

        private User ModelConverter(AuthenticateRequestModel requestModel)
        {
            return new User()
            {
                Email = requestModel.Email,
                Password = Encoding.UTF8.GetBytes(requestModel.Password)
            }; 
        }
        private String GetJwtToken()
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
