using AWESOME.Models.Entidades;

namespace AWESOME.Models.ViewModels;

public class IngresosIndexViewModel
{
    public List<BitacoraIngreso> Ingresos { get; set; }
        = new();

    public int TotalIngresos { get; set; }

    public DateTime FechaSeleccionada { get; set; }

    public string? Contenedor { get; set; }

    public string? Marchamos { get; set; }

    public string? Cliente { get; set; }

    public string? ViajeDua { get; set; }

    public bool BuscarHistorico { get; set; }
}