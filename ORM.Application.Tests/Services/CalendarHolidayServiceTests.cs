using FluentAssertions;
using Moq;
using ORM.Application.Common.Exceptions;
using ORM.Application.Common.Localization;
using ORM.Application.Services;
using ORM.Core.DTOs.ActivityLog;
using ORM.Core.DTOs.CalendarHoliday;
using ORM.Core.Interfaces.Repositories;
using ORM.Core.Interfaces.Services;
using ORM.Domain.Entities;
using Xunit;

namespace ORM.Application.Tests.Services;

public class CalendarHolidayServiceTests
{
    private readonly Mock<ICalendarHolidayRepository> _mockRepository;
    private readonly Mock<ILocalizationService> _mockLocalization;
    private readonly Mock<ICurrentUserService> _mockCurrentUserService;
    private readonly Mock<IActivityLogService> _mockActivityLogService;
    private readonly CalendarHolidayService _service;

    public CalendarHolidayServiceTests()
    {
        _mockRepository = new Mock<ICalendarHolidayRepository>();
        _mockLocalization = new Mock<ILocalizationService>();
        _mockCurrentUserService = new Mock<ICurrentUserService>();
        _mockActivityLogService = new Mock<IActivityLogService>();
        
        // Setup default responses
        _mockLocalization
            .Setup(x => x.Get(It.IsAny<string>()))
            .Returns((string key) => key);

        _mockCurrentUserService
            .Setup(x => x.AccountId)
            .Returns(1);

        _mockCurrentUserService
            .Setup(x => x.UserId)
            .Returns(1);

        _service = new CalendarHolidayService(
            _mockRepository.Object,
            _mockCurrentUserService.Object,
            _mockActivityLogService.Object,
            _mockLocalization.Object
        );
    }

    // Helper method to create test holiday entities
    private GrcCalendarHoliday CreateTestHoliday(int holidayId = 1, int accountId = 1, string description = "Test Holiday")
    {
        return new GrcCalendarHoliday
        {
            HolidayId = holidayId,
            AccountId = accountId,
            Description = description,
            HolidayStart = new DateTime(2024, 1, 1),
            HolidayEnd = new DateTime(2024, 1, 1),
            HolidayDays = 1,
            CreatedBy = 1,
            CreationDate = DateTime.UtcNow,
            LastUpdatedBy = 1,
            LastUpdateDate = DateTime.UtcNow
        };
    }

    // Helper method to create CreateCalendarHolidayDto
    private CreateCalendarHolidayDto CreateTestDto(string description = "Test Holiday", DateTime? holidayStart = null, DateTime? holidayEnd = null)
    {
        return new CreateCalendarHolidayDto
        {
            Description = description,
            HolidayStart = holidayStart ?? new DateTime(2024, 1, 1),
            HolidayEnd = holidayEnd ?? new DateTime(2024, 1, 1)
        };
    }

    // Helper method to create UpdateCalendarHolidayDto
    private UpdateCalendarHolidayDto CreateUpdateDto(string description = "Updated Holiday", DateTime? holidayStart = null, DateTime? holidayEnd = null)
    {
        return new UpdateCalendarHolidayDto
        {
            Description = description,
            HolidayStart = holidayStart ?? new DateTime(2024, 1, 1),
            HolidayEnd = holidayEnd ?? new DateTime(2024, 1, 1)
        };
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllHolidays()
    {
        // Arrange
        var accountId = 1;
        var expectedHolidays = new List<GrcCalendarHoliday>
        {
            CreateTestHoliday(1, accountId, "Holiday 1"),
            CreateTestHoliday(2, accountId, "Holiday 2"),
            CreateTestHoliday(3, accountId, "Holiday 3")
        };

        _mockRepository
            .Setup(x => x.GetAllAsync(accountId))
            .ReturnsAsync(expectedHolidays);

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(3);
        _mockRepository.Verify(x => x.GetAllAsync(accountId), Times.Once);
    }

    [Fact]
    public async Task GetByIdAsync_WithValidId_ShouldReturnHoliday()
    {
        // Arrange
        var holidayId = 1;
        var accountId = 1;
        var expectedHoliday = CreateTestHoliday(holidayId, accountId);

        _mockRepository
            .Setup(x => x.GetByIdAsync(holidayId, accountId))
            .ReturnsAsync(expectedHoliday);

        // Act
        var result = await _service.GetByIdAsync(holidayId);

        // Assert
        result.Should().NotBeNull();
        result!.HolidayId.Should().Be(holidayId);
        _mockRepository.Verify(x => x.GetByIdAsync(holidayId, accountId), Times.Once);
    }

    [Fact]
    public async Task GetByIdAsync_WithInvalidId_ShouldReturnNull()
    {
        // Arrange
        var invalidId = 999;
        var accountId = 1;

        _mockRepository
            .Setup(x => x.GetByIdAsync(invalidId, accountId))
            .ReturnsAsync((GrcCalendarHoliday?)null);

        // Act
        var result = await _service.GetByIdAsync(invalidId);

        // Assert
        result.Should().BeNull();
        _mockRepository.Verify(x => x.GetByIdAsync(invalidId, accountId), Times.Once);
    }

    [Fact]
    public async Task CreateAsync_WithValidData_ShouldCreateHoliday()
    {
        // Arrange
        var accountId = 1;
        var userId = 1;
        var createDto = CreateTestDto("New Year", DateTime.Now.Date, DateTime.Now.Date.AddDays(3));

        _mockRepository
            .Setup(x => x.ExistsAsync(
                createDto.Description,
                createDto.HolidayStart,
                createDto.HolidayEnd,
                accountId,
                null))
            .ReturnsAsync(false);

        _mockRepository
            .Setup(x => x.CreateAsync(It.IsAny<GrcCalendarHoliday>()))
            .ReturnsAsync((GrcCalendarHoliday h) => h);

        _mockActivityLogService
            .Setup(x => x.LogEntityCreatedAsync(
                It.IsAny<GrcCalendarHoliday>(),
                EventType.DataCreated,
                1,
                7))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreateAsync(createDto);

        // Assert
        result.Should().NotBeNull();
        result.Description.Should().Be(createDto.Description);
        result.HolidayStart.Should().Be(createDto.HolidayStart);
        result.HolidayEnd.Should().Be(createDto.HolidayEnd);
        _mockRepository.Verify(x => x.CreateAsync(It.IsAny<GrcCalendarHoliday>()), Times.Once);
    }

    [Fact]
    public async Task CreateAsync_WithDuplicateData_ShouldThrowBadRequestException()
    {
        // Arrange
        var accountId = 1;
        var createDto = CreateTestDto("Duplicate Holiday", DateTime.Now.Date, DateTime.Now.Date.AddDays(3));

        var expectedMessage = "Duplicate holiday";

        _mockRepository
            .Setup(x => x.ExistsAsync(
                createDto.Description,
                createDto.HolidayStart,
                createDto.HolidayEnd,
                accountId,
                null))
            .ReturnsAsync(true);

        _mockLocalization
            .Setup(x => x.Get(MessageKeys.CalendarHolidayDuplicate))
            .Returns(expectedMessage);

        // Act
        Func<Task> act = async () => await _service.CreateAsync(createDto);

        // Assert
        await act.Should().ThrowAsync<BadRequestException>()
            .WithMessage(expectedMessage);
        
        _mockRepository.Verify(x => x.CreateAsync(It.IsAny<GrcCalendarHoliday>()), Times.Never);
    }

    [Fact]
    public async Task UpdateAsync_WithValidData_ShouldUpdateHoliday()
    {
        // Arrange
        var holidayId = 1;
        var accountId = 1;
        var userId = 1;
        
        var existingHoliday = CreateTestHoliday(holidayId, accountId, "Old Holiday");
        
        var updateDto = CreateUpdateDto("Updated Holiday", DateTime.Now.Date, DateTime.Now.Date.AddDays(5));

        _mockRepository
            .Setup(x => x.GetByIdAsync(holidayId, accountId))
            .ReturnsAsync(existingHoliday);

        _mockRepository
            .Setup(x => x.ExistsAsync(
                updateDto.Description,
                updateDto.HolidayStart,
                updateDto.HolidayEnd,
                accountId,
                holidayId))
            .ReturnsAsync(false);

        _mockRepository
            .Setup(x => x.UpdateAsync(It.IsAny<GrcCalendarHoliday>()))
            .ReturnsAsync((GrcCalendarHoliday h) => h);

        // Act
        var result = await _service.UpdateAsync(holidayId, updateDto);

        // Assert
        result.Should().NotBeNull();
        result.Description.Should().Be(updateDto.Description);
        _mockRepository.Verify(x => x.UpdateAsync(It.IsAny<GrcCalendarHoliday>()), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_WithNonExistentId_ShouldThrowNotFoundException()
    {
        // Arrange
        var holidayId = 999;
        var accountId = 1;
        var updateDto = CreateUpdateDto("Non-existent Holiday");
        var expectedMessage = "Holiday not found";

        _mockRepository
            .Setup(x => x.GetByIdAsync(holidayId, accountId))
            .ReturnsAsync((GrcCalendarHoliday?)null);

        _mockLocalization
            .Setup(x => x.Get(MessageKeys.CalendarHolidayNotFound))
            .Returns(expectedMessage);

        // Act
        Func<Task> act = async () => await _service.UpdateAsync(holidayId, updateDto);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>()
            .WithMessage(expectedMessage);
        
        _mockRepository.Verify(x => x.UpdateAsync(It.IsAny<GrcCalendarHoliday>()), Times.Never);
    }

    [Fact]
    public async Task UpdateAsync_WithDuplicateData_ShouldThrowBadRequestException()
    {
        // Arrange
        var holidayId = 1;
        var accountId = 1;
        
        var existingHoliday = CreateTestHoliday(holidayId, accountId, "Existing Holiday");
        
        var updateDto = CreateUpdateDto("Duplicate Description", DateTime.Now.Date, DateTime.Now.Date.AddDays(2));
        var expectedMessage = "Duplicate holiday";

        _mockRepository
            .Setup(x => x.GetByIdAsync(holidayId, accountId))
            .ReturnsAsync(existingHoliday);

        _mockRepository
            .Setup(x => x.ExistsAsync(
                updateDto.Description,
                updateDto.HolidayStart,
                updateDto.HolidayEnd,
                accountId,
                holidayId))
            .ReturnsAsync(true);

        _mockLocalization
            .Setup(x => x.Get(MessageKeys.CalendarHolidayDuplicate))
            .Returns(expectedMessage);

        // Act
        Func<Task> act = async () => await _service.UpdateAsync(holidayId, updateDto);

        // Assert
        await act.Should().ThrowAsync<BadRequestException>()
            .WithMessage(expectedMessage);
    }

    [Fact]
    public async Task DeleteAsync_WithValidId_ShouldDeleteHoliday()
    {
        // Arrange
        var holidayId = 1;
        var accountId = 1;
        
        var existingHoliday = CreateTestHoliday(holidayId, accountId);

        _mockRepository
            .Setup(x => x.GetByIdAsync(holidayId, accountId))
            .ReturnsAsync(existingHoliday);

        _mockRepository
            .Setup(x => x.DeleteAsync(holidayId, accountId))
            .ReturnsAsync(true);

        // Act
        var result = await _service.DeleteAsync(holidayId);

        // Assert
        result.Should().BeTrue();
        _mockRepository.Verify(x => x.DeleteAsync(holidayId, accountId), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_WithNonExistentId_ShouldThrowNotFoundException()
    {
        // Arrange
        var holidayId = 999;
        var accountId = 1;
        var expectedMessage = "Holiday not found";

        _mockRepository
            .Setup(x => x.GetByIdAsync(holidayId, accountId))
            .ReturnsAsync((GrcCalendarHoliday?)null);

        _mockLocalization
            .Setup(x => x.Get(MessageKeys.CalendarHolidayNotFound))
            .Returns(expectedMessage);

        // Act
        Func<Task> act = async () => await _service.DeleteAsync(holidayId);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>()
            .WithMessage(expectedMessage);
        
        _mockRepository.Verify(x => x.DeleteAsync(It.IsAny<int>(), It.IsAny<int>()), Times.Never);
    }

    [Fact]
    public async Task GetByDateRangeAsync_ShouldReturnHolidaysInRange()
    {
        // Arrange
        var accountId = 1;
        var startDate = DateTime.Now.Date;
        var endDate = DateTime.Now.Date.AddDays(30);
        
        var holiday1 = CreateTestHoliday(1, accountId, "Holiday 1");
        holiday1.HolidayStart = startDate.AddDays(5);
        holiday1.HolidayEnd = startDate.AddDays(7);
        
        var holiday2 = CreateTestHoliday(2, accountId, "Holiday 2");
        holiday2.HolidayStart = startDate.AddDays(10);
        holiday2.HolidayEnd = startDate.AddDays(12);
        
        var expectedHolidays = new List<GrcCalendarHoliday> { holiday1, holiday2 };

        _mockRepository
            .Setup(x => x.GetByDateRangeAsync(startDate, endDate, accountId))
            .ReturnsAsync(expectedHolidays);

        // Act
        var result = await _service.GetByDateRangeAsync(startDate, endDate);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        _mockRepository.Verify(x => x.GetByDateRangeAsync(startDate, endDate, accountId), Times.Once);
    }
}
