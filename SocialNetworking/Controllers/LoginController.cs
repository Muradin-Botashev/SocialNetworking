using Microsoft.AspNetCore.Mvc;
using SocialNetworking.Models.Requests;
using SocialNetworking.Services.UserService;

namespace SocialNetworking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _userService.LoginAsync(request);
            return result ? Ok() : Unauthorized();
        }
    }
}