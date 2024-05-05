using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Tabi.Model;
using Tabi.Services;

namespace Tabi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUserService userService) : ControllerBase
    {

        [HttpPost("Login")]
        public async Task<IActionResult> Authenticate([FromForm] AuthRequest authRequest)
        {
            var response = await userService.Authenticate(authRequest);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm][Required] int UserTypeID,
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
            var response = await userService.CreateUser(
                UserTypeID,
                Name,
                LastName,
                DocumentTypeID,
                DocumentNumber,
                Username,
                Email,
                Password,
                Phone,
                Address);

            return Ok(response);
        }
    }
}
