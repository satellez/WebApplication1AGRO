using Microsoft.AspNetCore.Mvc;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Services;
using WebApplication1AGRO.Services.InterfacesRepository;

namespace WebApplication1AGRO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillDetailsController : ControllerBase
    {
        private readonly IBillDetailsService _billDetailsService;

        public BillDetailsController(IBillDetailsService billDetailsService)
        {
            _billDetailsService = billDetailsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<BillDetails>>> GetAllBillDetails()
        {
            var billDetails1 = await _billDetailsService.GetAllBillDetailsAsync();
            return Ok(billDetails1);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BillDetails>> GetBillDetailsById(int id)
        {
            var billDetails = await _billDetailsService.GetBillDetailsByIdAsync(id);
            if (billDetails == null)
            {
                return NotFound();
            }
            return Ok(billDetails);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateBillDetails([FromBody] BillDetails billDetails)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _billDetailsService.CreateBillDetailsAsync(billDetails);
            return CreatedAtAction(nameof(GetBillDetailsById), new { id = billDetails.BillDeta_id }, billDetails);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBillDetails(int id, [FromBody] BillDetails billDetails)
        {
            if (id != billDetails.BillDeta_id)
                return BadRequest();

            var existingBillDetails = await _billDetailsService.GetBillDetailsByIdAsync(id);
            if (existingBillDetails == null)
                return NotFound();

            await _billDetailsService.UpdateBillDetailsAsync(billDetails);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteBillDetails(int id)
        {
            var billDetails = await _billDetailsService.GetBillDetailsByIdAsync(id);
            if (billDetails == null)
                return NotFound();

            await _billDetailsService.SoftDeleteBillDetailsAsync(id);
            return NoContent();
        }
    }
}
