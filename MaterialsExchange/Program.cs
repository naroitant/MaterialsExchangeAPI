using FluentValidation;
using Hangfire;
using Hangfire.PostgreSql;
using MaterialsExchange.Data;
using MaterialsExchange.Interfaces;
using MaterialsExchange.Models.DTO;
using MaterialsExchange.Repositories;
using MaterialsExchange.Tasks;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<AppDbContext>(options => {
	options.UseNpgsql(builder.Configuration.GetConnectionString("defaultConnection"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHangfire(x => x.UsePostgreSqlStorage(builder.Configuration.GetConnectionString("defaultConnection")));
builder.Services.AddHangfireServer();

builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<IValidator<MaterialDto>, MaterialDtoValidator>();
builder.Services.AddScoped<IValidator<SellerDto>, SellerDtoValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHangfireDashboard();
app.UseHangfireServer();

app.StartRecurringJobs();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
