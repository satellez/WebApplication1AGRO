using Microsoft.AspNetCore.Mvc;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Services.InterfacesRepository;

namespace WebApplication1AGRO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsService _contactsService;

        public ContactsController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Contacts>>> GetAllContacts()
        {
            var contacts1 = await _contactsService.GetAllContactsAsync();
            return Ok(contacts1);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Contacts>> GetContactsById(int id)
        {
            var contacts = await _contactsService.GetContactsByIdAsync(id);
            if (contacts == null)
            {
                return NotFound($"Contact con ID {id} no encontrado.");
            }
            return Ok(contacts);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateContacts([FromBody] Contacts contacts)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _contactsService.CreateContactsAsync(contacts);
            return CreatedAtAction(nameof(GetContactsById), new { id = contacts.Contact_id }, contacts);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateContacts(int id, [FromBody] Contacts contacts)
        {
            if (id != contacts.Contact_id)
                return BadRequest("Contact ID mismatch.");

            var existingContacts = await _contactsService.GetContactsByIdAsync(id);
            if (existingContacts == null)
                return NotFound($"Contact con ID {id} no encontrado.");

            await _contactsService.UpdateContactsAsync(contacts);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteContacts(int id)
        {
            var contacts = await _contactsService.GetContactsByIdAsync(id);
            if (contacts == null)
                return NotFound($"Contact con ID {id} no encontrado.");

            await _contactsService.SoftDeleteContactsAsync(id);
            return NoContent();
        }
    }
}
