using AWESOME.Data;
using AWESOME.Models.Entidades;
using AWESOME.Services.Implementations;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AWESOME.Controllers;

[Authorize]
public class AperturasController : Controller
{
    private readonly AperturasService _service;

    public AperturasController(
        AperturasService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Upload(
        string contenedor,
        IFormFile? archivo)
    {
        try
        {
            // ============================
            // VALIDACIONES INICIALES
            // ============================

            if (string.IsNullOrWhiteSpace(contenedor))
            {
                return BadRequest(
                    "Debe indicar un contenedor.");
            }

            if (archivo == null || archivo.Length == 0)
            {
                return BadRequest(
                    "Debe seleccionar un archivo.");
            }

            var extension =
                Path.GetExtension(archivo.FileName)
                    .ToUpperInvariant();

            if (extension != ".XLSX")
            {
                return BadRequest(
                    "Solo se permiten archivos Excel (.xlsx).");
            }

            // ============================
            // LEER EXCEL
            // ============================

            using var stream =
                archivo.OpenReadStream();

            using var workbook =
                new XLWorkbook(stream);

            var hoja =
                workbook.Worksheet(1);

            // ============================
            // VALIDAR CONTENEDOR
            // ============================

            var contenedorExcel =
                LeerCelda(hoja, "B8")
                    .Trim()
                    .ToUpperInvariant();

            var contenedorSeleccionado =
                contenedor
                    .Trim()
                    .ToUpperInvariant();

            if (contenedorExcel != contenedorSeleccionado)
            {
                return BadRequest(
                    $"El contenedor del Excel ({contenedorExcel}) no coincide con el contenedor seleccionado ({contenedorSeleccionado}).");
            }

            // ============================
            // EVITAR DUPLICADOS
            // ============================

            var existe =
                await _service.Existe(contenedorSeleccionado);

            if (existe)
            {
                return BadRequest(
                    "Este contenedor ya posee una apertura registrada.");
            }

            // ============================
            // LEER DATOS
            // ============================

            var fecha =
                LeerCelda(hoja, "B6");

            var hora =
                LeerCelda(hoja, "B7");

            var tamano =
                LeerCelda(hoja, "B9");

            var viaje =
                LeerCelda(hoja, "B10");

            var transportista =
                LeerCelda(hoja, "B11");

            var marchamo =
                LeerCelda(hoja, "B12");

            var importador =
                LeerCelda(hoja, "B13");

            var agencia =
                LeerCelda(hoja, "B14");

            var mercaderia =
                LeerCelda(hoja, "B15");

            var bultos =
                LeerCelda(hoja, "B16");

            var peso =
                LeerCelda(hoja, "B17");

            var embalaje =
                LeerCelda(hoja, "B18");

            var bl =
                LeerCelda(hoja, "B19");

            // ============================
            // FECHA
            // ============================

            if (!DateTime.TryParse(
                fecha,
                out var fechaApertura))
            {
                return BadRequest(
                    "La fecha del Excel no es válida.");
            }

            // ============================
            // GUARDAR ARCHIVO
            // ============================

            var carpeta =
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "uploads",
                    contenedorSeleccionado,
                    "apertura"
                    );

            Directory.CreateDirectory(carpeta);

            var nombreArchivo =
                $"{contenedorSeleccionado}_{DateTime.Now:yyyyMMddHHmmss}.xlsx";

            var rutaCompleta =
                Path.Combine(
                    carpeta,
                    nombreArchivo);

            using (var fs =
                new FileStream(
                    rutaCompleta,
                    FileMode.Create))
            {
                await archivo.CopyToAsync(fs);
            }

            // ============================
            // CREAR ENTIDAD
            // ============================

            var apertura =
                new AperturaContenedor
                {
                    FechaRegistro =
                        DateTime.Now,

                    UsuarioRegistro =
                        User.Identity?.Name ?? "",

                    FechaApertura =
                        fechaApertura,

                    HoraApertura =
                        hora,

                    Contenedor =
                        contenedorSeleccionado,

                    Tamano =
                        tamano,

                    NumeroViaje =
                        viaje,

                    Transportista =
                        transportista,

                    Marchamo =
                        marchamo,

                    Importador =
                        importador,

                    Agencia =
                        agencia,

                    Mercaderia =
                        mercaderia,

                    Bultos =
                        bultos,

                    Peso =
                        peso,

                    Embalaje =
                        embalaje,

                    BL =
                        bl,

                    ArchivoExcel =
                        nombreArchivo
                };

            await _service.Guardar(apertura);

            return Json(new
            {
                ok = true
            });
        }
        catch (Exception ex)
        {
            return BadRequest(
                $"Error procesando archivo: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<IActionResult> Obtener(
    string contenedor)
    {
        if (string.IsNullOrWhiteSpace(contenedor))
        {
            return BadRequest(
                "Debe indicar un contenedor.");
        }

        var apertura =
            await _service.ObtenerPorContenedor(
                contenedor);

        if (apertura == null)
        {
            return NotFound(
                "No existe una apertura registrada para este contenedor.");
        }

        return Json(new
        {
            apertura.Id,
            apertura.FechaRegistro,
            apertura.UsuarioRegistro,

            apertura.FechaApertura,
            apertura.HoraApertura,

            apertura.Contenedor,
            apertura.Tamano,
            apertura.NumeroViaje,
            apertura.Transportista,
            apertura.Marchamo,
            apertura.Importador,
            apertura.Agencia,
            apertura.Mercaderia,
            apertura.Bultos,
            apertura.Peso,
            apertura.Embalaje,
            apertura.BL,
            apertura.UbicacionActual,

            apertura.ArchivoExcel
        });
    }

    [HttpPost]
    public async Task<IActionResult> Eliminar(
    string contenedor)
    {
        if (string.IsNullOrWhiteSpace(contenedor))
        {
            return BadRequest(
                "Debe indicar un contenedor.");
        }

        var apertura =
            await _service.ObtenerPorContenedor(
                contenedor);

        if (apertura == null)
        {
            return NotFound(
                "No existe una apertura registrada.");
        }

        // Eliminar archivo físico
        try
        {
            var carpeta =
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "uploads",
                    contenedor,
                    "apertura"
                    );

            var rutaArchivo =
                Path.Combine(
                    carpeta,
                    apertura.ArchivoExcel);

            if (System.IO.File.Exists(rutaArchivo))
            {
                System.IO.File.Delete(rutaArchivo);
            }
        }
        catch
        {
            // No detenemos el proceso si falla el borrado físico
        }

        await _service.Eliminar(apertura);

        return Json(new
        {
            ok = true
        });
    }

    private static string LeerCelda(
        IXLWorksheet ws,
        string celda)
    {
        return ws.Cell(celda)
            .GetValue<string>()
            .Trim();
    }
}
