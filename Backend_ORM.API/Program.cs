using Backend_ORM.Core.Interfaces.Repositories;
using Backend_ORM.Core.Interfaces.Services;
using Backend_ORM.Infrastructure.Context;
using Backend_ORM.Infrastructure.Repositories;
using Backend_ORM.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Backend ORM API",
        Version = "v1",
        Description = "GRC SLC ORM Backend API - Revamped LinkProcess Module"
    });
    
    // Include XML comments for better Swagger documentation
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

// Add DbContext
builder.Services.AddDbContext<ORMContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories
builder.Services.AddScoped<ILinkProcessRepository, LinkProcessRepository>();

// Register Services
builder.Services.AddScoped<ILinkProcessService, LinkProcessService>();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend ORM API v1");
    c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
});

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
