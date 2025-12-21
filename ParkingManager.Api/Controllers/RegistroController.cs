using Microsoft.AspNetCore.Mvc;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;

namespace Parking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistroController : ControllerBase
    {
        private readonly IRegistroService _registroService;

        public RegistroController(IRegistroService registroService)
        {
            _registroService = registroService;
        }

        [HttpPost("entrada")]
        public async Task<IActionResult> RegistrarEntrada([FromBody] Registro registro)
        {
            var creado = await _registroService.RegistrarEntradaAsync(registro);

            return CreatedAtAction(nameof(GetById),
                new { id = creado.Id },
                creado);
        }

        [HttpPut("salida/{id}")]
        public async Task<IActionResult> RegistrarSalida(int id)
        {
            var registro = await _registroService.RegistrarSalidaAsync(id);
            return Ok(registro);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var registro = await _registroService.GetRegistroByIdAsync(id);
            return registro == null ? NotFound() : Ok(registro);
        }
    }

}
