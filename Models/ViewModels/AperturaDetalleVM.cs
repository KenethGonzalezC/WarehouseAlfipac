namespace AWESOME.Models.ViewModels;

public class AperturaDetalleVM
{
    public int Id { get; set; }

    public string Contenedor { get; set; } = string.Empty;

    public DateTime FechaApertura { get; set; }

    public string HoraApertura { get; set; } = string.Empty;

    public string Tamano { get; set; } = string.Empty;

    public string NumeroViaje { get; set; } = string.Empty;

    public string Transportista { get; set; } = string.Empty;

    public string Marchamo { get; set; } = string.Empty;

    public string Importador { get; set; } = string.Empty;

    public string Agencia { get; set; } = string.Empty;

    public string Mercaderia { get; set; } = string.Empty;

    public string Bultos { get; set; } = string.Empty;

    public string Peso { get; set; } = string.Empty;

    public string Embalaje { get; set; } = string.Empty;

    public string BL { get; set; } = string.Empty;
}