using Microsoft.AspNetCore.Mvc;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Infrastructure.DTOs;
using System.Globalization;
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

        /// <summary>
        /// Obtiene la disponibilidad de todos los espacios en un rango de fechas
        /// </summary>
        [HttpPost("rango-fechas")]
        public async Task<IActionResult> GetDisponibilidadPorRango(
            [FromBody] DisponibilidadRangoRequestDto request)
        {
            try
            {
                // Convertir los campos individuales a DateTime
                var fechaInicio = request.ObtenerFechaInicio();
                var fechaFinal = request.ObtenerFechaFinal();

                // Validación adicional
                if (fechaInicio > fechaFinal)
                {
                    return BadRequest(new
                    {
                        message = "La fecha de inicio no puede ser mayor a la fecha final"
                    });
                }

                if ((fechaFinal - fechaInicio).TotalDays > 31)
                {
                    return BadRequest(new
                    {
                        message = "El rango de fechas no puede ser mayor a 31 días"
                    });
                }

                // Obtener datos del servicio
                var disponibilidades = await _service
                    .GetDisponibilidadesPorRangoFechasAsync(fechaInicio, fechaFinal);

                // Mapeo manual a DTO con manejo de NULL
                var resultado = disponibilidades.Select(d => new DisponibilidadRangoDto
                {
                    Fecha = d.FechaActualizacion.Date,
                    Dia = CultureInfo.GetCultureInfo("es-ES")
                        .DateTimeFormat.GetDayName(d.FechaActualizacion.DayOfWeek),
                    Hora = d.FechaActualizacion.TimeOfDay,
                    NumeroEspacio = d.NumeroEspacio ?? "Sin número",
                    Zona = string.IsNullOrEmpty(d.Zona) ? "Sin zona" : d.Zona,
                    Estado = string.IsNullOrEmpty(d.Estado)
                        ? (d.Ocupado ? "Ocupado" : "Libre")
                        : d.Estado
                }).ToList();

                return Ok(resultado);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest(new
                {
                    message = "Las fechas proporcionadas no son válidas. Verifique día, mes y año."
                });
            }
        }

        /// <summary>
        /// Obtiene solo los espacios disponibles en un rango de fechas
        /// </summary>
        [HttpPost("disponibles/rango-fechas")]
        public async Task<IActionResult> GetEspaciosDisponiblesPorRango(
            [FromBody] DisponibilidadRangoRequestDto request)
        {
            try
            {
                // Convertir los campos individuales a DateTime
                var fechaInicio = request.ObtenerFechaInicio();
                var fechaFinal = request.ObtenerFechaFinal();

                // Validación adicional
                if (fechaInicio > fechaFinal)
                {
                    return BadRequest(new
                    {
                        message = "La fecha de inicio no puede ser mayor a la fecha final"
                    });
                }

                if ((fechaFinal - fechaFinal).TotalDays > 31)
                {
                    return BadRequest(new
                    {
                        message = "El rango de fechas no puede ser mayor a 31 días"
                    });
                }

                // Obtener solo las fechas de espacios disponibles
                var fechasDisponibles = await _service
                    .GetDisponibilidadesPorRangoFechasAsync(fechaInicio, fechaFinal);

                // Mapeo a DTO simple
                var resultado = fechasDisponibles
                    .Where(d => !d.Ocupado) // Solo espacios disponibles
                    .Select(d => new DisponibilidadSimpleDto
                    {
                        Fecha = d.FechaActualizacion.Date,
                        Dia = CultureInfo.GetCultureInfo("es-ES")
                            .DateTimeFormat.GetDayName(d.FechaActualizacion.DayOfWeek),
                        Hora = d.FechaActualizacion.TimeOfDay
                    })
                    .ToList();

                return Ok(resultado);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest(new
                {
                    message = "Las fechas proporcionadas no son válidas. Verifique día, mes y año."
                });
            }
        }
    }
}