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
}