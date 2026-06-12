using AWESOME.Data;
using AWESOME.Models.Entidades;
using AWESOME.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AWESOME.Controllers;

[Authorize]
public class InventarioController : Controller
{
    private readonly SclDbContext _context;
    private readonly AwesomeDbContext _awesomeContext;

    public InventarioController(
        SclDbContext context,
        AwesomeDbContext awesomeContext)
    {
        _context = context;
        _awesomeContext = awesomeContext;
    }

    public async Task<IActionResult> Index(
        string? contenedor,
        string? cliente,
        string? transportista,
        string? estado,
        string? tamano,
        string? patio)
    {
        var sinAsignar =
            await _context.ContenedoresSinAsignarPatio
                .Select(x => new InventarioItemVM
                {
                    Id = x.Id,
                    Contenedor = x.Contenedor,
                    Marchamos = x.Marchamos,
                    Tamano = x.Tamano,
                    Chasis = x.Chasis,
                    Transportista = x.Transportista,
                    Cliente = x.Cliente,
                    EstadoCarga = x.EstadoCarga,
                    Patio = "S/Pat"
                })
                .ToListAsync();

        var patio1 =
            await _context.Patio1
                .Select(x => new InventarioItemVM
                {
                    Id = x.Id,
                    Contenedor = x.Contenedor,
                    Marchamos = x.Marchamos,
                    Tamano = x.Tamano,
                    Chasis = x.Chasis,
                    Transportista = x.Transportista,
                    Cliente = x.Cliente,
                    EstadoCarga = x.EstadoCarga,
                    Patio = "P1"
                })
                .ToListAsync();

        var patio2 =
            await _context.Patio2
                .Select(x => new InventarioItemVM
                {
                    Id = x.Id,
                    Contenedor = x.Contenedor,
                    Marchamos = x.Marchamos,
                    Tamano = x.Tamano,
                    Chasis = x.Chasis,
                    Transportista = x.Transportista,
                    Cliente = x.Cliente,
                    EstadoCarga = x.EstadoCarga,
                    Patio = "P2"
                })
                .ToListAsync();

        var anden2000 =
            await _context.Anden2000
                .Select(x => new InventarioItemVM
                {
                    Id = x.Id,
                    Contenedor = x.Contenedor,
                    Marchamos = x.Marchamos,
                    Tamano = x.Tamano,
                    Chasis = x.Chasis,
                    Transportista = x.Transportista,
                    Cliente = x.Cliente,
                    EstadoCarga = x.EstadoCarga,
                    Patio = "2000"
                })
                .ToListAsync();

        var quimicos =
            await _context.PatioQuimicos
                .Select(x => new InventarioItemVM
                {
                    Id = x.Id,
                    Contenedor = x.Contenedor,
                    Marchamos = x.Marchamos,
                    Tamano = x.Tamano,
                    Chasis = x.Chasis,
                    Transportista = x.Transportista,
                    Cliente = x.Cliente,
                    EstadoCarga = x.EstadoCarga,
                    Patio = "AgroQui"
                })
                .ToListAsync();

        var todos =
            sinAsignar
            .Concat(patio1)
            .Concat(patio2)
            .Concat(anden2000)
            .Concat(quimicos)
            .AsQueryable();

        // FILTROS

        if (!string.IsNullOrWhiteSpace(contenedor))
        {
            contenedor = contenedor.Trim().ToUpper();

            todos = todos.Where(x =>
                x.Contenedor != null &&
                x.Contenedor.Contains(contenedor));
        }

        if (!string.IsNullOrWhiteSpace(cliente))
        {
            cliente = cliente.Trim().ToUpper();

            todos = todos.Where(x =>
                x.Cliente != null &&
                x.Cliente.Contains(cliente));
        }

        if (!string.IsNullOrWhiteSpace(transportista))
        {
            transportista = transportista.Trim().ToUpper();

            todos = todos.Where(x =>
                x.Transportista != null &&
                x.Transportista.Contains(transportista));
        }

        if (!string.IsNullOrWhiteSpace(estado))
        {
            todos = todos.Where(x =>
                x.EstadoCarga == estado);
        }

        if (!string.IsNullOrWhiteSpace(tamano))
        {
            todos = todos.Where(x =>
                x.Tamano == tamano);
        }

        if (!string.IsNullOrWhiteSpace(patio))
        {
            todos = todos.Where(x =>
                x.Patio == patio);
        }

        var lista = todos.ToList();

        var contenedoresConApertura =
        await _awesomeContext.AperturasContenedores
            .Select(x => x.Contenedor.ToUpper())
            .ToListAsync();

        foreach (var item in lista)
        {
            item.TieneApertura =
                contenedoresConApertura.Contains(
                    item.Contenedor.ToUpper());
        }

        var vm = new InventarioGeneralVM
        {
            Items = lista
                .Where(x => !string.Equals(
            x.EstadoCarga,
            "VACIO",
            StringComparison.OrdinalIgnoreCase))
        .ToList(),

            Total = lista.Count,
            Cargados = lista.Count(x =>
                x.EstadoCarga != null &&
                x.EstadoCarga.Equals("CARGADO",
                    StringComparison.OrdinalIgnoreCase)),

            Vacios = lista.Count(x =>
                x.EstadoCarga != null &&
                x.EstadoCarga.Equals("VACIO",
                    StringComparison.OrdinalIgnoreCase)),

            SinAsignar = lista.Count(x => x.Patio == "S/Pat"),
            Patio1 = lista.Count(x => x.Patio == "P1"),
            Patio2 = lista.Count(x => x.Patio == "P2"),
            Anden2000 = lista.Count(x => x.Patio == "2000"),
            Quimicos = lista.Count(x => x.Patio == "AgroQui"),

            Contenedor = contenedor,
            Cliente = cliente,
            Transportista = transportista,
            Estado = estado,
            Tamano = tamano,
            Patio = patio
        };

        return View(vm);
    }
}