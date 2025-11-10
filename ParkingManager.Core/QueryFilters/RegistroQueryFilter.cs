using Swashbuckle.AspNetCore.Annotations;
using System;

namespace ParkingManager.Core.QueryFilters
{
    public class RegistroQueryFilter : PaginationQueryFilter
    {
        [SwaggerSchema("ID del vehículo asociado")]
        public int? VehiculoId { get; set; }

        [SwaggerSchema("Fecha de ingreso del vehículo")]
        public DateTime? FechaEntrada { get; set; }

        [SwaggerSchema("Fecha de salida del vehículo")]
        public DateTime? FechaSalida { get; set; }
    }
}
