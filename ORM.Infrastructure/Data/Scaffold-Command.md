# Database Scaffolding Command

## Overview

This document contains the Entity Framework Core scaffolding command used to generate the database entities and context from the existing SQL Server database.

## Database Information

- **Server**: MUSTAFA\MUSTAFA2019SERVE
- **Database**: GRC_SLC_ORM
- **Authentication**: Windows Authentication
- **Connection**: Trusted Connection

## Prerequisites

Before running the scaffold command, ensure you have:

1. Installed the EF Core tools globally:

   ```bash
   dotnet tool install --global dotnet-ef
   ```

2. Added the required NuGet packages to the ORM.Infrastructure project:
   ```bash
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer
   dotnet add package Microsoft.EntityFrameworkCore.Tools
   dotnet add package Microsoft.EntityFrameworkCore.Design
   ```

## Scaffold Command

Run this command from the `ORM.Infrastructure` project directory:

```bash
dotnet ef dbcontext scaffold "Server=MUSTAFA\MUSTAFA2019SERVE;Database=GRC_SLC_ORM;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context-dir Data --context ORMContext --force
```

### Command Parameters Explained:

- **Connection String**: `"Server=MUSTAFA\MUSTAFA2019SERVE;Database=GRC_SLC_ORM;Trusted_Connection=True;TrustServerCertificate=True;"`
- **Provider**: `Microsoft.EntityFrameworkCore.SqlServer`
- **--output-dir Models**: Generates entity classes in the Models folder
- **--context-dir Data**: Generates the DbContext in the Data folder
- **--context ORMContext**: Names the DbContext class as "ORMContext"
- **--force**: Overwrites existing files

## Post-Scaffolding Steps

After running the scaffold command:

1. **Move Entity Files**: Move all entity files from `ORM.Infrastructure/Models` to `ORM.Domain/Entities`

   ```bash
   mv Models/*.cs ../ORM.Domain/Entities/
   rmdir Models
   ```

2. **Update Namespaces**: Change namespace in all entity files from `ORM.Infrastructure.Models` to `ORM.Domain.Entities`

   ```bash
   cd ../ORM.Domain/Entities
   find . -name "*.cs" -type f -exec sed -i 's/namespace ORM.Infrastructure.Models;/namespace ORM.Domain.Entities;/g' {} +
   ```

3. **Update ORMContext**: Update the using statement in `ORM.Infrastructure/Data/ORMContext.cs`:
   - Change: `using ORM.Infrastructure.Models;`
   - To: `using ORM.Domain.Entities;`

## Connection String Security

⚠️ **Important**: The connection string shown above is for development purposes only. For production:

- Store connection strings in `appsettings.json` or environment variables
- Use the `Name=` syntax to reference connection strings from configuration
- Never commit connection strings with sensitive information to source control

Example using configuration:

```bash
dotnet ef dbcontext scaffold "Name=ConnectionStrings:DefaultConnection" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context-dir Data --context ORMContext
```

## Re-scaffolding the Database

If the database schema changes and you need to re-scaffold:

1. Run the same scaffold command with `--force` flag (already included above)
2. Repeat the post-scaffolding steps
3. Review and merge any custom code you may have added to the entities or context

## Notes

- The scaffold command automatically skips duplicate foreign keys
- Entities are generated as partial classes, allowing you to extend them in separate files
- The DbContext is also a partial class for extensibility

---

**Last Updated**: December 1, 2025
**Database**: GRC_SLC_ORM
**Context Name**: ORMContext
