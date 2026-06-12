using AWESOME.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AWESOME.Data;

public class SclDbContext : DbContext
{
    public SclDbContext(
        DbContextOptions<SclDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<BitacoraIngreso> BitacoraIngresos { get; set; } = null!;
    public DbSet<BitacoraDespacho> BitacoraDespachos { get; set; }
    public DbSet<ContenedorSinAsignarPatio> ContenedoresSinAsignarPatio { get; set; }
    public DbSet<Patio1> Patio1 { get; set; }
    public DbSet<Patio2> Patio2 { get; set; }
    public DbSet<Anden2000> Anden2000 { get; set; }
    public DbSet<PatioQuimicos> PatioQuimicos { get; set; }

}