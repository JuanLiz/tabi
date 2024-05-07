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
    public class CropManagementController(ISieveProcessor sieveProcessor, ICropManagementService cropManagementService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCropManagements([FromQuery] SieveModel sieveModel)
        {
            IEnumerable<CropManagement> cropManagements = await cropManagementService.GetCropManagements();
            return Ok(sieveProcessor.Apply(sieveModel, cropManagements.AsQueryable()));
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
            [FromForm][Required] int CropID,
            [FromForm][Required] int CropManagementTypeID,
            [FromForm][Required] DateOnly Date,
            [FromForm][Required][MaxLength(int.MaxValue)] string Description)
        {
            CropManagement cropManagement = await cropManagementService.CreateCropManagement(CropID, CropManagementTypeID, Date, Description);
            return CreatedAtAction(nameof(GetCropManagement), new { id = cropManagement.CropManagementID }, cropManagement);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCropManagement(
            [FromForm][Required] int CropManagementID,
            [FromForm] int? CropID,
            [FromForm] int? CropManagementTypeID,
            [FromForm] DateOnly? Date,
            [FromForm][MaxLength(int.MaxValue)] string? Description)
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
