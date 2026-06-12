namespace AWESOME.Models.ViewModels;

public class InventarioGeneralVM
{
    public List<InventarioItemVM> Items { get; set; }
        = new();

    // KPI
    public int Total { get; set; }

    public int Cargados { get; set; }

    public int Vacios { get; set; }

    // Resumen patios
    public int SinAsignar { get; set; }

    public int Patio1 { get; set; }

    public int Patio2 { get; set; }

    public int Anden2000 { get; set; }

    public int Quimicos { get; set; }

    // Filtros
    public string? Contenedor { get; set; }

    public string? Marchamos { get; set; }

    public string? Transportista { get; set; }

    public string? Cliente { get; set; }

    public string? Estado { get; set; }

    public string? Tamano { get; set; }

    public string? Patio { get; set; }
}