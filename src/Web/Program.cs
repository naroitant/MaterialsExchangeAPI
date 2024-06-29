using Hangfire;
using MaterialsExchangeAPI.Infrastructure.Services;
using MaterialsExchangeAPI.Infrastructure.Hangfire;
using Microsoft.AspNetCore.Diagnostics;
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

app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<DbTransactionMiddleware>();

app.UseExceptionHandler(builder => builder.Run(async context =>
{
    context.Response.StatusCode = 500;
    context.Response.ContentType = "text/plain";

    var exception = context.Features.Get<IExceptionHandlerFeature>();

    if (exception is not null)
    {
        var err = 
            $"Error: {exception.Error.Message} \n{exception.Error.StackTrace}";
        await context.Response.WriteAsync(err);
    }
}));

app.UseAuthorization();

app.MapControllers();

app.Run();
