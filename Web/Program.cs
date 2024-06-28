using Hangfire;
using MaterialsExchangeAPI.Infrastructure.Services;
using MaterialsExchangeAPI.Infrastructure.Hangfire;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Регистрируем сервисы из разных сборок.
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseHangfireDashboard();

app.StartRecurringJobs();

app.UseHttpsRedirection();

app.UseMiddleware<DbTransactionMiddleware>();
app.UseMiddleware<LoggingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
