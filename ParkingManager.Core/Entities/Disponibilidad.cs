namespace ParkingManager.Core.Entities
{
    public class Disponibilidad
    {
        public int Id { get; set; }
        public string? Zona { get; set; }
        public int EspaciosTotales { get; set; }
        public int EspaciosLibres { get; set; }

        public bool Disponible => EspaciosLibres > 0;

        public int IdDisponibilidad { get; set; }
        public string Estado { get; set; }
    }
}
