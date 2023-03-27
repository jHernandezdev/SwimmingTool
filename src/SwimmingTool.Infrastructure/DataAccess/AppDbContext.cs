using Microsoft.EntityFrameworkCore;
using SwimmingTool.Domain;
using System.Reflection;

namespace SwimmingTool.Infrastructure.DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext() { }
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Swimmer> Swimmers { get; set; } = null;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}