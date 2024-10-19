using Microsoft.AspNetCore.Mvc;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Services;
using WebApplication1AGRO.Services.InterfacesRepository;

namespace WebApplication1AGRO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentMethodsController : ControllerBase
    {
        private readonly IPaymentMethodsService _paymentMethodsService;

        public PaymentMethodsController(IPaymentMethodsService paymentMethodsService)
        {
            _paymentMethodsService = paymentMethodsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<PaymentMethods>>> GetAllPaymentMethods()
        {
            var paymentMethods = await _paymentMethodsService.GetAllPaymentMethodsAsync();
            return Ok(paymentMethods);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PaymentMethods>> GetPaymentMethodsById(int id)
        {
            var paymentMethod = await _paymentMethodsService.GetPaymentMethodsByIdAsync(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }
            return Ok(paymentMethod);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreatePaymentMethods([FromBody] PaymentMethods paymentMethods)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _paymentMethodsService.CreatePaymentMethodsAsync(paymentMethods);
            return CreatedAtAction(nameof(GetPaymentMethodsById), new { id = paymentMethods.Method_id }, paymentMethods);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePaymentMethods(int id, [FromBody] PaymentMethods paymentMethods)
        {
            if (id != paymentMethods.Method_id)
                return BadRequest();

            var existingPaymentMethod = await _paymentMethodsService.GetPaymentMethodsByIdAsync(id);
            if (existingPaymentMethod == null)
                return NotFound();

            await _paymentMethodsService.UpdatePaymentMethodsAsync(paymentMethods);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeletePaymentMethods(int id)
        {
            var paymentMethod = await _paymentMethodsService.GetPaymentMethodsByIdAsync(id);
            if (paymentMethod == null)
                return NotFound();

            await _paymentMethodsService.SoftDeletePaymentMethodsAsync(id);
            return NoContent();
        }
    }
}
