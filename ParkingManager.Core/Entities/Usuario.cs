namespace ParkingManager.Core.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? Rol { get; set; }
        public string? Clave { get; set; }
        public string Password { get; set; }
        public ICollection<Vehiculo>? Vehiculos { get; set; }
        public object? Email { get; set; }
    }
}
