using FlightDispatcher.API.Helpers;
using FlightDispatcher.API.Models;
using FlightDispatcher.Infostructure.Interfaces;
using FlightDispatcher.Infostructure.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// SWAGGER
builder.Services.AddSwaggerGen();

// MongoDB Configuration
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddScoped<IMongoDatabase>(x =>
{
    var settings = x.GetRequiredService<IOptions<MongoDBSettings>>().Value;

    MongoClient client = new MongoClient(settings.GetConnectionString());
    return client.GetDatabase(settings.DatabaseName);
});

// Register repositories
builder.Services.AddScoped<CountryRepository>();
builder.Services.AddScoped<AirlineRepository>();
builder.Services.AddScoped<AirportRepository>();
builder.Services.AddScoped<FlightRouteRepository>();

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flight Dispatcher API");
});

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
