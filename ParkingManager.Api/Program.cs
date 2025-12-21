// http://localhost:5044/index.html
//FUNCIONAAA y guarda en db

using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ParkingManager.Core.CustomEntities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Core.Services;
using ParkingManager.Infrastructure.Data;
using ParkingManager.Infrastructure.Filters;
using ParkingManager.Infrastructure.Repositories;
using ParkingManager.Infrastructure.Validators;
//using ParkingManager.Infrastructure.Mappings;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// CONFIGURACIÓN - ORDEN CORRECTO
Console.WriteLine("=== INICIANDO APLICACIÓN ===");
Console.WriteLine($"Ambiente: {builder.Environment.EnvironmentName}");

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
    Console.WriteLine("User Secrets cargados");
}

builder.Configuration.AddEnvironmentVariables();

// BASE DE DATOS
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"Connection String configurado: {!string.IsNullOrEmpty(connectionString)}");
Console.WriteLine($"Connection String: {connectionString}"); // TEMPORAL PARA DEBUG

builder.Services.AddDbContext<ParkingContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.EnableSensitiveDataLogging(); // TEMPORAL PARA DEBUG
    options.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
});

//// AGREGAR AUTOMAPPER
//builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


// INYECCIÓN DE DEPENDENCIAS
builder.Services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
builder.Services.AddScoped<IDapperContext, DapperContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();
builder.Services.AddScoped<IRegistroRepository, RegistroRepository>();
builder.Services.AddScoped<IDisponibilidadRepository, DisponibilidadRepository>();
builder.Services.AddScoped<ITarifaRepository, TarifaRepository>();
builder.Services.AddScoped<ISecurityRepository, SecurityRepository>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IVehiculoService, VehiculoService>();
builder.Services.AddScoped<IRegistroService, RegistroService>();
builder.Services.AddScoped<ITarifaService, TarifaService>();
builder.Services.AddScoped<IDisponibilidadService, DisponibilidadService>();
builder.Services.AddScoped<ISecurityService, SecurityService>();
builder.Services.AddSingleton<IPasswordService, PasswordService>();

builder.Services.Configure<PasswordOptions>(
    builder.Configuration.GetSection("PasswordOptions"));

// FLUENT VALIDATION
builder.Services.AddValidatorsFromAssemblyContaining<UsuarioDtoValidator>();

// VERSIONAMIENTO
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);

    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("x-api-version"),
        new QueryStringApiVersionReader("api-version")
    );
});

// CONTROLADORES Y FILTROS
builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
})
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.ReferenceHandler =
        System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

// AUTENTICACIÓN JWT
var jwtSecretKey = builder.Configuration["Authentication:SecretKey"];
Console.WriteLine($"JWT SecretKey configurado: {!string.IsNullOrEmpty(jwtSecretKey)}");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Authentication:Issuer"],
        ValidAudience = builder.Configuration["Authentication:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtSecretKey!))
    };
});

builder.Services.AddAuthorization();

// SWAGGER
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ParkingManager API",
        Version = "v1",
        Description = "API para gestión de estacionamientos",
        Contact = new OpenApiContact
        {
            Name = "Equipo de Desarrollo",
            Email = "desarrollo@parkingmanager.com"
        }
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingrese 'Bearer' [espacio] y luego su token JWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });

    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }

    options.EnableAnnotations();
});

// CORS
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

if (!app.Environment.IsDevelopment())
{
    app.Use(async (context, next) =>
    {
        if (context.Request.Path.StartsWithSegments("/swagger"))
        {
            if (!context.User.Identity?.IsAuthenticated ?? true)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }
        }
        await next();
    });
}

//Desde if hasta acà
//    ¿Qué hace?

//En Development → Swagger libre

//En Production → Swagger requiere JWT

//Usa el mismo token JWT de tu API

//💡 Esto es exactamente como se protege Swagger en APIs reales.


// MIDDLEWARE
Console.WriteLine(" Configurando middleware...");

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "ParkingManager API v1");
    options.RoutePrefix = string.Empty;
});

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

Console.WriteLine("Aplicación iniciada correctamente");
Console.WriteLine($"Swagger disponible en: https://localhost:5044/");

app.Run();