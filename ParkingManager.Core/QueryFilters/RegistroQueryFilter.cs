namespace ParkingManager.Core.QueryFilters
{
    public class RegistroQueryFilter : PaginationQueryFilter
    {
        public int? IdVehiculo { get; set; }
        public int? IdEspacio { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public string? Estado { get; set; }
        public DateTime? FechaSalida { get; set; }
    }
}