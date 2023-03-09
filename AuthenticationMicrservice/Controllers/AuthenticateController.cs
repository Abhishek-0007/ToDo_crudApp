using AuthenticationMicrservice.Models;
using AuthenticationMicrservice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationMicrservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService _service;
        public AuthenticateController(IServiceProvider serviceProvider)
        {
            _service = serviceProvider.GetRequiredService<IAuthenticateService>();      
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(AuthenticateRequestModel requestModel)
        {
            return await _service.LoginAsync(requestModel);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync(AuthenticateRequestModel requestModel)
        {
            return await _service.RegisterAsync(requestModel);
        }

    }
}
