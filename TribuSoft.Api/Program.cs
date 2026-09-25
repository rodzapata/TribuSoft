using Microsoft.EntityFrameworkCore;
using TribuSoft.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add cadena de conexion a la base de datos
var provider = builder.Configuration["DatabaseProvider"]
    ?? throw new InvalidOperationException(
        "No se ha configurado 'DatabaseProvider'.");

var connectionString = builder.Configuration
    .GetConnectionString(provider)
    ?? throw new InvalidOperationException(
        $"No se ha configurado la cadena de conexión para '{provider}'.");


builder.Services.AddDbContext<AppDbContext>(options =>
{
    switch (provider)
    {
        case "Postgres":
            options.UseNpgsql(connectionString);
            break;

        case "SqlServer":
            options.UseSqlServer(connectionString);
            break;

        default:
            throw new InvalidOperationException(
                $"Proveedor de base de datos no soportado: '{provider}'.");
    }
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Add cadena de conextion
/*
app.MapGet("/configuracion", (IConfiguration configuration) =>
{
    return configuration.GetValue<string>("DatabaseProvider") ?? "valor no configurado";
    //return configuration.GetValue<string>("Postgres") ?? "valor no configurado";
});
*/


app.UseAuthorization();

app.MapControllers();

app.Run();
