using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tabi.Model;
using Tabi.Services;

namespace Tabi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HarvestStateController(IHarvestStateService harvestStateService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetHarvestStates()
        {
            IEnumerable<HarvestState> harvestStates = await harvestStateService.GetHarvestStates();
            return Ok(harvestStates);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetHarvestState(int id)
        {
            HarvestState? harvestState = await harvestStateService.GetHarvestState(id);
            if (harvestState == null) return NotFound();
            return Ok(harvestState);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHarvestState(
            [FromForm]
            [Required] [MaxLength(30)] string Name)
        {
            HarvestState harvestState = await harvestStateService.CreateHarvestState(Name);
            return CreatedAtAction(nameof(GetHarvestState), new { id = harvestState.HarvestStateID }, harvestState);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHarvestState(
            [FromForm]
            [Required] int HarvestStateID,
            [MaxLength(30)] string? Name)
        {
            HarvestState? harvestState = await harvestStateService.GetHarvestState(HarvestStateID);
            if (harvestState == null) return NotFound();
            harvestState = await harvestStateService.UpdateHarvestState(HarvestStateID, Name);
            return Ok(harvestState);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteHarvestState(int id)
        {
            HarvestState? harvestState = await harvestStateService.GetHarvestState(id);
            if (harvestState == null) return NotFound();
            await harvestStateService.DeleteHarvestState(id);
            return NoContent();
        }
    }
}
