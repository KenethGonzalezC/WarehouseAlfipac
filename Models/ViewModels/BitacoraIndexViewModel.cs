namespace AWESOME.Models.ViewModels;

public class BitacoraIndexViewModel
{
    public List<BitacoraDiaViewModel> Movimientos { get; set; }
        = new();

    public DateTime FechaSeleccionada { get; set; }

    public int TotalMovimientos { get; set; }

    public int TotalIngresos { get; set; }

    public int TotalDespachos { get; set; }
}