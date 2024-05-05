using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tabi.Model;
using Tabi.Services;

namespace Tabi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CropManagementController(ICropManagementService cropManagementService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCropManagements()
        {
            IEnumerable<CropManagement> cropManagements = await cropManagementService.GetCropManagements();
            return Ok(cropManagements);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCropManagement(int id)
        {
            CropManagement? cropManagement = await cropManagementService.GetCropManagement(id);
            if (cropManagement == null) return NotFound();
            return Ok(cropManagement);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCropManagement(
            [FromForm]
            [Required] int CropID,
            [Required] int CropManagementTypeID,
            [Required] DateOnly Date,
            [Required][MaxLength(int.MaxValue)] string Description)
        {
            CropManagement cropManagement = await cropManagementService.CreateCropManagement(CropID, CropManagementTypeID, Date, Description);
            return CreatedAtAction(nameof(GetCropManagement), new { id = cropManagement.CropManagementID }, cropManagement);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCropManagement(
            [FromForm]
            [Required] int CropManagementID,
            int? CropID,
            int? CropManagementTypeID,
            DateOnly? Date,
            [MaxLength(int.MaxValue)] string? Description)
        {
            CropManagement? cropManagement = await cropManagementService.GetCropManagement(CropManagementID);
            if (cropManagement == null) return NotFound();
            cropManagement = await cropManagementService.UpdateCropManagement(CropManagementID, CropID, CropManagementTypeID, Date, Description);
            return Ok(cropManagement);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCropManagement(int id)
        {
            CropManagement? cropManagement = await cropManagementService.GetCropManagement(id);
            if (cropManagement == null) return NotFound();
            await cropManagementService.DeleteCropManagement(id);
            return NoContent();
        }

    }

}
