namespace AWESOME.Models.Entidades;

public class AperturaContenedor
{
    public int Id { get; set; }

    // Auditoría
    public DateTime FechaRegistro { get; set; }

    public string UsuarioRegistro { get; set; } = string.Empty;

    // Datos del Excel
    public DateTime FechaApertura { get; set; }

    public string HoraApertura { get; set; } = string.Empty;

    public string Contenedor { get; set; } = string.Empty;

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

    // Archivo original
    public string ArchivoExcel { get; set; } = string.Empty;

    //aperturas
    private string _ubicacionActual = "PENDIENTE";

    public string UbicacionActual
    {
        get => _ubicacionActual;
        set => _ubicacionActual =
            value?.Trim().ToUpperInvariant()
            ?? "PENDIENTE";
    }

    //campos del excel
    public DateTime? FechaIngreso { get; set; }
    public string? HoraIngreso { get; set; }

    public DateTime? FechaAduana { get; set; }
    public string? HoraAduana { get; set; }

    public DateTime? FechaInicioDescarga { get; set; }
    public string? HoraInicioDescarga { get; set; }

    public DateTime? FechaFinalDescarga { get; set; }
    public string? HoraFinalDescarga { get; set; }

    public DateTime? FechaInventario { get; set; }
    public string? HoraInventario { get; set; }

    public DateTime? FechaRepVacio { get; set; }
    public string? HoraRepVacio { get; set; }

    public DateTime? FechaSalidaVacio { get; set; }
    public string? HoraSalidaVacio { get; set; }

    public DateTime? FechaDespacho { get; set; }
    public string? HoraDespacho { get; set; }

    //booleanos para checkbox
    public bool M1 { get; set; }

    public bool M6 { get; set; }

    public bool SeparaciondeMercaderias { get; set; }

    public bool PrevioExamen { get; set; }

    public bool ServicioAdicionalMontacargas { get; set; }

    public bool ServicioEspecialMontacargas5tons { get; set; }

    public bool ServicioEspecialMontacargas12tons { get; set; }

    public bool Peonaje { get; set; }

    public bool Etiquetado { get; set; }

    public bool Flejeado { get; set; }

    public bool EntarimadoyEmplasticado { get; set; }

    public bool MarchamosAdicionales { get; set; }

    public bool ExtraccionMuestras { get; set; }

    public bool Tarimas { get; set; }

    public bool MovilizacionaAnden { get; set; }

    //observaciones
    public string? Inventario { get; set; }

    public string? Bodega { get; set; }

    public string? Dua { get; set; }

    public string? Factura { get; set; }

    public string? Observaciones { get; set; }

    public string? Anotaciones { get; set; }

    //sello de descarga
    public DateTime? FechaVerificacionCarga { get; set; }

    public bool VerificacionCompleta { get; set; }
    public bool VerificacionDanada { get; set; }
    public bool VerificacionBalanceo { get; set; }

    public bool VerificacionFaltante { get; set; }
    public bool VerificacionTrasiego { get; set; }
    public bool VerificacionOtros1 { get; set; }

    public bool VerificacionSobrante { get; set; }
    public bool VerificacionRevision { get; set; }
    public bool VerificacionOtros2 { get; set; }

    public string? ObservacionesVerificacion { get; set; }

    public bool Transmision { get; set; }
    public bool NoTransmision { get; set; }

    //firma igual que transportistas SCL
    public string? RutaFirmaVerificacion { get; set; }
}