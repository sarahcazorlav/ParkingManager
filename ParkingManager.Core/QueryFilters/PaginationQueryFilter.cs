using Swashbuckle.AspNetCore.Annotations;

namespace ParkingManager.Core.QueryFilters
{
    public abstract class PaginationQueryFilter
    {
        [SwaggerSchema("Cantidad de registros por página")]
        public int PageSize { get; set; } = 10;

        [SwaggerSchema("Número de página a mostrar")]
        public int PageNumber { get; set; } = 1;
    }
}
