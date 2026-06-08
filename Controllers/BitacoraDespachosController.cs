using AWESOME.Data;
using AWESOME.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AWESOME.Controllers;

[Authorize]
public class BitacoraDespachosController : Controller
{
    private readonly SclDbContext _context;

    public BitacoraDespachosController(SclDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(DateTime? fecha, string? contenedor, string? contenedorReferencia)
    {
        var fechaFiltro = fecha?.Date ?? DateTime.Today;

        var query = _context.BitacoraDespachos
            .AsNoTracking()
            .Where(x => x.FechaHoraDespacho.Date == fechaFiltro);

        if (!string.IsNullOrWhiteSpace(contenedor))
        {
            var c = contenedor.Trim().ToUpper();
            query = query.Where(x => x.Contenedor.Contains(c));
        }

        if (!string.IsNullOrWhiteSpace(contenedorReferencia))
        {
            var c = contenedorReferencia.Trim().ToUpper();

            query = query.Where(x =>
                x.ContenedorReferencia != null &&
                x.ContenedorReferencia.Contains(c));
        }

        var data = await query
            .OrderByDescending(x => x.FechaHoraDespacho)
            .ToListAsync();

        var vm = new DespachosIndexViewModel
        {
            Despachos = data,
            TotalHoy = data.Count,
            FechaSeleccionada = fechaFiltro,
            Contenedor = contenedor,
            ContenedorReferencia = contenedorReferencia
        };

        return View(vm);
    }
}