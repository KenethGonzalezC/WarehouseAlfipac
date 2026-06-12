using AWESOME.Data;
using AWESOME.Models.Entidades;
using AWESOME.Models.ViewModels;
using AWESOME.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AWESOME.Controllers;

[Authorize]
public class AperturasOperativasController
    : Controller
{
    private readonly AperturasService _service;
    private readonly AwesomeDbContext _context;
    private readonly IWebHostEnvironment _environment;

    public AperturasOperativasController(
        AperturasService service,
        AwesomeDbContext context,
        IWebHostEnvironment environment)
    {
        _service = service;
        _context = context;
        _environment = environment;
    }

    public async Task<IActionResult> Index()
    {
        var vm =
            new AperturasIndexViewModel
            {
                Pendientes =
                    await _service.ObtenerPendientes(),

                Bodega2000 =
                    await _service.ObtenerBodega2000(),

                Agroquimicos =
                    await _service.ObtenerAgroquimicos()
            };

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Mover(
        string contenedor,
        string ubicacion)
    {
        var ok =
            await _service.MoverContenedor(
                contenedor,
                ubicacion);

        return Json(new
        {
            ok
        });
    }

    // ==========================================
    // DETALLE
    // ==========================================

    [HttpGet]
    public async Task<IActionResult> Detalle(
        string contenedor)
    {
        var apertura =
            await _service.ObtenerPorContenedor(
                contenedor);

        if (apertura == null)
        {
            return NotFound();
        }

        return View(apertura);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Detalle(
        AperturaContenedor model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await _service.Actualizar(model);

        TempData["Success"] =
            "Información guardada correctamente.";

        return RedirectToAction(
            nameof(Detalle),
            new
            {
                contenedor = model.Contenedor
            });
    }

    //guardar
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> GuardarDetalle(
    AperturaContenedor model,
    string? FirmaBase64)
    {

        TempData["FirmaDebug"] =
    FirmaBase64?.Length.ToString()
    ?? "NULL";

        var apertura =
            await _service.ObtenerPorId(model.Id);

        if (apertura == null)
        {
            return NotFound();
        }

        // ============================================
        // FECHAS Y HORAS
        // ============================================

        apertura.FechaIngreso = model.FechaIngreso;
        apertura.HoraIngreso = model.HoraIngreso;

        apertura.FechaAduana = model.FechaAduana;
        apertura.HoraAduana = model.HoraAduana;

        apertura.FechaInicioDescarga = model.FechaInicioDescarga;
        apertura.HoraInicioDescarga = model.HoraInicioDescarga;

        apertura.FechaFinalDescarga = model.FechaFinalDescarga;
        apertura.HoraFinalDescarga = model.HoraFinalDescarga;

        apertura.FechaInventario = model.FechaInventario;
        apertura.HoraInventario = model.HoraInventario;

        apertura.FechaRepVacio = model.FechaRepVacio;
        apertura.HoraRepVacio = model.HoraRepVacio;

        apertura.FechaSalidaVacio = model.FechaSalidaVacio;
        apertura.HoraSalidaVacio = model.HoraSalidaVacio;

        apertura.FechaDespacho = model.FechaDespacho;
        apertura.HoraDespacho = model.HoraDespacho;

        // ============================================
        // CAMPOS GENERALES
        // ============================================

        apertura.Inventario = model.Inventario;
        apertura.Bodega = model.Bodega;
        apertura.Dua = model.Dua;
        apertura.Factura = model.Factura;
        apertura.Observaciones = model.Observaciones;
        apertura.Anotaciones = model.Anotaciones;

        // ============================================
        // CHECKBOXES
        // ============================================

        apertura.M1 = model.M1;
        apertura.M6 = model.M6;
        apertura.SeparaciondeMercaderias = model.SeparaciondeMercaderias;
        apertura.PrevioExamen = model.PrevioExamen;
        apertura.ServicioAdicionalMontacargas = model.ServicioAdicionalMontacargas;
        apertura.ServicioEspecialMontacargas5tons = model.ServicioEspecialMontacargas5tons;
        apertura.ServicioEspecialMontacargas12tons = model.ServicioEspecialMontacargas12tons;
        apertura.Peonaje = model.Peonaje;
        apertura.Etiquetado = model.Etiquetado;
        apertura.Flejeado = model.Flejeado;
        apertura.EntarimadoyEmplasticado = model.EntarimadoyEmplasticado;
        apertura.MarchamosAdicionales = model.MarchamosAdicionales;
        apertura.ExtraccionMuestras = model.ExtraccionMuestras;
        apertura.Tarimas = model.Tarimas;
        apertura.MovilizacionaAnden = model.MovilizacionaAnden;

        //Sello
        apertura.FechaVerificacionCarga = model.FechaVerificacionCarga;

        apertura.VerificacionCompleta = model.VerificacionCompleta;
        apertura.VerificacionDanada = model.VerificacionDanada;
        apertura.VerificacionBalanceo = model.VerificacionBalanceo;

        apertura.VerificacionFaltante = model.VerificacionFaltante;
        apertura.VerificacionTrasiego = model.VerificacionTrasiego;
        apertura.VerificacionOtros1 = model.VerificacionOtros1;

        apertura.VerificacionSobrante = model.VerificacionSobrante;
        apertura.VerificacionRevision = model.VerificacionRevision;
        apertura.VerificacionOtros2 = model.VerificacionOtros2;

        apertura.ObservacionesVerificacion = model.ObservacionesVerificacion;

        apertura.Transmision = model.Transmision;
        apertura.NoTransmision = model.NoTransmision;

        // ============================================
        // FIRMA DIGITAL
        // ============================================

        if (!string.IsNullOrWhiteSpace(FirmaBase64))
        {
            var base64 =
                FirmaBase64.Substring(
                    FirmaBase64.IndexOf(',') + 1);

            byte[] bytes =
                Convert.FromBase64String(base64);

            string carpetaFirmas =
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "uploads",
                    apertura.Contenedor,
                    "apertura");

            if (!Directory.Exists(carpetaFirmas))
            {
                Directory.CreateDirectory(
                    carpetaFirmas);
            }

            string nombreArchivo =
                $"FirmaVerificacion_{Guid.NewGuid()}.jpg";

            string rutaFisica =
                Path.Combine(
                    carpetaFirmas,
                    nombreArchivo);

            await System.IO.File.WriteAllBytesAsync(
                rutaFisica,
                bytes);

            // ========================================
            // ELIMINAR FIRMA ANTERIOR
            // ========================================

            if (!string.IsNullOrWhiteSpace(
                apertura.RutaFirmaVerificacion))
            {
                string firmaAnterior =
                    Path.Combine(
                        _environment.WebRootPath,
                        apertura.RutaFirmaVerificacion
                            .TrimStart('/')
                            .Replace('/',
                                Path.DirectorySeparatorChar));

                if (System.IO.File.Exists(firmaAnterior))
                {
                    System.IO.File.Delete(
                        firmaAnterior);
                }
            }

            // ========================================
            // GUARDAR RUTA RELATIVA
            // ========================================

            apertura.RutaFirmaVerificacion =
                $"/uploads/{apertura.Contenedor}/apertura/{nombreArchivo}";
        }

        await _service.Actualizar(apertura);

        TempData["Success"] =
            "Información guardada correctamente.";

        return RedirectToAction(
            nameof(Detalle),
            new
            {
                contenedor = apertura.Contenedor
            });
    }

    public async Task Actualizar(
    AperturaContenedor apertura)
    {
        _context.AperturasContenedores.Update(apertura);

        await _context.SaveChangesAsync();
    }
}