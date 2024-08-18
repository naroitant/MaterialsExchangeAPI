using Application;
using Hangfire;
using Infrastructure;
using Infrastructure.Middlewares;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;
using Web;
using Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services from the assemblies.
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

app.UseExceptionHandler(applicationBuilder =>
    applicationBuilder.Run(async context =>
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
