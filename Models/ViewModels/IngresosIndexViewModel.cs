using AWESOME.Models.Entidades;

namespace AWESOME.Models.ViewModels;

public class IngresosIndexViewModel
{
    public List<BitacoraIngreso> Ingresos { get; set; } = new();

    public DateTime FechaSeleccionada { get; set; }

    public int TotalIngresos { get; set; }
}