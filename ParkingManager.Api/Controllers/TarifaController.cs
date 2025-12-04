using Microsoft.AspNetCore.Mvc;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;

namespace Parking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarifaController : ControllerBase
    {
        private readonly ITarifaRepository _tarifaRepository;

        public TarifaController(ITarifaRepository tarifaRepository)
        {
            _tarifaRepository = tarifaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tarifas = await _tarifaRepository.GetAllAsync();
            return Ok(tarifas);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Tarifa tarifa)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _tarifaRepository.AddAsync(tarifa);
            return Ok(tarifa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Tarifa tarifa)
        {
            if (id != tarifa.Id)
                return BadRequest("El ID no coincide");

            await _tarifaRepository.UpdateAsync(tarifa);
            return NoContent();
        }
    }
}
