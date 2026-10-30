using FloraShop.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using FloraShop.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<FloraContext>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<FloraContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("FloraDb")));
// Register Application Services
DependencyContainer.RegisterServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
