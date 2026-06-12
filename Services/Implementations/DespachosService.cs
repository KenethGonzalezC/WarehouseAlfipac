using AWESOME.Data;
using AWESOME.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AWESOME.Services.Implementations;

public class DespachosService
{
    private readonly SclDbContext _context;

    public DespachosService(SclDbContext context)
    {
        _context = context;
    }

    public async Task<List<BitacoraDespacho>> GetByDate(DateTime fecha)
    {
        var queryDate = fecha.Date;

        return await _context.BitacoraDespachos
            .AsNoTracking()
            .Where(x => x.FechaHoraDespacho.Date == queryDate)
            .OrderByDescending(x => x.FechaHoraDespacho)
            .ToListAsync();
    }

    public async Task<int> GetCountByDate(DateTime fecha)
    {
        var queryDate = fecha.Date;

        return await _context.BitacoraDespachos
            .AsNoTracking()
            .CountAsync(x => x.FechaHoraDespacho.Date == queryDate);
    }
}