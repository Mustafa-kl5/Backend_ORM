using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ORM.Application.Common.Exceptions;
using ORM.Application.Common.Responses;
using ORM.Core.DTOs.CalendarHoliday;
using ORM.Core.Interfaces.Services;
using ORM_API.Controllers;
using Xunit;

namespace ORM_API.Tests.Controllers;

/// <summary>
/// Unit tests for CalendarHolidayController
/// Tests HTTP endpoints, request/response handling, and controller logic
/// </summary>
public class CalendarHolidayControllerTests
{
    private readonly Mock<ICalendarHolidayService> _mockService;
    private readonly CalendarHolidayController _controller;

    public CalendarHolidayControllerTests()
    {
        _mockService = new Mock<ICalendarHolidayService>();
        _controller = new CalendarHolidayController(_mockService.Object);
    }

    #region Helper Methods

    private CalendarHolidayDto CreateTestHolidayDto(int id = 1, string description = "Test Holiday")
    {
        return new CalendarHolidayDto
        {
            HolidayId = id,
            Description = description,
            HolidayStart = DateTime.Now,
            HolidayEnd = DateTime.Now.AddDays(1),
            HolidayDays = 2
        };
    }

    #endregion

    #region GetAll Tests

    [Fact]
    public async Task GetAll_ShouldReturnOkWithHolidays()
    {
        // Arrange
        var holidays = new List<CalendarHolidayDto>
        {
            CreateTestHolidayDto(1, "Holiday 1"),
            CreateTestHolidayDto(2, "Holiday 2"),
            CreateTestHolidayDto(3, "Holiday 3")
        };

        _mockService
            .Setup(x => x.GetAllAsync())
            .ReturnsAsync(holidays);

        // Act
        var result = await _controller.GetAll();

        // Assert
        var okResult = result.Should().BeOfType<ObjectResult>().Subject;
        okResult.StatusCode.Should().Be(200);
        
        var response = okResult.Value.Should().BeAssignableTo<ApiResponse<IEnumerable<CalendarHolidayDto>>>().Subject;
        response.Success.Should().BeTrue();
        response.Data.Should().HaveCount(3);
        
        _mockService.Verify(x => x.GetAllAsync(), Times.Once);
    }

    [Fact]
    public async Task GetAll_WhenEmpty_ShouldReturnEmptyList()
    {
        // Arrange
        _mockService
            .Setup(x => x.GetAllAsync())
            .ReturnsAsync(new List<CalendarHolidayDto>());

        // Act
        var result = await _controller.GetAll();

        // Assert
        var okResult = result.Should().BeOfType<ObjectResult>().Subject;
        var response = okResult.Value.Should().BeAssignableTo<ApiResponse<IEnumerable<CalendarHolidayDto>>>().Subject;
        response.Success.Should().BeTrue();
        response.Data.Should().BeEmpty();
    }

    #endregion

    #region GetById Tests

    [Fact]
    public async Task GetById_WithValidId_ShouldReturnOk()
    {
        // Arrange
        var holidayId = 1;
        var holiday = CreateTestHolidayDto(holidayId);

        _mockService
            .Setup(x => x.GetByIdAsync(holidayId))
            .ReturnsAsync(holiday);

        // Act
        var result = await _controller.GetById(holidayId);

        // Assert
        var okResult = result.Should().BeOfType<ObjectResult>().Subject;
        okResult.StatusCode.Should().Be(200);
        
        var response = okResult.Value.Should().BeAssignableTo<ApiResponse<CalendarHolidayDto>>().Subject;
        response.Success.Should().BeTrue();
        response.Data.Should().NotBeNull();
        response.Data!.HolidayId.Should().Be(holidayId);
        
        _mockService.Verify(x => x.GetByIdAsync(holidayId), Times.Once);
    }

    [Fact]
    public async Task GetById_WithInvalidId_ShouldReturnNotFound()
    {
        // Arrange
        var invalidId = 999;
        _mockService
            .Setup(x => x.GetByIdAsync(invalidId))
            .ReturnsAsync((CalendarHolidayDto?)null);

        // Act
        var result = await _controller.GetById(invalidId);

        // Assert
        var notFoundResult = result.Should().BeOfType<ObjectResult>().Subject;
        notFoundResult.StatusCode.Should().Be(404);
        
        _mockService.Verify(x => x.GetByIdAsync(invalidId), Times.Once);
    }

    #endregion

    #region GetByCountry Tests

    [Fact]
    public async Task GetByCountry_WithValidCountryId_ShouldReturnHolidays()
    {
        // Arrange
        var countryId = 1;
        var holidays = new List<CalendarHolidayDto>
        {
            CreateTestHolidayDto(1, "Country Holiday 1"),
            CreateTestHolidayDto(2, "Country Holiday 2")
        };

        _mockService
            .Setup(x => x.GetByCountryAsync(countryId))
            .ReturnsAsync(holidays);

        // Act
        var result = await _controller.GetByCountry(countryId);

        // Assert
        var okResult = result.Should().BeOfType<ObjectResult>().Subject;
        var response = okResult.Value.Should().BeAssignableTo<ApiResponse<IEnumerable<CalendarHolidayDto>>>().Subject;
        response.Success.Should().BeTrue();
        response.Data.Should().HaveCount(2);
    }

    [Fact]
    public async Task GetByCountry_WithNullCountryId_ShouldReturnAllHolidays()
    {
        // Arrange
        var holidays = new List<CalendarHolidayDto>
        {
            CreateTestHolidayDto(1, "Holiday 1"),
            CreateTestHolidayDto(2, "Holiday 2")
        };

        _mockService
            .Setup(x => x.GetByCountryAsync(null))
            .ReturnsAsync(holidays);

        // Act
        var result = await _controller.GetByCountry(null);

        // Assert
        var okResult = result.Should().BeOfType<ObjectResult>().Subject;
        var response = okResult.Value.Should().BeAssignableTo<ApiResponse<IEnumerable<CalendarHolidayDto>>>().Subject;
        response.Success.Should().BeTrue();
        response.Data.Should().HaveCount(2);
    }

    #endregion

    #region GetByDateRange Tests

    [Fact]
    public async Task GetByDateRange_WithValidRange_ShouldReturnHolidays()
    {
        // Arrange
        var startDate = DateTime.Now;
        var endDate = DateTime.Now.AddMonths(1);
        var holidays = new List<CalendarHolidayDto>
        {
            CreateTestHolidayDto(1, "Holiday 1"),
            CreateTestHolidayDto(2, "Holiday 2")
        };

        _mockService
            .Setup(x => x.GetByDateRangeAsync(startDate, endDate))
            .ReturnsAsync(holidays);

        // Act
        var result = await _controller.GetByDateRange(startDate, endDate);

        // Assert
        var okResult = result.Should().BeOfType<ObjectResult>().Subject;
        var response = okResult.Value.Should().BeAssignableTo<ApiResponse<IEnumerable<CalendarHolidayDto>>>().Subject;
        response.Success.Should().BeTrue();
        response.Data.Should().HaveCount(2);
    }

    [Fact]
    public async Task GetByDateRange_WithInvalidRange_ShouldReturnBadRequest()
    {
        // Arrange
        var startDate = DateTime.Now;
        var endDate = DateTime.Now.AddDays(-10); // End before start

        // Act
        var result = await _controller.GetByDateRange(startDate, endDate);

        // Assert
        var badRequestResult = result.Should().BeOfType<ObjectResult>().Subject;
        badRequestResult.StatusCode.Should().Be(400);
        
        var response = badRequestResult.Value.Should().BeAssignableTo<ApiResponse>().Subject;
        response.Success.Should().BeFalse();
        response.Message.Should().Contain("Start date must be before");
        
        _mockService.Verify(x => x.GetByDateRangeAsync(It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Never);
    }

    #endregion

    #region Create Tests

    [Fact]
    public async Task Create_WithValidData_ShouldReturnCreated()
    {
        // Arrange
        var createDto = new CreateCalendarHolidayDto
        {
            Description = "New Holiday",
            HolidayStart = DateTime.Now,
            HolidayEnd = DateTime.Now.AddDays(1)
        };

        var createdHoliday = CreateTestHolidayDto(1, createDto.Description);

        _mockService
            .Setup(x => x.CreateAsync(createDto))
            .ReturnsAsync(createdHoliday);

        // Act
        var result = await _controller.Create(createDto);

        // Assert
        var createdResult = result.Should().BeOfType<ObjectResult>().Subject;
        createdResult.StatusCode.Should().Be(201);
        
        var response = createdResult.Value.Should().BeAssignableTo<ApiResponse<CalendarHolidayDto>>().Subject;
        response.Success.Should().BeTrue();
        response.Data.Should().NotBeNull();
        
        _mockService.Verify(x => x.CreateAsync(createDto), Times.Once);
    }

    [Fact]
    public async Task Create_WithInvalidModelState_ShouldReturnBadRequest()
    {
        // Arrange
        var createDto = new CreateCalendarHolidayDto();
        _controller.ModelState.AddModelError("Description", "Description is required");

        // Act
        var result = await _controller.Create(createDto);

        // Assert
        var badRequestResult = result.Should().BeOfType<ObjectResult>().Subject;
        badRequestResult.StatusCode.Should().Be(400);
        
        _mockService.Verify(x => x.CreateAsync(It.IsAny<CreateCalendarHolidayDto>()), Times.Never);
    }

    [Fact]
    public async Task Create_WithStartDateAfterEndDate_ShouldReturnBadRequest()
    {
        // Arrange
        var createDto = new CreateCalendarHolidayDto
        {
            Description = "Invalid Holiday",
            HolidayStart = DateTime.Now.AddDays(5),
            HolidayEnd = DateTime.Now // End before start
        };

        // Act
        var result = await _controller.Create(createDto);

        // Assert
        var badRequestResult = result.Should().BeOfType<ObjectResult>().Subject;
        badRequestResult.StatusCode.Should().Be(400);
        
        var response = badRequestResult.Value.Should().BeAssignableTo<ApiResponse>().Subject;
        response.Success.Should().BeFalse();
        response.Message.Should().Contain("start date must be before");
        
        _mockService.Verify(x => x.CreateAsync(It.IsAny<CreateCalendarHolidayDto>()), Times.Never);
    }

    #endregion

    #region Update Tests

    [Fact]
    public async Task Update_WithValidData_ShouldReturnOk()
    {
        // Arrange
        var holidayId = 1;
        var updateDto = new UpdateCalendarHolidayDto
        {
            Description = "Updated Holiday",
            HolidayStart = DateTime.Now,
            HolidayEnd = DateTime.Now.AddDays(1)
        };

        var updatedHoliday = CreateTestHolidayDto(holidayId, updateDto.Description);

        _mockService
            .Setup(x => x.UpdateAsync(holidayId, updateDto))
            .ReturnsAsync(updatedHoliday);

        // Act
        var result = await _controller.Update(holidayId, updateDto);

        // Assert
        var okResult = result.Should().BeOfType<ObjectResult>().Subject;
        okResult.StatusCode.Should().Be(200);
        
        var response = okResult.Value.Should().BeAssignableTo<ApiResponse<CalendarHolidayDto>>().Subject;
        response.Success.Should().BeTrue();
        
        _mockService.Verify(x => x.UpdateAsync(holidayId, updateDto), Times.Once);
    }

    [Fact]
    public async Task Update_WithInvalidModelState_ShouldReturnBadRequest()
    {
        // Arrange
        var holidayId = 1;
        var updateDto = new UpdateCalendarHolidayDto();
        _controller.ModelState.AddModelError("Description", "Description is required");

        // Act
        var result = await _controller.Update(holidayId, updateDto);

        // Assert
        var badRequestResult = result.Should().BeOfType<ObjectResult>().Subject;
        badRequestResult.StatusCode.Should().Be(400);
        
        _mockService.Verify(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<UpdateCalendarHolidayDto>()), Times.Never);
    }

    [Fact]
    public async Task Update_WithStartDateAfterEndDate_ShouldReturnBadRequest()
    {
        // Arrange
        var holidayId = 1;
        var updateDto = new UpdateCalendarHolidayDto
        {
            Description = "Invalid Holiday",
            HolidayStart = DateTime.Now.AddDays(5),
            HolidayEnd = DateTime.Now
        };

        // Act
        var result = await _controller.Update(holidayId, updateDto);

        // Assert
        var badRequestResult = result.Should().BeOfType<ObjectResult>().Subject;
        badRequestResult.StatusCode.Should().Be(400);
        
        _mockService.Verify(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<UpdateCalendarHolidayDto>()), Times.Never);
    }

    #endregion

    #region Delete Tests

    [Fact]
    public async Task Delete_WithValidId_ShouldReturnOk()
    {
        // Arrange
        var holidayId = 1;
        _mockService
            .Setup(x => x.DeleteAsync(holidayId))
            .ReturnsAsync(true);

        // Act
        var result = await _controller.Delete(holidayId);

        // Assert
        var okResult = result.Should().BeOfType<ObjectResult>().Subject;
        okResult.StatusCode.Should().Be(200);
        
        var response = okResult.Value.Should().BeAssignableTo<ApiResponse<bool>>().Subject;
        response.Success.Should().BeTrue();
        response.Data.Should().BeTrue();
        
        _mockService.Verify(x => x.DeleteAsync(holidayId), Times.Once);
    }

    [Fact]
    public async Task Delete_ServiceReturnsFalse_ShouldStillReturnOk()
    {
        // Arrange
        var holidayId = 999;
        _mockService
            .Setup(x => x.DeleteAsync(holidayId))
            .ReturnsAsync(false);

        // Act
        var result = await _controller.Delete(holidayId);

        // Assert
        var okResult = result.Should().BeOfType<ObjectResult>().Subject;
        var response = okResult.Value.Should().BeAssignableTo<ApiResponse<bool>>().Subject;
        response.Data.Should().BeFalse();
    }

    #endregion
}
