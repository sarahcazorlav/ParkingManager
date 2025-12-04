using Microsoft.AspNetCore.Mvc;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;

namespace Parking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoRepository _vehiculoRepository;

        public VehiculoController(IVehiculoRepository vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehiculos = await _vehiculoRepository.GetAllAsync();
            return Ok(vehiculos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vehiculo = await _vehiculoRepository.GetByIdAsync(id);
            if (vehiculo == null)
                return NotFound("Vehículo no encontrado");

            return Ok(vehiculo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Vehiculo vehiculo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _vehiculoRepository.AddAsync(vehiculo);
            return CreatedAtAction(nameof(GetById), new { id = vehiculo.Id }, vehiculo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Vehiculo vehiculo)
        {
            if (id != vehiculo.Id)
                return BadRequest("El ID no coincide");

            await _vehiculoRepository.UpdateAsync(vehiculo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _vehiculoRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
