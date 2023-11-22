using Microsoft.AspNetCore.Mvc;
using SocialNetworking.Models.Requests;
using SocialNetworking.Services.UserService;

namespace SocialNetworking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _userService.RegisterAsync(request);
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetUser([FromRoute] GetUserRequest request)
        {
            var result = await _userService.FindByIdAsync(request);
            return result is null ? NotFound() : Ok(result);
        }
    }
}