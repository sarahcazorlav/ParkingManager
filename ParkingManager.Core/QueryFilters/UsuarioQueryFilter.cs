namespace ParkingManager.Core.QueryFilters
{
    public class UsuarioQueryFilter : PaginationQueryFilter
    {
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public string? Rol { get; set; }
        public bool? Activo { get; set; }
    }
}