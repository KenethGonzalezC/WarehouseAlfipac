using AWESOME.Data;
using AWESOME.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AWESOME.Controllers;

[Authorize]
public class BitacoraController : Controller
{
    private readonly SclDbContext _context;

    public BitacoraController(
        SclDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(
        DateTime? fecha)
    {
        var dia =
            fecha?.Date ?? DateTime.Today;

        // INGRESOS
        var ingresos =
            await _context.BitacoraIngresos
                .AsNoTracking()
                .Where(x =>
                    x.FechaHoraIngreso.Date == dia)
                .Select(x => new BitacoraDiaViewModel
                {
                    Contenedor = x.Contenedor,
                    Marchamos = x.Marchamos,

                    HoraEntrada = x.FechaHoraIngreso,
                    HoraSalida = null,

                    HoraOrden = x.FechaHoraIngreso,

                    Transportista = x.Transportista,
                    Informacion = x.Cliente,

                    Chofer = x.Chofer,
                    Placa = x.PlacaCabezal,
                    Chasis = x.Chasis,

                    ViajeODua = x.ViajeDua
                })
                .ToListAsync();

        // DESPACHOS
        var despachosRaw =
            await _context.BitacoraDespachos
                .AsNoTracking()
                .Where(x =>
                    x.FechaHoraDespacho.Date == dia)
                .ToListAsync();

        var despachos =
            despachosRaw
            .Select(x => new BitacoraDiaViewModel
            {
                Contenedor =
                    x.GuardarContenedorSalida &&
                    !string.IsNullOrWhiteSpace(x.ContenedorReferencia)
                    ? $"{x.Contenedor} / REF: {x.ContenedorReferencia}"
                    : !string.IsNullOrWhiteSpace(x.ContenedorReferencia)
                        ? $"REF: {x.ContenedorReferencia}"
                        : x.Contenedor,

                Marchamos = x.Marchamos,

                HoraEntrada = null,
                HoraSalida = x.FechaHoraDespacho,

                HoraOrden = x.FechaHoraDespacho,

                Transportista = x.Transportista,
                Informacion = x.Informacion,

                Chofer = x.Chofer,
                Placa = x.PlacaCabezal,
                Chasis = x.Chasis,

                ViajeODua = x.ViajeDua
            })
            .ToList();

        var movimientos =
            ingresos
            .Concat(despachos)
            .OrderBy(x => x.HoraOrden)
            .ToList();

        var vm =
            new BitacoraIndexViewModel
            {
                Movimientos = movimientos,

                FechaSeleccionada = dia,

                TotalMovimientos = movimientos.Count,
                TotalIngresos = ingresos.Count,
                TotalDespachos = despachos.Count
            };

        return View(vm);
    }
}