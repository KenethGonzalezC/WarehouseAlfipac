using AWESOME.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AWESOME.Data;

public class AwesomeDbContext : DbContext
{
    public AwesomeDbContext(
        DbContextOptions<AwesomeDbContext> options)
        : base(options)
    {
    }

    public DbSet<ConfiguracionSistema> ConfiguracionesSistema { get; set; }
    public DbSet<AperturaContenedor> AperturasContenedores { get; set; }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}