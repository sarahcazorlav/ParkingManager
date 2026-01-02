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

        /// <summary>
        /// Registra la entrada de un vehículo al estacionamiento
        /// </summary>
        [HttpPost("entrada")]
        public async Task<IActionResult> RegistrarEntrada([FromBody] Registro registro)
        {
            var creado = await _registroService.RegistrarEntradaAsync(registro);

            return CreatedAtAction(nameof(GetById),
                new { id = creado.Id },
                creado);
        }

        /// <summary>
        /// Registra la salida de un vehículo del estacionamiento
        /// </summary>
        [HttpPut("salida/{id}")]
        public async Task<IActionResult> RegistrarSalida(int id)
        {
            var registro = await _registroService.RegistrarSalidaAsync(id);
            return Ok(registro);
        }

        /// <summary>
        /// Obtiene un registro por su ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var registro = await _registroService.GetRegistroByIdAsync(id);
            return registro == null ? NotFound() : Ok(registro);
        }
    }

}
