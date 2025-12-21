namespace ParkingManager.Infrastructure.DTOs
{
    public class DisponibilidadRangoDto
    {
        public DateTime Fecha { get; set; }
        public string Dia { get; set; } = string.Empty;
        public TimeSpan Hora { get; set; }
        public string NumeroEspacio { get; set; } = string.Empty;
        public string Zona { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty; //libre, ocupado
    }
}