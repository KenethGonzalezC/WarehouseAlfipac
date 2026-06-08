namespace AWESOME.Models.Entidades;

public class ConfiguracionSistema
{
    public int Id { get; set; }

    public string NombreEmpresa { get; set; } = string.Empty;

    public DateTime FechaCreacion { get; set; }

    public bool Activo { get; set; }
}