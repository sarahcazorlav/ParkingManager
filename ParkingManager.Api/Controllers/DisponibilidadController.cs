using Microsoft.AspNetCore.Mvc;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Infrastructure.DTOs;
using AutoMapper;
using System.Globalization;
using System.Threading.Tasks;
using System.Collections.Generic;

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


        //para el historial de disponibilidades
        [HttpGet("rango-fechas")]
        public async Task<IActionResult> GetDisponibilidadPorRango(
            [FromQuery] DateTime fechaInicio,
            [FromQuery] DateTime fechaFin)
        {
            // Validación
            if (fechaInicio > fechaFin)
            {
                return BadRequest(new
                {
                    message = "La fecha de inicio no puede ser mayor a la fecha de fin"
                });
            }

            if ((fechaFin - fechaInicio).TotalDays > 31)
            {
                return BadRequest(new
                {
                    message = "El rango de fechas no puede ser mayor a 31 días"
                });
            }

            // Obtener datos del servicio
            var disponibilidades = await _service
                .GetDisponibilidadesPorRangoFechasAsync(fechaInicio, fechaFin);
            // Mapeo manual a DTO
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
    }
}

