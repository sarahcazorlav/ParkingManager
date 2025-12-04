namespace ParkingManager.Core.QueryFilters
{
    public class VehiculoQueryFilter : PaginationQueryFilter
    {
        public string? Placa { get; set; }
        public int? IdUsuario { get; set; }
        public string? TipoVehiculo { get; set; }
        public bool? Activo { get; set; }
    }
}