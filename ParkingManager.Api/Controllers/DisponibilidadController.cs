using Microsoft.AspNetCore.Mvc;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using System.Threading.Tasks;

namespace ParkingManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisponibilidadController : ControllerBase
    {
        private readonly IDisponibilidadService _service;

        public DisponibilidadController(IDisponibilidadService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Disponibilidad disponibilidad)
        {
            await _service.InsertDisponibilidadAsync(disponibilidad);

            return CreatedAtAction(
                nameof(GetPorZona),
                new { zona = disponibilidad.Zona },
                disponibilidad
            );
        }

        [HttpGet("zona/{zona}")]
        public async Task<IActionResult> GetPorZona(string zona)
        {
            var result = await _service.GetDisponiblesPorZonaAsync(zona);
            return Ok(result);
        }
    }
}
