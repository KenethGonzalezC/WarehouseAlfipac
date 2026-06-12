using AWESOME.Models.Entidades;

namespace AWESOME.Models.ViewModels;

public class DespachosIndexViewModel
{
    public List<BitacoraDespacho> Despachos { get; set; }
        = new();

    public int TotalHoy { get; set; }

    public DateTime FechaSeleccionada { get; set; }

    public string? Contenedor { get; set; }

    public string? Marchamos { get; set; }

    public string? Cliente { get; set; }

    public string? Referencia { get; set; }

    public string? ViajeDua { get; set; }

    public bool BuscarHistorico { get; set; }
}