using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tabi.Model;
using Tabi.Services;

namespace Tabi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CropManagementTypeController(ICropManagementTypeService cropManagementTypeService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCropManagementTypes()
        {
            IEnumerable<CropManagementType> cropManagementTypes = await cropManagementTypeService.GetCropManagementTypes();
            return Ok(cropManagementTypes);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCropManagementType(int id)
        {
            CropManagementType? cropManagementType = await cropManagementTypeService.GetCropManagementType(id);
            if (cropManagementType == null) return NotFound();
            return Ok(cropManagementType);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCropManagementType(
            [FromForm][Required][MaxLength(30)] string Name)
        {
            CropManagementType cropManagementType = await cropManagementTypeService.CreateCropManagementType(Name);
            return CreatedAtAction(nameof(GetCropManagementType), new { id = cropManagementType.CropManagementTypeID }, cropManagementType);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCropManagementType(
           [FromForm][Required] int CropManagementTypeID,
           [FromForm][MaxLength(30)] string? Name)
        {
            CropManagementType? cropManagementType = await cropManagementTypeService.GetCropManagementType(CropManagementTypeID);
            if (cropManagementType == null) return NotFound();
            cropManagementType = await cropManagementTypeService.UpdateCropManagementType(CropManagementTypeID, Name);
            return Ok(cropManagementType);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCropManagementType(int id)
        {
            CropManagementType? cropManagementType = await cropManagementTypeService.GetCropManagementType(id);
            if (cropManagementType == null) return NotFound();
            await cropManagementTypeService.DeleteCropManagementType(id);
            return NoContent();
        }
    }
}
