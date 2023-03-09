using AuthenticationMicrservice.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationMicrservice.Services.Interfaces
{
    public interface IAuthenticateService
    {
        public Task<IActionResult> LoginAsync(AuthenticateRequestModel login);
        public Task<IActionResult> RegisterAsync(AuthenticateRequestModel register);

    }
}
