using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PDP_Test.Application.Interfaces.Respository;
using PDP_Test.Persistence.Context;

namespace PDP_Test.Persistence.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var conStr = configuration.GetConnectionString("DefaultConnection");
        services.AddSqlServer<ApplicationDbContext>(conStr);
        services.AddScoped<IApplicationDbContext>(p => p.GetService<ApplicationDbContext>());
    }
}
