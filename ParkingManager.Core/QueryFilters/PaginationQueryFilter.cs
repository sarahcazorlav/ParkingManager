using Swashbuckle.AspNetCore.Annotations;

namespace ParkingManager.Core.QueryFilters
{
    public abstract class PaginationQueryFilter
    {
        [SwaggerSchema("Cantidad de registros por pagina")]
        public int PageSize { get; set; } = 10;

        [SwaggerSchema("Numero de página a mostrar")]
        public int PageNumber { get; set; } = 1;
    }
}
