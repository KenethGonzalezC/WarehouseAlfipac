using AWESOME.Data;
using AWESOME.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AWESOME.Services.Implementations;

public class AperturasService
{
    private readonly AwesomeDbContext _context;

    public AperturasService(
        AwesomeDbContext context)
    {
        _context = context;
    }

    public async Task<AperturaContenedor?> ObtenerPorContenedor(
    string contenedor)
    {
        contenedor = contenedor
            .Trim()
            .ToUpperInvariant();

        return await _context.AperturasContenedores
            .AsNoTracking()
            .FirstOrDefaultAsync(x =>
                x.Contenedor == contenedor);
    }

    public async Task Guardar(
        AperturaContenedor apertura)
    {
        _context.AperturasContenedores.Add(apertura);

        await _context.SaveChangesAsync();
    }

    public async Task Eliminar(
        int id)
    {
        var apertura =
            await _context.AperturasContenedores
                .FirstOrDefaultAsync(x => x.Id == id);

        if (apertura == null)
            return;

        _context.AperturasContenedores.Remove(apertura);

        await _context.SaveChangesAsync();
    }

    public async Task Eliminar(
    AperturaContenedor apertura)
    {
        _context.AperturasContenedores.Remove(
            apertura);

        await _context.SaveChangesAsync();
    }

    public async Task<bool> Existe(
    string contenedor)
    {
        contenedor = contenedor
            .Trim()
            .ToUpperInvariant();

        return await _context.AperturasContenedores
            .AnyAsync(x =>
                x.Contenedor == contenedor);
    }

    public async Task<List<AperturaContenedor>>
    ObtenerPendientes()
    {
        return await _context.AperturasContenedores
            .AsNoTracking()
            .Where(x => x.UbicacionActual == "PENDIENTE")
            .OrderBy(x => x.Contenedor)
            .ToListAsync();
    }

    public async Task<List<AperturaContenedor>>
    ObtenerBodega2000()
    {
        return await _context.AperturasContenedores
            .AsNoTracking()
            .Where(x => x.UbicacionActual == "BODEGA2000")
            .OrderBy(x => x.Contenedor)
            .ToListAsync();
    }

    public async Task<List<AperturaContenedor>>
    ObtenerAgroquimicos()
    {
        return await _context.AperturasContenedores
            .AsNoTracking()
            .Where(x => x.UbicacionActual == "AGROQUIMICOS")
            .OrderBy(x => x.Contenedor)
            .ToListAsync();
    }

    public async Task<bool> MoverContenedor(
    string contenedor,
    string ubicacion)
    {
        contenedor = contenedor
            .Trim()
            .ToUpperInvariant();

        ubicacion = ubicacion
            .Trim()
            .ToUpperInvariant();

        var apertura =
            await _context.AperturasContenedores
                .FirstOrDefaultAsync(x =>
                    x.Contenedor == contenedor);

        if (apertura == null)
            return false;

        apertura.UbicacionActual =
            ubicacion;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task Actualizar(
    AperturaContenedor model)
    {
        var actual =
            await _context.AperturasContenedores
                .FirstOrDefaultAsync(x =>
                    x.Id == model.Id);

        if (actual == null)
        {
            return;
        }

        _context.Entry(actual)
            .CurrentValues
            .SetValues(model);

        await _context.SaveChangesAsync();
    }

    public async Task<AperturaContenedor?> ObtenerPorId(
    int id)
    {
        return await _context.AperturasContenedores
            .FirstOrDefaultAsync(x => x.Id == id);
    }

}