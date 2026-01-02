using Microsoft.AspNetCore.Mvc;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Core.QueryFilters;

namespace Parking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarifaController : ControllerBase
    {
        private readonly ITarifaService _tarifaService;

        public TarifaController(ITarifaService tarifaService)
        {
            _tarifaService = tarifaService;
        }

        /// <summary>
        /// Obtiene todas las tarifas con filtros opcionales
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] TarifaQueryFilter filters)
        {
            var tarifas = await _tarifaService.GetTarifasAsync(filters ?? new TarifaQueryFilter());
            return Ok(tarifas);
        }

        /// <summary>
        /// Obtiene una tarifa por su ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTarifaById(int id)
        {
            var tarifa = await _tarifaService.GetTarifaByIdAsync(id);
            if (tarifa is null) return NotFound();
            return Ok(tarifa);
        }

        /// <summary>
        /// Crea una nueva tarifa
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Tarifa tarifa)
        {
            var creada = await _tarifaService.CrearTarifaAsync(tarifa);

            return CreatedAtAction(
                nameof(GetTarifaById),
                new { id = creada.Id },
                creada
            );
        }

        /// <summary>
        /// Actualiza una tarifa existente
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Tarifa tarifa)
        {
            if (id != tarifa.Id)
                return BadRequest("El ID no coincide");

            await _tarifaService.UpdateTarifaAsync(tarifa);
            return NoContent();
        }
    }
}
