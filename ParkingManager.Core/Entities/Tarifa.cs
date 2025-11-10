
namespace ParkingManager.Core.Entities
{
    public class Tarifa
    {
        public int Id { get; set; }
        public string? TipoVehiculo { get; set; } // Auto, Moto, Camión, etc.
        public decimal PrecioPorHora { get; set; }
        public bool Activa { get; set; }
        public int IdTarifa { get; set; }
        public decimal Precio { get; internal set; }
        public decimal Monto { get; set; }
        public DateTime FechaVigenciaInicio { get; set; }
        public DateTime FechaVigenciaFin { get; set; }
    }
}
