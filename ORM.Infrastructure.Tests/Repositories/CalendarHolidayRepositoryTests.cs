using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ORM.Domain.Entities;
using ORM.Infrastructure.Data;
using ORM.Infrastructure.Repositories;
using Xunit;

namespace ORM.Infrastructure.Tests.Repositories;

/// <summary>
/// Integration tests for CalendarHolidayRepository
/// Tests actual database operations using in-memory database
/// </summary>
public class CalendarHolidayRepositoryTests : IDisposable
{
    private readonly ORMContext _context;
    private readonly CalendarHolidayRepository _repository;

    public CalendarHolidayRepositoryTests()
    {
        // Setup in-memory database with unique name for each test run
        var options = new DbContextOptionsBuilder<ORMContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new ORMContext(options);
        _repository = new CalendarHolidayRepository(_context);
    }

    #region Helper Methods

    private GrcCalendarHoliday CreateTestHoliday(
        int holidayId,
        int accountId,
        string description = "Test Holiday",
        DateTime? holidayStart = null,
        DateTime? holidayEnd = null,
        int? countryId = null)
    {
        var start = holidayStart ?? DateTime.Now;
        var end = holidayEnd ?? DateTime.Now.AddDays(1);
        
        return new GrcCalendarHoliday
        {
            HolidayId = holidayId,
            AccountId = accountId,
            Description = description,
            HolidayStart = start,
            HolidayEnd = end,
            HolidayDays = (int)(end - start).TotalDays + 1,
            CreatedBy = 1,
            CreationDate = DateTime.UtcNow,
            CountryId = countryId
        };
    }

    #endregion

    #region GetAllAsync Tests

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllHolidaysForAccount()
    {
        // Arrange
        var accountId = 1;
        var holidays = new List<GrcCalendarHoliday>
        {
            CreateTestHoliday(1, accountId, "Holiday 1"),
            CreateTestHoliday(2, accountId, "Holiday 2"),
            CreateTestHoliday(3, accountId, "Holiday 3")
        };

        await _context.GrcCalendarHolidays.AddRangeAsync(holidays);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetAllAsync(accountId);

        // Assert
        result.Should().HaveCount(3);
        result.Should().Contain(h => h.Description == "Holiday 1");
        result.Should().Contain(h => h.Description == "Holiday 2");
        result.Should().Contain(h => h.Description == "Holiday 3");
    }

    [Fact]
    public async Task GetAllAsync_ShouldFilterByAccountId()
    {
        // Arrange
        var account1 = 1;
        var account2 = 2;
        
        await _context.GrcCalendarHolidays.AddRangeAsync(new[]
        {
            CreateTestHoliday(1, account1, "Account 1 Holiday"),
            CreateTestHoliday(2, account2, "Account 2 Holiday")
        });
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetAllAsync(account1);

        // Assert
        result.Should().HaveCount(1);
        result.Should().AllSatisfy(h => h.AccountId.Should().Be(account1));
    }

    [Fact]
    public async Task GetAllAsync_WhenEmpty_ShouldReturnEmptyList()
    {
        // Act
        var result = await _repository.GetAllAsync(1);

        // Assert
        result.Should().BeEmpty();
    }

    #endregion

    #region GetByIdAsync Tests

    [Fact]
    public async Task GetByIdAsync_WithValidId_ShouldReturnHoliday()
    {
        // Arrange
        var holiday = CreateTestHoliday(1, 1, "Test Holiday");
        await _context.GrcCalendarHolidays.AddAsync(holiday);
        await _context.SaveChangesAsync();

        // Detach to simulate fresh read
        _context.Entry(holiday).State = EntityState.Detached;

        // Act
        var result = await _repository.GetByIdAsync(1, 1);

        // Assert
        result.Should().NotBeNull();
        result!.HolidayId.Should().Be(1);
        result.Description.Should().Be("Test Holiday");
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
    public async Task GetByIdAsync_WithWrongAccountId_ShouldReturnNull()
    {
        // Arrange
        var holiday = CreateTestHoliday(1, 1, "Holiday");
        await _context.GrcCalendarHolidays.AddAsync(holiday);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetByIdAsync(1, 999); // Wrong account ID

        // Assert
        result.Should().BeNull();
    }

    #endregion

    #region GetByCountryAsync Tests

    [Fact]
    public async Task GetByCountryAsync_ShouldReturnHolidaysForCountry()
    {
        // Arrange
        var accountId = 1;
        var countryId = 5;
        
        await _context.GrcCalendarHolidays.AddRangeAsync(new[]
        {
            CreateTestHoliday(1, accountId, "Country 5 Holiday 1", countryId: countryId),
            CreateTestHoliday(2, accountId, "Country 5 Holiday 2", countryId: countryId),
            CreateTestHoliday(3, accountId, "Country 10 Holiday", countryId: 10)
        });
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetByCountryAsync(countryId, accountId);

        // Assert
        result.Should().HaveCount(2);
        result.Should().AllSatisfy(h => h.CountryId.Should().Be(countryId));
    }

    #endregion

    #region GetByDateRangeAsync Tests

    [Fact]
    public async Task GetByDateRangeAsync_ShouldReturnHolidaysInRange()
    {
        // Arrange
        var accountId = 1;
        var baseDate = new DateTime(2024, 1, 1);
        
        await _context.GrcCalendarHolidays.AddRangeAsync(new[]
        {
            CreateTestHoliday(1, accountId, "Holiday 1", baseDate, baseDate.AddDays(1)),
            CreateTestHoliday(2, accountId, "Holiday 2", baseDate.AddDays(5), baseDate.AddDays(6)),
            CreateTestHoliday(3, accountId, "Holiday 3", baseDate.AddDays(20), baseDate.AddDays(21)) // Outside range
        });
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetByDateRangeAsync(
            baseDate,
            baseDate.AddDays(10),
            accountId);

        // Assert
        result.Should().HaveCount(2);
        result.Should().Contain(h => h.Description == "Holiday 1");
        result.Should().Contain(h => h.Description == "Holiday 2");
        result.Should().NotContain(h => h.Description == "Holiday 3");
    }

    [Fact]
    public async Task GetByDateRangeAsync_ShouldOrderByStartDate()
    {
        // Arrange
        var accountId = 1;
        var baseDate = new DateTime(2024, 1, 1);
        
        await _context.GrcCalendarHolidays.AddRangeAsync(new[]
        {
            CreateTestHoliday(1, accountId, "Holiday 2", baseDate.AddDays(10), baseDate.AddDays(11)),
            CreateTestHoliday(2, accountId, "Holiday 1", baseDate, baseDate.AddDays(1)),
            CreateTestHoliday(3, accountId, "Holiday 3", baseDate.AddDays(20), baseDate.AddDays(21))
        });
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetByDateRangeAsync(
            baseDate,
            baseDate.AddDays(30),
            accountId);

        // Assert
        result.Should().HaveCount(3);
        result[0].Description.Should().Be("Holiday 1");
        result[1].Description.Should().Be("Holiday 2");
        result[2].Description.Should().Be("Holiday 3");
    }

    #endregion

    #region CreateAsync Tests

    [Fact]
    public async Task CreateAsync_ShouldAddHolidayToDatabase()
    {
        // Arrange
        var holiday = CreateTestHoliday(0, 1, "New Holiday"); // ID 0 will be auto-generated

        // Act
        var result = await _repository.CreateAsync(holiday);

        // Assert
        result.Should().NotBeNull();
        result.HolidayId.Should().BeGreaterThan(0);
        result.Description.Should().Be("New Holiday");
        
        var savedHoliday = await _context.GrcCalendarHolidays.FindAsync(result.HolidayId);
        savedHoliday.Should().NotBeNull();
        savedHoliday!.Description.Should().Be("New Holiday");
    }

    [Fact]
    public async Task CreateAsync_ShouldCalculateHolidayDays()
    {
        // Arrange
        var start = new DateTime(2024, 1, 1);
        var end = new DateTime(2024, 1, 5);
        var holiday = CreateTestHoliday(0, 1, "Multi-day Holiday", start, end);

        // Act
        var result = await _repository.CreateAsync(holiday);

        // Assert
        result.HolidayDays.Should().Be(5);
    }

    #endregion

    #region UpdateAsync Tests

    [Fact]
    public async Task UpdateAsync_ShouldModifyExistingHoliday()
    {
        // Arrange
        var holiday = CreateTestHoliday(1, 1, "Original Description");
        await _context.GrcCalendarHolidays.AddAsync(holiday);
        await _context.SaveChangesAsync();
        
        _context.Entry(holiday).State = EntityState.Detached;

        // Modify
        var updatedHoliday = await _context.GrcCalendarHolidays.FindAsync(1);
        updatedHoliday!.Description = "Updated Description";

        // Act
        var result = await _repository.UpdateAsync(updatedHoliday);

        // Assert
        result.Description.Should().Be("Updated Description");
        
        var savedHoliday = await _context.GrcCalendarHolidays.AsNoTracking().FirstAsync(h => h.HolidayId == 1);
        savedHoliday.Description.Should().Be("Updated Description");
    }

    #endregion

    #region DeleteAsync Tests

    [Fact]
    public async Task DeleteAsync_WithValidId_ShouldRemoveHoliday()
    {
        // Arrange
        var holiday = CreateTestHoliday(1, 1, "To Delete");
        await _context.GrcCalendarHolidays.AddAsync(holiday);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.DeleteAsync(1, 1);

        // Assert
        result.Should().BeTrue();
        
        var deletedHoliday = await _context.GrcCalendarHolidays.FindAsync(1);
        deletedHoliday.Should().BeNull();
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
    public async Task DeleteAsync_WithWrongAccountId_ShouldReturnFalse()
    {
        // Arrange
        var holiday = CreateTestHoliday(1, 1, "Holiday");
        await _context.GrcCalendarHolidays.AddAsync(holiday);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.DeleteAsync(1, 999); // Wrong account

        // Assert
        result.Should().BeFalse();
        
        var stillExists = await _context.GrcCalendarHolidays.FindAsync(1);
        stillExists.Should().NotBeNull();
    }

    #endregion

    #region ExistsAsync Tests

    [Fact]
    public async Task ExistsAsync_WithDuplicateDescriptionAndOverlappingDates_ShouldReturnTrue()
    {
        // Arrange
        var holiday = CreateTestHoliday(1, 1, "Duplicate Holiday", new DateTime(2024, 1, 1), new DateTime(2024, 1, 5));
        await _context.GrcCalendarHolidays.AddAsync(holiday);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.ExistsAsync(
            "Duplicate Holiday",
            new DateTime(2024, 1, 1),
            new DateTime(2024, 1, 5),
            1,
            null);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task ExistsAsync_WithDifferentDescription_ShouldReturnFalse()
    {
        // Arrange
        var holiday = CreateTestHoliday(1, 1, "Holiday A", new DateTime(2024, 1, 1), new DateTime(2024, 1, 5));
        await _context.GrcCalendarHolidays.AddAsync(holiday);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.ExistsAsync(
            "Holiday B", // Different description
            new DateTime(2024, 1, 1),
            new DateTime(2024, 1, 5),
            1,
            null);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task ExistsAsync_WithCaseInsensitiveMatch_ShouldReturnTrue()
    {
        // Arrange
        var holiday = CreateTestHoliday(1, 1, "Holiday Name", new DateTime(2024, 1, 1), new DateTime(2024, 1, 5));
        await _context.GrcCalendarHolidays.AddAsync(holiday);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.ExistsAsync(
            "HOLIDAY NAME", // Different case
            new DateTime(2024, 1, 1),
            new DateTime(2024, 1, 5),
            1,
            null);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task ExistsAsync_WithTrimmedMatch_ShouldReturnTrue()
    {
        // Arrange
        var holiday = CreateTestHoliday(1, 1, "Holiday", new DateTime(2024, 1, 1), new DateTime(2024, 1, 5));
        await _context.GrcCalendarHolidays.AddAsync(holiday);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.ExistsAsync(
            "  Holiday  ", // With spaces
            new DateTime(2024, 1, 1),
            new DateTime(2024, 1, 5),
            1,
            null);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task ExistsAsync_WithOverlappingStartDate_ShouldReturnTrue()
    {
        // Arrange
        var holiday = CreateTestHoliday(1, 1, "Holiday", new DateTime(2024, 1, 1), new DateTime(2024, 1, 10));
        await _context.GrcCalendarHolidays.AddAsync(holiday);
        await _context.SaveChangesAsync();

        // Act - New range starts during existing holiday
        var result = await _repository.ExistsAsync(
            "Holiday",
            new DateTime(2024, 1, 5), // Starts during existing
            new DateTime(2024, 1, 15),
            1,
            null);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task ExistsAsync_WithOverlappingEndDate_ShouldReturnTrue()
    {
        // Arrange
        var holiday = CreateTestHoliday(1, 1, "Holiday", new DateTime(2024, 1, 10), new DateTime(2024, 1, 20));
        await _context.GrcCalendarHolidays.AddAsync(holiday);
        await _context.SaveChangesAsync();

        // Act - New range ends during existing holiday
        var result = await _repository.ExistsAsync(
            "Holiday",
            new DateTime(2024, 1, 5),
            new DateTime(2024, 1, 15), // Ends during existing
            1,
            null);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task ExistsAsync_WithEncompassingRange_ShouldReturnTrue()
    {
        // Arrange
        var holiday = CreateTestHoliday(1, 1, "Holiday", new DateTime(2024, 1, 10), new DateTime(2024, 1, 15));
        await _context.GrcCalendarHolidays.AddAsync(holiday);
        await _context.SaveChangesAsync();

        // Act - New range encompasses existing holiday
        var result = await _repository.ExistsAsync(
            "Holiday",
            new DateTime(2024, 1, 1),
            new DateTime(2024, 1, 31),
            1,
            null);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task ExistsAsync_WithNonOverlappingDates_ShouldReturnFalse()
    {
        // Arrange
        var holiday = CreateTestHoliday(1, 1, "Holiday", new DateTime(2024, 1, 1), new DateTime(2024, 1, 5));
        await _context.GrcCalendarHolidays.AddAsync(holiday);
        await _context.SaveChangesAsync();

        // Act - Completely different date range
        var result = await _repository.ExistsAsync(
            "Holiday",
            new DateTime(2024, 2, 1),
            new DateTime(2024, 2, 5),
            1,
            null);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task ExistsAsync_WhenUpdating_ShouldIgnoreCurrentRecord()
    {
        // Arrange
        var holiday = CreateTestHoliday(1, 1, "Holiday", new DateTime(2024, 1, 1), new DateTime(2024, 1, 5));
        await _context.GrcCalendarHolidays.AddAsync(holiday);
        await _context.SaveChangesAsync();

        // Act - Same data but exclude current holiday ID
        var result = await _repository.ExistsAsync(
            "Holiday",
            new DateTime(2024, 1, 1),
            new DateTime(2024, 1, 5),
            1,
            1); // Exclude this ID

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task ExistsAsync_WhenUpdating_WithActualDuplicate_ShouldReturnTrue()
    {
        // Arrange
        await _context.GrcCalendarHolidays.AddRangeAsync(new[]
        {
            CreateTestHoliday(1, 1, "Holiday", new DateTime(2024, 1, 1), new DateTime(2024, 1, 5)),
            CreateTestHoliday(2, 1, "Holiday", new DateTime(2024, 1, 1), new DateTime(2024, 1, 5))
        });
        await _context.SaveChangesAsync();

        // Act - Updating holiday 1, but holiday 2 exists with same data
        var result = await _repository.ExistsAsync(
            "Holiday",
            new DateTime(2024, 1, 1),
            new DateTime(2024, 1, 5),
            1,
            1); // Exclude ID 1

        // Assert
        result.Should().BeTrue(); // Because holiday 2 matches
    }

    [Fact]
    public async Task ExistsAsync_WithDifferentAccountId_ShouldReturnFalse()
    {
        // Arrange
        var holiday = CreateTestHoliday(1, 1, "Holiday", new DateTime(2024, 1, 1), new DateTime(2024, 1, 5));
        await _context.GrcCalendarHolidays.AddAsync(holiday);
        await _context.SaveChangesAsync();

        // Act - Different account
        var result = await _repository.ExistsAsync(
            "Holiday",
            new DateTime(2024, 1, 1),
            new DateTime(2024, 1, 5),
            999, // Different account
            null);

        // Assert
        result.Should().BeFalse();
    }

    #endregion

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}
