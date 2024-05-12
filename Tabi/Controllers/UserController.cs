using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using Sieve.Services;
using Tabi.Helpers;
using Tabi.Model;
using Tabi.Services;

namespace Tabi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController(ISieveProcessor sieveProcessor, IUserService userService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] SieveModel sieveModel)
        {
            IEnumerable<User> users = await userService.GetUsers();
            return Ok(sieveProcessor.Apply(sieveModel, users.AsQueryable()));
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
            [FromForm][Required] int UserTypeID,
            [FromForm][Required][MaxLength(30)] string Name,
            [FromForm][Required][MaxLength(30)] string LastName,
            [FromForm] int? DocumentTypeID,
            [FromForm][MaxLength(10)] string? DocumentNumber,
            [FromForm][MaxLength(12)] string? Username,
            [FromForm][Required][MaxLength(320)][EmailAddress(ErrorMessage = "Invalid email address")]
            string Email,
            [FromForm][Required][MaxLength(30)] string Password,
            [FromForm][Length(10, 10, ErrorMessage = "Phone number must be 10 digits")]
            [Phone(ErrorMessage = "Invalid phone number")]
            string? Phone,
            [FromForm][MaxLength(50)] string? Address)
        {
            // Check if the email is already taken
            User? emailUser = await userService.GetUserByEmail(Email);
            if (emailUser != null && emailUser.UserTypeID == UserTypeID)
                return BadRequest(new { message = "Email is already taken" });
        
            // Check if the username is already taken
            if (Username != null)
            {
                User? userCheck = await userService.GetUserByUsername(Username);
                if (userCheck != null && userCheck.UserTypeID == UserTypeID)
                    return BadRequest(new { message = "Username is already taken" });
            }


            User user = await userService.CreateUser(UserTypeID, Name, LastName, DocumentTypeID, DocumentNumber, Username, Email, Password, Phone, Address);
            return CreatedAtAction(nameof(GetUser), new { id = user.UserID }, user);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(
            [FromForm][Required] int UserID,
            [FromForm] int? UserTypeID,
            [FromForm][MaxLength(30)] string? Name,
            [FromForm][MaxLength(30)] string? LastName,
            [FromForm] int? DocumentTypeID,
            [FromForm][MaxLength(10)] string? DocumentNumber,
            [FromForm][MaxLength(12)] string? Username,
            [FromForm] [MaxLength(320)] [EmailAddress(ErrorMessage = "Invalid email address")]
            string? Email,
            [FromForm][MaxLength(30)] string? Password,
            [FromForm] [Length(10, 10, ErrorMessage = "Phone number must be 10 digits")]
            [Phone(ErrorMessage = "Invalid phone number")]
            string? Phone,
            [FromForm][MaxLength(50)] string? Address)
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
