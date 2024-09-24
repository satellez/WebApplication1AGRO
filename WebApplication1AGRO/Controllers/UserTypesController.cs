using Microsoft.AspNetCore.Mvc;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Services;

namespace WebApplication1AGRO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTypesController : ControllerBase
    {
        private readonly IUserTypesService _userTypesService;

        public UserTypesController(IUserTypesService userTypesService)
        {
            _userTypesService = userTypesService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<UserTypes>>> GetAllUserTypes()
        {
            var userTypes1 = await _userTypesService.GetAllUserTypesAsync();
            return Ok(userTypes1);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<UserTypes>> GetUserTypesById(int id)
        {
            var userTypes = await _userTypesService.GetUserTypesByIdAsync(id);
            if (userTypes == null)
            {
                return NotFound();
            }
            return Ok(userTypes);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateUserTypes([FromBody] UserTypes userTypes)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userTypesService.CreateUserTypesAsync(userTypes);
            return CreatedAtAction(nameof(GetUserTypesById), new { id = userTypes.UserType_id }, userTypes);

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateUserTypes(int id, [FromBody] UserTypes userTypes)
        {
            if (id != userTypes.UserType_id)
                return BadRequest();

            var existingUserTypes = await _userTypesService.GetUserTypesByIdAsync(id);
            if (existingUserTypes == null)
                return NotFound();

            await _userTypesService.UpdateUserTypesAsync(userTypes);
            return NoContent();

        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteUserTypes(int id)
        {
            var userTypes = await _userTypesService.GetUserTypesByIdAsync(id);
            if (userTypes == null)
                return NotFound();

            await _userTypesService.SoftDeleteUserTypesAsync(id);
            return NoContent();
        }
    }
}
