using ParkingManager.Core.Entities;

namespace ParkingManager.Core.Entities
{
    public class Usuario : BaseEntity
    {
        public object Password;

        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string Rol { get; set; } = "Usuario"; // "Admin" o "Usuario"
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool Activo { get; set; } = true;

        // Navegación
        public ICollection<Vehiculo>? Vehiculos { get; set; }
    }
}