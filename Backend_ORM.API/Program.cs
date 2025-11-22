using Backend_ORM.Core.Interfaces.Repositories;
using Backend_ORM.Core.Interfaces.Repositories.RBA;
using Backend_ORM.Core.Interfaces.Services;
using Backend_ORM.Core.Interfaces.Services.RBA;
using Backend_ORM.Infrastructure.Context;
using Backend_ORM.Infrastructure.Repositories;
using Backend_ORM.Infrastructure.Repositories.RBA;
using Backend_ORM.Services.Services;
using Backend_ORM.Services.Services.RBA;
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
builder.Services.AddScoped<IProcessTypeRepository, ProcessTypeRepository>();
builder.Services.AddScoped<IProcessRepository, ProcessRepository>();
builder.Services.AddScoped<ISubProcessRepository, SubProcessRepository>();
builder.Services.AddScoped<IProcessDetailRepository, ProcessDetailRepository>();

// Register RBA Repositories
builder.Services.AddScoped<IRbaRiskRepository, RbaRiskRepository>();
builder.Services.AddScoped<IRbaProcessRiskRepository, RbaProcessRiskRepository>();
builder.Services.AddScoped<IRbaControlRepository, RbaControlRepository>();
builder.Services.AddScoped<IRbaReferenceDataRepository, RbaReferenceDataRepository>();

// Register Services
builder.Services.AddScoped<ILinkProcessService, LinkProcessService>();
builder.Services.AddScoped<IProcessTypeService, ProcessTypeService>();
builder.Services.AddScoped<IProcessService, ProcessService>();
builder.Services.AddScoped<ISubProcessService, SubProcessService>();
builder.Services.AddScoped<IProcessDetailService, ProcessDetailService>();

// Register RBA Services
builder.Services.AddScoped<IRbaRiskService, RbaRiskService>();
builder.Services.AddScoped<IRbaProcessRiskService, RbaProcessRiskService>();
builder.Services.AddScoped<IRbaControlService, RbaControlService>();
builder.Services.AddScoped<IRbaReferenceDataService, RbaReferenceDataService>();

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
