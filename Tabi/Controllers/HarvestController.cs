using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tabi.Model;
using Tabi.Services;

namespace Tabi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HarvestController(IHarvestService harvestService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetHarvests()
        {
            IEnumerable<Harvest> harvests = await harvestService.GetHarvests();
            return Ok(harvests);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetHarvest(int id)
        {
            Harvest? harvest = await harvestService.GetHarvest(id);
            if (harvest == null) return NotFound();
            return Ok(harvest);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHarvest(
            [Required] int CropID,
            [Required] int HarvestStateID,
            [Required] DateOnly Date,
            [Required] float Amount)
        {
            Harvest harvest = await harvestService.CreateHarvest(CropID, HarvestStateID, Date, Amount);
            return CreatedAtAction(nameof(GetHarvest), new { id = harvest.HarvestID }, harvest);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHarvest(
            [Required] int HarvestID,
            int? CropID,
            int? HarvestStateID,
            DateOnly? Date,
            float? Amount)
        {
            Harvest? harvest = await harvestService.GetHarvest(HarvestID);
            if (harvest == null) return NotFound();
            harvest = await harvestService.UpdateHarvest(HarvestID, CropID, HarvestStateID, Date, Amount);
            return Ok(harvest);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteHarvest(int id)
        {
            Harvest? harvest = await harvestService.GetHarvest(id);
            if (harvest == null) return NotFound();
            await harvestService.DeleteHarvest(id);
            return NoContent();
        }
    }
}
