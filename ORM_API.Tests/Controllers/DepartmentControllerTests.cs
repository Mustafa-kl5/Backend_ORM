using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ORM.Application.Common.Exceptions;
using ORM.Application.Common.Localization;
using ORM.Application.Common.Responses;
using ORM.Core.DTOs.Department;
using ORM.Core.Interfaces.Services;
using ORM_API.Controllers;
using Xunit;

namespace ORM_API.Tests.Controllers;

/// <summary>
/// Unit tests for DepartmentController
/// Tests HTTP endpoints, request/response handling, and controller logic
/// </summary>
public class DepartmentControllerTests
{
    private readonly Mock<IDepartmentService> _mockService;
    private readonly Mock<ILocalizationService> _mockLocalization;
    private readonly DepartmentController _controller;

    public DepartmentControllerTests()
    {
        _mockService = new Mock<IDepartmentService>();
        _mockLocalization = new Mock<ILocalizationService>();
        
        _mockLocalization
            .Setup(x => x.Get(It.IsAny<string>()))
            .Returns((string key) => key);

        _controller = new DepartmentController(_mockService.Object, _mockLocalization.Object);
    }

    #region Helper Methods

    private DepartmentDto CreateTestDepartmentDto(int id = 1, string name = "Test Department")
    {
        return new DepartmentDto
        {
            DepartmentId = id,
            DepartmentName = name,
            DepartmentEmail1 = "test@example.com",
            DepartmentCode = "TEST001",
            CountryId = 1,
            SectorId = 1,
            AccountId = 1
        };
    }

    private CreateDepartmentDto CreateTestCreateDto(string name = "New Department")
    {
        return new CreateDepartmentDto
        {
            DepartmentName = name,
            DepartmentEmail1 = "new@example.com",
            DepartmentCode = "NEW001"
        };
    }

    private UpdateDepartmentDto CreateTestUpdateDto(string name = "Updated Department")
    {
        return new UpdateDepartmentDto
        {
            DepartmentName = name,
            DepartmentEmail1 = "updated@example.com",
            DepartmentCode = "UPD001"
        };
    }

    #endregion

    #region GetAll Tests

    [Fact]
    public async Task GetAll_ShouldReturnOkWithDepartments()
    {
        // Arrange
        var departments = new List<DepartmentDto>
        {
            CreateTestDepartmentDto(1, "Department 1"),
            CreateTestDepartmentDto(2, "Department 2"),
            CreateTestDepartmentDto(3, "Department 3")
        };

        _mockService
            .Setup(x => x.GetAllAsync())
            .ReturnsAsync(departments);

        // Act
        var result = await _controller.GetAll();

        // Assert
        var okResult = result.Should().BeOfType<ObjectResult>().Subject;
        okResult.StatusCode.Should().Be(200);
        
        var response = okResult.Value.Should().BeAssignableTo<ApiResponse<IEnumerable<DepartmentDto>>>().Subject;
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
            .ReturnsAsync(new List<DepartmentDto>());

        // Act
        var result = await _controller.GetAll();

        // Assert
        var okResult = result.Should().BeOfType<ObjectResult>().Subject;
        var response = okResult.Value.Should().BeAssignableTo<ApiResponse<IEnumerable<DepartmentDto>>>().Subject;
        response.Success.Should().BeTrue();
        response.Data.Should().BeEmpty();
    }

    #endregion

    #region GetById Tests

    [Fact]
    public async Task GetById_WithValidId_ShouldReturnOk()
    {
        // Arrange
        var departmentId = 1;
        var department = CreateTestDepartmentDto(departmentId);

        _mockService
            .Setup(x => x.GetByIdAsync(departmentId))
            .ReturnsAsync(department);

        // Act
        var result = await _controller.GetById(departmentId);

        // Assert
        var okResult = result.Should().BeOfType<ObjectResult>().Subject;
        okResult.StatusCode.Should().Be(200);
        
        var response = okResult.Value.Should().BeAssignableTo<ApiResponse<DepartmentDto>>().Subject;
        response.Success.Should().BeTrue();
        response.Data.DepartmentId.Should().Be(departmentId);
    }

    [Fact]
    public async Task GetById_WithInvalidId_ShouldReturnNotFound()
    {
        // Arrange
        var invalidId = 999;

        _mockService
            .Setup(x => x.GetByIdAsync(invalidId))
            .ReturnsAsync((DepartmentDto?)null);

        // Act
        var result = await _controller.GetById(invalidId);

        // Assert
        var notFoundResult = result.Should().BeOfType<NotFoundObjectResult>().Subject;
        notFoundResult.StatusCode.Should().Be(404);
    }

    #endregion

    #region GetByCountry Tests

    [Fact]
    public async Task GetByCountry_ShouldReturnOkWithDepartments()
    {
        // Arrange
        var countryId = 1;
        var departments = new List<DepartmentDto>
        {
            CreateTestDepartmentDto(1, "Dept 1"),
            CreateTestDepartmentDto(2, "Dept 2")
        };

        _mockService
            .Setup(x => x.GetByCountryAsync(countryId))
            .ReturnsAsync(departments);

        // Act
        var result = await _controller.GetByCountry(countryId);

        // Assert
        var okResult = result.Should().BeOfType<ObjectResult>().Subject;
        okResult.StatusCode.Should().Be(200);
        
        var response = okResult.Value.Should().BeAssignableTo<ApiResponse<IEnumerable<DepartmentDto>>>().Subject;
        response.Data.Should().HaveCount(2);
    }

    #endregion

    #region Create Tests

    [Fact]
    public async Task Create_WithValidData_ShouldReturnCreated()
    {
        // Arrange
        var createDto = CreateTestCreateDto();
        var createdDepartment = CreateTestDepartmentDto(1, createDto.DepartmentName);

        _mockService
            .Setup(x => x.CreateAsync(createDto))
            .ReturnsAsync(createdDepartment);

        // Act
        var result = await _controller.Create(createDto);

        // Assert
        var createdResult = result.Should().BeOfType<ObjectResult>().Subject;
        createdResult.StatusCode.Should().Be(201);
        
        var response = createdResult.Value.Should().BeAssignableTo<ApiResponse<DepartmentDto>>().Subject;
        response.Success.Should().BeTrue();
        response.Data.DepartmentName.Should().Be(createDto.DepartmentName);
        
        _mockService.Verify(x => x.CreateAsync(createDto), Times.Once);
    }

    [Fact]
    public async Task Create_WithInvalidModelState_ShouldReturnBadRequest()
    {
        // Arrange
        var createDto = CreateTestCreateDto();
        _controller.ModelState.AddModelError("DepartmentName", "Department name is required");

        // Act
        var result = await _controller.Create(createDto);

        // Assert
        var badRequestResult = result.Should().BeOfType<ObjectResult>().Subject;
        badRequestResult.StatusCode.Should().Be(400);
        
        _mockService.Verify(x => x.CreateAsync(It.IsAny<CreateDepartmentDto>()), Times.Never);
    }

    [Fact]
    public async Task Create_WithDuplicateName_ShouldThrowBadRequestException()
    {
        // Arrange
        var createDto = CreateTestCreateDto();

        _mockService
            .Setup(x => x.CreateAsync(createDto))
            .ThrowsAsync(new BadRequestException("Department.Duplicate"));

        // Act & Assert
        await Assert.ThrowsAsync<BadRequestException>(() => _controller.Create(createDto));
    }

    [Fact]
    public async Task Create_WithDuplicateEmail_ShouldThrowBadRequestException()
    {
        // Arrange
        var createDto = CreateTestCreateDto();

        _mockService
            .Setup(x => x.CreateAsync(createDto))
            .ThrowsAsync(new BadRequestException("Department.EmailDuplicate"));

        // Act & Assert
        await Assert.ThrowsAsync<BadRequestException>(() => _controller.Create(createDto));
    }

    #endregion

    #region Update Tests

    [Fact]
    public async Task Update_WithValidData_ShouldReturnOk()
    {
        // Arrange
        var departmentId = 1;
        var updateDto = CreateTestUpdateDto();
        var updatedDepartment = CreateTestDepartmentDto(departmentId, updateDto.DepartmentName);

        _mockService
            .Setup(x => x.UpdateAsync(departmentId, updateDto))
            .ReturnsAsync(updatedDepartment);

        // Act
        var result = await _controller.Update(departmentId, updateDto);

        // Assert
        var okResult = result.Should().BeOfType<ObjectResult>().Subject;
        okResult.StatusCode.Should().Be(200);
        
        var response = okResult.Value.Should().BeAssignableTo<ApiResponse<DepartmentDto>>().Subject;
        response.Success.Should().BeTrue();
        response.Data.DepartmentName.Should().Be(updateDto.DepartmentName);
        
        _mockService.Verify(x => x.UpdateAsync(departmentId, updateDto), Times.Once);
    }

    [Fact]
    public async Task Update_WithInvalidModelState_ShouldReturnBadRequest()
    {
        // Arrange
        var departmentId = 1;
        var updateDto = CreateTestUpdateDto();
        _controller.ModelState.AddModelError("DepartmentName", "Department name is required");

        // Act
        var result = await _controller.Update(departmentId, updateDto);

        // Assert
        var badRequestResult = result.Should().BeOfType<ObjectResult>().Subject;
        badRequestResult.StatusCode.Should().Be(400);
        
        _mockService.Verify(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<UpdateDepartmentDto>()), Times.Never);
    }

    [Fact]
    public async Task Update_WithNonExistentId_ShouldThrowNotFoundException()
    {
        // Arrange
        var invalidId = 999;
        var updateDto = CreateTestUpdateDto();

        _mockService
            .Setup(x => x.UpdateAsync(invalidId, updateDto))
            .ThrowsAsync(new NotFoundException("Department.NotFound"));

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => _controller.Update(invalidId, updateDto));
    }

    [Fact]
    public async Task Update_WithDuplicateName_ShouldThrowBadRequestException()
    {
        // Arrange
        var departmentId = 1;
        var updateDto = CreateTestUpdateDto();

        _mockService
            .Setup(x => x.UpdateAsync(departmentId, updateDto))
            .ThrowsAsync(new BadRequestException("Department.Duplicate"));

        // Act & Assert
        await Assert.ThrowsAsync<BadRequestException>(() => _controller.Update(departmentId, updateDto));
    }

    #endregion

    #region Delete Tests

    [Fact]
    public async Task Delete_WithValidId_ShouldReturnOk()
    {
        // Arrange
        var departmentId = 1;

        _mockService
            .Setup(x => x.DeleteAsync(departmentId))
            .ReturnsAsync(true);

        // Act
        var result = await _controller.Delete(departmentId);

        // Assert
        var okResult = result.Should().BeOfType<ObjectResult>().Subject;
        okResult.StatusCode.Should().Be(200);
        
        var response = okResult.Value.Should().BeAssignableTo<ApiResponse<bool>>().Subject;
        response.Success.Should().BeTrue();
        response.Data.Should().BeTrue();
        
        _mockService.Verify(x => x.DeleteAsync(departmentId), Times.Once);
    }

    [Fact]
    public async Task Delete_WithNonExistentId_ShouldThrowNotFoundException()
    {
        // Arrange
        var invalidId = 999;

        _mockService
            .Setup(x => x.DeleteAsync(invalidId))
            .ThrowsAsync(new NotFoundException("Department.NotFound"));

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => _controller.Delete(invalidId));
    }

    #endregion
}
