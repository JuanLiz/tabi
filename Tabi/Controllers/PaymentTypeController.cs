using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tabi.Model;
using Tabi.Services;

namespace Tabi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypeController(IPaymentTypeService paymentTypeService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPaymentTypes()
        {
            IEnumerable<PaymentType> paymentTypes = await paymentTypeService.GetPaymentTypes();
            return Ok(paymentTypes);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPaymentType(int id)
        {
            PaymentType? paymentType = await paymentTypeService.GetPaymentType(id);
            if (paymentType == null) return NotFound();
            return Ok(paymentType);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePaymentType(
            [FromForm]
            [Required] [MaxLength(30)] string Name)
        {
            PaymentType paymentType = await paymentTypeService.CreatePaymentType(Name);
            return CreatedAtAction(nameof(GetPaymentType), new { id = paymentType.PaymentTypeID }, paymentType);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePaymentType(
            [FromForm]
            [Required] int PaymentTypeID,
            [MaxLength(30)] string? Name)
        {
            PaymentType? paymentType = await paymentTypeService.GetPaymentType(PaymentTypeID);
            if (paymentType == null) return NotFound();
            paymentType = await paymentTypeService.UpdatePaymentType(PaymentTypeID, Name);
            return Ok(paymentType);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePaymentType(int id)
        {
            PaymentType? paymentType = await paymentTypeService.GetPaymentType(id);
            if (paymentType == null) return NotFound();
            await paymentTypeService.DeletePaymentType(id);
            return NoContent();
        }
    }
}
