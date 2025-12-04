using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingManager.Core.Interfaces;

namespace ParkingManager.Api.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/usuario")]
    public class UsuarioV2Controller : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioV2Controller(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Obtiene usuarios (Versión 2 - Mejorada con información adicional)
        /// </summary>
        [HttpGet]
        public IActionResult GetUsuarios()
        {
            return Ok(new
            {
                Version = "2.0",
                Message = "Versión 2 del endpoint de usuarios",
                Features = new[]
                {
                    "Paginación mejorada",
                    "Filtros avanzados",
                    "Información de vehículos incluida"
                },
                Data = "Aquí irían los usuarios con más información"
            });
        }

        /// <summary>
        /// Obtiene un usuario por ID (V2)
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);

            if (usuario == null)
                return NotFound(new { message = "Usuario no encontrado" });

            return Ok(new
            {
                Version = "2.0",
                Data = usuario,
                AdditionalInfo = new
                {
                    CreatedAt = usuario.FechaRegistro,
                    IsActive = usuario.Activo
                }
            });
        }
    }
}