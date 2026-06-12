namespace AWESOME.Models.ViewModels;

public class InventarioItemVM
{
    public int Id { get; set; }

    public string? Contenedor { get; set; }

    public string? Marchamos { get; set; }

    public string? Tamano { get; set; }

    public string? Chasis { get; set; }

    public string? Transportista { get; set; }

    public string? Cliente { get; set; }

    public string? EstadoCarga { get; set; }

    public string? Patio { get; set; }

    //aperturas
    public bool TieneApertura { get; set; }
}