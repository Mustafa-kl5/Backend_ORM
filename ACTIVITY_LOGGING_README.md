# Activity Logging System

## Overview

Comprehensive activity logging system for tracking user activities, entity changes, authentication events, and API operations across the entire ORM backend. Uses synchronous logging with automatic sensitive data masking.

## Features

- ✅ **Automatic API Request Logging** via middleware
- ✅ **Sensitive Data Masking** (passwords, tokens, keys, etc.)
- ✅ **Authentication Tracking** (login, logout, token refresh)
- ✅ **Entity Change Tracking** (CRUD operations with old/new values)
- ✅ **Correlation ID Tracking** for request chains
- ✅ **Multi-tenant Support** via TenantId
- ✅ **Statistics & Analytics** (user activity, failure rates, module usage)
- ✅ **Dynamic Source System Management** via API

## Database Schema

### Tables

- **`[AuditLogging].[ActivityLog]`** - Main activity log table
- **`[AuditLogging].[SourceSystem]`** - Systems (GRC, ORM, BCM, etc.)
- **`[AuditLogging].[SourceModule]`** - Modules within systems

### Indexes

- `IX_ActivityLog_Tenant_EventType_TimestampUTC`
- `IX_ActivityLog_Tenant_TargetObject_TargetObjectId`
- `IX_ActivityLog_Tenant_UserId_TimestampUTC`

## Architecture

### DTOs

```
ORM.Core/DTOs/ActivityLog/
├── EventType.cs                 // Enum: Login, Logout, Create, Update, Delete, View, Export, etc.
├── ActionType.cs                // Enum: Authentication, Read, Write, Delete, Execute, Export
├── ActivityLogDto.cs
├── CreateActivityLogDto.cs
├── ActivityLogFilterDto.cs
├── ActivityLogStatisticsDto.cs
├── SourceSystemDto.cs
├── SourceModuleDto.cs
└── SensitiveDataAttribute.cs    // Mark properties for masking
```

### Services

- **ISensitiveDataMaskingService** - Masks sensitive fields in JSON
- **IActivityLogService** - Core logging functionality
- **ISourceSystemService** - Manage source systems
- **ISourceModuleService** - Manage source modules

### Repositories

- **IActivityLogRepository** - Activity log data access
- **ISourceSystemRepository** - Source system data access
- **ISourceModuleRepository** - Source module data access

### Middleware

- **ActivityLoggingMiddleware** - Automatic API request/response logging

## Configuration

### appsettings.json

```json
{
  "ActivityLogging": {
    "EnableMiddleware": true,
    "ExcludedEndpoints": ["/health", "/swagger", "/api/activitylog"],
    "MaskSensitiveData": true,
    "SensitiveKeywords": [
      "password",
      "token",
      "secret",
      "key",
      "pin",
      "ssn",
      "creditcard",
      "cvv",
      "apikey",
      "jwt",
      "bearer"
    ]
  }
}
```

## Usage Examples

### 1. Manual Activity Logging

```csharp
// Inject IActivityLogService
private readonly IActivityLogService _activityLogService;

// Log entity creation
await _activityLogService.LogEntityCreatedAsync(
    targetObject: "User",
    targetObjectId: user.UserId.ToString(),
    newValues: user,
    sourceModuleId: 1
);

// Log entity update
await _activityLogService.LogEntityUpdatedAsync(
    targetObject: "Regulation",
    targetObjectId: regulation.RegulationId.ToString(),
    oldValues: oldRegulation,
    newValues: updatedRegulation,
    sourceModuleId: 2
);

// Log entity deletion
await _activityLogService.LogEntityDeletedAsync(
    targetObject: "Control",
    targetObjectId: control.ControlId.ToString(),
    oldValues: control,
    sourceModuleId: 3
);

// Log export operation
await _activityLogService.LogExportAsync(
    targetObject: "Reports",
    recordCount: 150,
    sourceModuleId: 4
);

// Log failure
await _activityLogService.LogFailureAsync(
    eventType: EventType.Update,
    failureReason: "Validation failed: Missing required fields",
    targetObject: "Risk",
    sourceModuleId: 5
);
```

### 2. Authentication Logging (Already Integrated)

```csharp
// In AuthService - Login
await _activityLogService.LogAuthenticationAsync(EventType.Login, true);

// Failed login
await _activityLogService.LogAuthenticationAsync(
    EventType.Login,
    false,
    "Invalid password"
);

// Token refresh
await _activityLogService.LogAuthenticationAsync(EventType.TokenRefresh, true);
```

### 3. Automatic Middleware Logging

The middleware automatically logs all API requests:

- Request path, method, query parameters
- Response status code
- Success/failure status
- Correlation ID tracking

Excluded endpoints (configurable):

- `/health`
- `/swagger`
- `/api/activitylog`

### 4. Query Activity Logs

```csharp
// Get filtered logs with pagination
var filter = new ActivityLogFilterDto
{
    FromDate = DateTime.UtcNow.AddDays(-7),
    ToDate = DateTime.UtcNow,
    EventType = EventType.Login,
    IsSuccess = true,
    PageNumber = 1,
    PageSize = 50
};

var result = await _activityLogService.GetFilteredAsync(filter);

// Get logs by correlation ID
var correlatedLogs = await _activityLogService.GetByCorrelationIdAsync(correlationId);

// Get statistics
var stats = await _activityLogService.GetStatisticsAsync(
    tenantId: "123",
    fromDate: DateTime.UtcNow.AddMonths(-1),
    toDate: DateTime.UtcNow
);
```

## API Endpoints

### Activity Logs

- `GET /api/ActivityLog/{id}` - Get activity log by ID
- `GET /api/ActivityLog` - Get filtered activity logs (pagination)
- `GET /api/ActivityLog/correlation/{correlationId}` - Get correlated logs
- `GET /api/ActivityLog/statistics` - Get activity statistics
- `POST /api/ActivityLog` - Manually log an activity
- `GET /api/ActivityLog/export` - Export activity logs

### Source Systems

- `GET /api/SourceSystem` - Get all source systems
- `GET /api/SourceSystem/{id}` - Get source system by ID
- `GET /api/SourceSystem/code/{code}` - Get source system by code
- `POST /api/SourceSystem` - Create new source system
- `PUT /api/SourceSystem/{id}` - Update source system
- `PATCH /api/SourceSystem/{id}/activate` - Activate source system
- `PATCH /api/SourceSystem/{id}/deactivate` - Deactivate source system

### Source Modules

- `GET /api/SourceModule` - Get all active modules
- `GET /api/SourceModule/{id}` - Get module by ID
- `GET /api/SourceModule/system/{systemId}` - Get modules by system
- `POST /api/SourceModule` - Create new module
- `PUT /api/SourceModule/{id}` - Update module
- `PATCH /api/SourceModule/{id}/activate` - Activate module
- `PATCH /api/SourceModule/{id}/deactivate` - Deactivate module

## Sensitive Data Masking

### Automatic Masking

The system automatically masks fields containing these keywords:

- `password`, `passwd`, `pwd`
- `token`, `accesstoken`, `refreshtoken`, `jwt`
- `secret`, `key`, `apikey`, `privatekey`
- `pin`, `ssn`, `social_security`
- `creditcard`, `cardnumber`, `cvv`, `cvc`
- `authorization`, `bearer`

### Example

```json
// Original
{
  "userId": 123,
  "password": "MySecret123",
  "email": "user@example.com"
}

// Masked in ActivityLog
{
  "userId": 123,
  "password": "***MASKED***",
  "email": "user@example.com"
}
```

### Custom Attribute

Mark properties for masking:

```csharp
public class LoginDto
{
    public string UserName { get; set; }

    [SensitiveData]
    public string Password { get; set; }
}
```

## Initial Setup

### 1. Run Seed Script

Execute the SQL script to populate initial source systems and modules:

```bash
sqlcmd -S your_server -d GRC_SLC_ORM -i SeedActivityLogSystem.sql
```

Or run manually via SSMS.

### 2. Verify Setup

```bash
# Build and run the application
cd ORM_API
dotnet build
dotnet run

# Navigate to Swagger
# https://localhost:5001
```

### 3. Test Endpoints

```bash
# Login to get JWT token
POST /api/Auth/login

# View activity logs (requires authentication)
GET /api/ActivityLog?pageNumber=1&pageSize=50

# Check source systems
GET /api/SourceSystem
```

## Pre-seeded Systems & Modules

### Systems

1. **GRC** - Governance, Risk & Compliance
2. **ORM** - Operational Risk Management
3. **BCM** - Business Continuity Management
4. **RCM** - Regulatory Compliance Management
5. **POLICY** - Policy Management
6. **AUDIT** - Audit Management

### Modules (Examples)

- **GRC**: User Management, Regulations, Controls, Risks
- **ORM**: Loss Events, KRI, RCSA
- **BCM**: BIA, Recovery Planning
- **AUDIT**: Audit Findings, Audit Reports
- **POLICY**: Policy Management, Policy Review

## Integration Guide

### Add to Existing Service

```csharp
public class YourService
{
    private readonly IActivityLogService _activityLogService;
    private readonly IYourRepository _repository;

    public YourService(
        IActivityLogService activityLogService,
        IYourRepository repository)
    {
        _activityLogService = activityLogService;
        _repository = repository;
    }

    public async Task<int> CreateEntityAsync(YourEntity entity)
    {
        var id = await _repository.CreateAsync(entity);

        // Log the creation
        await _activityLogService.LogEntityCreatedAsync(
            "YourEntity",
            id.ToString(),
            entity,
            sourceModuleId: 1 // Your module ID
        );

        return id;
    }
}
```

### Add to Controller

```csharp
[HttpPost]
public async Task<IActionResult> Create([FromBody] CreateDto dto)
{
    var id = await _service.CreateAsync(dto);

    // Manual logging (if middleware doesn't cover it)
    await _activityLogService.LogEntityCreatedAsync(
        "Entity",
        id.ToString(),
        dto
    );

    return Success(new { Id = id });
}
```

## Performance Considerations

### Synchronous Logging

- Activity logging is **synchronous** by design
- Adds ~10-50ms per request (database write time)
- Trade-off: Guaranteed audit trail vs. slight performance impact

### Optimization Tips

1. **Indexes**: Already optimized with composite indexes
2. **Pagination**: Always use pagination for queries
3. **Filtering**: Apply filters to reduce result sets
4. **Exclusions**: Exclude high-frequency endpoints (health checks)
5. **Archival**: Implement periodic archival of old logs (future enhancement)

## Troubleshooting

### Logs Not Appearing

1. Check `ActivityLogging:EnableMiddleware` is `true` in appsettings.json
2. Verify endpoint is not in `ExcludedEndpoints` list
3. Check if `IActivityLogService` is properly injected
4. Review database connection and permissions

### Compilation Errors

If you see errors about missing types:

```bash
# Rebuild all projects in order
dotnet build ORM.Domain
dotnet build ORM.Core
dotnet build ORM.Infrastructure
dotnet build ORM.Application
dotnet build ORM_API
```

### Sensitive Data Not Masked

1. Check `ActivityLogging:MaskSensitiveData` is `true`
2. Verify field names contain sensitive keywords
3. Add custom keywords to `SensitiveKeywords` array in appsettings.json

## Future Enhancements

- [ ] Automatic archival/purging (retention policy)
- [ ] Real-time activity dashboard
- [ ] Anomaly detection (suspicious activities)
- [ ] Export to CSV/Excel
- [ ] Advanced search with full-text indexing
- [ ] Integration with external SIEM systems

## Support

For issues or questions:

- Review this documentation
- Check Swagger API documentation at `/swagger`
- Review database schema and indexes
- Contact development team

---

**Last Updated**: December 4, 2025  
**Version**: 1.0.0
