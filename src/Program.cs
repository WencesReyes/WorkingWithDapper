using AutoMapper;
using Microsoft.OpenApi.Models;
using System.Reflection;
using WorkingWithDapper;
using WorkingWithDapper.DataContexts;
using WorkingWithDapper.Repositories;
using WorkingWithDapper.Repositories.Implementations;
using WorkingWithDapper.Services;
using WorkingWithDapper.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Working with dapper",
        Description = "A test Api to try dapper"
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    config.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

//builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(provider =>
{
    return new MapperConfiguration(config =>
    {
        config.AddProfile<AutoMapperProfile>();
        config.ConstructServicesUsing(type =>
        ActivatorUtilities.GetServiceOrCreateInstance(provider, type));
    }).CreateMapper();
});

builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<ICausaService, CausaService>();
builder.Services.AddScoped<ICauseRepository, CauseRepository>();

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
