using System.Text;
using Backend_ORM.Core.Helpers;
using Backend_ORM.Core.Interfaces.Repositories;
using Backend_ORM.Core.Interfaces.Repositories.RBA;
using Backend_ORM.Core.Interfaces.Services;
using Backend_ORM.Core.Interfaces.Services.RBA;
using Backend_ORM.Core.Settings;
using Backend_ORM.Infrastructure.Context;
using Backend_ORM.Infrastructure.Repositories;
using Backend_ORM.Infrastructure.Repositories.RBA;
using Backend_ORM.Services.Services;
using Backend_ORM.Services.Services.RBA;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configure Swagger with JWT support
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Backend ORM API",
        Version = "v1",
        Description = "GRC SLC ORM Backend API - Revamped LinkProcess Module"
    });

    // Add JWT Authentication to Swagger (enter token only, no 'Bearer' prefix needed)
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Enter your JWT token (without 'Bearer' prefix). Get token from /api/auth/login",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "bearer",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            Array.Empty<string>()
        }
    });

    // Include XML comments for better Swagger documentation
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

// Configure JWT Settings
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

// Configure JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings!.SecretKey)),
        ValidateIssuer = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidateAudience = true,
        ValidAudience = jwtSettings.Audience,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

// Add HttpContextAccessor for CurrentUserService
builder.Services.AddHttpContextAccessor();

// Add DbContext
builder.Services.AddDbContext<ORMContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Helpers
builder.Services.AddSingleton<EncryptionHelper>();

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

// Register Authentication Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<DataMigrationService>();

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
    c.ConfigObject.AdditionalItems["persistAuthorization"] = true; // Keep token after page refresh
});

app.UseCors("AllowAll");

app.UseHttpsRedirection();

// Add Authentication middleware (must come before Authorization)
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
