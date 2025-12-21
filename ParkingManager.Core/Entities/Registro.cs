//Ya funciona Registros
namespace ParkingManager.Core.Entities
{
    public class Registro : BaseEntity
    {
        public int VehiculoId { get; set; }
        public int EspacioId { get; set; }       

        public DateTime FechaEntrada { get; set; } = DateTime.UtcNow;
        public DateTime? FechaSalida { get; set; }
        public int? TiempoEstadia { get; set; } // En minutos
        public decimal? MontoTotal { get; set; }
        public string Estado { get; set; } = "Activo"; // 'Activo', 'Finalizado'
        public string Zona { get; set; }
        public DateTime Fecha { get; set; }

        // Navegación
        public Vehiculo? Vehiculo { get; set; }
        public Disponibilidad? Espacio { get; set; }
        
        
    }
}