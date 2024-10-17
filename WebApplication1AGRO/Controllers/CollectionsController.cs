using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Services.InterfacesService;

namespace WebApplication1AGRO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionsController : ControllerBase
    {
        private readonly ICollectionsService _collectionsService;

        public CollectionsController(ICollectionsService collectionsService)
        {
            _collectionsService = collectionsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Collections>>> GetAllCollections()
        {
            var collections = await _collectionsService.GetAllCollectionsAsync();
            return Ok(collections);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Collections>> GetCollectionsById(int id)
        {
            var collections = await _collectionsService.GetCollectionsByIdAsync(id);
            if (collections == null)
            {
                return NotFound();
            }
            return Ok(collections);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateCollections([FromBody] Collections collections)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _collectionsService.CreateCollectionsAsync(collections);
            return CreatedAtAction(nameof(GetCollectionsById), new { id = collections.CollectionPoint_id }, collections);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCollections(int id, [FromBody] Collections collections)
        {
            if (id != collections.CollectionPoint_id)
                return BadRequest();

            var existingCollections = await _collectionsService.GetCollectionsByIdAsync(id);
            if (existingCollections == null)
                return NotFound();

            await _collectionsService.UpdateCollectionsAsync(collections);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteCollections(int id)
        {
            var collections = await _collectionsService.GetCollectionsByIdAsync(id);
            if (collections == null)
                return NotFound();

            await _collectionsService.SoftDeleteCollectionsAsync(id);
            return NoContent();
        }
    }
}
