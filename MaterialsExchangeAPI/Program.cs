using Hangfire;
using MaterialsExchangeAPI.Infrastructure.Hangfire;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices(builder.Configuration);

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

app.UseAuthorization();

app.MapControllers();

app.Run();
