using AWESOME.Models.Entidades;

namespace AWESOME.Models.ViewModels;

public class AperturasIndexViewModel
{
    public List<AperturaContenedor> Pendientes
    { get; set; } = new();

    public List<AperturaContenedor> Bodega2000
    { get; set; } = new();

    public List<AperturaContenedor> Agroquimicos
    { get; set; } = new();
}