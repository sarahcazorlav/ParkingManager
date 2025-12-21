namespace ParkingManager.Core.QueryFilters;
using Swashbuckle.AspNetCore.Annotations;

public class DisponibilidadQueryFilter
{
    /// <summary>
    /// Zona del estacionamiento
    /// </summary>
    [SwaggerSchema("Zona del estacionamiento (Zona A, Zona B, etc.)", Nullable = true)]
    public string? Zona { get; set; }

    /// <summary>
    /// Tipo de espacio (Auto, Moto, Camioneta)
    /// </summary>
    [SwaggerSchema("Tipo de espacio: Auto, Moto, Camioneta")]
    public string? TipoEspacio { get; set; }

    /// <summary>
    /// Estado del espacio
    /// </summary>
    [SwaggerSchema("Estado del espacio: Libre u Ocupado", Nullable = true)]
    public string? Estado { get; set; }
    public int PageNumber { get; internal set; }
    public int PageSize { get; internal set; }
    public bool? Ocupado { get; set; }

    /// <summary>
    /// Piso del estacionamiento
    /// </summary>
    [SwaggerSchema("Número de piso")]
    public int? Piso { get; set; }

    /// <summary>
    /// Fecha desde (para consultar disponibilidad en rango)
    /// </summary>
    [SwaggerSchema("Fecha inicio del rango")]
    public DateTime? FechaDesde { get; set; }

    /// <summary>
    /// Fecha hasta (para consultar disponibilidad en rango)
    /// </summary>
    [SwaggerSchema("Fecha fin del rango")]
    public DateTime? FechaHasta { get; set; }
}