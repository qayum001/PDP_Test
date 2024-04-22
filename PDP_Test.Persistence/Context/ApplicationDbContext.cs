using Microsoft.EntityFrameworkCore;
using PDP_Test.Application.Interfaces.Respository;
using PDP_Test.Domain.Models;

namespace PDP_Test.Persistence.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
{
    public DbSet<Company> Companies => Set<Company>();

    public DbSet<Department> Departments => Set<Department>();

    public DbSet<Employee> Employees => Set<Employee>();

    public async Task SaveAsync()
    {
        await base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>().HasKey(e => e.Id);
        modelBuilder.Entity<Department>().HasKey(e => e.Id);
        modelBuilder.Entity<Employee>().HasKey(e => e.Id);

        base.OnModelCreating(modelBuilder);
    }
}
