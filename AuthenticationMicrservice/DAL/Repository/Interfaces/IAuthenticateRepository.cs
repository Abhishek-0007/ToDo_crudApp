using AuthenticationMicrservice.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationMicrservice.DAL.Repository.Interfaces
{
    public interface IAuthenticateRepository
    {
        public Task<IActionResult> Login(User user); 
        public Task<IActionResult> Register(User user);

    }
}
