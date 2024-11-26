using Infrastructure.Data;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace MessageBroker;

public static class DependencyInjection
{
    public static IServiceCollection AddMessageBroker(
        this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddEntityFrameworkOutbox<AppDbContext>(o =>
            {
                o.QueryDelay = TimeSpan.FromSeconds(30);
                o.DuplicateDetectionWindow = TimeSpan.FromSeconds(30);
                o.UsePostgres();
                o.UseBusOutbox();
            });
            
            x.AddConfigureEndpointsCallback((context, name, cfg) =>
            {
                cfg.UseEntityFrameworkOutbox<AppDbContext>(context);
            });
            
            x.UsingRabbitMq((context, config) =>
            {
                config.Host("localhost", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
                
                config.UseMessageRetry(r => r.Exponential(10, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(5)));
                
                config.ConfigureEndpoints(context);
            });

            x.AddConsumer<SynchronizeSellersEventConsumer>();
        });

        return services;    
    }
}
