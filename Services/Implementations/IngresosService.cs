using AWESOME.Data;
using AWESOME.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AWESOME.Services.Implementations;

public class IngresosService
{
    private readonly SclDbContext _context;

    public IngresosService(SclDbContext context)
    {
        _context = context;
    }

    public async Task<List<BitacoraIngreso>> GetByDate(DateTime fecha)
    {
        var queryDate = fecha.Date;

        return await _context.BitacoraIngresos
            .AsNoTracking()
            .Where(x => x.FechaHoraIngreso.Date == queryDate)
            .OrderByDescending(x => x.FechaHoraIngreso)
            .ToListAsync();
    }

    public async Task<int> GetCountByDate(DateTime fecha)
    {
        var queryDate = fecha.Date;

        return await _context.BitacoraIngresos
            .AsNoTracking()
            .CountAsync(x => x.FechaHoraIngreso.Date == queryDate);
    }
}