using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tabi.Model;
using Tabi.Services;

namespace Tabi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FarmController(IFarmService farmService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetFarms()
        {
            IEnumerable<Farm> farms = await farmService.GetFarms();
            return Ok(farms);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFarm(int id)
        {
            Farm? farm = await farmService.GetFarm(id);
            if (farm == null) return NotFound();
            return Ok(farm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFarm(
            [Required] int UserID,
            [Required][MaxLength(30)] string Name,
            [MaxLength(50)] string? Address,
            [Required] float Hectares
        )
        {
            Farm farm = await farmService.CreateFarm(UserID, Name, Address, Hectares);
            return CreatedAtAction(nameof(GetFarm), new { id = farm.FarmID }, farm);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFarm(
            [Required] int FarmID,
            int? UserID,
            [MaxLength(30)] string? Name,
            [MaxLength(50)] string? Address,
            float? Hectares
        )
        {
            Farm? farm = await farmService.GetFarm(FarmID);
            if (farm == null) return NotFound();
            farm = await farmService.UpdateFarm(FarmID, UserID, Name, Address, Hectares);
            return Ok(farm);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteFarm(int id)
        {
            Farm? farm = await farmService.GetFarm(id);
            if (farm == null) return NotFound();
            await farmService.DeleteFarm(id);
            return NoContent();
        }
    }
}
