namespace ParkingManager.Core.Entities
{
    public class Tarifa : BaseEntity
    {
        public string TipoVehiculo { get; set; } = string.Empty;
        public decimal TarifaPorHora { get; set; }
        public decimal TarifaPorDia { get; set; }
        public string? Descripcion { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
}

//funciona todo en Tarifa
