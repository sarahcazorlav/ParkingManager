namespace ParkingManager.Core.QueryFilters
{
    public class TarifaQueryFilter : PaginationQueryFilter
    {
        public string? TipoVehiculo { get; set; }
        public bool? Activo { get; set; }
    }
}