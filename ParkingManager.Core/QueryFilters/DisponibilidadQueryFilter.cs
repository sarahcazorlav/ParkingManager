namespace ParkingManager.Core.QueryFilters
{
    public class DisponibilidadQueryFilter : PaginationQueryFilter
    {
        public string? TipoEspacio { get; set; }
        public int? Piso { get; set; }
        public bool? Ocupado { get; set; }
        public string? Zona { get; set; }
        public string? Estado { get; set; }
    }
}