using Microsoft.EntityFrameworkCore;
using ParkingManager.Infrastructure.Data;
using ParkingManager.Infrastructure.Repositories;
using ParkingManager.Core.Interfaces;
using ParkingManager.Core.Services;
using ParkingManager.Infrastructure.Filters;
using ParkingManager.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

//EF Core con SQL Server
builder.Services.AddDbContext<ParkingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//dependencias (repositorios y servicios)
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();
builder.Services.AddScoped<IRegistroRepository, IRegistroRepository>();
builder.Services.AddScoped<ITarifaRepository, TarifaRepository>();
builder.Services.AddScoped<IDisponibilidadRepository, DisponibilidadRepository>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IVehiculoService, VehiculoService>();
builder.Services.AddScoped<IRegistroService, RegistroService>();
builder.Services.AddScoped<ITarifaService, TarifaService>();
builder.Services.AddScoped<IDisponibilidadService, DisponibilidadService>();

//controladores y filtros globales
builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
    options.Filters.Add<ValidationFilter>();
})
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
