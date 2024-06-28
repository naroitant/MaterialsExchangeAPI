using Microsoft.Extensions.Configuration;
using MaterialsExchangeAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MaterialsExchangeAPI.Application.Common.Interfaces;

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

        return services;    
    }
}
