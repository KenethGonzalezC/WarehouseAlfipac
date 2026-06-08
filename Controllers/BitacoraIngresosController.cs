using AWESOME.Models.ViewModels;
using AWESOME.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AWESOME.Controllers;

[Authorize]
public class BitacoraIngresosController : Controller
{
    private readonly IngresosService _service;

    public BitacoraIngresosController(IngresosService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index(DateTime? fecha)
    {
        var selectedDate = fecha ?? DateTime.Today;

        var ingresos = await _service.GetByDate(selectedDate);
        var total = await _service.GetCountByDate(selectedDate);

        var vm = new IngresosIndexViewModel
        {
            Ingresos = ingresos,
            FechaSeleccionada = selectedDate,
            TotalIngresos = total
        };

        return View(vm);
    }
}