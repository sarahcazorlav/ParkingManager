using Microsoft.AspNetCore.Mvc;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;

namespace Parking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistroController : ControllerBase
    {
        private readonly IRegistroRepository _registroRepository;

        public RegistroController(IRegistroRepository registroRepository)
        {
            _registroRepository = registroRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var registros = await _registroRepository.GetAllAsync();
            return Ok(registros);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var registro = await _registroRepository.GetByIdAsync(id);
            if (registro == null)
                return NotFound("Registro no encontrado");

            return Ok(registro);
        }

        [HttpPost("entrada")]
        public async Task<IActionResult> RegistrarEntrada([FromBody] Registro registro)
        {
            await _registroRepository.RegistrarEntradaAsync(registro);
            return Ok("Entrada registrada correctamente");
        }

        [HttpPut("salida/{id}")]
        public async Task<IActionResult> RegistrarSalida(int id)
        {
            await _registroRepository.RegistrarSalidaAsync(id);
            return Ok("Salida registrada correctamente");
        }
    }
}
