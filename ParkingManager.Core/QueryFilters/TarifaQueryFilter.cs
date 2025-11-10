using Swashbuckle.AspNetCore.Annotations;
using System;

namespace ParkingManager.Core.QueryFilters
{
    public class TarifaQueryFilter : PaginationQueryFilter
    {
        [SwaggerSchema("Tipo de vehículo asociado a la tarifa")]
        public string? TipoVehiculo { get; set; }

        [SwaggerSchema("Monto mínimo de la tarifa")]
        public decimal? MontoMinimo { get; set; }

        [SwaggerSchema("Monto máximo de la tarifa")]
        public decimal? MontoMaximo { get; set; }

        [SwaggerSchema("Fecha de inicio de vigencia")]
        public DateTime? FechaInicio { get; set; }

        [SwaggerSchema("Fecha de fin de vigencia")]
        public DateTime? FechaFin { get; set; }
        public object MontoMin { get; set; }
        public object MontoMax { get; set; }
    }
}
