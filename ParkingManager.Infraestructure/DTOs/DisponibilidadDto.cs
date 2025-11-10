namespace ParkingManager.Infrastructure.DTOs;

public class DisponibilidadDto
{
    public int Id { get; set; }
    public string? Zona { get; set; }
    public int EspaciosLibres { get; set; }
    public int EspaciosTotales { get; set; }


    public bool Disponible => EspaciosLibres > 0;
}
