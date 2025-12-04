using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingManager.Api.Responses;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Enum;
using ParkingManager.Core.Interfaces;
using ParkingManager.Infrastructure.DTOs;
using System.Net;

namespace ParkingManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IPasswordService _passwordService;

        public SecurityController(
            ISecurityService securityService,
            IPasswordService passwordService)
        {
            _securityService = securityService;
            _passwordService = passwordService;
        }

        /// <summary>
        /// Registra un nuevo usuario en el sistema
        /// </summary>
        /// <param name="securityDto">Datos del usuario</param>
        /// <returns>Usuario registrado</returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] SecurityDto securityDto)
        {
            try
            {
                // Crear entidad Security
                var security = new Security
                {
                    Login = securityDto.Login,
                    Password = _passwordService.Hash(securityDto.Password),
                    Name = securityDto.Name,
                    Role = securityDto.Role
                };

                await _securityService.RegisterUser(security);

                // No devolver el password
                var response = new
                {
                    Id = security.Id,
                    Login = security.Login,
                    Name = security.Name,
                    Role = security.Role
                };

                return Ok(new ApiResponse<object>(response));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new { message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene información del usuario autenticado (requiere token)
        /// </summary>
        [Authorize]
        [HttpGet("me")]
        public IActionResult GetCurrentUser()
        {
            var name = User.Claims.FirstOrDefault(c => c.Type == "Name")?.Value;
            var login = User.Claims.FirstOrDefault(c => c.Type == "Login")?.Value;
            var role = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;

            return Ok(new
            {
                Name = name,
                Login = login,
                Role = role
            });
        }
    }
}