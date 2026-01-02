using Microsoft.AspNetCore.Mvc;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;

namespace Parking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoService _vehiculoService;

        public VehiculoController(IVehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService;
        }

        /// <summary>
        /// Crea un nuevo vehículo
        /// <summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Vehiculo vehiculo)
        {
            await _vehiculoService.InsertVehiculoAsync(vehiculo);

            // Suponiendo que el objeto 'vehiculo' tiene el Id asignado después de la inserción
            return CreatedAtAction(nameof(GetById), new { id = vehiculo.Id }, vehiculo);
        }

        /// <summary>
        /// Obtiene un vehículo por su ID
        /// <summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vehiculo = await _vehiculoService.GetVehiculoByIdAsync(id);
            return vehiculo == null ? NotFound() : Ok(vehiculo);
        }
    }

}
