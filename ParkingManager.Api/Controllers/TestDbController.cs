using Microsoft.AspNetCore.Mvc;
using ParkingManager.Infrastructure.Data;

namespace ParkingManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestDbController : ControllerBase
    {
        private readonly ParkingContext _context;

        public TestDbController(ParkingContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Verifica la conexión con la base de datos
        /// </summary>
        [HttpGet("check")]
        public IActionResult CheckConnection()
        {
            try
            {
                bool canConnect = _context.Database.CanConnect();
                return Ok(canConnect
                    ? "Conexión exitosa con la base de datos."
                    : "No se pudo conectar a la base de datos.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
