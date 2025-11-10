using Swashbuckle.AspNetCore.Annotations;

namespace ParkingManager.Core.QueryFilters
{
    public class VehiculoQueryFilter : PaginationQueryFilter
    {
        [SwaggerSchema("Placa del vehículo")]
        public string? Placa { get; set; }

        [SwaggerSchema("Tipo de vehículo (Auto, Moto, etc.)")]
        public string? Tipo { get; set; }

        [SwaggerSchema("ID del usuario propietario")]
        public int? UsuarioId { get; set; }
    }
}
