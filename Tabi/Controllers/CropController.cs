using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tabi.Model;
using Tabi.Services;

namespace Tabi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CropController(ICropService cropService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCrops()
        {
            IEnumerable<Crop> crops = await cropService.GetCrops();
            return Ok(crops);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCrop(int id)
        {
            Crop? crop = await cropService.GetCrop(id);
            if (crop == null) return NotFound();
            return Ok(crop);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCrop(
            [FromForm][Required] int LotID,
            [FromForm][Required] float Hectares,
            [FromForm][Required] int CropTypeID,
            [FromForm][Required] int CropStateID,
            [FromForm][Required] DateOnly PlantingDate,
            [FromForm] DateOnly? HarvestDate
            )
        {
            Crop crop = await cropService.CreateCrop(LotID, Hectares, CropTypeID, CropStateID, PlantingDate, HarvestDate);
            return CreatedAtAction(nameof(GetCrop), new { id = crop.CropID }, crop);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCrop(
            [FromForm][Required] int CropID,
            [FromForm] int? LotID,
            [FromForm] float? Hectares,
            [FromForm] int? CropTypeID,
            [FromForm] int? CropStateID,
            [FromForm] DateOnly? PlantingDate,
            [FromForm] DateOnly? HarvestDate
        )
        {
            Crop? crop = await cropService.GetCrop(CropID);
            if (crop == null) return NotFound();
            crop = await cropService.UpdateCrop(CropID, LotID, Hectares, CropTypeID, CropStateID, PlantingDate, HarvestDate);
            return Ok(crop);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCrop(int id)
        {
            Crop? crop = await cropService.DeleteCrop(id);
            if (crop == null) return NotFound();
            await cropService.DeleteCrop(id);
            return NoContent();
        }


    }
}
