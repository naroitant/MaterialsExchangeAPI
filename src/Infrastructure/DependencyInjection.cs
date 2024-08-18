using Application.Common.Interfaces;
using Infrastructure.Data;
using Infrastructure.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

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
        services.AddScoped<DbTransactionMiddleware>();
        services.AddSingleton<LoggingMiddleware>();

        return services;    
    }
}
