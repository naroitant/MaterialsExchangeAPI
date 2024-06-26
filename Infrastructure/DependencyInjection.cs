using Microsoft.Extensions.Configuration;
using MaterialsExchangeAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MaterialsExchangeAPI.Application.Common.Interfaces;
using Infrastructure.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => {
            options.UseNpgsql(configuration.GetConnectionString("defaultConnection"));
        });

        services.AddScoped<IAppDbContext>(
            provider => provider.GetRequiredService<AppDbContext>());

        services.AddScoped<IDbTransactionMiddleware>(
            provider => provider.GetRequiredService<DbTransactionMiddleware>());

        return services;    
    }
}
