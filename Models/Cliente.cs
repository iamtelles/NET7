namespace TodoApi.Models;

public class Clientes
{
    public long Id { get; set; }
    public string? Nombres { get; set; }
    public string? Apellidos { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public DateTime? Fecha_nacimiento { get; set; }
}