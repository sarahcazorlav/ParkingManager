using Swashbuckle.AspNetCore.Annotations;

namespace ParkingManager.Core.QueryFilters
{
    public class UsuarioQueryFilter : PaginationQueryFilter
    {
        [SwaggerSchema("Id del usuario")]
        public int? Id { get; set; }

        [SwaggerSchema("Nombre del usuario")]
        public string? Nombre { get; set; }

        [SwaggerSchema("Correo del usuario")]
        public string? Correo { get; set; }
        public string? Email { get; set; }
    }
}
