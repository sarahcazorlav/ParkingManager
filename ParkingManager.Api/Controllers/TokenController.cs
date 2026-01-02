using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ParkingManager.Infrastructure.Data;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;

namespace ParkingManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISecurityService _securityService;
        private readonly IPasswordService _passwordService;
        private readonly ParkingContext _context;

        public TokenController(
            IConfiguration configuration,
            ISecurityService securityService,
            IPasswordService passwordService,
            ParkingContext context)
        {
            _configuration = configuration;
            _securityService = securityService;
            _passwordService = passwordService;
            _context = context;
        }

        /// <summary>
        /// Autentica un usuario y genera un token JWT
        /// </summary>
        /// <param name="userLogin">Credenciales del usuario</param>
        /// <returns>Token JWT</returns>
        /// 
        [HttpGet("test-connection")]
        public async Task<IActionResult> TestConnection()
        {
            try
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");

                Console.WriteLine($"Intentando conectar con: {connectionString}");

                // Intentar conectar
                var canConnect = await _context.Database.CanConnectAsync();

                if (canConnect)
                {
                    // Verificar tablas
                    var tables = await _context.Database
                        .SqlQueryRaw<string>("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'")
                        .ToListAsync();

                    return Ok(new
                    {
                        Status = "✅ CONEXIÓN EXITOSA",
                        Server = "DESKTOP-GTGUPQO\\SQLEXPRESS",
                        Database = "ParkingDB",
                        TablesCount = tables.Count,
                        Tables = tables,
                        Message = "Base de datos conectada correctamente"
                    });
                }
                else
                {
                    return StatusCode(500, new
                    {
                        Status = "❌ NO SE PUEDE CONECTAR",
                        ConnectionString = connectionString,
                        Message = "Verifica que SQL Server Express esté corriendo"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Status = "❌ ERROR",
                    Error = ex.Message,
                    InnerError = ex.InnerException?.Message,
                    StackTrace = ex.StackTrace?.Split('\n').Take(5)
                });
            }
        }

        private string MaskConnectionString(string? connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                return "NO CONFIGURADO";

            // Ocultar password si existe
            var masked = connectionString;
            if (masked.Contains("Password="))
            {
                var parts = masked.Split(';');
                masked = string.Join(";", parts.Select(p =>
                    p.TrimStart().StartsWith("Password=", StringComparison.OrdinalIgnoreCase)
                        ? "Password=***"
                        : p));
            }

            return masked;
        }

        /// <summary>
        /// Autentica un usuario y genera un token JWT
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Authentication([FromBody] UserLogin userLogin)
        {
            try
            {
                // Validar usuario
                var validation = await IsValidUser(userLogin);
                if (validation.Item1)
                {
                    var token = GenerateToken(validation.Item2);
                    return Ok(new { token });
                }

                return NotFound(new { message = "Credenciales no válidas" });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new { message = ex.Message });
            }
        }

        //private async Task<(bool, Security)> IsValidUser(UserLogin userLogin)
        //{
        //    try
        //    {
        //        var user = await _securityService.GetLoginByCredentials(userLogin);

        //        if (user == null)
        //            return (false, null!);

        //        var isValidHash = _passwordService.Check(user.Password, userLogin.Password);
        //        return (isValidHash, user);
        //    }
        //    catch
        //    {
        //        return (false, null!);
        //    }
        //}
        private async Task<(bool, Security)> IsValidUser(UserLogin userLogin)
        {
            var user = await _securityService.GetLoginByCredentials(userLogin);

            if (user == null)
                return (false, null!);

            // Comparación directa (TEMPORAL)
            bool isValid = user.Password == userLogin.Password;

            return (isValid, user);
        }

        private string GenerateToken(Security security)
        {
            string secretKey = _configuration["Authentication:SecretKey"]!;

            // Header
            var symmetricSecurityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(
                symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            // Claims (Payload)
            var claims = new[]
            {
                new Claim("Name", security.Name),
                new Claim("Login", security.Login),
                new Claim(ClaimTypes.Role, security.Role.ToString())
            };

            var payload = new JwtPayload(
                issuer: _configuration["Authentication:Issuer"],
                audience: _configuration["Authentication:Audience"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(60)
            );

            // Token
            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Endpoint de prueba para verificar la configuración
        /// </summary>
        [HttpGet("config")]
        public IActionResult GetConfig()
        {
            try
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                var result = new
                {
                    connectionString = connectionString != null ? "Configurado" : "NO CONFIGURADO",
                    Environment = _configuration["ASPNETCORE_ENVIRONMENT"] ?? "NO CONFIGURADO",
                    Authentication = _configuration.GetSection("Authentication")
                        .GetChildren()
                        .Select(x => new { Key = x.Key, Value = x.Value != null ? "***" : "NULL" })
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new { message = ex.Message });
            }
        }
    }
}