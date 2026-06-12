using AWESOME.Data;
using AWESOME.Models.Entidades;
using AWESOME.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AWESOME.Controllers;

[Authorize]
public class BitacoraIngresosController : Controller
{
    private readonly SclDbContext _context;

    public BitacoraIngresosController(
        SclDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(
        DateTime? fecha,
        string? contenedor,
        string? marchamos,
        string? cliente,
        string? viajeDua,
        bool buscarHistorico = false)
    {
        var fechaFiltro =
            fecha?.Date ?? DateTime.Today;

        IQueryable<BitacoraIngreso> query =
            _context.BitacoraIngresos
                .AsNoTracking();

        // FECHA OPERATIVA
        if (!buscarHistorico)
        {
            query = query.Where(x =>
                x.FechaHoraIngreso.Date == fechaFiltro);
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
                x.Cliente.Contains(cliente));
        }

        // VIAJE / DUA
        if (!string.IsNullOrWhiteSpace(viajeDua))
        {
            viajeDua = viajeDua.Trim().ToUpper();

            query = query.Where(x =>
                x.ViajeDua.Contains(viajeDua));
        }

        var ingresos = await query
            .OrderByDescending(x => x.FechaHoraIngreso)
            .ToListAsync();

        var vm = new IngresosIndexViewModel
        {
            Ingresos = ingresos,
            TotalIngresos = ingresos.Count,

            FechaSeleccionada = fechaFiltro,

            Contenedor = contenedor,
            Marchamos = marchamos,
            Cliente = cliente,
            ViajeDua = viajeDua,

            BuscarHistorico = buscarHistorico
        };

        return View(vm);
    }
}