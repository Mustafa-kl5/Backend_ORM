# ORM Backend - Clean Architecture .NET API

## 🚀 Quick Start

### Prerequisites

- .NET 10 SDK
- SQL Server
- Visual Studio 2022 or VS Code

### Running the Application

```bash
# Clone and navigate to project
cd d:/ORM/Backend_ORM/ORM_API

# Restore dependencies
dotnet restore

# Run the API
dotnet run

# API will be available at:
# - https://localhost:7xxx/swagger (Swagger UI)
# - https://localhost:7xxx (API endpoint)
```

### Running Tests

```bash
# Run all tests
cd d:/ORM/Backend_ORM
dotnet test

# Run specific test project
dotnet test ORM.Application.Tests
dotnet test ORM_API.Tests
dotnet test ORM.Infrastructure.Tests

# Run with detailed output
dotnet test --verbosity detailed
```

## 📚 Architecture

This project follows **Clean Architecture** principles with clear separation of concerns:

```
ORM_API              → Presentation Layer (Controllers, API endpoints)
ORM.Application      → Business Logic Layer (Services)
ORM.Core             → Contracts Layer (DTOs, Interfaces)
ORM.Domain           → Domain Layer (Entities)
ORM.Infrastructure   → Data Access Layer (Repositories, DbContext)
```

### Test Projects

```
ORM.Application.Tests      → Service unit tests (mocked dependencies)
ORM_API.Tests              → Controller unit tests (mocked services)
ORM.Infrastructure.Tests   → Repository integration tests (InMemory database)
```

## 🎯 Development Guidelines

**CRITICAL:** All development must follow the established patterns documented in:

📖 **[.github/copilot-instructions.md](.github/copilot-instructions.md)**

This comprehensive guide covers:

- ✅ Complete feature implementation checklist (7 phases)
- ✅ Testing standards (mandatory for all features)
- ✅ Code patterns for all layers
- ✅ Localization & multi-language support
- ✅ Error handling & validation
- ✅ Common workflows
- ✅ Quick reference guide

### Key Principles

1. **Layer Separation**: Never skip layers or mix responsibilities
2. **Testing is Mandatory**: All features need 3 layers of tests (Service, Controller, Repository)
3. **Async/Await**: All I/O operations must be async
4. **Localization First**: Use `ILocalizationService` for all user messages
5. **Multi-Tenancy**: Filter by `AccountId` in all queries
6. **BaseController**: All controllers inherit from `BaseController`
7. **Dependency Injection**: Use interfaces, inject dependencies

## 📋 Adding a New Feature

Follow this 7-phase checklist (see [copilot-instructions.md](.github/copilot-instructions.md) for details):

### Phase 1: Core Layer

- [ ] Create DTOs in `ORM.Core/DTOs/[Feature]/`
- [ ] Create interfaces in `ORM.Core/Interfaces/`

### Phase 2: Infrastructure Layer

- [ ] Implement repository in `ORM.Infrastructure/Repositories/`

### Phase 3: Application Layer

- [ ] Implement service in `ORM.Application/Services/`
- [ ] Use localization for all messages

### Phase 4: Presentation Layer

- [ ] Create controller in `ORM_API/Controllers/`
- [ ] Inherit from `BaseController`

### Phase 5: Dependency Registration

- [ ] Register in `Program.cs`

### Phase 6: Testing (MANDATORY)

- [ ] Service tests (8-12 minimum)
- [ ] Controller tests (12-17 minimum)
- [ ] Repository tests (20-27 minimum)
- [ ] All tests must pass ✅

### Phase 7: Validation

- [ ] Test in Swagger UI
- [ ] Verify localization (EN/AR)
- [ ] Run `dotnet test` - all pass

## 🧪 Testing Standards

### Minimum Test Counts

- **Service Layer**: 8-12 unit tests
- **Controller Layer**: 12-17 unit tests
- **Repository Layer**: 20-27 integration tests

### Test Stack

- **xUnit** - Test framework
- **Moq** - Mocking library
- **FluentAssertions** - Assertion library
- **InMemory Database** - For integration tests

### Running Tests

```bash
# All tests must pass before committing
dotnet test

# Current test status:
# ✅ ORM.Application.Tests: 12/12 passing
# ✅ ORM.Infrastructure.Tests: 27/27 passing
# ⏳ ORM_API.Tests: 17 tests created
```

## 🌍 Localization

Supports **English** and **Arabic** (AR-1, AR-2):

```csharp
// In services/controllers
private readonly ILocalizationService _localization;

// Usage
_localization.Get(MessageKeys.RecordCreatedSuccessfully)
```

Message keys defined in: `ORM.Application/Common/Localization/Messages.cs`

## 📦 Project Structure

```
Backend_ORM/
├── .github/
│   ├── copilot-instructions.md           ⭐ READ THIS FIRST
│   └── COPILOT_INSTRUCTIONS_SUMMARY.md
├── ORM_API/
│   ├── Controllers/                      [API endpoints]
│   ├── Program.cs                        [DI registration]
│   └── appsettings.json
├── ORM.Application/
│   ├── Services/                         [Business logic]
│   └── Common/
│       ├── Localization/                 [Multi-language]
│       ├── Helpers/                      [Utilities]
│       └── Exceptions/                   [Custom exceptions]
├── ORM.Core/
│   ├── DTOs/                             [Data transfer objects]
│   └── Interfaces/                       [Contracts]
├── ORM.Domain/
│   └── Entities/                         [Database models]
├── ORM.Infrastructure/
│   ├── Data/
│   │   └── ORMContext.cs                [EF Core DbContext]
│   └── Repositories/                     [Data access]
├── ORM.Application.Tests/               [Service unit tests]
├── ORM_API.Tests/                       [Controller unit tests]
└── ORM.Infrastructure.Tests/            [Repository integration tests]
```

## 🔑 Reference Implementations

Study these for complete examples:

### Best Examples

1. **CalendarHoliday** - Complete CRUD feature

   - Controller: `CalendarHolidayController.cs`
   - Service: `CalendarHolidayService.cs`
   - Repository: `CalendarHolidayRepository.cs`
   - Tests: 56 total tests across all 3 layers

2. **Auth** - Authentication & authorization
   - Controller: `AuthController.cs`
   - Service: `AuthService.cs`

## 📖 Documentation

- **[copilot-instructions.md](.github/copilot-instructions.md)** - Complete development guide ⭐
- **[COPILOT_INSTRUCTIONS_SUMMARY.md](.github/COPILOT_INSTRUCTIONS_SUMMARY.md)** - What's in the guide
- **[ACTIVITY_LOGGING_README.md](ACTIVITY_LOGGING_README.md)** - Activity logging implementation
- **[BUG_FIX_DBCONTEXT_CONCURRENCY.md](../BUG_FIX_DBCONTEXT_CONCURRENCY.md)** - DbContext testing setup

## ⚠️ Critical Rules

**DON'T:**

- ❌ Skip tests (mandatory for all features)
- ❌ Access DbContext from Services
- ❌ Put business logic in Controllers
- ❌ Use `return Ok()` directly (use BaseController methods)
- ❌ Hardcode messages (use localization)
- ❌ Forget AccountId filtering
- ❌ Use synchronous database operations

**DO:**

- ✅ Follow the 7-phase checklist
- ✅ Write tests for all 3 layers
- ✅ Use async/await for I/O
- ✅ Use localization for messages
- ✅ Inherit from BaseController
- ✅ Register services in Program.cs
- ✅ Filter by AccountId
- ✅ Use AsNoTracking() for reads

## 🛠️ Common Commands

```bash
# Build
dotnet build

# Run API
dotnet run --project ORM_API

# Run tests
dotnet test
dotnet test --verbosity detailed
dotnet test ORM.Application.Tests

# Add package
dotnet add package [PackageName]

# Restore dependencies
dotnet restore
```

## 🌐 API Endpoints

Once running, access:

- **Swagger UI**: https://localhost:7xxx/swagger
- **API Base**: https://localhost:7xxx/api

## 🔐 Security

- JWT token-based authentication
- Multi-tenant data isolation (AccountId)
- Encrypted sensitive fields
- Password hashing with BCrypt
- Role-based authorization

## 🐛 Troubleshooting

### Tests Failing

- Check DbContext configuration in `ORMContext.OnConfiguring`
- Ensure `if (!optionsBuilder.IsConfigured)` check exists
- Verify all dependencies are restored: `dotnet restore`

### API Not Starting

- Check SQL Server connection string in `appsettings.json`
- Ensure database exists
- Check port conflicts

### Localization Not Working

- Verify message key exists in `Messages.cs`
- Check translations in `LocalizationService.cs`
- Confirm `ILocalizationService` is injected

## 📞 Getting Help

1. Read the [copilot-instructions.md](.github/copilot-instructions.md)
2. Check reference implementations (CalendarHoliday, Auth)
3. Review existing tests for patterns
4. Ask specific questions with context

## 🎯 Quality Standards

Before committing code:

- [ ] All tests pass (`dotnet test`)
- [ ] No build errors/warnings
- [ ] Localization works in EN & AR
- [ ] Tested in Swagger UI
- [ ] Follows naming conventions
- [ ] All dependencies registered
- [ ] Code reviewed against copilot-instructions.md

---

**Version:** 2.0  
**Last Updated:** December 8, 2025  
**Framework:** .NET 10  
**Architecture:** Clean Architecture

For detailed implementation guidelines, see **[.github/copilot-instructions.md](.github/copilot-instructions.md)**
