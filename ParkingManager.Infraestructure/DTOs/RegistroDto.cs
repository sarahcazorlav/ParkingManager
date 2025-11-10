namespace ParkingManager.Infrastructure.DTOs;

public class RegistroDto
{
    public int Id { get; set; }
    public int VehiculoId { get; set; }
    public DateTime HoraEntrada { get; set; }
    public DateTime? HoraSalida { get; set; }
    public int TarifaId { get; set; }
    public decimal Monto { get; set; }
    public object FechaEntrada { get; internal set; }
}
