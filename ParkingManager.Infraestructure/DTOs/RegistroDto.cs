namespace ParkingManager.Infrastructure.DTOs;

public class RegistroDto
{
    public int Id { get; set; }
    public int VehiculoId { get; set; }
    public int EspacioId { get; set; }
    public string Zona { get; set; } = string.Empty;
    public DateTime HoraEntrada { get; set; }
    public DateTime? HoraSalida { get; set; }
    public int TarifaId { get; set; }
    public decimal Monto { get; set; }
    public object FechaEntrada { get; internal set; }
}
