using Microsoft.AspNetCore.Mvc;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Services.InterfacesRepository;

namespace WebApplication1AGRO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataTypesController : ControllerBase
    {
        private readonly IDataTypesService _dataTypesService;

        public DataTypesController(IDataTypesService dataTypesService)
        {
            _dataTypesService = dataTypesService;
        }

        // Obtener todos los tipos de datos
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<DataTypes>>> GetAllDataTypes()
        {
            var dataTypes = await _dataTypesService.GetAllDataTypesAsync();
            return Ok(dataTypes);
        }

        // Obtener un tipo de dato por ID
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DataTypes>> GetDataTypesById(int id)
        {
            var dataTypes = await _dataTypesService.GetDataTypesByIdAsync(id);
            if (dataTypes == null)
            {
                return NotFound();
            }
            return Ok(dataTypes);
        }

        // Crear un nuevo tipo de dato
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateDataTypes([FromBody] DataTypes dataTypes)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _dataTypesService.CreateDataTypesAsync(dataTypes);
            return CreatedAtAction(nameof(GetDataTypesById), new { id = dataTypes.DataType_id }, dataTypes);
        }

        // Actualizar un tipo de dato existente
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateDataTypes(int id, [FromBody] DataTypes dataTypes)
        {
            if (id != dataTypes.DataType_id)
                return BadRequest();

            var existingDataTypes = await _dataTypesService.GetDataTypesByIdAsync(id);
            if (existingDataTypes == null)
                return NotFound();

            await _dataTypesService.UpdateDataTypesAsync(dataTypes);
            return NoContent();
        }

        // Eliminar lógicamente un tipo de dato
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteDataTypes(int id)
        {
            var dataTypes = await _dataTypesService.GetDataTypesByIdAsync(id);
            if (dataTypes == null)
                return NotFound();

            await _dataTypesService.SoftDeleteDataTypesAsync(id);
            return NoContent();
        }
    }
}
