using FluentValidation;
using Hangfire;
using Hangfire.PostgreSql;
using MaterialsExchangeAPI.Data;
using MaterialsExchangeAPI.Interfaces;
using MaterialsExchangeAPI.Repositories;
using MaterialsExchangeAPI.Tasks;
using MaterialsExchangeAPI.Behaviors;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("defaultConnection"));
});

// Настраиваем Swagger.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var basePath = AppContext.BaseDirectory;
    var xmlPath = Path.Combine(basePath, "MaterialsExchangeAPI.xml");

    options.IncludeXmlComments(xmlPath);
});
builder.Services.ConfigureSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "MaterialsExchangeAPI",
        Description = "ASP.NET Core Web API для биржи материалов",
    });
});

// Настраиваем Hangfire.
builder.Services.AddHangfire(
    x => x.UsePostgreSqlStorage(options => options.UseNpgsqlConnection(
        builder.Configuration.GetConnectionString("defaultConnection")))
);
builder.Services.AddHangfireServer();

// Настраиваем MediatR.
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
});

builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<ISellerRepository, SellerRepository>();

// Регистрируем все валидаторы из выполняемой сборки.
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


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

// Запускаем повторяемые задачи Hangfire.
app.StartRecurringJobs();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
