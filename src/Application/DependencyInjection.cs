using System.Reflection;
using Application.Common.Behaviors;
using Application.Common.Mappings;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(AppMappingProfile));

        services.AddSwaggerGen(options =>
        {
            var basePath = AppContext.BaseDirectory;
            var xmlPath = Path.Combine(basePath, "xml");

            options.IncludeXmlComments(xmlPath);
        });
        services.ConfigureSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
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
