namespace ParkingManager.Core.Entities
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string? Placa { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Color { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public ICollection<Registro>? Registros { get; set; }
        public object IdVehiculo { get; set; }
        public int IdUsuario { get; set; }
        public object? Tipo { get; set; }
        public object Descripcion { get; set; }
    }
}
