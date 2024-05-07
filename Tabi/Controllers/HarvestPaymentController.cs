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
    public class HarvestPaymentController(ISieveProcessor sieveProcessor, IHarvestPaymentService harvestPaymentService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetHarvestPayments([FromQuery] SieveModel sieveModel)
        {
            IEnumerable<HarvestPayment> harvestPayments = await harvestPaymentService.GetHarvestPayments();
            return Ok(sieveProcessor.Apply(sieveModel, harvestPayments.AsQueryable()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetHarvestPayment(int id)
        {
            HarvestPayment? harvestPayment = await harvestPaymentService.GetHarvestPayment(id);
            if (harvestPayment == null) return NotFound();
            return Ok(harvestPayment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHarvestPayment(
            [FromForm][Required] int HarvestID,
            [FromForm][Required] int UserID,
            [FromForm][Required] float HarvestedAmount,
            [FromForm][Required] int PaymentTypeID,
            [FromForm][Required] float PaymentAmount,
            [FromForm][Required] DateOnly PaymentDate)
        {
            HarvestPayment harvestPayment = await harvestPaymentService.CreateHarvestPayment(HarvestID, UserID, HarvestedAmount, PaymentTypeID, PaymentAmount, PaymentDate);
            return CreatedAtAction(nameof(GetHarvestPayment), new { id = harvestPayment.HarvestPaymentID }, harvestPayment);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHarvestPayment(
            [FromForm][Required] int HarvestPaymentID,
            [FromForm] int? HarvestID,
            [FromForm] int? UserID,
            [FromForm] float? HarvestedAmount,
            [FromForm] int? PaymentTypeID,
            [FromForm] float? PaymentAmount,
            [FromForm] DateOnly? PaymentDate)
        {
            HarvestPayment? harvestPayment = await harvestPaymentService.GetHarvestPayment(HarvestPaymentID);
            if (harvestPayment == null) return NotFound();
            harvestPayment = await harvestPaymentService.UpdateHarvestPayment(HarvestPaymentID, HarvestID, UserID, HarvestedAmount, PaymentTypeID, PaymentAmount, PaymentDate);
            return Ok(harvestPayment);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteHarvestPayment(int id)
        {
            HarvestPayment? harvestPayment = await harvestPaymentService.GetHarvestPayment(id);
            if (harvestPayment == null) return NotFound();
            await harvestPaymentService.DeleteHarvestPayment(id);
            return NoContent();
        }
    }
}
