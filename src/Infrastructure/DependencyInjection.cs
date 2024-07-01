using MaterialsExchangeAPI.Infrastructure.Data;
using MaterialsExchangeAPI.Infrastructure.Services;
using MaterialsExchangeAPI.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => {
            options.UseNpgsql(configuration.
                GetConnectionString("defaultConnection"));
        });

        services.AddScoped<IAppDbContext>(
            provider => provider.GetRequiredService<AppDbContext>());
        services.AddTransient<DbTransactionMiddleware>();
        services.AddTransient<LoggingMiddleware>();

        return services;    
    }
}
