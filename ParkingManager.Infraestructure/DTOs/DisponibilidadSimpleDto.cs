using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.Infrastructure.DTOs
{
    public class DisponibilidadSimpleDto
    {
        public DateTime Fecha { get; set; }
        public string Dia { get; set; } = string.Empty;
        public TimeSpan Hora { get; set; }
    }
}