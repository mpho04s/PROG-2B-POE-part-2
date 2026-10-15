using Microsoft.AspNetCore.Mvc;
using RaceDayAPI.Models;

namespace RaceDayAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private static List<Users> users = new List<Users>
        {
            new Users
            {
                UserID = 1,
                FullName = "John Smith",
                Email = "john@gmail.com",
                PasswordHash = "12345",
                Role = "Participant",
                CreatedAt = "2026-09-10"
            },

            new Users
            {
                UserID = 2,
                FullName = "Mary Jones",
                Email = "mary@gmail.com",
                PasswordHash = "12345",
                Role = "Organiser",
                CreatedAt = "2026-09-10"
            }
        };

        [HttpPost("register")]
        public IActionResult Register(Users user)
        {
            var existingUser = users.FirstOrDefault(u => u.Email == user.Email);

            if (existingUser != null)
            {
                return BadRequest("Email is already registered.");
            }

            user.UserID = users.Count + 1;
            user.CreatedAt = DateTime.Now.ToString();

            users.Add(user);

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            var user = users.FirstOrDefault(u =>
                u.Email == email &&
                u.PasswordHash == password);

            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            return Ok(new
            {
                Message = "Login successful.",
                UserID = user.UserID,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role
            });
        }
    }
}
