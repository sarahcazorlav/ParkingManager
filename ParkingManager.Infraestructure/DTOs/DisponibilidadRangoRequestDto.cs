namespace ParkingManager.Infrastructure.DTOs
{
    public class DisponibilidadRangoRequestDto
    {
        // Fecha de inicio
        public int DiaInicio { get; set; }
        public int MesInicio { get; set; }
        public int AnioInicio { get; set; }

        // Fecha final
        public int DiaFinal { get; set; }
        public int MesFinal { get; set; }
        public int AnioFinal { get; set; }

        // Método helper para convertir a DateTime
        public DateTime ObtenerFechaInicio()
        {
            return new DateTime(AnioInicio, MesInicio, DiaInicio, 0, 0, 0);
        }

        public DateTime ObtenerFechaFinal()
        {
            return new DateTime(AnioFinal, MesFinal, DiaFinal, 23, 59, 59);
        }
    }
}