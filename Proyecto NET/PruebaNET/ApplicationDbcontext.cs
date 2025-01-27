using Microsoft.EntityFrameworkCore;
using PRUEBANET.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<RegistrosContablesAORRALA> registroscontables_aorrala { get; set; }
    public DbSet<MovimientosBancariosAORRALA> movimientosbancarios_aorrala { get; set; }
    public DbSet<DiscrepanciasAORRALA> discrepancias_aorrala { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);
    }
}
