using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tabi.Model;
using Tabi.Services;

namespace Tabi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LotController(ILotService lotService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetLots()
        {
            IEnumerable<Lot> lots = await lotService.GetLots();
            return Ok(lots);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetLot(int id)
        {
            Lot? lot = await lotService.GetLot(id);
            if (lot == null) return NotFound();
            return Ok(lot);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLot(
            [Required] int FarmID,
            [Required][MaxLength(30)] string Name,
            [Required] float Hectares,
            [Required] int SlopeTypeID)
        {
            Lot lot = await lotService.CreateLot(FarmID, Name, Hectares, SlopeTypeID);
            return CreatedAtAction(nameof(GetLot), new { id = lot.LotID }, lot);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLot(
            [Required] int LotID,
            int? FarmID,
            [MaxLength(30)] string? Name,
            float? Hectares,
            int? SlopeTypeID)
        {
            Lot? lot = await lotService.GetLot(LotID);
            if (lot == null) return NotFound();
            lot = await lotService.UpdateLot(LotID, FarmID, Name, Hectares, SlopeTypeID);
            return Ok(lot);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteLot(int id)
        {
            Lot? lot = await lotService.GetLot(id);
            if (lot == null) return NotFound();
            await lotService.DeleteLot(id);
            return NoContent();
        }
    }
}
