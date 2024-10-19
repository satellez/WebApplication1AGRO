using Microsoft.AspNetCore.Mvc;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Services;
using WebApplication1AGRO.Services.InterfacesRepository;

namespace WebApplication1AGRO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentsService _documentsService;

        public DocumentsController(IDocumentsService documentsService)
        {
            _documentsService = documentsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Documents>>> GetAllDocuments()
        {
            var documents = await _documentsService.GetAllDocumentsAsync();
            return Ok(documents);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Documents>> GetDocumentsById(int id)
        {
            var documents = await _documentsService.GetDocumentsByIdAsync(id);
            if (documents == null)
            {
                return NotFound();
            }
            return Ok(documents);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateDocuments([FromBody] Documents documents)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _documentsService.CreateDocumentsAsync(documents);
            return CreatedAtAction(nameof(GetDocumentsById), new { id = documents.Document_id }, documents);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateDocuments(int id, [FromBody] Documents documents)
        {
            if (id != documents.Document_id)
                return BadRequest();

            var existingDocuments = await _documentsService.GetDocumentsByIdAsync(id);
            if (existingDocuments == null)
                return NotFound();

            await _documentsService.UpdateDocumentsAsync(documents);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteDocuments(int id)
        {
            var documents = await _documentsService.GetDocumentsByIdAsync(id);
            if (documents == null)
                return NotFound();

            await _documentsService.SoftDeleteDocumentsAsync(id);
            return NoContent();
        }
    }
}
