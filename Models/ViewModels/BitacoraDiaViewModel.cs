namespace AWESOME.Models.ViewModels;

public class BitacoraDiaViewModel
{
    public string Contenedor { get; set; } = string.Empty;

    public string? Marchamos { get; set; }

    public DateTime? HoraEntrada { get; set; }

    public DateTime? HoraSalida { get; set; }

    public DateTime HoraOrden { get; set; }

    public string? Transportista { get; set; }

    public string? Informacion { get; set; }

    public string? Chofer { get; set; }

    public string? Placa { get; set; }

    public string? Chasis { get; set; }

    public string? ViajeODua { get; set; }
}