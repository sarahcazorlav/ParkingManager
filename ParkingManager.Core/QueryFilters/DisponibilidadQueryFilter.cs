namespace ParkingManager.Core.QueryFilters;
using Swashbuckle.AspNetCore.Annotations;

public class DisponibilidadQueryFilter
{
    /// <summary>
    /// Zona del estacionamiento
    /// </summary>
    [SwaggerSchema("Zona del estacionamiento", Nullable = true)]
    public string? Zona { get; set; }

    /// <summary>
    /// Estado del espacio
    /// </summary>
    [SwaggerSchema("Estado: Libre u Ocupado", Nullable = true)]
    public string? Estado { get; set; }
    public int PageNumber { get; internal set; }
    public int PageSize { get; internal set; }
    public int? Piso { get; set; }
    public bool? Ocupado { get; set; }
}