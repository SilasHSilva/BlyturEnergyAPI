using BlyturEnergyAPI.Application.Services;
using BlyturEnergyAPI.Infrastructure.Interfaces;
using BlyturEnergyAPI.Infrastructure.Repositories;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// MongoDB Configuration
var mongoDbConnection = Environment.GetEnvironmentVariable("ConnectionStrings__MongoDb") 
                        ?? builder.Configuration.GetConnectionString("MongoDb");
var databaseName = Environment.GetEnvironmentVariable("DatabaseName") 
                   ?? builder.Configuration["DatabaseName"];

if (string.IsNullOrEmpty(mongoDbConnection) || string.IsNullOrEmpty(databaseName))
{
    throw new ArgumentNullException("MongoDb connection string or database name is not configured.");
}

builder.Services.AddSingleton<IMongoClient, MongoClient>(_ =>
    new MongoClient(mongoDbConnection));

builder.Services.AddScoped<IMongoDatabase>(provider =>
    provider.GetService<IMongoClient>().GetDatabase(databaseName));


// Dependency Injection
builder.Services.AddScoped<ITurbineRepository, TurbineRepository>();
builder.Services.AddScoped<IEnergyMeasurementRepository, EnergyMeasurementRepository>();
builder.Services.AddScoped<TurbineService>();
builder.Services.AddScoped<EnergyMeasurementService>();


// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
