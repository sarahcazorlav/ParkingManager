using Swashbuckle.AspNetCore.Annotations;

namespace ParkingManager.Core.QueryFilters
{
    public class DisponibilidadQueryFilter : PaginationQueryFilter
    {
        [SwaggerSchema("Estado de la plaza (true = disponible, false = ocupada)")]
        public bool? Disponible { get; set; }

        [SwaggerSchema("Número de plaza o sector")]
        public string? Sector { get; set; }
    }
}