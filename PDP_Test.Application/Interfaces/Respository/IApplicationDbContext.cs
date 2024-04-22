
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using PDP_Test.Domain.Models;

namespace PDP_Test.Application.Interfaces.Respository
{
    public interface IApplicationDbContext
    {
        DbSet<Company> Companies { get; }
        DbSet<Department> Departments { get; }
        DbSet<Employee> Employees { get; }

        Task SaveAsync();
    }
}
