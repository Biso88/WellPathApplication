using BookBuddy_backend.Models;
using BookBuddy_backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookBuddy_backend.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            try
            {
                var registeredUser = _userService.Register(user);
                return Ok(registeredUser);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            try
            {
                var user = _userService.Login(username, password);
                if (user == null)
                {
                    return Unauthorized(new { message = "Invalid username or password." });
                }

                var token = _userService.GenerateJwtToken(user);

                return Ok(new { user, token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
    }
}