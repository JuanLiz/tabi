using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tabi.Model;
using Tabi.Services;

namespace Tabi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            IEnumerable<User> users = await userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            User? user = await userService.GetUser(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(
            [Required] int UserTypeID,
            [Required][MaxLength(30)] string Name,
            [Required][MaxLength(30)] string LastName,
            int? DocumentTypeID,
            [MaxLength(10)] string? DocumentNumber,
            [MaxLength(12)] string? Username,
            [Required] [MaxLength(320)] [EmailAddress(ErrorMessage = "Invalid email address")]
            string Email,
            [Required][MaxLength(30)] string Password,
            [Length(10, 10, ErrorMessage = "Phone number must be 10 digits")]
            [Phone(ErrorMessage = "Invalid phone number")]
            string? Phone,
            [MaxLength(50)] string? Address)
        {
            User user = await userService.CreateUser(UserTypeID, Name, LastName, DocumentTypeID, DocumentNumber, Username, Email, Password, Phone, Address);
            return CreatedAtAction(nameof(GetUser), new { id = user.UserID }, user);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(
            [Required] int UserID,
            int? UserTypeID,
            [MaxLength(30)] string? Name,
            [MaxLength(30)] string? LastName,
            int? DocumentTypeID,
            [MaxLength(10)] string? DocumentNumber,
            [MaxLength(12)] string? Username,
            [MaxLength(320)] [EmailAddress(ErrorMessage = "Invalid email address")]
            string? Email,
            [MaxLength(30)] string? Password,
            [Length(10, 10, ErrorMessage = "Phone number must be 10 digits")]
            [Phone(ErrorMessage = "Invalid phone number")]
            string? Phone,
            [MaxLength(50)] string? Address)
        {
            User? user = await userService.GetUser(UserID);
            if (user == null) return NotFound();
            user = await userService.UpdateUser(UserID, UserTypeID, Name, LastName, DocumentTypeID, DocumentNumber, Username, Email, Password, Phone, Address);
            return Ok(user);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            User? user = await userService.GetUser(id);
            if (user == null) return NotFound();
            await userService.DeleteUser(id);
            return NoContent();
        }
    }
}
