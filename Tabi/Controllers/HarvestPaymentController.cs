using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tabi.Model;
using Tabi.Services;

namespace Tabi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HarvestPaymentController(IHarvestPaymentService harvestPaymentService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetHarvestPayments()
        {
            IEnumerable<HarvestPayment> harvestPayments = await harvestPaymentService.GetHarvestPayments();
            return Ok(harvestPayments);
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
            [Required] int HarvestID,
            [Required] int UserID,
            [Required] float HarvestedAmount,
            [Required] int PaymentTypeID,
            [Required] float PaymentAmount,
            [Required] DateOnly PaymentDate)
        {
            HarvestPayment harvestPayment = await harvestPaymentService.CreateHarvestPayment(HarvestID, UserID, HarvestedAmount, PaymentTypeID, PaymentAmount, PaymentDate);
            return CreatedAtAction(nameof(GetHarvestPayment), new { id = harvestPayment.HarvestPaymentID }, harvestPayment);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHarvestPayment(
            [Required] int HarvestPaymentID,
            int? HarvestID,
            int? UserID,
            float? HarvestedAmount,
            int? PaymentTypeID,
            float? PaymentAmount,
            DateOnly? PaymentDate)
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
