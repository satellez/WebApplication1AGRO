using Microsoft.AspNetCore.Mvc;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Services.InterfacesRepository;

namespace WebApplication1AGRO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        // GET all users
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Users>>> GetAllUsers()
        {
            var users1 = await _usersService.GetAllUsersAsync();
            return Ok(users1);
        }

        // GET user by ID
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Users>> GetUsersById(int id)
        {
            var users = await _usersService.GetUsersByIdAsync(id);
            if (users == null)
            {
                return NotFound($"User with ID {id} not found.");
            }
            return Ok(users);
        }

        // POST create new user
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateUsers([FromBody] Users users)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _usersService.CreateUsersAsync(users);
            return CreatedAtAction(nameof(GetUsersById), new { id = users.User_id }, users);
        }

        // PUT update existing user
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUsers(int id, [FromBody] Users users)
        {
            
            if (id != users.User_id)
                return BadRequest("User ID mismatch.");

            
            var existingUsers = await _usersService.GetUsersByIdAsync(id);
            if (existingUsers == null)
                return NotFound($"User with ID {id} not found.");

            
            await _usersService.UpdateUsersAsync(users);
            return NoContent();  // Return 204 if successful
        }

        // DELETE soft delete user
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteUsers(int id)
        {
            var users = await _usersService.GetUsersByIdAsync(id);
            if (users == null)
                return NotFound($"User with ID {id} not found.");

            await _usersService.SoftDeleteUsersAsync(id);
            return NoContent();
        }
    }
}
