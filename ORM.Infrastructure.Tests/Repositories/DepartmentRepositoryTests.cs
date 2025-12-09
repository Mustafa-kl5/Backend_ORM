using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ORM.Domain.Entities;
using ORM.Infrastructure.Data;
using ORM.Infrastructure.Repositories;
using Xunit;

namespace ORM.Infrastructure.Tests.Repositories;

/// <summary>
/// Integration tests for DepartmentRepository
/// Tests actual database operations using in-memory database
/// </summary>
public class DepartmentRepositoryTests : IDisposable
{
    private readonly ORMContext _context;
    private readonly DepartmentRepository _repository;

    public DepartmentRepositoryTests()
    {
        // Setup in-memory database with unique name for each test run
        var options = new DbContextOptionsBuilder<ORMContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new ORMContext(options);
        _repository = new DepartmentRepository(_context);
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }

    #region Helper Methods

    private GrcDepartment CreateTestDepartment(
        int departmentId,
        int accountId,
        string name = "Test Department",
        string email = "test@example.com",
        int? countryId = null,
        int? sectorId = null)
    {
        return new GrcDepartment
        {
            DepartmentId = departmentId,
            AccountId = accountId,
            DepartmentName = name,
            DepartmentEmail1 = email,
            DepartmentEmail2 = null,
            DepartmentCode = $"DEPT{departmentId:000}",
            CountryId = countryId,
            SectorId = sectorId,
            CreatedBy = 1,
            CreationDate = DateTime.UtcNow
        };
    }

    #endregion

    #region GetAllAsync Tests

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllDepartmentsForAccount()
    {
        // Arrange
        var accountId = 1;
        var departments = new List<GrcDepartment>
        {
            CreateTestDepartment(1, accountId, "Department 1", "dept1@example.com"),
            CreateTestDepartment(2, accountId, "Department 2", "dept2@example.com"),
            CreateTestDepartment(3, accountId, "Department 3", "dept3@example.com")
        };

        await _context.GrcDepartments.AddRangeAsync(departments);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetAllAsync(accountId);

        // Assert
        result.Should().HaveCount(3);
        result.Should().Contain(d => d.DepartmentName == "Department 1");
        result.Should().Contain(d => d.DepartmentName == "Department 2");
        result.Should().Contain(d => d.DepartmentName == "Department 3");
    }

    [Fact]
    public async Task GetAllAsync_ShouldFilterByAccountId()
    {
        // Arrange
        var account1 = 1;
        var account2 = 2;
        
        await _context.GrcDepartments.AddRangeAsync(new[]
        {
            CreateTestDepartment(1, account1, "Account 1 Department", "acc1@example.com"),
            CreateTestDepartment(2, account2, "Account 2 Department", "acc2@example.com")
        });
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetAllAsync(account1);

        // Assert
        result.Should().HaveCount(1);
        result.Should().AllSatisfy(d => d.AccountId.Should().Be(account1));
    }

    [Fact]
    public async Task GetAllAsync_WhenEmpty_ShouldReturnEmptyList()
    {
        // Act
        var result = await _repository.GetAllAsync(1);

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetAllAsync_ShouldOrderByDepartmentName()
    {
        // Arrange
        var accountId = 1;
        var departments = new List<GrcDepartment>
        {
            CreateTestDepartment(1, accountId, "Zebra Department", "z@example.com"),
            CreateTestDepartment(2, accountId, "Alpha Department", "a@example.com"),
            CreateTestDepartment(3, accountId, "Mike Department", "m@example.com")
        };

        await _context.GrcDepartments.AddRangeAsync(departments);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetAllAsync(accountId);

        // Assert
        result[0].DepartmentName.Should().Be("Alpha Department");
        result[1].DepartmentName.Should().Be("Mike Department");
        result[2].DepartmentName.Should().Be("Zebra Department");
    }

    #endregion

    #region GetByIdAsync Tests

    [Fact]
    public async Task GetByIdAsync_WithValidId_ShouldReturnDepartment()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1, "Test Department", "test@example.com");
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        // Detach to simulate fresh read
        _context.Entry(department).State = EntityState.Detached;

        // Act
        var result = await _repository.GetByIdAsync(1, 1);

        // Assert
        result.Should().NotBeNull();
        result!.DepartmentId.Should().Be(1);
        result.DepartmentName.Should().Be("Test Department");
    }

    [Fact]
    public async Task GetByIdAsync_WithInvalidId_ShouldReturnNull()
    {
        // Act
        var result = await _repository.GetByIdAsync(999, 1);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetByIdAsync_WithDifferentAccountId_ShouldReturnNull()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1);
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetByIdAsync(1, 999);

        // Assert
        result.Should().BeNull();
    }

    #endregion

    #region GetByCountryAsync Tests

    [Fact]
    public async Task GetByCountryAsync_ShouldReturnDepartmentsForCountry()
    {
        // Arrange
        var accountId = 1;
        var countryId = 1;
        var departments = new List<GrcDepartment>
        {
            CreateTestDepartment(1, accountId, "Dept 1", "d1@example.com", countryId: countryId),
            CreateTestDepartment(2, accountId, "Dept 2", "d2@example.com", countryId: countryId),
            CreateTestDepartment(3, accountId, "Dept 3", "d3@example.com", countryId: 2)
        };

        await _context.GrcDepartments.AddRangeAsync(departments);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetByCountryAsync(countryId, accountId);

        // Assert
        result.Should().HaveCount(2);
        result.Should().AllSatisfy(d => d.CountryId.Should().Be(countryId));
    }

    [Fact]
    public async Task GetByCountryAsync_WithNoMatches_ShouldReturnEmptyList()
    {
        // Act
        var result = await _repository.GetByCountryAsync(999, 1);

        // Assert
        result.Should().BeEmpty();
    }

    #endregion

    #region GetBySectorAsync Tests

    [Fact]
    public async Task GetBySectorAsync_ShouldReturnDepartmentsForSector()
    {
        // Arrange
        var accountId = 1;
        var sectorId = 1;
        var departments = new List<GrcDepartment>
        {
            CreateTestDepartment(1, accountId, "Dept 1", "d1@example.com", sectorId: sectorId),
            CreateTestDepartment(2, accountId, "Dept 2", "d2@example.com", sectorId: sectorId),
            CreateTestDepartment(3, accountId, "Dept 3", "d3@example.com", sectorId: 2)
        };

        await _context.GrcDepartments.AddRangeAsync(departments);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetBySectorAsync(sectorId, accountId);

        // Assert
        result.Should().HaveCount(2);
        result.Should().AllSatisfy(d => d.SectorId.Should().Be(sectorId));
    }

    #endregion

    #region CreateAsync Tests

    [Fact]
    public async Task CreateAsync_ShouldAddDepartmentToDatabase()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1, "New Department", "new@example.com");

        // Act
        var result = await _repository.CreateAsync(department);

        // Assert
        result.Should().NotBeNull();
        result.DepartmentId.Should().Be(1);
        
        var saved = await _context.GrcDepartments.FindAsync(1);
        saved.Should().NotBeNull();
        saved!.DepartmentName.Should().Be("New Department");
    }

    [Fact]
    public async Task CreateAsync_ShouldSetCreationProperties()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1);
        department.CreatedBy = 5;
        department.CreationDate = DateTime.UtcNow;

        // Act
        await _repository.CreateAsync(department);

        // Assert
        var saved = await _context.GrcDepartments.FindAsync(1);
        saved!.CreatedBy.Should().Be(5);
        saved.CreationDate.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
    }

    #endregion

    #region UpdateAsync Tests

    [Fact]
    public async Task UpdateAsync_ShouldModifyExistingDepartment()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1, "Original Name", "original@example.com");
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        _context.Entry(department).State = EntityState.Detached;

        department.DepartmentName = "Updated Name";
        department.DepartmentEmail1 = "updated@example.com";
        department.LastUpdatedBy = 2;
        department.LastUpdateDate = DateTime.UtcNow;

        // Act
        var result = await _repository.UpdateAsync(department);

        // Assert
        result.DepartmentName.Should().Be("Updated Name");
        result.DepartmentEmail1.Should().Be("updated@example.com");
        
        var saved = await _context.GrcDepartments.FindAsync(1);
        saved!.DepartmentName.Should().Be("Updated Name");
        saved.LastUpdatedBy.Should().Be(2);
    }

    #endregion

    #region DeleteAsync Tests

    [Fact]
    public async Task DeleteAsync_WithValidId_ShouldRemoveDepartment()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1);
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.DeleteAsync(1, 1);

        // Assert
        result.Should().BeTrue();
        
        var deleted = await _context.GrcDepartments.FindAsync(1);
        deleted.Should().BeNull();
    }

    [Fact]
    public async Task DeleteAsync_WithInvalidId_ShouldReturnFalse()
    {
        // Act
        var result = await _repository.DeleteAsync(999, 1);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task DeleteAsync_WithDifferentAccountId_ShouldReturnFalse()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1);
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.DeleteAsync(1, 999);

        // Assert
        result.Should().BeFalse();
        
        // Verify department still exists
        var stillExists = await _context.GrcDepartments.FindAsync(1);
        stillExists.Should().NotBeNull();
    }

    #endregion

    #region ExistsAsync Tests

    [Fact]
    public async Task ExistsAsync_WithDuplicateName_ShouldReturnTrue()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1, "Test Department", "test@example.com");
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.ExistsAsync("Test Department", 1);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task ExistsAsync_WithUniqueName_ShouldReturnFalse()
    {
        // Act
        var result = await _repository.ExistsAsync("Unique Department", 1);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task ExistsAsync_ShouldBeCaseInsensitive()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1, "Test Department", "test@example.com");
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.ExistsAsync("test department", 1);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task ExistsAsync_ShouldIgnoreWhitespace()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1, "Test Department", "test@example.com");
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.ExistsAsync("  Test Department  ", 1);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task ExistsAsync_WithExcludedId_ShouldIgnoreThatDepartment()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1, "Test Department", "test@example.com");
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.ExistsAsync("Test Department", 1, excludeDepartmentId: 1);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task ExistsAsync_ShouldFilterByAccountId()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1, "Test Department", "test@example.com");
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.ExistsAsync("Test Department", 999);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task ExistsAsync_WithNameAndCode_ShouldReturnTrue_WhenBothMatch()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1, "Test Department", "test@example.com");
        department.DepartmentCode = "TEST001";
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.ExistsAsync("Test Department", "TEST001", 1);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task ExistsAsync_WithNameAndCode_ShouldReturnFalse_WhenNameMatchesButCodeDifferent()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1, "Test Department", "test@example.com");
        department.DepartmentCode = "TEST001";
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.ExistsAsync("Test Department", "TEST002", 1);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task ExistsAsync_WithNameAndCode_ShouldReturnFalse_WhenCodeMatchesButNameDifferent()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1, "Test Department", "test@example.com");
        department.DepartmentCode = "TEST001";
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.ExistsAsync("Different Department", "TEST001", 1);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task ExistsAsync_WithNameAndCode_ShouldBeCaseInsensitive()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1, "Test Department", "test@example.com");
        department.DepartmentCode = "TEST001";
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.ExistsAsync("test department", "test001", 1);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task ExistsAsync_WithNameAndCode_ShouldIgnoreWhitespace()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1, "Test Department", "test@example.com");
        department.DepartmentCode = "TEST001";
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.ExistsAsync("  Test Department  ", "  TEST001  ", 1);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task ExistsAsync_WithNameAndCode_ShouldExcludeSpecifiedId()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1, "Test Department", "test@example.com");
        department.DepartmentCode = "TEST001";
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.ExistsAsync("Test Department", "TEST001", 1, excludeDepartmentId: 1);

        // Assert
        result.Should().BeFalse();
    }

    #endregion

    #region CodeExistsAsync Tests

    [Fact]
    public async Task CodeExistsAsync_WithDuplicateCode_ShouldReturnTrue()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1, "Test Department", "test@example.com");
        department.DepartmentCode = "TEST001";
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.CodeExistsAsync("TEST001", 1);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task CodeExistsAsync_WithUniqueCode_ShouldReturnFalse()
    {
        // Act
        var result = await _repository.CodeExistsAsync("UNIQUE001", 1);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task CodeExistsAsync_ShouldBeCaseInsensitive()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1, "Test Department", "test@example.com");
        department.DepartmentCode = "TEST001";
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.CodeExistsAsync("test001", 1);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task CodeExistsAsync_ShouldIgnoreWhitespace()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1, "Test Department", "test@example.com");
        department.DepartmentCode = "TEST001";
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.CodeExistsAsync("  TEST001  ", 1);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task CodeExistsAsync_ShouldExcludeSpecifiedId()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1, "Test Department", "test@example.com");
        department.DepartmentCode = "TEST001";
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.CodeExistsAsync("TEST001", 1, excludeDepartmentId: 1);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task CodeExistsAsync_ShouldFilterByAccountId()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1, "Test Department", "test@example.com");
        department.DepartmentCode = "TEST001";
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.CodeExistsAsync("TEST001", 999);

        // Assert
        result.Should().BeFalse();
    }

    #endregion

    #region EmailExistsAsync Tests

    [Fact]
    public async Task EmailExistsAsync_WithDuplicateEmail1_ShouldReturnTrue()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1, "Dept 1", "test@example.com");
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.EmailExistsAsync("test@example.com", 1);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task EmailExistsAsync_WithDuplicateEmail2_ShouldReturnTrue()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1, "Dept 1", "primary@example.com");
        department.DepartmentEmail2 = "secondary@example.com";
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.EmailExistsAsync("secondary@example.com", 1);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task EmailExistsAsync_WithUniqueEmail_ShouldReturnFalse()
    {
        // Act
        var result = await _repository.EmailExistsAsync("unique@example.com", 1);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task EmailExistsAsync_ShouldBeCaseInsensitive()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1, "Dept 1", "Test@Example.com");
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.EmailExistsAsync("test@example.com", 1);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task EmailExistsAsync_WithExcludedId_ShouldIgnoreThatDepartment()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1, "Dept 1", "test@example.com");
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.EmailExistsAsync("test@example.com", 1, excludeDepartmentId: 1);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task EmailExistsAsync_ShouldFilterByAccountId()
    {
        // Arrange
        var department = CreateTestDepartment(1, 1, "Dept 1", "test@example.com");
        await _context.GrcDepartments.AddAsync(department);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.EmailExistsAsync("test@example.com", 999);

        // Assert
        result.Should().BeFalse();
    }

    #endregion
}
