using Microsoft.AspNetCore.Mvc;
using RaceDayAPI.Models;

namespace RaceDayAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static List<Users> users = new List<Users>
        {
            new Users
            {
                UserID = 1,
                FullName = "John Smith",
                Email = "john@example.com",
                PasswordHash = "password123",
                Role = "Participant",
                CreatedAt = "2026-09-10"
            },

            new Users
            {
                UserID = 2,
                FullName = "Mary Jones",
                Email = "mary@example.com",
                PasswordHash = "password456",
                Role = "Organiser",
                CreatedAt = "2026-09-10"
            }
        };

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = users.FirstOrDefault(u => u.UserID == id);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser(Users user)
        {
            users.Add(user);

            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, Users updatedUser)
        {
            var user = users.FirstOrDefault(u => u.UserID == id);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            user.FullName = updatedUser.FullName;
            user.Email = updatedUser.Email;
            user.PasswordHash = updatedUser.PasswordHash;
            user.Role = updatedUser.Role;
            user.CreatedAt = updatedUser.CreatedAt;

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = users.FirstOrDefault(u => u.UserID == id);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            users.Remove(user);

            return Ok("User deleted successfully.");
        }
    }
}
