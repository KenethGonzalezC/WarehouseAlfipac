using AWESOME.Data;
using AWESOME.Models.Entidades;
using AWESOME.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AWESOME.Controllers;

[Authorize]
public class BitacoraDespachosController : Controller
{
    private readonly SclDbContext _context;

    public BitacoraDespachosController(
        SclDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(
    DateTime? fecha,
    string? contenedor,
    string? marchamos,
    string? cliente,
    string? referencia,
    string? viajeDua,
    bool buscarHistorico = false)
    {
        var fechaFiltro =
            fecha?.Date ?? DateTime.Today;

        IQueryable<BitacoraDespacho> query =
            _context.BitacoraDespachos
                .AsNoTracking();

        // SOLO FILTRAR FECHA SI NO ES HISTÓRICO
        if (!buscarHistorico)
        {
            query = query.Where(x =>
                x.FechaHoraDespacho.Date == fechaFiltro);
        }

        // CONTENEDOR
        if (!string.IsNullOrWhiteSpace(contenedor))
        {
            contenedor = contenedor.Trim().ToUpper();

            query = query.Where(x =>
                x.Contenedor.Contains(contenedor));
        }

        // MARCHAMOS
        if (!string.IsNullOrWhiteSpace(marchamos))
        {
            marchamos = marchamos.Trim().ToUpper();

            query = query.Where(x =>
                x.Marchamos.Contains(marchamos));
        }

        // CLIENTE
        if (!string.IsNullOrWhiteSpace(cliente))
        {
            cliente = cliente.Trim().ToUpper();

            query = query.Where(x =>
                x.Informacion.Contains(cliente));
        }

        // REFERENCIA
        if (!string.IsNullOrWhiteSpace(referencia))
        {
            referencia = referencia.Trim().ToUpper();

            query = query.Where(x =>
                x.ContenedorReferencia != null &&
                x.ContenedorReferencia.Contains(referencia));
        }

        // VIAJE / DUA
        if (!string.IsNullOrWhiteSpace(viajeDua))
        {
            viajeDua = viajeDua.Trim().ToUpper();

            query = query.Where(x =>
                x.ViajeDua.Contains(viajeDua));
        }

        var despachos = await query
            .OrderByDescending(x => x.FechaHoraDespacho)
            .ToListAsync();

        var vm = new DespachosIndexViewModel
        {
            Despachos = despachos,
            TotalHoy = despachos.Count,

            FechaSeleccionada = fechaFiltro,

            Contenedor = contenedor,
            Marchamos = marchamos,
            Cliente = cliente,
            Referencia = referencia,
            ViajeDua = viajeDua,

            BuscarHistorico = buscarHistorico
        };

        return View(vm);
    }
}