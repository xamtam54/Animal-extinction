using Animal_extinction.Context;
using Animal_extinction.Repository;
using Animal_extinction.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<TodoDBContext>(options => options.UseSqlServer(conString));


builder.Services.AddScoped<IDetailObservationsRepository, DetailObservationsRepository>();
builder.Services.AddScoped<IDetailObservationsService, DetailObservationsService>();

builder.Services.AddScoped<IObservationsRepository, ObservationsRepository>();
builder.Services.AddScoped<IObservationsService, ObservationsService>();

builder.Services.AddScoped<ISpeciesRepository, SpeciesRepository>();
builder.Services.AddScoped<ISpeciesService, SpeciesService>();

builder.Services.AddScoped<IThreatsRepository, ThreatsRepository>();
builder.Services.AddScoped<IThreatsService, ThreatsService>();

builder.Services.AddScoped<IViabilityRepository, ViabilityRepository>();
builder.Services.AddScoped<IViabilityService, ViabilityService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
