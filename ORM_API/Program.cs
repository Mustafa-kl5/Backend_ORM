using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ORM.Application.Common.Localization;
using ORM.Application.Common.Responses;
using ORM.Application.Common.Settings;
using ORM.Application.Services;
using ORM.Core.Interfaces.Repositories;
using ORM.Core.Interfaces.Services;
using ORM.Infrastructure.Data;
using ORM.Infrastructure.Middleware;
using ORM.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add HttpContextAccessor for localization
builder.Services.AddHttpContextAccessor();

// Register Localization Service
builder.Services.AddScoped<ILocalizationService, LocalizationService>();

// Configure DbContext
builder.Services.AddDbContext<ORMContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure JWT Settings
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

// Configure JWT Authentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>()!;
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
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
        ValidateIssuer = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidateAudience = true,
        ValidAudience = jwtSettings.Audience,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };

    // Customize JWT authentication responses to use standard API response format with localization
    options.Events = new JwtBearerEvents
    {
        OnChallenge = context =>
        {
            // Skip default behavior
            context.HandleResponse();

            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json";

            // Get localization service
            var localizationService = context.HttpContext.RequestServices.GetService<ILocalizationService>();
            var message = localizationService?.Get(MessageKeys.AuthenticationRequired)
                ?? "Authentication required. Please provide a valid token.";

            var response = ApiResponse.FailResponse(
                message: string.IsNullOrEmpty(context.ErrorDescription)
                    ? message
                    : context.ErrorDescription,
                statusCode: StatusCodes.Status401Unauthorized,
                errors: new List<string> { context.Error ?? "unauthorized" }
            );

            var json = JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return context.Response.WriteAsync(json);
        },
        OnForbidden = context =>
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            context.Response.ContentType = "application/json";

            // Get localization service
            var localizationService = context.HttpContext.RequestServices.GetService<ILocalizationService>();
            var message = localizationService?.Get(MessageKeys.AccessDenied)
                ?? "You do not have permission to access this resource.";

            var response = ApiResponse.FailResponse(
                message: message,
                statusCode: StatusCodes.Status403Forbidden,
                errors: new List<string> { "forbidden" }
            );

            var json = JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return context.Response.WriteAsync(json);
        },
        OnAuthenticationFailed = context =>
        {
            if (context.Exception is SecurityTokenExpiredException)
            {
                context.Response.Headers.Append("Token-Expired", "true");
            }
            return Task.CompletedTask;
        }
    };
});

// Register Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserContextRepository, UserContextRepository>();
builder.Services.AddScoped<IMigrationRepository, MigrationRepository>();
builder.Services.AddScoped<ICommonRepository, CommonRepository>();
builder.Services.AddScoped<IActivityLogRepository, ActivityLogRepository>();
builder.Services.AddScoped<ISourceSystemRepository, SourceSystemRepository>();
builder.Services.AddScoped<ISourceModuleRepository, SourceModuleRepository>();
builder.Services.AddScoped<ICalendarHolidayRepository, CalendarHolidayRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

// Register Services
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserContextService, UserContextService>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<IMigrationService, MigrationService>();
builder.Services.AddScoped<ICommonService, CommonService>();
builder.Services.AddScoped<ISensitiveDataMaskingService, SensitiveDataMaskingService>();
builder.Services.AddScoped<IActivityLogService, ActivityLogService>();
builder.Services.AddScoped<ISourceSystemService, SourceSystemService>();
builder.Services.AddScoped<ISourceModuleService, SourceModuleService>();
builder.Services.AddScoped<ICalendarHolidayService, CalendarHolidayService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddControllers();

// Configure Swagger with JWT Authentication
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ORM API",
        Version = "v1",
        Description = "GRC ORM Web API with JWT Authentication",
        Contact = new OpenApiContact
        {
            Name = "ORM Support",
            Email = "support@orm.com"
        }
    });

    // Add JWT Authentication to Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your JWT token below.\n\nExample: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
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
});

var app = builder.Build();

// Configure the HTTP request pipeline.

// Configure CORS - Allow all origins
app.UseCors(policy =>
{
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader();
});

// Use Global Exception Handler (MUST be first in pipeline)
app.UseGlobalExceptionHandler();

// Enable Swagger UI
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "ORM API v1");
    options.RoutePrefix = string.Empty; // Serve Swagger UI at the root URL
    options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
    options.DefaultModelsExpandDepth(-1); // Hide schemas section by default
    options.DisplayRequestDuration();
    options.EnablePersistAuthorization(); // Persist authorization between page refreshes
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// Use Activity Logging Middleware (after authentication, before controllers)
app.UseMiddleware<ActivityLoggingMiddleware>();

app.MapControllers();

app.Run();
