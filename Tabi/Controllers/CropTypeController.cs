using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tabi.Helpers;
using Tabi.Model;
using Tabi.Services;

namespace Tabi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CropTypeController(ICropTypeService cropTypeService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCropTypes()
        {
            IEnumerable<CropType> cropTypes = await cropTypeService.GetCropTypes();
            return Ok(cropTypes);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCropType(int id)
        {
            CropType? cropType = await cropTypeService.GetCropType(id);
            if (cropType == null) return NotFound();
            return Ok(cropType);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCropType(
            [FromForm][Required][MaxLength(30)] string Name,
            [FromForm][Required] float ExpectedYield)
        {
            CropType cropType = await cropTypeService.CreateCropType(Name, ExpectedYield);
            return CreatedAtAction(nameof(GetCropType), new { id = cropType.CropTypeID }, cropType);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCropType(
            [FromForm][Required] int CropTypeID,
            [FromForm][MaxLength(30)] string? Name,
            [FromForm] float? ExpectedYield)
        {
            CropType? cropType = await cropTypeService.GetCropType(CropTypeID);
            if (cropType == null) return NotFound();
            cropType = await cropTypeService.UpdateCropType(CropTypeID, Name, ExpectedYield);
            return Ok(cropType);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCropType(int id)
        {
            CropType? cropType = await cropTypeService.GetCropType(id);
            if (cropType == null) return NotFound();
            await cropTypeService.DeleteCropType(id);
            return NoContent();
        }
    }
}
