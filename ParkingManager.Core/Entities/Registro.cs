namespace ParkingManager.Core.Entities
{
    public class Registro : BaseEntity
    {
        public int IdVehiculo { get; set; }
        public int IdEspacio { get; set; }
        public DateTime FechaEntrada { get; set; } = DateTime.UtcNow;
        public DateTime? FechaSalida { get; set; }
        public int? TiempoEstadia { get; set; } // En minutos
        public decimal? MontoTotal { get; set; }
        public string Estado { get; set; } = "Activo"; // 'Activo', 'Finalizado'

        // Navegación
        public virtual Vehiculo? Vehiculo { get; set; }
        public virtual Disponibilidad? Espacio { get; set; }
        public object Zona { get; set; }
        public DateTime Fecha { get; set; }
    }
}