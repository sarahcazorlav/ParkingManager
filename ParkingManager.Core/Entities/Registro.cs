namespace ParkingManager.Core.Entities
{
    public class Registro
    {
        public int Id { get; set; }
        public int VehiculoId { get; set; }
        public Vehiculo? Vehiculo { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public decimal? MontoTotal { get; set; }
        public int TarifaId { get; set; }
        public Tarifa? Tarifa { get; set; }
        public string? Estado { get; set; }
        public string VehiculoPlaca { get; set; }
        public object HoraSalida { get; set; }
        public object Zona { get; set; }
        public DateTime Fecha { get; set; }
    }
}
