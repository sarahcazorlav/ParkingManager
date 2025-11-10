namespace ParkingManager.Infrastructure.DTOs;

public class TarifaDto
{
    public int Id { get; set; }
    public string? TipoVehiculo { get; set; }
    public decimal PrecioPorHora { get; set; }
    public bool Activa { get; set; }
    public decimal MontoPorHora { get; internal set; }
}
