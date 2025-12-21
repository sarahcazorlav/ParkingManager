// si se puede insertar a la bd
namespace ParkingManager.Core.Entities 
{ public class Vehiculo : BaseEntity 
    { public int IdUsuario { get; set; }
      public string Placa { get; set; } = string.Empty; 
      public string? Marca { get; set; } 
        public string? Modelo { get; set; } 
        public string? Color { get; set; } 
        public string TipoVehiculo { get; set; } = string.Empty; // 'Auto', 'Moto', 'Camioneta'
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow; 
        public bool Activo { get; set; } = true;
        
        // Navegación
        public virtual Usuario? Usuario { get; set; } 
        public virtual ICollection<Registro> Registros { get; set; } = new List<Registro>(); 
    } 
}