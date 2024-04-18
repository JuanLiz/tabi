using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tabi.Model;
using Tabi.Services;

namespace Tabi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController(IUserTypeService userTypeService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUserTypes()
        {
            IEnumerable<UserType> userTypes = await userTypeService.GetUserTypes();
            return Ok(userTypes);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserType(int id)
        {
            UserType? userType = await userTypeService.GetUserType(id);
            if (userType == null) return NotFound();
            return Ok(userType);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserType(
            [Required][MaxLength(30)] string Name)
        {
            UserType userType = await userTypeService.CreateUserType(Name);
            return CreatedAtAction(nameof(GetUserType), new { id = userType.UserTypeID }, userType);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserType(
            [Required] int UserTypeID,
            [MaxLength(30)] string? Name)
        {
            UserType? userType = await userTypeService.GetUserType(UserTypeID);
            if (userType == null) return NotFound();
            userType = await userTypeService.UpdateUserType(UserTypeID, Name);
            return Ok(userType);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUserType(int id)
        {
            UserType? userType = await userTypeService.GetUserType(id);
            if (userType == null) return NotFound();
            await userTypeService.DeleteUserType(id);
            return NoContent();
        }
    }
}
