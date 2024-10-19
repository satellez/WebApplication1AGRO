using Microsoft.AspNetCore.Mvc;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Services.InterfacesRepository;

namespace WebApplication1AGRO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillsController : ControllerBase
    {
        private readonly IBillsService _billsService;

        public BillsController(IBillsService billsService)
        {
            _billsService = billsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Bills>>> GetAllBills()
        {
            var bills = await _billsService.GetAllBillsAsync();
            return Ok(bills);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Bills>> GetBillsById(int id)
        {
            var bills = await _billsService.GetBillsByIdAsync(id);
            if (bills == null)
            {
                return NotFound();
            }
            return Ok(bills);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateBills([FromBody] Bills bills)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _billsService.CreateBillsAsync(bills);
            return CreatedAtAction(nameof(GetBillsById), new { id = bills.Bill_id }, bills);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBills(int id, [FromBody] Bills bills)
        {
            if (id != bills.Bill_id)
                return BadRequest();

            var existingBills = await _billsService.GetBillsByIdAsync(id);
            if (existingBills == null)
                return NotFound();

            await _billsService.UpdateBillsAsync(bills);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteBills(int id)
        {
            var bills = await _billsService.GetBillsByIdAsync(id);
            if (bills == null)
                return NotFound();

            await _billsService.SoftDeleteBillsAsync(id);
            return NoContent();
        }
    }
}
