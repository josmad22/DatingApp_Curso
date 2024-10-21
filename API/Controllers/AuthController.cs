using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var result = await _userService.RegisterUser(model.Email, model.Password, model.UserName);
            if (!result)
            {
                return BadRequest("User registration failed");
            }
            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _userService.AuthenticateUser(model.Email, model.Password);
            if (!result)
            {
                return Unauthorized("Invalid email or password");
            }
            return Ok("User logged in successfully");
        }
    }
}
