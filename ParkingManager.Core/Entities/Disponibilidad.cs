namespace ParkingManager.Core.Entities
{
    public class Disponibilidad : BaseEntity
    {
        public string TipoEspacio { get; set; } = string.Empty;
        public string NumeroEspacio { get; set; } = string.Empty;
        public int Piso { get; set; }
        public bool Ocupado { get; set; } = false;
        public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;

        // Navegación
        public virtual ICollection<Registro> Registros { get; set; } = new List<Registro>();
        public string Estado { get; set; }
        public string Zona { get; set; }
    }
}