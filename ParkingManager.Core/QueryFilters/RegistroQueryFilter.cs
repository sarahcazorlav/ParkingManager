using Swashbuckle.AspNetCore.Annotations;
using System;

namespace ParkingManager.Core.QueryFilters
{
    public class RegistroQueryFilter : PaginationQueryFilter
    {
        [SwaggerSchema("ID del vehiculo asociado")]
        public int? VehiculoId { get; set; }

        [SwaggerSchema("Fecha de ingreso del vehiculo")]
        public DateTime? FechaEntrada { get; set; }

        [SwaggerSchema("Fecha de salida del vehiculo")]
        public DateTime? FechaSalida { get; set; }
    }
}
