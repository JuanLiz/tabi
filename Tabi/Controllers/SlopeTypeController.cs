using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tabi.Model;
using Tabi.Services;

namespace Tabi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SlopeTypeController(ISlopeTypeService slopeTypeService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetSlopeTypes()
        {
            IEnumerable<SlopeType> slopeTypes = await slopeTypeService.GetSlopeTypes();
            return Ok(slopeTypes);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSlopeType(int id)
        {
            SlopeType? slopeType = await slopeTypeService.GetSlopeType(id);
            if (slopeType == null) return NotFound();
            return Ok(slopeType);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlopeType(
            [Required][MaxLength(30)] string Name)
        {
            SlopeType slopeType = await slopeTypeService.CreateSlopeType(Name);
            return CreatedAtAction(nameof(GetSlopeType), new { id = slopeType.SlopeTypeID }, slopeType);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSlopeType(
            [Required] int SlopeTypeID,
            [MaxLength(30)] string? Name)
        {
            SlopeType? slopeType = await slopeTypeService.GetSlopeType(SlopeTypeID);
            if (slopeType == null) return NotFound();
            slopeType = await slopeTypeService.UpdateSlopeType(SlopeTypeID, Name);
            return Ok(slopeType);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSlopeType(int id)
        {
            SlopeType? slopeType = await slopeTypeService.GetSlopeType(id);
            if (slopeType == null) return NotFound();
            await slopeTypeService.DeleteSlopeType(id);
            return NoContent();
        }
    }
}
