using FlightDispatcher.API.Helpers;
using FlightDispatcher.API.Models;
using FlightDispatcher.API.Services;
using FlightDispatcher.API.Services.Interfaces;
using FlightDispatcher.Infrastructure.Interfaces;
using FlightDispatcher.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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

// Auth0 implementation
// 1. Add Authentication Services
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(options =>
//{
//    options.Authority = "https://dev-6cqpy6gyp63oihc0.us.auth0.com/";
//    options.Audience = "api.flightdispatcher.cloud";
//});

// Register repositories
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IAirlineRepository, AirlineRepository>();
builder.Services.AddScoped<IAirportRepository, AirportRepository>();
builder.Services.AddScoped<IFlightRouteRepository, FlightRouteRepository>();

// Register Services
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IAirlineService, AirlineService>();
builder.Services.AddScoped<IAirportService, AirportService>();
builder.Services.AddScoped<IFlightRouteService, FlightRouteService>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
