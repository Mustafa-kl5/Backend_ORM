# ORM API Development Guidelines - GitHub Copilot Instructions

## Project Architecture Overview

This is a **Clean Architecture ASP.NET Core Web API** project with the following layers:

### Layer Structure

1. **ORM_API** - Presentation Layer (Controllers, Program.cs)
2. **ORM.Application** - Application Layer (Services, Common utilities)
3. **ORM.Core** - Domain/Core Layer (DTOs, Interfaces)
4. **ORM.Domain** - Domain Entities (Database models)
5. **ORM.Infrastructure** - Infrastructure Layer (Repositories, DbContext, Middleware)

### Test Projects Structure

6. **ORM.Application.Tests** - Service Layer Unit Tests (Mocked dependencies)
7. **ORM_API.Tests** - Controller/API Unit Tests (Mocked services)
8. **ORM.Infrastructure.Tests** - Repository Integration Tests (InMemory database)

---

## 🎯 CRITICAL PATTERNS TO FOLLOW

### 1. Creating New API Endpoints - Step-by-Step Process

#### Step 1: Define DTOs in `ORM.Core/DTOs`

```csharp
// Example: ORM.Core/DTOs/[Feature]/[Action]RequestDto.cs
using System.ComponentModel.DataAnnotations;

namespace ORM.Core.DTOs.[Feature];

public class [Action]RequestDto
{
    [Required(ErrorMessage = "[Field] is required")]
    public string PropertyName { get; set; } = string.Empty;
}

// Example: ORM.Core/DTOs/[Feature]/[Action]ResponseDto.cs
namespace ORM.Core.DTOs.[Feature];

public class [Action]ResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
}
```

#### Step 2: Create Interface in `ORM.Core/Interfaces`

**Service Interface:**

```csharp
// ORM.Core/Interfaces/Services/I[Feature]Service.cs
using ORM.Core.DTOs.[Feature];

namespace ORM.Core.Interfaces.Services;

public interface I[Feature]Service
{
    Task<[Response]Dto> [Action]Async([Request]Dto request);
    Task<List<[Response]Dto>> GetAllAsync();
    Task<[Response]Dto?> GetByIdAsync(int id);
}
```

**Repository Interface:**

```csharp
// ORM.Core/Interfaces/Repositories/I[Feature]Repository.cs
using ORM.Domain.Entities;

namespace ORM.Core.Interfaces.Repositories;

public interface I[Feature]Repository
{
    Task<[Entity]?> GetByIdAsync(int id);
    Task<List<[Entity]>> GetAllAsync();
    Task<bool> CreateAsync([Entity] entity);
    Task<bool> UpdateAsync([Entity] entity);
    Task<bool> DeleteAsync(int id);
}
```

#### Step 3: Implement Repository in `ORM.Infrastructure/Repositories`

```csharp
// ORM.Infrastructure/Repositories/[Feature]Repository.cs
using Microsoft.EntityFrameworkCore;
using ORM.Core.Interfaces.Repositories;
using ORM.Domain.Entities;
using ORM.Infrastructure.Data;

namespace ORM.Infrastructure.Repositories;

public class [Feature]Repository : I[Feature]Repository
{
    private readonly ORMContext _context;

    public [Feature]Repository(ORMContext context)
    {
        _context = context;
    }

    public async Task<[Entity]?> GetByIdAsync(int id)
    {
        return await _context.[DbSetName]
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<[Entity]>> GetAllAsync()
    {
        return await _context.[DbSetName]
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> CreateAsync([Entity] entity)
    {
        await _context.[DbSetName].AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync([Entity] entity)
    {
        _context.[DbSetName].Update(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.[DbSetName].FindAsync(id);
        if (entity == null) return false;

        _context.[DbSetName].Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}
```

#### Step 4: Implement Service in `ORM.Application/Services`

```csharp
// ORM.Application/Services/[Feature]Service.cs
using ORM.Application.Common.Exceptions;
using ORM.Application.Common.Localization;
using ORM.Core.DTOs.[Feature];
using ORM.Core.Interfaces.Repositories;
using ORM.Core.Interfaces.Services;

namespace ORM.Application.Services;

public class [Feature]Service : I[Feature]Service
{
    private readonly I[Feature]Repository _repository;
    private readonly ILocalizationService _localization;

    public [Feature]Service(
        I[Feature]Repository repository,
        ILocalizationService localization)
    {
        _repository = repository;
        _localization = localization;
    }

    public async Task<[Response]Dto> [Action]Async([Request]Dto request)
    {
        // Business logic here
        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
            throw new ApiException(
                _localization.Get(MessageKeys.NotFound),
                404
            );

        // Map and return
        return new [Response]Dto
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }

    public async Task<List<[Response]Dto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();

        return entities.Select(e => new [Response]Dto
        {
            Id = e.Id,
            Name = e.Name
        }).ToList();
    }

    public async Task<[Response]Dto?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);

        if (entity == null)
            return null;

        return new [Response]Dto
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }
}
```

#### Step 5: Create Controller in `ORM_API/Controllers`

```csharp
// ORM_API/Controllers/[Feature]Controller.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ORM.Application.Common.Localization;
using ORM.Core.DTOs.[Feature];
using ORM.Core.Interfaces.Services;

namespace ORM_API.Controllers;

/// <summary>
/// Controller for [Feature] management
/// </summary>
public class [Feature]Controller : BaseController
{
    private readonly I[Feature]Service _service;
    private readonly ILocalizationService _localization;

    public [Feature]Controller(
        I[Feature]Service service,
        ILocalizationService localization)
    {
        _service = service;
        _localization = localization;
    }

    /// <summary>
    /// Get all [features]
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Success(result, _localization.Get(MessageKeys.DataRetrieved));
    }

    /// <summary>
    /// Get [feature] by ID
    /// </summary>
    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);

        if (result == null)
            return NotFoundResponse(_localization.Get(MessageKeys.NotFound));

        return Success(result);
    }

    /// <summary>
    /// Create new [feature]
    /// </summary>
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] [Create]RequestDto request)
    {
        var result = await _service.CreateAsync(request);
        return Created(result, _localization.Get(MessageKeys.Created));
    }

    /// <summary>
    /// Update existing [feature]
    /// </summary>
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(int id, [FromBody] [Update]RequestDto request)
    {
        var result = await _service.UpdateAsync(id, request);
        return Success(result, _localization.Get(MessageKeys.Updated));
    }

    /// <summary>
    /// Delete [feature]
    /// </summary>
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Success(_localization.Get(MessageKeys.Deleted));
    }
}
```

#### Step 6: Register Services in `Program.cs`

```csharp
// Add to Program.cs in the services registration section

// Register Repositories
builder.Services.AddScoped<I[Feature]Repository, [Feature]Repository>();

// Register Services
builder.Services.AddScoped<I[Feature]Service, [Feature]Service>();
```

---

## 🔑 MANDATORY CONVENTIONS

### Response Handling (ALWAYS use BaseController methods)

```csharp
// ✅ SUCCESS Responses
return Success(data, message);                    // 200 OK with data
return Success(message);                          // 200 OK without data
return Created(data, message);                    // 201 Created

// ✅ ERROR Responses
return NotFoundResponse(message);                 // 404 Not Found
return Fail(message, statusCode, errors);         // Custom error
return UnauthorizedResponse(message);             // 401 Unauthorized

// ✅ PAGINATED Response
return Paginated(data, currentPage, pageSize, totalCount, message);
```

### Authorization Attributes

```csharp
[Authorize]              // Requires valid JWT token
[AllowAnonymous]         // Public endpoint (use sparingly!)
```

### Getting Current User Info

```csharp
// In Controller (inherited from BaseController)
var userId = GetCurrentUserId();
var accountId = GetCurrentAccountId();
var hasPermission = HasPermission("PermissionName");
```

### Exception Handling

```csharp
// ✅ Use ApiException for business logic errors
throw new ApiException(
    _localization.Get(MessageKeys.InvalidOperation),
    400
);

// ✅ Use UnauthorizedAccessException for auth errors
throw new UnauthorizedAccessException(
    _localization.Get(MessageKeys.Unauthorized)
);

// ✅ Use KeyNotFoundException for not found scenarios
throw new KeyNotFoundException(
    _localization.Get(MessageKeys.NotFound)
);
```

### Data Encryption Pattern

```csharp
// When dealing with encrypted fields (Email, UserLogin, Name)
using ORM.Application.Common.Helpers;

// Encrypt before saving
var encrypted = EncryptionHelper.Encrypt(plainText);

// Decrypt when reading
var decrypted = EncryptionHelper.Decrypt(encryptedText);

// Check if value is encrypted
if (EncryptionHelper.IsEncrypted(value))
{
    return EncryptionHelper.Decrypt(value);
}
```

### Password Handling

```csharp
using ORM.Application.Common.Helpers;

// Hash password before saving
var hashedPassword = PasswordHelper.HashPassword(plainPassword);

// Verify password during login
var isValid = PasswordHelper.VerifyPassword(plainPassword, hashedPassword);
```

### Localization Pattern

```csharp
// Always inject ILocalizationService
private readonly ILocalizationService _localization;

// Use predefined message keys
_localization.Get(MessageKeys.LoginSuccess)
_localization.Get(MessageKeys.NotFound)
_localization.Get(MessageKeys.InvalidCredentials)
_localization.Get(MessageKeys.Unauthorized)
```

---

## 📝 API Response Standards

### Standard Success Response

```json
{
  "success": true,
  "statusCode": 200,
  "message": "Operation completed successfully",
  "data": {},
  "errors": [],
  "timestamp": "2025-12-01T10:30:00Z"
}
```

### Standard Error Response

```json
{
  "success": false,
  "statusCode": 400,
  "message": "Error message",
  "data": null,
  "errors": ["Detailed error 1", "Detailed error 2"],
  "timestamp": "2025-12-01T10:30:00Z"
}
```

### Paginated Response

```json
{
  "success": true,
  "statusCode": 200,
  "message": "Data retrieved successfully",
  "data": [],
  "currentPage": 1,
  "pageSize": 10,
  "totalCount": 100,
  "totalPages": 10,
  "hasPreviousPage": false,
  "hasNextPage": true,
  "errors": [],
  "timestamp": "2025-12-01T10:30:00Z"
}
```

---

## 🔐 Security Standards

### JWT Token Configuration

- Token expiration: Set in `JwtSettings.TokenExpirationInMinutes`
- Refresh token expiration: Set in `JwtSettings.RefreshTokenExpirationInDays`
- Claims included: UserId (NameIdentifier), AccountId, Email, Permissions

### Authentication Flow

1. **Login** → Returns JWT + Refresh Token
2. **Token Expires** → Use Refresh Token endpoint
3. **Refresh Token** → Returns new JWT + new Refresh Token

### Controller Authorization

```csharp
// Default: All endpoints require authentication
[Authorize]

// For public endpoints ONLY (e.g., login, register)
[AllowAnonymous]
```

---

## 🗂️ File Naming Conventions

### DTOs

- `[Feature][Action]RequestDto.cs` - For input (e.g., `CreateUserRequestDto`)
- `[Feature][Action]ResponseDto.cs` - For output (e.g., `UserResponseDto`)
- Location: `ORM.Core/DTOs/[Feature]/`

### Interfaces

- Services: `I[Feature]Service.cs` → `ORM.Core/Interfaces/Services/`
- Repositories: `I[Feature]Repository.cs` → `ORM.Core/Interfaces/Repositories/`

### Implementations

- Services: `[Feature]Service.cs` → `ORM.Application/Services/`
- Repositories: `[Feature]Repository.cs` → `ORM.Infrastructure/Repositories/`
- Controllers: `[Feature]Controller.cs` → `ORM_API/Controllers/`

### Entities

- `[EntityName].cs` → `ORM.Domain/Entities/`
- Use existing database entities; don't create new ones without schema updates

---

## 🔄 Dependency Injection Pattern

### Registration Order in `Program.cs`

```csharp
// 1. DbContext
builder.Services.AddDbContext<ORMContext>(options =>
    options.UseSqlServer(connectionString));

// 2. Settings
builder.Services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

// 3. HTTP Context
builder.Services.AddHttpContextAccessor();

// 4. Localization
builder.Services.AddScoped<ILocalizationService, LocalizationService>();

// 5. Repositories (Data Access)
builder.Services.AddScoped<I[Feature]Repository, [Feature]Repository>();

// 6. Services (Business Logic)
builder.Services.AddScoped<I[Feature]Service, [Feature]Service>();

// 7. Controllers
builder.Services.AddControllers();
```

---

## 🚀 Complete Feature Implementation Checklist

When implementing a new feature/endpoint, follow this **MANDATORY** order:

### Phase 1: Core Layer (DTOs & Interfaces)

- [ ] Create Request/Response DTOs in `ORM.Core/DTOs/[Feature]/`
- [ ] Create Service Interface in `ORM.Core/Interfaces/Services/`
- [ ] Create Repository Interface in `ORM.Core/Interfaces/Repositories/`

### Phase 2: Infrastructure Layer (Data Access)

- [ ] Implement Repository in `ORM.Infrastructure/Repositories/`
- [ ] Use `AsNoTracking()` for read operations
- [ ] Handle multi-tenancy with AccountId filtering

### Phase 3: Application Layer (Business Logic)

- [ ] Implement Service in `ORM.Application/Services/`
- [ ] Inject `ILocalizationService` for all user messages
- [ ] Use `ICurrentUserService` for user context
- [ ] Implement business validation logic
- [ ] Handle duplicate detection if applicable
- [ ] Throw appropriate exceptions (`ApiException`, `KeyNotFoundException`)

### Phase 4: Presentation Layer (API)

- [ ] Create Controller in `ORM_API/Controllers/` inheriting `BaseController`
- [ ] Add XML documentation comments to all actions
- [ ] Use appropriate authorization attributes (`[Authorize]`, `[AllowAnonymous]`)
- [ ] Use BaseController response methods (Success, Created, NotFoundResponse)
- [ ] Validate ModelState for all POST/PUT requests

### Phase 5: Dependency Registration

- [ ] Register Repository in `Program.cs` → `builder.Services.AddScoped<I[Feature]Repository, [Feature]Repository>();`
- [ ] Register Service in `Program.cs` → `builder.Services.AddScoped<I[Feature]Service, [Feature]Service>();`

### Phase 6: Testing (MANDATORY - DO NOT SKIP!)

#### 6.1 Application Layer Tests (Service Unit Tests)

- [ ] Create `[Feature]ServiceTests.cs` in `ORM.Application.Tests/Services/`
- [ ] Mock all dependencies: Repository, Localization, CurrentUser, ActivityLog
- [ ] Test ALL service methods (GetAll, GetById, Create, Update, Delete)
- [ ] Test success scenarios
- [ ] Test failure scenarios (NotFound, Duplicate, Invalid data)
- [ ] Test business logic validation
- [ ] Use FluentAssertions for readable assertions
- [ ] Target: **Minimum 8-12 tests per service**

#### 6.2 API Layer Tests (Controller Unit Tests)

- [ ] Create `[Feature]ControllerTests.cs` in `ORM_API.Tests/Controllers/`
- [ ] Mock `I[Feature]Service` and `ILocalizationService`
- [ ] Test ALL controller actions
- [ ] Test HTTP status codes (200 OK, 201 Created, 404 NotFound, 400 BadRequest)
- [ ] Test ModelState validation
- [ ] Test successful responses with data
- [ ] Test error responses
- [ ] Target: **Minimum 12-17 tests per controller**

#### 6.3 Infrastructure Layer Tests (Repository Integration Tests)

- [ ] Create `[Feature]RepositoryTests.cs` in `ORM.Infrastructure.Tests/Repositories/`
- [ ] Use **InMemory database** with unique GUID-named databases per test
- [ ] Implement `IDisposable` for cleanup
- [ ] Create helper methods for test data (`CreateTest[Entity]`)
- [ ] Test ALL repository methods
- [ ] Test data persistence and retrieval
- [ ] Test filtering logic (by AccountId, by DateRange, etc.)
- [ ] Test ordering and pagination if applicable
- [ ] Test duplicate detection logic in `ExistsAsync`
- [ ] Test edge cases (null handling, empty results, overlapping data)
- [ ] Target: **Minimum 20-27 tests per repository**

### Phase 7: Validation

- [ ] Run all tests: `dotnet test` (all should pass ✅)
- [ ] Test with Swagger UI (manual testing)
- [ ] Verify localization works in EN and AR
- [ ] Check API response format matches standards
- [ ] Verify authorization works correctly

---

## 🧪 TESTING STANDARDS (CRITICAL)

### Testing Philosophy

**EVERY new feature MUST have tests at ALL three layers before being considered complete.**

- No exceptions
- Tests are not optional
- Tests should be written immediately after implementation
- All tests must pass before pushing code

### Test Project Dependencies

Each test project must have these NuGet packages:

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.12.0" />
  <PackageReference Include="xunit" Version="3.1.4" />
  <PackageReference Include="xunit.runner.visualstudio" Version="3.1.4" />
  <PackageReference Include="Moq" Version="4.20.72" />
  <PackageReference Include="FluentAssertions" Version="8.8.0" />

  <!-- For API Tests -->
  <PackageReference Include="Microsoft.AspNetCore.Mvc.Testing" Version="10.0.0" />

  <!-- For Infrastructure Tests -->
  <PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="10.0.0" />
</ItemGroup>
```

### 1. Application Layer Tests Pattern (Service Unit Tests)

**File:** `ORM.Application.Tests/Services/[Feature]ServiceTests.cs`

```csharp
using FluentAssertions;
using Moq;
using ORM.Application.Common.Exceptions;
using ORM.Application.Common.Localization;
using ORM.Application.Services;
using ORM.Core.DTOs.[Feature];
using ORM.Core.Interfaces.Repositories;
using ORM.Core.Interfaces.Services;
using ORM.Domain.Entities;

namespace ORM.Application.Tests.Services;

public class [Feature]ServiceTests
{
    private readonly Mock<I[Feature]Repository> _mockRepository;
    private readonly Mock<ILocalizationService> _mockLocalization;
    private readonly Mock<ICurrentUserService> _mockCurrentUser;
    private readonly Mock<IActivityLogService> _mockActivityLog;
    private readonly [Feature]Service _service;

    public [Feature]ServiceTests()
    {
        _mockRepository = new Mock<I[Feature]Repository>();
        _mockLocalization = new Mock<ILocalizationService>();
        _mockCurrentUser = new Mock<ICurrentUserService>();
        _mockActivityLog = new Mock<IActivityLogService>();

        // Setup default mock returns
        _mockCurrentUser.Setup(x => x.GetCurrentUserId()).Returns(1);
        _mockCurrentUser.Setup(x => x.GetCurrentAccountId()).Returns(100);
        _mockLocalization.Setup(x => x.Get(It.IsAny<string>())).Returns("Test Message");

        _service = new [Feature]Service(
            _mockRepository.Object,
            _mockLocalization.Object,
            _mockCurrentUser.Object,
            _mockActivityLog.Object
        );
    }

    #region Helper Methods

    private [Entity] CreateTest[Entity](int id = 1, string name = "Test")
    {
        return new [Entity]
        {
            Id = id,
            Name = name,
            AccountId = 100,
            CreatedDate = DateTime.UtcNow,
            CreatedBy = 1,
            IsActive = true
        };
    }

    private [Create]RequestDto CreateTest[Create]Dto()
    {
        return new [Create]RequestDto
        {
            Name = "Test Name",
            Description = "Test Description"
        };
    }

    #endregion

    #region GetAllAsync Tests

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllItems_WhenDataExists()
    {
        // Arrange
        var entities = new List<[Entity]>
        {
            CreateTest[Entity](1, "Test 1"),
            CreateTest[Entity](2, "Test 2")
        };
        _mockRepository.Setup(x => x.GetAllAsync(It.IsAny<int>()))
            .ReturnsAsync(entities);

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result[0].Name.Should().Be("Test 1");
        result[1].Name.Should().Be("Test 2");
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnEmptyList_WhenNoDataExists()
    {
        // Arrange
        _mockRepository.Setup(x => x.GetAllAsync(It.IsAny<int>()))
            .ReturnsAsync(new List<[Entity]>());

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    #endregion

    #region GetByIdAsync Tests

    [Fact]
    public async Task GetByIdAsync_ShouldReturnItem_WhenItemExists()
    {
        // Arrange
        var entity = CreateTest[Entity]();
        _mockRepository.Setup(x => x.GetByIdAsync(1, It.IsAny<int>()))
            .ReturnsAsync(entity);

        // Act
        var result = await _service.GetByIdAsync(1);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(1);
        result.Name.Should().Be("Test");
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnNull_WhenItemDoesNotExist()
    {
        // Arrange
        _mockRepository.Setup(x => x.GetByIdAsync(99, It.IsAny<int>()))
            .ReturnsAsync((CalendarHoliday?)null);

        // Act
        var result = await _service.GetByIdAsync(99);

        // Assert
        result.Should().BeNull();
    }

    #endregion

    #region CreateAsync Tests

    [Fact]
    public async Task CreateAsync_ShouldReturnSuccess_WhenDataIsValid()
    {
        // Arrange
        var dto = CreateTest[Create]Dto();
        _mockRepository.Setup(x => x.ExistsAsync(
            It.IsAny<string>(),
            It.IsAny<DateTime>(),
            It.IsAny<DateTime>(),
            It.IsAny<int>(),
            null))
            .ReturnsAsync(false);
        _mockRepository.Setup(x => x.CreateAsync(It.IsAny<[Entity]>()))
            .ReturnsAsync(true);

        // Act
        var result = await _service.CreateAsync(dto);

        // Assert
        result.Should().BeTrue();
        _mockRepository.Verify(x => x.CreateAsync(It.IsAny<[Entity]>()), Times.Once);
    }

    [Fact]
    public async Task CreateAsync_ShouldThrowApiException_WhenDuplicateExists()
    {
        // Arrange
        var dto = CreateTest[Create]Dto();
        _mockRepository.Setup(x => x.ExistsAsync(
            It.IsAny<string>(),
            It.IsAny<DateTime>(),
            It.IsAny<DateTime>(),
            It.IsAny<int>(),
            null))
            .ReturnsAsync(true);

        // Act
        var act = async () => await _service.CreateAsync(dto);

        // Assert
        await act.Should().ThrowAsync<ApiException>()
            .WithMessage("*Test Message*");
    }

    #endregion

    #region UpdateAsync Tests

    [Fact]
    public async Task UpdateAsync_ShouldReturnSuccess_WhenDataIsValid()
    {
        // Arrange
        var entity = CreateTest[Entity]();
        var dto = CreateTest[Update]Dto();

        _mockRepository.Setup(x => x.GetByIdAsync(1, It.IsAny<int>()))
            .ReturnsAsync(entity);
        _mockRepository.Setup(x => x.ExistsAsync(
            It.IsAny<string>(),
            It.IsAny<DateTime>(),
            It.IsAny<DateTime>(),
            It.IsAny<int>(),
            1))
            .ReturnsAsync(false);
        _mockRepository.Setup(x => x.UpdateAsync(It.IsAny<[Entity]>()))
            .ReturnsAsync(true);

        // Act
        var result = await _service.UpdateAsync(1, dto);

        // Assert
        result.Should().BeTrue();
        _mockRepository.Verify(x => x.UpdateAsync(It.IsAny<[Entity]>()), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldThrowKeyNotFoundException_WhenItemDoesNotExist()
    {
        // Arrange
        var dto = CreateTest[Update]Dto();
        _mockRepository.Setup(x => x.GetByIdAsync(99, It.IsAny<int>()))
            .ReturnsAsync(([Entity]?)null);

        // Act
        var act = async () => await _service.UpdateAsync(99, dto);

        // Assert
        await act.Should().ThrowAsync<KeyNotFoundException>();
    }

    #endregion

    #region DeleteAsync Tests

    [Fact]
    public async Task DeleteAsync_ShouldReturnTrue_WhenItemExists()
    {
        // Arrange
        _mockRepository.Setup(x => x.DeleteAsync(1, It.IsAny<int>()))
            .ReturnsAsync(true);

        // Act
        var result = await _service.DeleteAsync(1);

        // Assert
        result.Should().BeTrue();
        _mockRepository.Verify(x => x.DeleteAsync(1, It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnFalse_WhenItemDoesNotExist()
    {
        // Arrange
        _mockRepository.Setup(x => x.DeleteAsync(99, It.IsAny<int>()))
            .ReturnsAsync(false);

        // Act
        var result = await _service.DeleteAsync(99);

        // Assert
        result.Should().BeFalse();
    }

    #endregion
}
```

### 2. API Layer Tests Pattern (Controller Unit Tests)

**File:** `ORM_API.Tests/Controllers/[Feature]ControllerTests.cs`

```csharp
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ORM.Application.Common.Localization;
using ORM.Core.DTOs.[Feature];
using ORM.Core.Interfaces.Services;
using ORM_API.Controllers;

namespace ORM_API.Tests.Controllers;

public class [Feature]ControllerTests
{
    private readonly Mock<I[Feature]Service> _mockService;
    private readonly Mock<ILocalizationService> _mockLocalization;
    private readonly [Feature]Controller _controller;

    public [Feature]ControllerTests()
    {
        _mockService = new Mock<I[Feature]Service>();
        _mockLocalization = new Mock<ILocalizationService>();
        _mockLocalization.Setup(x => x.Get(It.IsAny<string>())).Returns("Test Message");

        _controller = new [Feature]Controller(_mockService.Object, _mockLocalization.Object);
    }

    #region GetAll Tests

    [Fact]
    public async Task GetAll_ShouldReturnOkResult_WithData()
    {
        // Arrange
        var items = new List<[Response]Dto>
        {
            new() { Id = 1, Name = "Test 1" },
            new() { Id = 2, Name = "Test 2" }
        };
        _mockService.Setup(x => x.GetAllAsync()).ReturnsAsync(items);

        // Act
        var result = await _controller.GetAll();

        // Assert
        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        okResult.StatusCode.Should().Be(200);
        okResult.Value.Should().NotBeNull();
    }

    [Fact]
    public async Task GetAll_ShouldReturnOkResult_WithEmptyList_WhenNoDataExists()
    {
        // Arrange
        _mockService.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<[Response]Dto>());

        // Act
        var result = await _controller.GetAll();

        // Assert
        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        okResult.StatusCode.Should().Be(200);
    }

    #endregion

    #region GetById Tests

    [Fact]
    public async Task GetById_ShouldReturnOkResult_WhenItemExists()
    {
        // Arrange
        var item = new [Response]Dto { Id = 1, Name = "Test" };
        _mockService.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(item);

        // Act
        var result = await _controller.GetById(1);

        // Assert
        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        okResult.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetById_ShouldReturnNotFound_WhenItemDoesNotExist()
    {
        // Arrange
        _mockService.Setup(x => x.GetByIdAsync(99)).ReturnsAsync(([Response]Dto?)null);

        // Act
        var result = await _controller.GetById(99);

        // Assert
        var notFoundResult = result.Should().BeOfType<NotFoundObjectResult>().Subject;
        notFoundResult.StatusCode.Should().Be(404);
    }

    #endregion

    #region Create Tests

    [Fact]
    public async Task Create_ShouldReturnCreatedResult_WhenDataIsValid()
    {
        // Arrange
        var request = new [Create]RequestDto { Name = "New Item" };
        _mockService.Setup(x => x.CreateAsync(request)).ReturnsAsync(true);

        // Act
        var result = await _controller.Create(request);

        // Assert
        var createdResult = result.Should().BeOfType<ObjectResult>().Subject;
        createdResult.StatusCode.Should().Be(201);
    }

    [Fact]
    public async Task Create_ShouldReturnBadRequest_WhenModelStateIsInvalid()
    {
        // Arrange
        var request = new [Create]RequestDto();
        _controller.ModelState.AddModelError("Name", "Name is required");

        // Act
        var result = await _controller.Create(request);

        // Assert
        var badRequestResult = result.Should().BeOfType<BadRequestObjectResult>().Subject;
        badRequestResult.StatusCode.Should().Be(400);
    }

    #endregion

    #region Update Tests

    [Fact]
    public async Task Update_ShouldReturnOkResult_WhenDataIsValid()
    {
        // Arrange
        var request = new [Update]RequestDto { Name = "Updated" };
        _mockService.Setup(x => x.UpdateAsync(1, request)).ReturnsAsync(true);

        // Act
        var result = await _controller.Update(1, request);

        // Assert
        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        okResult.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Update_ShouldReturnBadRequest_WhenModelStateIsInvalid()
    {
        // Arrange
        var request = new [Update]RequestDto();
        _controller.ModelState.AddModelError("Name", "Name is required");

        // Act
        var result = await _controller.Update(1, request);

        // Assert
        var badRequestResult = result.Should().BeOfType<BadRequestObjectResult>().Subject;
        badRequestResult.StatusCode.Should().Be(400);
    }

    #endregion

    #region Delete Tests

    [Fact]
    public async Task Delete_ShouldReturnOkResult_WhenItemExists()
    {
        // Arrange
        _mockService.Setup(x => x.DeleteAsync(1)).ReturnsAsync(true);

        // Act
        var result = await _controller.Delete(1);

        // Assert
        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        okResult.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Delete_ShouldReturnNotFound_WhenServiceReturnsFalse()
    {
        // Arrange
        _mockService.Setup(x => x.DeleteAsync(99)).ReturnsAsync(false);

        // Act
        var result = await _controller.Delete(99);

        // Assert
        // Behavior depends on your controller implementation
        // Adjust assertion based on actual return
    }

    #endregion
}
```

### 3. Infrastructure Layer Tests Pattern (Repository Integration Tests)

**File:** `ORM.Infrastructure.Tests/Repositories/[Feature]RepositoryTests.cs`

```csharp
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ORM.Domain.Entities;
using ORM.Infrastructure.Data;
using ORM.Infrastructure.Repositories;

namespace ORM.Infrastructure.Tests.Repositories;

public class [Feature]RepositoryTests : IDisposable
{
    private readonly ORMContext _context;
    private readonly [Feature]Repository _repository;
    private readonly string _databaseName;

    public [Feature]RepositoryTests()
    {
        // Use unique database name for each test to avoid conflicts
        _databaseName = $"TestDb_{Guid.NewGuid()}";

        var options = new DbContextOptionsBuilder<ORMContext>()
            .UseInMemoryDatabase(databaseName: _databaseName)
            .Options;

        _context = new ORMContext(options);
        _repository = new [Feature]Repository(_context);
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }

    #region Helper Methods

    private [Entity] CreateTest[Entity](
        int id = 1,
        string name = "Test",
        int accountId = 100)
    {
        return new [Entity]
        {
            Id = id,
            Name = name,
            AccountId = accountId,
            CreatedDate = DateTime.UtcNow,
            CreatedBy = 1,
            IsActive = true
        };
    }

    #endregion

    #region GetAllAsync Tests

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllItems_ForSpecificAccount()
    {
        // Arrange
        var items = new List<[Entity]>
        {
            CreateTest[Entity](1, "Test 1", 100),
            CreateTest[Entity](2, "Test 2", 100),
            CreateTest[Entity](3, "Test 3", 200) // Different account
        };
        await _context.[DbSetName].AddRangeAsync(items);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetAllAsync(100);

        // Assert
        result.Should().HaveCount(2);
        result.Should().AllSatisfy(x => x.AccountId.Should().Be(100));
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnEmptyList_WhenNoDataExists()
    {
        // Act
        var result = await _repository.GetAllAsync(100);

        // Assert
        result.Should().BeEmpty();
    }

    #endregion

    #region GetByIdAsync Tests

    [Fact]
    public async Task GetByIdAsync_ShouldReturnItem_WhenItemExists()
    {
        // Arrange
        var item = CreateTest[Entity]();
        await _context.[DbSetName].AddAsync(item);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetByIdAsync(1, 100);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(1);
        result.Name.Should().Be("Test");
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnNull_WhenItemDoesNotExist()
    {
        // Act
        var result = await _repository.GetByIdAsync(99, 100);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnNull_WhenAccountIdDoesNotMatch()
    {
        // Arrange
        var item = CreateTest[Entity](1, "Test", 100);
        await _context.[DbSetName].AddAsync(item);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetByIdAsync(1, 200); // Wrong account

        // Assert
        result.Should().BeNull();
    }

    #endregion

    #region CreateAsync Tests

    [Fact]
    public async Task CreateAsync_ShouldAddItemToDatabase()
    {
        // Arrange
        var item = CreateTest[Entity]();

        // Act
        var result = await _repository.CreateAsync(item);

        // Assert
        result.Should().BeTrue();
        var savedItem = await _context.[DbSetName].FindAsync(1);
        savedItem.Should().NotBeNull();
        savedItem!.Name.Should().Be("Test");
    }

    #endregion

    #region UpdateAsync Tests

    [Fact]
    public async Task UpdateAsync_ShouldModifyExistingItem()
    {
        // Arrange
        var item = CreateTest[Entity]();
        await _context.[DbSetName].AddAsync(item);
        await _context.SaveChangesAsync();

        item.Name = "Updated";

        // Act
        var result = await _repository.UpdateAsync(item);

        // Assert
        result.Should().BeTrue();
        var updatedItem = await _context.[DbSetName].FindAsync(1);
        updatedItem!.Name.Should().Be("Updated");
    }

    #endregion

    #region DeleteAsync Tests

    [Fact]
    public async Task DeleteAsync_ShouldRemoveItem_WhenItemExists()
    {
        // Arrange
        var item = CreateTest[Entity]();
        await _context.[DbSetName].AddAsync(item);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.DeleteAsync(1, 100);

        // Assert
        result.Should().BeTrue();
        var deletedItem = await _context.[DbSetName].FindAsync(1);
        deletedItem.Should().BeNull();
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnFalse_WhenItemDoesNotExist()
    {
        // Act
        var result = await _repository.DeleteAsync(99, 100);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnFalse_WhenAccountIdDoesNotMatch()
    {
        // Arrange
        var item = CreateTest[Entity](1, "Test", 100);
        await _context.[DbSetName].AddAsync(item);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.DeleteAsync(1, 200); // Wrong account

        // Assert
        result.Should().BeFalse();
    }

    #endregion

    #region ExistsAsync Tests (If applicable for duplicate detection)

    [Fact]
    public async Task ExistsAsync_ShouldReturnTrue_WhenDuplicateExists()
    {
        // Arrange
        var item = CreateTest[Entity](1, "Duplicate Name", 100);
        await _context.[DbSetName].AddAsync(item);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.ExistsAsync("Duplicate Name", 100, null);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task ExistsAsync_ShouldReturnFalse_WhenNoDuplicateExists()
    {
        // Act
        var result = await _repository.ExistsAsync("Unique Name", 100, null);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task ExistsAsync_ShouldIgnoreCurrentItem_WhenUpdating()
    {
        // Arrange
        var item = CreateTest[Entity](1, "Test", 100);
        await _context.[DbSetName].AddAsync(item);
        await _context.SaveChangesAsync();

        // Act - Should not find duplicate when checking against itself
        var result = await _repository.ExistsAsync("Test", 100, 1);

        // Assert
        result.Should().BeFalse();
    }

    #endregion
}
```

### Running Tests

```bash
# Run all tests in solution
dotnet test

# Run tests for specific project
dotnet test ORM.Application.Tests
dotnet test ORM_API.Tests
dotnet test ORM.Infrastructure.Tests

# Run tests with detailed output
dotnet test --verbosity detailed

# Run tests with coverage (if configured)
dotnet test --collect:"XPlat Code Coverage"
```

### Test Naming Convention

Follow AAA pattern (Arrange, Act, Assert) and descriptive naming:

```csharp
[Fact]
public async Task MethodName_Should[ExpectedBehavior]_When[Condition]()
{
    // Arrange

    // Act

    // Assert
}
```

Examples:

- `GetAllAsync_ShouldReturnAllItems_WhenDataExists`
- `CreateAsync_ShouldThrowException_WhenDuplicateExists`
- `DeleteAsync_ShouldReturnFalse_WhenItemDoesNotExist`

---

## 📚 Common Patterns Reference

### DbContext Configuration for Testing

**CRITICAL:** The `ORMContext.OnConfiguring` method must support both SQL Server (production) and InMemory (testing):

```csharp
// ORM.Infrastructure/Data/ORMContext.cs
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    // Only configure SQL Server if no provider is already configured
    // This allows tests to inject InMemory provider
    if (!optionsBuilder.IsConfigured)
    {
        #warning To protect potentially sensitive information...
        optionsBuilder.UseSqlServer("YourConnectionString");
    }
}
```

**Why this matters:**

- Production code uses SQL Server from OnConfiguring
- Test code injects InMemory provider via constructor options
- Without the `if (!optionsBuilder.IsConfigured)` check, you'll get provider conflicts
- This pattern enables true integration testing with InMemory database

### Async/Await Pattern

```csharp
// ✅ ALWAYS use async/await for database operations
public async Task<ResultDto> GetDataAsync(int id)
{
    var entity = await _repository.GetByIdAsync(id);
    return MapToDto(entity);
}
```

### Entity to DTO Mapping

```csharp
// Simple mapping
return new UserDto
{
    Id = user.UserId,
    Name = user.Name
};

// Collection mapping
return users.Select(u => new UserDto
{
    Id = u.UserId,
    Name = u.Name
}).ToList();
```

### Validation Pattern

```csharp
// Use Data Annotations in DTOs
[Required(ErrorMessage = "Field is required")]
[StringLength(100, ErrorMessage = "Max length is 100")]
[EmailAddress(ErrorMessage = "Invalid email format")]
public string Email { get; set; } = string.Empty;
```

### Controller ModelState Validation Pattern

```csharp
// ALWAYS check ModelState in POST/PUT actions
[HttpPost]
public async Task<IActionResult> Create([FromBody] CreateRequestDto request)
{
    if (!ModelState.IsValid)
        return BadRequest(ModelState);

    var result = await _service.CreateAsync(request);
    return Created(result, _localization.Get(MessageKeys.Created));
}
```

### Business Validation Pattern (in Services)

```csharp
// Duplicate detection example
public async Task<bool> CreateAsync(CreateDto dto)
{
    // Check for duplicates
    var exists = await _repository.ExistsAsync(dto.Name, accountId, null);
    if (exists)
    {
        throw new ApiException(
            _localization.Get(MessageKeys.DuplicateRecord),
            400
        );
    }

    // Proceed with creation
    var entity = MapToEntity(dto);
    return await _repository.CreateAsync(entity);
}
```

---

## ⚠️ CRITICAL DON'Ts

❌ **DON'T** create controllers without inheriting from `BaseController`
❌ **DON'T** return raw data without wrapping in `ApiResponse`
❌ **DON'T** use `return Ok()` or `return BadRequest()` directly - use BaseController methods
❌ **DON'T** hardcode error messages; use `ILocalizationService`
❌ **DON'T** access DbContext directly from Services; use Repositories
❌ **DON'T** put business logic in Controllers; use Services
❌ **DON'T** store sensitive data unencrypted
❌ **DON'T** forget to register new services in `Program.cs`
❌ **DON'T** use synchronous database operations (use async/await)
❌ **DON'T** expose internal exceptions to API responses in production
❌ **DON'T** skip ModelState validation in POST/PUT endpoints
❌ **DON'T** forget to filter by AccountId in multi-tenant queries
❌ **DON'T** write code without accompanying tests (all 3 layers required!)
❌ **DON'T** use `.ToList()` before `.Where()` - filter in database, not memory
❌ **DON'T** forget `AsNoTracking()` for read-only queries
❌ **DON'T** create DbContext without conditional provider configuration

---

## 🎯 Summary: The Golden Rules

1. **Always** follow the Clean Architecture layer separation (API → Application → Infrastructure)
2. **Always** use BaseController response methods (Success, Created, NotFoundResponse, Fail)
3. **Always** use dependency injection (register in Program.cs)
4. **Always** use async/await for I/O operations
5. **Always** use localization for user-facing messages (ILocalizationService)
6. **Always** handle exceptions properly (ApiException, KeyNotFoundException, UnauthorizedAccessException)
7. **Always** validate input using Data Annotations + ModelState
8. **Always** document APIs with XML comments
9. **Always** use `[Authorize]` unless explicitly public
10. **Always** register new services in Program.cs
11. **Always** filter by AccountId for multi-tenant data
12. **Always** use `AsNoTracking()` for read-only queries
13. **Always** write tests at ALL three layers (Service, Controller, Repository)
14. **Always** use InMemory database for integration tests
15. **Always** run `dotnet test` before committing code

---

## 🧪 Test Coverage Standards

### Minimum Test Counts Per Feature

- **Service Layer**: 8-12 unit tests minimum
- **Controller Layer**: 12-17 unit tests minimum
- **Repository Layer**: 20-27 integration tests minimum

### Test Coverage Checklist

For each new feature, ensure tests cover:

**Service Tests:**

- [ ] GetAll - success with data
- [ ] GetAll - empty result
- [ ] GetById - found
- [ ] GetById - not found
- [ ] Create - success
- [ ] Create - duplicate/validation error
- [ ] Update - success
- [ ] Update - not found
- [ ] Update - duplicate/validation error
- [ ] Delete - success
- [ ] Delete - not found
- [ ] Business logic edge cases

**Controller Tests:**

- [ ] GetAll - 200 OK with data
- [ ] GetAll - 200 OK empty list
- [ ] GetById - 200 OK
- [ ] GetById - 404 Not Found
- [ ] Create - 201 Created
- [ ] Create - 400 Bad Request (ModelState)
- [ ] Create - 400 Bad Request (business validation)
- [ ] Update - 200 OK
- [ ] Update - 400 Bad Request (ModelState)
- [ ] Update - 404 Not Found
- [ ] Delete - 200 OK
- [ ] Delete - 404 Not Found
- [ ] Authorization scenarios (if applicable)

**Repository Tests:**

- [ ] GetAll - returns all for account
- [ ] GetAll - filters by AccountId
- [ ] GetAll - empty result
- [ ] GetById - found
- [ ] GetById - not found
- [ ] GetById - wrong AccountId returns null
- [ ] Create - adds to database
- [ ] Create - sets audit fields
- [ ] Update - modifies existing
- [ ] Delete - removes item
- [ ] Delete - not found returns false
- [ ] Delete - wrong AccountId returns false
- [ ] ExistsAsync - duplicate detection (if applicable)
- [ ] ExistsAsync - case insensitive
- [ ] ExistsAsync - ignores self when updating
- [ ] Filtering logic (by date range, country, etc.)
- [ ] Ordering logic
- [ ] Pagination (if applicable)

---

## 📞 Example: Complete Feature Implementation

See the following files for complete reference implementations:

### Backend Reference Files

- **Controller**: `CalendarHolidayController.cs` - Shows proper BaseController usage, authorization, XML docs
- **Service**: `CalendarHolidayService.cs` - Business logic, localization, duplicate detection
- **Repository**: `CalendarHolidayRepository.cs` - Data access with AccountId filtering, date overlap logic
- **DTOs**: `ORM.Core/DTOs/CalendarHoliday/` - Request/Response DTOs with validation
- **Localization**: `LocalizationService.cs` - Multi-language support (EN/AR)

### Test Reference Files

- **Service Tests**: `ORM.Application.Tests/Services/CalendarHolidayServiceTests.cs` - 12 unit tests
- **Controller Tests**: `ORM_API.Tests/Controllers/CalendarHolidayControllerTests.cs` - 17 API tests
- **Repository Tests**: `ORM.Infrastructure.Tests/Repositories/CalendarHolidayRepositoryTests.cs` - 27 integration tests

---

## 🌍 LOCALIZATION & MULTI-LANGUAGE SUPPORT

### Backend Localization Pattern

The project supports **English** and **Arabic** (AR-1, AR-2) languages.

#### Using Localization Service

```csharp
// Inject in constructor
private readonly ILocalizationService _localization;

public [Feature]Service(ILocalizationService localization)
{
    _localization = localization;
}

// Use predefined message keys
return Success(
    data,
    _localization.Get(MessageKeys.DataRetrievedSuccessfully)
);

throw new ApiException(
    _localization.Get(MessageKeys.CalendarHolidayDuplicate),
    400
);
```

#### Message Keys Reference

Located in `ORM.Application/Common/Localization/Messages.cs`:

```csharp
public static class MessageKeys
{
    // General
    public const string DataRetrievedSuccessfully = "DataRetrievedSuccessfully";
    public const string OperationCompletedSuccessfully = "OperationCompletedSuccessfully";
    public const string RecordCreatedSuccessfully = "RecordCreatedSuccessfully";
    public const string RecordUpdatedSuccessfully = "RecordUpdatedSuccessfully";
    public const string RecordDeletedSuccessfully = "RecordDeletedSuccessfully";

    // Errors
    public const string RecordNotFound = "RecordNotFound";
    public const string InvalidData = "InvalidData";
    public const string DuplicateRecord = "DuplicateRecord";

    // Feature-specific (example)
    public const string CalendarHolidayDuplicate = "CalendarHolidayDuplicate";
    public const string CalendarHolidayNotFound = "CalendarHolidayNotFound";
}
```

#### Adding New Translations

1. Add message key to `Messages.cs`
2. Add translations in `LocalizationService.cs`:

```csharp
private Dictionary<string, string> GetEnglishTranslations()
{
    return new Dictionary<string, string>
    {
        { MessageKeys.YourNewKey, "English translation" }
    };
}

private Dictionary<string, string> GetArabicTranslations()
{
    return new Dictionary<string, string>
    {
        { MessageKeys.YourNewKey, "الترجمة العربية" }
    };
}
```

### Frontend Localization Pattern

The frontend uses `react-i18next` with translation files in `src/locales/`:

- `en.json` - English
- `ar-1.json` - Arabic (Standard)
- `ar-2.json` - Arabic (Alternative)

#### Using Translations in Components

```typescript
import { useTranslation } from "react-i18next";

function MyComponent() {
  const { t } = useTranslation();

  return (
    <div>
      <h1>{t("calendarHoliday.title")}</h1>
      <button>{t("common.save")}</button>
      <p>{t("calendarHoliday.description")}</p>
    </div>
  );
}
```

#### RTL/LTR Support

```typescript
// Direction is automatically detected from i18n language
const { i18n } = useTranslation();
const isRTL = i18n.language.startsWith("ar");

// Apply RTL classes conditionally
<div className={isRTL ? "rtl" : "ltr"}>
  <ToastContainer position={isRTL ? "top-left" : "top-right"} />
</div>;
```

#### Adding New Translations to Frontend

Add keys to all three translation files:

**en.json:**

```json
{
  "yourFeature": {
    "title": "Feature Title",
    "save": "Save",
    "cancel": "Cancel"
  }
}
```

**ar-1.json:**

```json
{
  "yourFeature": {
    "title": "عنوان الميزة",
    "save": "حفظ",
    "cancel": "إلغاء"
  }
}
```

**ar-2.json:** (Similar structure with alternative translations)

---

## 🔧 COMMON DEVELOPMENT WORKFLOWS

### Workflow 1: Adding a New Feature (Complete End-to-End)

1. **Plan the Feature**

   - Identify entities/tables needed
   - Define business rules
   - Plan API endpoints

2. **Backend Implementation** (Follow Phase 1-5 from checklist)

   - Create DTOs (Request/Response)
   - Create Interfaces (Service & Repository)
   - Implement Repository (Data Access)
   - Implement Service (Business Logic)
   - Create Controller (API Endpoints)
   - Register in Program.cs

3. **Backend Testing** (Phase 6 - MANDATORY)

   - Write Service unit tests (8-12 tests)
   - Write Controller unit tests (12-17 tests)
   - Write Repository integration tests (20-27 tests)
   - Run `dotnet test` - all must pass ✅

4. **Frontend Implementation**

   - Create TypeScript types/interfaces
   - Create API service client
   - Create page component with CRUD operations
   - Add translations (en.json, ar-1.json, ar-2.json)
   - Add route to router
   - Test UI in browser

5. **Validation & Documentation**
   - Test in Swagger
   - Test in UI
   - Verify localization works
   - Ensure all tests pass
   - Update documentation if needed

### Workflow 2: Fixing a Bug

1. **Reproduce the Bug**

   - Understand the issue
   - Check error logs
   - Identify the layer (Controller/Service/Repository)

2. **Write a Failing Test**

   - Add a test that reproduces the bug
   - Test should fail initially

3. **Fix the Bug**

   - Make minimal changes to fix
   - Ensure test now passes
   - Verify no other tests broke

4. **Run All Tests**

   ```bash
   dotnet test
   ```

5. **Validate in UI**
   - Test the fix manually
   - Ensure no regression

### Workflow 3: Running and Testing the Application

#### Backend (API)

```bash
# Run the API
cd d:/ORM/Backend_ORM/ORM_API
dotnet run

# API will be available at:
# https://localhost:7xxx
# http://localhost:5xxx
# Swagger UI: https://localhost:7xxx/swagger
```

#### Run All Tests

```bash
# From Backend_ORM folder
cd d:/ORM/Backend_ORM

# Run all tests in solution
dotnet test

# Run specific test project
dotnet test ORM.Application.Tests
dotnet test ORM_API.Tests
dotnet test ORM.Infrastructure.Tests

# Run with detailed output
dotnet test --verbosity detailed
```

#### Frontend

```bash
# Install dependencies (first time)
cd d:/ORM/FRONTEND_ORM/ORM-frontend
npm install

# Run development server
npm run dev

# Frontend will be available at:
# http://localhost:5173 (or similar)
```

### Workflow 4: Adding Localization Messages

**Backend:**

1. Add key to `Messages.cs`:

   ```csharp
   public const string NewFeatureSuccess = "NewFeatureSuccess";
   ```

2. Add translations to `LocalizationService.cs`:

   ```csharp
   // English
   { MessageKeys.NewFeatureSuccess, "Feature completed successfully" }

   // Arabic
   { MessageKeys.NewFeatureSuccess, "تم إكمال الميزة بنجاح" }
   ```

3. Use in code:
   ```csharp
   return Success(data, _localization.Get(MessageKeys.NewFeatureSuccess));
   ```

**Frontend:**

1. Add to `en.json`:

   ```json
   {
     "newFeature": {
       "success": "Feature completed successfully"
     }
   }
   ```

2. Add to `ar-1.json` and `ar-2.json`:

   ```json
   {
     "newFeature": {
       "success": "تم إكمال الميزة بنجاح"
     }
   }
   ```

3. Use in component:
   ```typescript
   const { t } = useTranslation();
   toast.success(t("newFeature.success"));
   ```

---

## 🛡️ ERROR HANDLING & VALIDATION

### Backend Error Handling

#### Exception Types

```csharp
// 400 Bad Request - Business logic errors
throw new ApiException("Duplicate record found", 400);

// 404 Not Found - Resource doesn't exist
throw new KeyNotFoundException("Record not found");

// 401 Unauthorized - Authentication failure
throw new UnauthorizedAccessException("Invalid credentials");
```

#### Global Exception Handling

All exceptions are caught by middleware and converted to standard API responses:

```json
{
  "success": false,
  "statusCode": 400,
  "message": "Duplicate record found",
  "data": null,
  "errors": ["Detail 1", "Detail 2"],
  "timestamp": "2025-12-08T10:30:00Z"
}
```

#### Validation Errors

```csharp
// Data Annotation validation (automatic)
[Required(ErrorMessage = "Name is required")]
[StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be 3-100 characters")]
public string Name { get; set; } = string.Empty;

// Manual ModelState check in controllers
if (!ModelState.IsValid)
    return BadRequest(ModelState);

// Business logic validation in services
if (await _repository.ExistsAsync(name, accountId, null))
{
    throw new ApiException(
        _localization.Get(MessageKeys.DuplicateRecord),
        400
    );
}
```

### Frontend Error Handling

#### API Interceptor Pattern

Located in `src/interceptors/api.interceptor.ts`:

```typescript
// Handles all API errors automatically
// - 401 Unauthorized → Redirects to login
// - 403 Forbidden → Shows forbidden page
// - 500 Server Error → Shows error page
// - Other errors → Shows toast notification
```

#### Component Error Handling

```typescript
try {
  await calendarHolidayService.create(data);
  toast.success(t("calendarHoliday.createSuccess"));
  await loadData();
} catch (error: any) {
  // Error is automatically handled by interceptor
  // You can add specific handling if needed
  console.error("Create failed:", error);
}
```

#### Form Validation with Yup

```typescript
import * as Yup from "yup";

const validationSchema = Yup.object().shape({
  holidayName: Yup.string()
    .required(t("calendarHoliday.validation.nameRequired"))
    .min(3, t("calendarHoliday.validation.nameMinLength")),
  startDate: Yup.date()
    .required(t("calendarHoliday.validation.startDateRequired"))
    .nullable(),
  endDate: Yup.date()
    .required(t("calendarHoliday.validation.endDateRequired"))
    .min(
      Yup.ref("startDate"),
      t("calendarHoliday.validation.endDateAfterStart")
    )
    .nullable(),
});
```

---

## 🎨 FRONTEND COMPONENT PATTERNS

### Reusable Components Available

Located in `src/shared/components/`:

- **Button** - Styled button with variants (primary, secondary, danger)
- **Dialog** - Sidebar modal for forms
- **ConfirmDialog** - Confirmation modal (RTL/LTR support)
- **PageHeader** - Page title with breadcrumbs
- **DateInput** - Date picker component
- **TextArea** - Multi-line text input
- **FileUpload** - File upload with drag & drop
- **TableSkeleton** - Loading skeleton for tables
- **Skeleton** - Generic loading skeleton

### Component Usage Examples

#### ConfirmDialog

```typescript
import ConfirmDialog from "@/shared/components/ConfirmDialog";

const [showDeleteDialog, setShowDeleteDialog] = useState(false);

<ConfirmDialog
  isOpen={showDeleteDialog}
  onClose={() => setShowDeleteDialog(false)}
  onConfirm={handleDelete}
  title={t("common.confirmDelete")}
  message={t("calendarHoliday.deleteConfirmMessage")}
  confirmText={t("common.delete")}
  cancelText={t("common.cancel")}
  type="danger"
/>;
```

#### TableSkeleton

```typescript
import TableSkeleton from "@/shared/components/TableSkeleton";

{
  loading ? (
    <TableSkeleton columns={5} rows={10} />
  ) : (
    <table>{/* Your table content */}</table>
  );
}
```

#### Date Formatting Utility

```typescript
import { formatDate } from "@/utils/date.utilts";

// Format as dd-MM-yyyy
const formatted = formatDate(new Date(), "dd-MM-yyyy");

// Format as MM/dd/yyyy
const formatted2 = formatDate(dateString, "MM/dd/yyyy");
```

### CRUD Page Pattern

Standard pattern for list/create/edit/delete pages:

```typescript
function FeaturePage() {
  const { t } = useTranslation();
  const [items, setItems] = useState([]);
  const [loading, setLoading] = useState(true);
  const [showDialog, setShowDialog] = useState(false);
  const [editingItem, setEditingItem] = useState(null);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [deletingId, setDeletingId] = useState(null);

  // Load data
  const loadData = async () => {
    setLoading(true);
    try {
      const data = await featureService.getAll();
      setItems(data);
    } catch (error) {
      console.error("Load failed:", error);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadData();
  }, []);

  // Create/Update
  const handleSubmit = async (formData) => {
    try {
      if (editingItem) {
        await featureService.update(editingItem.id, formData);
        toast.success(t("feature.updateSuccess"));
      } else {
        await featureService.create(formData);
        toast.success(t("feature.createSuccess"));
      }
      setShowDialog(false);
      setEditingItem(null);
      await loadData();
    } catch (error) {
      console.error("Submit failed:", error);
    }
  };

  // Delete
  const handleDelete = async () => {
    try {
      await featureService.delete(deletingId);
      toast.success(t("feature.deleteSuccess"));
      setShowDeleteDialog(false);
      setDeletingId(null);
      await loadData();
    } catch (error) {
      console.error("Delete failed:", error);
    }
  };

  // Return JSX with table, dialogs, etc.
}
```

---

## 📋 QUICK REFERENCE

### Essential Commands

```bash
# Backend
cd d:/ORM/Backend_ORM/ORM_API
dotnet run                              # Run API
dotnet build                            # Build solution
dotnet test                             # Run all tests
dotnet test --verbosity detailed        # Run tests with details
dotnet test ORM.Application.Tests       # Run specific test project
dotnet add package [PackageName]        # Add NuGet package
dotnet restore                          # Restore dependencies

# Frontend
cd d:/ORM/FRONTEND_ORM/ORM-frontend
npm install                             # Install dependencies
npm run dev                             # Run dev server
npm run build                           # Build for production
npm run lint                            # Run linter

# Git
git status                              # Check status
git add .                               # Stage all changes
git commit -m "message"                 # Commit changes
git push                                # Push to remote
```

### Project Structure Quick Reference

```
Backend_ORM/
├── ORM_API/                          # API Layer (Controllers)
│   ├── Controllers/                  # API endpoints
│   │   └── [Feature]Controller.cs    # Inherit from BaseController
│   └── Program.cs                    # DI registration, middleware
│
├── ORM.Application/                  # Business Logic Layer
│   ├── Services/                     # Business logic implementations
│   │   └── [Feature]Service.cs      # Service implementations
│   └── Common/
│       ├── Exceptions/               # Custom exceptions
│       ├── Localization/             # Multi-language support
│       │   ├── LocalizationService.cs
│       │   └── Messages.cs           # Message key constants
│       └── Helpers/                  # Utilities (Encryption, Password)
│
├── ORM.Core/                         # Interfaces & DTOs
│   ├── DTOs/                         # Data Transfer Objects
│   │   └── [Feature]/
│   │       ├── [Action]RequestDto.cs
│   │       └── [Action]ResponseDto.cs
│   └── Interfaces/
│       ├── Services/                 # Service interfaces
│       │   └── I[Feature]Service.cs
│       └── Repositories/             # Repository interfaces
│           └── I[Feature]Repository.cs
│
├── ORM.Domain/                       # Domain Entities
│   └── Entities/                     # Database entities
│       └── [Entity].cs
│
├── ORM.Infrastructure/               # Data Access Layer
│   ├── Data/
│   │   └── ORMContext.cs            # EF Core DbContext
│   ├── Repositories/                 # Data access implementations
│   │   └── [Feature]Repository.cs
│   └── Middleware/                   # Custom middleware
│
├── ORM.Application.Tests/            # Service Unit Tests
│   └── Services/
│       └── [Feature]ServiceTests.cs  # 8-12 tests minimum
│
├── ORM_API.Tests/                    # Controller Unit Tests
│   └── Controllers/
│       └── [Feature]ControllerTests.cs # 12-17 tests minimum
│
└── ORM.Infrastructure.Tests/         # Repository Integration Tests
    └── Repositories/
        └── [Feature]RepositoryTests.cs # 20-27 tests minimum

FRONTEND_ORM/
└── ORM-frontend/
    ├── src/
    │   ├── components/               # Shared components
    │   │   └── ConfirmDialog.tsx     # Reusable components
    │   ├── pages/                    # Page components
    │   │   └── admin/
    │   │       └── [Feature].tsx     # Feature pages
    │   ├── services/                 # API clients
    │   │   └── admin/
    │   │       └── [feature].service.ts
    │   ├── types/                    # TypeScript interfaces
    │   │   └── admin/
    │   │       └── [feature].types.ts
    │   ├── locales/                  # Translations
    │   │   ├── en.json               # English
    │   │   ├── ar-1.json             # Arabic (Standard)
    │   │   └── ar-2.json             # Arabic (Alternative)
    │   ├── utils/                    # Utility functions
    │   │   ├── date.utilts.ts        # Date formatting
    │   │   ├── file.utils.ts         # File handling
    │   │   └── storage.utils.ts      # Local storage
    │   ├── shared/                   # Shared resources
    │   │   ├── components/           # Reusable UI components
    │   │   ├── lib/                  # Third-party configs
    │   │   └── utils/                # Shared utilities
    │   └── interceptors/             # HTTP interceptors
    │       └── api.interceptor.ts    # Global error handling
    └── package.json
```

### File Naming Conventions

| Type                      | Pattern                          | Example                             | Location                                 |
| ------------------------- | -------------------------------- | ----------------------------------- | ---------------------------------------- |
| DTO (Request)             | `[Feature][Action]RequestDto.cs` | `CreateUserRequestDto.cs`           | `ORM.Core/DTOs/[Feature]/`               |
| DTO (Response)            | `[Feature]ResponseDto.cs`        | `UserResponseDto.cs`                | `ORM.Core/DTOs/[Feature]/`               |
| Service Interface         | `I[Feature]Service.cs`           | `ICalendarHolidayService.cs`        | `ORM.Core/Interfaces/Services/`          |
| Service Implementation    | `[Feature]Service.cs`            | `CalendarHolidayService.cs`         | `ORM.Application/Services/`              |
| Repository Interface      | `I[Feature]Repository.cs`        | `ICalendarHolidayRepository.cs`     | `ORM.Core/Interfaces/Repositories/`      |
| Repository Implementation | `[Feature]Repository.cs`         | `CalendarHolidayRepository.cs`      | `ORM.Infrastructure/Repositories/`       |
| Controller                | `[Feature]Controller.cs`         | `CalendarHolidayController.cs`      | `ORM_API/Controllers/`                   |
| Entity                    | `[EntityName].cs`                | `CalendarHoliday.cs`                | `ORM.Domain/Entities/`                   |
| Service Tests             | `[Feature]ServiceTests.cs`       | `CalendarHolidayServiceTests.cs`    | `ORM.Application.Tests/Services/`        |
| Controller Tests          | `[Feature]ControllerTests.cs`    | `CalendarHolidayControllerTests.cs` | `ORM_API.Tests/Controllers/`             |
| Repository Tests          | `[Feature]RepositoryTests.cs`    | `CalendarHolidayRepositoryTests.cs` | `ORM.Infrastructure.Tests/Repositories/` |

### Common Code Snippets

#### Service Constructor Pattern

```csharp
private readonly I[Feature]Repository _repository;
private readonly ILocalizationService _localization;
private readonly ICurrentUserService _currentUser;
private readonly IActivityLogService _activityLog;

public [Feature]Service(
    I[Feature]Repository repository,
    ILocalizationService localization,
    ICurrentUserService currentUser,
    IActivityLogService activityLog)
{
    _repository = repository;
    _localization = localization;
    _currentUser = currentUser;
    _activityLog = activityLog;
}
```

#### Repository Constructor Pattern

```csharp
private readonly ORMContext _context;

public [Feature]Repository(ORMContext context)
{
    _context = context;
}
```

#### Controller Constructor Pattern

```csharp
private readonly I[Feature]Service _service;
private readonly ILocalizationService _localization;

public [Feature]Controller(
    I[Feature]Service service,
    ILocalizationService localization)
{
    _service = service;
    _localization = localization;
}
```

#### Test Class Constructor Pattern

```csharp
// Service Tests
private readonly Mock<I[Feature]Repository> _mockRepository;
private readonly Mock<ILocalizationService> _mockLocalization;
private readonly [Feature]Service _service;

public [Feature]ServiceTests()
{
    _mockRepository = new Mock<I[Feature]Repository>();
    _mockLocalization = new Mock<ILocalizationService>();
    _mockLocalization.Setup(x => x.Get(It.IsAny<string>())).Returns("Test Message");

    _service = new [Feature]Service(_mockRepository.Object, _mockLocalization.Object);
}

// Repository Tests (Integration)
private readonly ORMContext _context;
private readonly [Feature]Repository _repository;
private readonly string _databaseName;

public [Feature]RepositoryTests()
{
    _databaseName = $"TestDb_{Guid.NewGuid()}";
    var options = new DbContextOptionsBuilder<ORMContext>()
        .UseInMemoryDatabase(databaseName: _databaseName)
        .Options;

    _context = new ORMContext(options);
    _repository = new [Feature]Repository(_context);
}

public void Dispose()
{
    _context.Database.EnsureDeleted();
    _context.Dispose();
}
```

### API Response Status Codes

| Code | Method                 | Meaning      | When to Use                               |
| ---- | ---------------------- | ------------ | ----------------------------------------- |
| 200  | Success()              | OK           | Successful GET, PUT, DELETE               |
| 201  | Created()              | Created      | Successful POST                           |
| 400  | Fail()                 | Bad Request  | Validation errors, business logic errors  |
| 401  | UnauthorizedResponse() | Unauthorized | Missing/invalid JWT token                 |
| 403  | Forbidden()            | Forbidden    | Valid token but insufficient permissions  |
| 404  | NotFoundResponse()     | Not Found    | Resource doesn't exist                    |
| 500  | (Automatic)            | Server Error | Unhandled exceptions (middleware catches) |

### Testing Checklist per Feature

- [ ] **Service Tests (8-12 minimum)**

  - GetAll (with data, empty)
  - GetById (found, not found)
  - Create (success, duplicate, validation error)
  - Update (success, not found, duplicate, validation error)
  - Delete (success, not found)
  - Business logic scenarios

- [ ] **Controller Tests (12-17 minimum)**

  - All HTTP methods (GET, POST, PUT, DELETE)
  - Status codes (200, 201, 400, 404)
  - ModelState validation
  - Success and error responses

- [ ] **Repository Tests (20-27 minimum)**
  - CRUD operations
  - AccountId filtering
  - Duplicate detection (ExistsAsync)
  - Edge cases (null, empty, overlapping data)
  - Ordering and filtering logic

### Environment URLs

| Environment | Backend API            | Frontend              | Swagger                        |
| ----------- | ---------------------- | --------------------- | ------------------------------ |
| Development | https://localhost:7xxx | http://localhost:5173 | https://localhost:7xxx/swagger |
| Production  | (TBD)                  | (TBD)                 | (TBD)                          |

---

## 🎓 LEARNING RESOURCES

### Reference Implementations (Study These!)

**Best Complete Examples:**

1. **CalendarHoliday Feature** - Complete CRUD with all patterns

   - Controller: `CalendarHolidayController.cs`
   - Service: `CalendarHolidayService.cs`
   - Repository: `CalendarHolidayRepository.cs`
   - Tests: All 3 test projects have CalendarHoliday tests (56 total tests)

2. **Auth Feature** - Authentication & authorization
   - Controller: `AuthController.cs`
   - Service: `AuthService.cs`
   - JWT token handling

**Documentation Files:**

- `ACTIVITY_LOGGING_README.md` - Activity logging implementation
- `BUG_FIX_DBCONTEXT_CONCURRENCY.md` - DbContext testing setup
- `CALENDAR_HOLIDAY_IMPLEMENTATION.md` - Frontend implementation guide
- `MENU_VISIBILITY_GUIDE.md` - Frontend menu/routing
- `ERROR_HANDLING.md` - Error handling patterns

### Key Principles Summary

1. **Separation of Concerns**: Each layer has specific responsibility
2. **Dependency Injection**: Use interfaces, inject dependencies
3. **Async/Await**: All I/O operations must be async
4. **Localization First**: Never hardcode user-facing messages
5. **Test Everything**: 3 layers of tests for every feature
6. **Type Safety**: Use DTOs for API boundaries
7. **Multi-Tenancy**: Filter by AccountId everywhere
8. **Security**: Use [Authorize], encrypt sensitive data
9. **Consistency**: Follow naming conventions strictly
10. **Documentation**: XML comments on all public APIs

---

## 🚨 CRITICAL REMINDERS

### Before Writing Any Code:

✅ Read this document completely
✅ Understand the layer structure
✅ Check existing implementations for patterns
✅ Plan your tests alongside your implementation

### Before Committing Code:

✅ All tests pass (`dotnet test`)
✅ No compilation errors/warnings (except connection string warning)
✅ Localization works in EN and AR
✅ Tested in Swagger UI
✅ Tested in frontend UI
✅ All 3 test layers implemented (Service, Controller, Repository)
✅ Code follows naming conventions
✅ Dependencies registered in Program.cs

### Red Flags (Stop and Review):

🚩 Returning `Ok()` directly instead of `Success()`
🚩 Hardcoded strings instead of localization
🚩 Missing AccountId filter in queries
🚩 No tests for new feature
🚩 Synchronous database calls
🚩 Business logic in Controller
🚩 DbContext accessed from Service
🚩 Missing `AsNoTracking()` on read queries
🚩 Sensitive data not encrypted
🚩 No ModelState validation on POST/PUT

---

## 📞 SUPPORT & QUESTIONS

When asking for help or implementing features:

1. **Specify the layer** you're working on (API/Application/Infrastructure/Frontend)
2. **Reference existing examples** similar to what you want to build
3. **Show error messages** completely (don't truncate)
4. **Mention what you've tried** already
5. **Ask specific questions** rather than "how do I build X?"

**Example Good Question:**

> "I'm implementing a new feature similar to CalendarHoliday but for Departments. I've created the DTOs and interfaces. When I try to run the Repository tests, I'm getting a provider conflict error. I saw the fix in BUG_FIX_DBCONTEXT_CONCURRENCY.md but not sure how to apply it."

**Example Bad Question:**

> "Tests not working, help!"

---

**Last Updated:** December 8, 2025
**Version:** 2.0 (With comprehensive testing standards)
**Maintained By:** Development Team

---

_Remember: Code quality is not negotiable. Tests are not optional. Patterns exist for consistency and maintainability. Follow them strictly._
