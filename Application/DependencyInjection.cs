using System.Reflection;
using Hangfire;
using Hangfire.PostgreSql;
using MaterialsExchangeAPI.Application.Common.Behaviors;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(options =>
        {
            var basePath = AppContext.BaseDirectory;
            var xmlPath = Path.Combine(basePath, "MaterialsExchangeAPI.xml");

            options.IncludeXmlComments(xmlPath);
        });
        services.ConfigureSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApi.Models.OpenApiInfo
            {
                Version = "v1",
                Title = "MaterialsExchangeAPI",
                Description = "ASP.NET Core Web API для биржи материалов",
            });
        });

        services.AddHangfire(
            x => x.UsePostgreSqlStorage(options => options.UseNpgsqlConnection(
                configuration.GetConnectionString("defaultConnection")))
            );
        services.AddHangfireServer();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;    
    }
}
