
public class VehiculoDto
{
    public int Id { get; set; }
    public string? Placa { get; set; }
    public string? Marca { get; set; }
    public string? Modelo { get; set; }
    public string? Color { get; set; }
    public int UsuarioId { get; set; }
    public object? Tipo { get; internal set; }
}
