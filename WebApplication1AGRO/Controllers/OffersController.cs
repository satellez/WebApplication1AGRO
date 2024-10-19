using Microsoft.AspNetCore.Mvc;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Services.InterfacesService;

namespace WebApplication1AGRO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OffersController : ControllerBase
    {
        private readonly IOffersService _offersService;

        public OffersController(IOffersService offersService)
        {
            _offersService = offersService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Offers>>> GetAllOffers()
        {
            var offers = await _offersService.GetAllOffersAsync();
            return Ok(offers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Offers>> GetOffersById(int id)
        {
            var offers = await _offersService.GetOffersByIdAsync(id);
            if (offers == null)
            {
                return NotFound($"Oferta con ID {id} no encontrada.");
            }
            return Ok(offers);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateOffers([FromBody] Offers offers)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _offersService.CreateOffersAsync(offers);
            return CreatedAtAction(nameof(GetOffersById), new { id = offers.Offer_id }, offers);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateOffers(int id, [FromBody] Offers offers)
        {
            if (id != offers.Offer_id)
                return BadRequest("ID de oferta no coincide.");

            var existingOffers = await _offersService.GetOffersByIdAsync(id);
            if (existingOffers == null)
                return NotFound($"Oferta con ID {id} no encontrada.");

            await _offersService.UpdateOffersAsync(offers);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteOffers(int id)
        {
            var offers = await _offersService.GetOffersByIdAsync(id);
            if (offers == null)
                return NotFound($"Oferta con ID {id} no encontrada.");

            await _offersService.SoftDeleteOffersAsync(id);
            return NoContent();
        }
    }
}
