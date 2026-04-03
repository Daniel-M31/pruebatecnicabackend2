using Cine_PruebaDanielMartinez.Contexts;
using Cine_PruebaDanielMartinez.Repository;
using Cine_PruebaDanielMartinez.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
// Configuración de la conexión a la base de datos
builder.Services.AddDbContext<MoviesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar Repository con su interfaz
builder.Services.AddScoped<IPeliculaRepository, PeliculaRepository>();

// Registrar Service con su interfaz
builder.Services.AddScoped<IPeliculaService, PeliculaService>();
// Registrar Repository de SalaCine
builder.Services.AddScoped<ISalaCineRepository, SalaCineRepository>();

// Registrar Service de SalaCine
builder.Services.AddScoped<ISalaCineService, SalaCineService>();

builder.Services.AddScoped<IPeliculaSalaRepository, PeliculaSalaRepository>();
builder.Services.AddScoped<IPeliculaSalaService, PeliculaSalaService>();


// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
       builder => builder. AllowAnyOrigin()
    .AllowAnyMethod()// Permite cualquier método HTTP (GET, POST, etc.)
    .AllowAnyHeader()); // Permite cualquier encabezado

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors("AllowAngularApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
