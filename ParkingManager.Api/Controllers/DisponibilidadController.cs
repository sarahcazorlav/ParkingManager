using Microsoft.AspNetCore.Mvc;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;

namespace Parking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisponibilidadController : ControllerBase
    {
        private readonly IDisponibilidadRepository _disponibilidadRepository;

        public DisponibilidadController(IDisponibilidadRepository disponibilidadRepository)
        {
            _disponibilidadRepository = disponibilidadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lugares = await _disponibilidadRepository.GetAllAsync();
            return Ok(lugares);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var lugar = await _disponibilidadRepository.GetByIdAsync(id);
            if (lugar == null)
                return NotFound("Lugar no encontrado");

            return Ok(lugar);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Disponibilidad disponibilidad)
        {
            await _disponibilidadRepository.AddAsync(disponibilidad);
            return Ok(disponibilidad);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Disponibilidad disponibilidad)
        {
            if (id != disponibilidad.Id)
                return BadRequest("El ID no coincide");

            await _disponibilidadRepository.UpdateAsync(disponibilidad);
            return NoContent();
        }
    }
}
