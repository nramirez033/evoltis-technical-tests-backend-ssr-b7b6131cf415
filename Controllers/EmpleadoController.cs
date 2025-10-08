using Microsoft.AspNetCore.Mvc;
using technical_tests_backend_ssr.DTOs;
using technical_tests_backend_ssr.Services;

namespace technical_tests_backend_ssr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _service;

        public EmpleadoController(IEmpleadoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.ListarAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var empleado = await _service.ObtenerByIdAsync(id);
            return empleado == null ? NotFound() : Ok(empleado);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EmpleadoDTO dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                Console.WriteLine("Errores: " + string.Join(", ", errors));
                return BadRequest(errors);
            }

            var result = await _service.AgregarAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmpleadoDTO dto)
        {
            var result = await _service.ActualizarAsync(id, dto);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.EliminarAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
