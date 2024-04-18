using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tabi.Model;
using Tabi.Services;

namespace Tabi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CropStateController(ICropStateService cropStateService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCropStates()
        {
            IEnumerable<CropState> cropStates = await cropStateService.GetCropStates();
            return Ok(cropStates);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCropState(int id)
        {
            CropState? cropState = await cropStateService.GetCropState(id);
            if (cropState == null) return NotFound();
            return Ok(cropState);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCropState(
            [Required] [MaxLength(30)] string Name)
        {
            CropState cropState = await cropStateService.CreateCropState(Name);
            return CreatedAtAction(nameof(GetCropState), new { id = cropState.CropStateID }, cropState);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCropState(
            [Required] int CropStateID,
            [MaxLength(30)] string? Name)
        {
            CropState? cropState = await cropStateService.GetCropState(CropStateID);
            if (cropState == null) return NotFound();
            cropState = await cropStateService.UpdateCropState(CropStateID, Name);
            return Ok(cropState);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCropState(int id)
        {
            CropState? cropState = await cropStateService.GetCropState(id);
            if (cropState == null) return NotFound();
            await cropStateService.DeleteCropState(id);
            return NoContent();
        }
    }
}
