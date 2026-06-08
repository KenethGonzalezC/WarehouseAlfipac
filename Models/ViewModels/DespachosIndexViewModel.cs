using AWESOME.Models.Entidades;

namespace AWESOME.Models.ViewModels
{
    public class DespachosIndexViewModel
    {
        public List<BitacoraDespacho> Despachos { get; set; } = new();

        public int TotalHoy { get; set; }

        public DateTime FechaSeleccionada { get; set; }

        public string? Contenedor { get; set; }

        public string? ContenedorReferencia { get; set; }
    }
}
