using FluentAssertions;
using Moq;
using ORM.Application.Common.Exceptions;
using ORM.Application.Common.Localization;
using ORM.Application.Services;
using ORM.Core.DTOs.Department;
using ORM.Core.Interfaces.Repositories;
using ORM.Core.Interfaces.Services;
using ORM.Domain.Entities;
using Xunit;

namespace ORM.Application.Tests.Services;

public class DepartmentServiceTests
{
    private readonly Mock<IDepartmentRepository> _mockRepository;
    private readonly Mock<ILocalizationService> _mockLocalization;
    private readonly Mock<ICurrentUserService> _mockCurrentUserService;
    private readonly Mock<IActivityLogService> _mockActivityLogService;
    private readonly DepartmentService _service;

    public DepartmentServiceTests()
    {
        _mockRepository = new Mock<IDepartmentRepository>();
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

        _mockCurrentUserService
            .Setup(x => x.GetUserContextAsync())
            .ReturnsAsync(new ORM.Core.DTOs.User.UserContextDto { CountryId = 1 });

        _service = new DepartmentService(
            _mockRepository.Object,
            _mockCurrentUserService.Object,
            _mockActivityLogService.Object,
            _mockLocalization.Object
        );
    }

    // Helper method to create test department entities
    private GrcDepartment CreateTestDepartment(
        int departmentId = 1, 
        int accountId = 1, 
        string name = "Test Department",
        string email = "test@example.com")
    {
        return new GrcDepartment
        {
            DepartmentId = departmentId,
            AccountId = accountId,
            DepartmentName = name,
            DepartmentEmail1 = email,
            DepartmentEmail2 = null,
            DepartmentCode = "TEST001",
            CountryId = 1,
            SectorId = 1,
            CreatedBy = 1,
            CreationDate = DateTime.UtcNow,
            Country = new GrcCountry { CountryId = 1, CountryName = "Test Country" },
            Sector = new GrcSector { Id = 1, Description = "Test Sector" }
        };
    }

    // Helper method to create CreateDepartmentDto
    private CreateDepartmentDto CreateTestDto(
        string name = "Test Department", 
        string email = "test@example.com")
    {
        return new CreateDepartmentDto
        {
            DepartmentName = name,
            DepartmentEmail1 = email,
            DepartmentEmail2 = null,
            DepartmentCode = "TEST001"
        };
    }

    // Helper method to create UpdateDepartmentDto
    private UpdateDepartmentDto CreateUpdateDto(
        string name = "Updated Department", 
        string email = "updated@example.com")
    {
        return new UpdateDepartmentDto
        {
            DepartmentName = name,
            DepartmentEmail1 = email,
            DepartmentEmail2 = null,
            DepartmentCode = "UPD001"
        };
    }

    #region GetAllAsync Tests

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllDepartments()
    {
        // Arrange
        var accountId = 1;
        var expectedDepartments = new List<GrcDepartment>
        {
            CreateTestDepartment(1, accountId, "Department 1", "dept1@example.com"),
            CreateTestDepartment(2, accountId, "Department 2", "dept2@example.com"),
            CreateTestDepartment(3, accountId, "Department 3", "dept3@example.com")
        };

        _mockRepository
            .Setup(x => x.GetAllAsync(accountId))
            .ReturnsAsync(expectedDepartments);

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(3);
        result[0].DepartmentName.Should().Be("Department 1");
        _mockRepository.Verify(x => x.GetAllAsync(accountId), Times.Once);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnEmptyList_WhenNoDepartments()
    {
        // Arrange
        var accountId = 1;
        _mockRepository
            .Setup(x => x.GetAllAsync(accountId))
            .ReturnsAsync(new List<GrcDepartment>());

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    #endregion

    #region GetByIdAsync Tests

    [Fact]
    public async Task GetByIdAsync_WithValidId_ShouldReturnDepartment()
    {
        // Arrange
        var departmentId = 1;
        var accountId = 1;
        var expectedDepartment = CreateTestDepartment(departmentId, accountId);

        _mockRepository
            .Setup(x => x.GetByIdAsync(departmentId, accountId))
            .ReturnsAsync(expectedDepartment);

        // Act
        var result = await _service.GetByIdAsync(departmentId);

        // Assert
        result.Should().NotBeNull();
        result!.DepartmentId.Should().Be(departmentId);
        result.DepartmentName.Should().Be("Test Department");
        _mockRepository.Verify(x => x.GetByIdAsync(departmentId, accountId), Times.Once);
    }

    [Fact]
    public async Task GetByIdAsync_WithInvalidId_ShouldReturnNull()
    {
        // Arrange
        var invalidId = 999;
        var accountId = 1;

        _mockRepository
            .Setup(x => x.GetByIdAsync(invalidId, accountId))
            .ReturnsAsync((GrcDepartment?)null);

        // Act
        var result = await _service.GetByIdAsync(invalidId);

        // Assert
        result.Should().BeNull();
    }

    #endregion

    #region GetByCountryAsync Tests

    [Fact]
    public async Task GetByCountryAsync_ShouldReturnDepartmentsForCountry()
    {
        // Arrange
        var countryId = 1;
        var accountId = 1;
        var expectedDepartments = new List<GrcDepartment>
        {
            CreateTestDepartment(1, accountId, "Dept 1", "dept1@example.com"),
            CreateTestDepartment(2, accountId, "Dept 2", "dept2@example.com")
        };

        _mockRepository
            .Setup(x => x.GetByCountryAsync(countryId, accountId))
            .ReturnsAsync(expectedDepartments);

        // Act
        var result = await _service.GetByCountryAsync(countryId);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
    }

    #endregion

    #region CreateAsync Tests

    [Fact]
    public async Task CreateAsync_WithValidData_ShouldReturnCreatedDepartment()
    {
        // Arrange
        var dto = CreateTestDto();
        var accountId = 1;
        var createdDepartment = CreateTestDepartment(1, accountId);

        _mockRepository
            .Setup(x => x.CodeExistsAsync(dto.DepartmentCode, accountId, null))
            .ReturnsAsync(false);

        _mockRepository
            .Setup(x => x.ExistsAsync(dto.DepartmentName, dto.DepartmentCode, accountId, null))
            .ReturnsAsync(false);

        _mockRepository
            .Setup(x => x.EmailExistsAsync(dto.DepartmentEmail1, accountId, null))
            .ReturnsAsync(false);

        _mockRepository
            .Setup(x => x.CreateAsync(It.IsAny<GrcDepartment>()))
            .ReturnsAsync(createdDepartment);

        // Act
        var result = await _service.CreateAsync(dto);

        // Assert
        result.Should().NotBeNull();
        result.DepartmentName.Should().Be("Test Department");
        _mockRepository.Verify(x => x.CreateAsync(It.IsAny<GrcDepartment>()), Times.Once);
    }

    [Fact]
    public async Task CreateAsync_WithDuplicateName_ShouldThrowBadRequestException()
    {
        // Arrange
        var dto = CreateTestDto();
        var accountId = 1;

        _mockRepository
            .Setup(x => x.CodeExistsAsync(dto.DepartmentCode, accountId, null))
            .ReturnsAsync(false);

        _mockRepository
            .Setup(x => x.ExistsAsync(dto.DepartmentName, dto.DepartmentCode, accountId, null))
            .ReturnsAsync(true);

        // Act & Assert
        await Assert.ThrowsAsync<BadRequestException>(() => _service.CreateAsync(dto));
        _mockRepository.Verify(x => x.CreateAsync(It.IsAny<GrcDepartment>()), Times.Never);
    }

    [Fact]
    public async Task CreateAsync_WithDuplicateEmail_ShouldThrowBadRequestException()
    {
        // Arrange
        var dto = CreateTestDto();
        var accountId = 1;

        _mockRepository
            .Setup(x => x.CodeExistsAsync(dto.DepartmentCode, accountId, null))
            .ReturnsAsync(false);

        _mockRepository
            .Setup(x => x.ExistsAsync(dto.DepartmentName, dto.DepartmentCode, accountId, null))
            .ReturnsAsync(false);

        _mockRepository
            .Setup(x => x.EmailExistsAsync(dto.DepartmentEmail1, accountId, null))
            .ReturnsAsync(true);

        // Act & Assert
        await Assert.ThrowsAsync<BadRequestException>(() => _service.CreateAsync(dto));
        _mockRepository.Verify(x => x.CreateAsync(It.IsAny<GrcDepartment>()), Times.Never);
    }

    [Fact]
    public async Task CreateAsync_WithDuplicateCode_ShouldThrowBadRequestException()
    {
        // Arrange
        var dto = CreateTestDto();
        var accountId = 1;

        _mockRepository
            .Setup(x => x.CodeExistsAsync(dto.DepartmentCode, accountId, null))
            .ReturnsAsync(true);

        // Act & Assert
        await Assert.ThrowsAsync<BadRequestException>(() => _service.CreateAsync(dto));
        _mockRepository.Verify(x => x.CreateAsync(It.IsAny<GrcDepartment>()), Times.Never);
    }

    #endregion

    #region UpdateAsync Tests

    [Fact]
    public async Task UpdateAsync_WithValidData_ShouldReturnUpdatedDepartment()
    {
        // Arrange
        var departmentId = 1;
        var accountId = 1;
        var dto = CreateUpdateDto();
        var existingDepartment = CreateTestDepartment(departmentId, accountId);
        var updatedDepartment = CreateTestDepartment(departmentId, accountId, "Updated Department", "updated@example.com");

        _mockRepository
            .Setup(x => x.GetByIdAsync(departmentId, accountId))
            .ReturnsAsync(existingDepartment);

        _mockRepository
            .Setup(x => x.CodeExistsAsync(dto.DepartmentCode, accountId, departmentId))
            .ReturnsAsync(false);

        _mockRepository
            .Setup(x => x.ExistsAsync(dto.DepartmentName, dto.DepartmentCode, accountId, departmentId))
            .ReturnsAsync(false);

        _mockRepository
            .Setup(x => x.EmailExistsAsync(dto.DepartmentEmail1, accountId, departmentId))
            .ReturnsAsync(false);

        _mockRepository
            .Setup(x => x.UpdateAsync(It.IsAny<GrcDepartment>()))
            .ReturnsAsync(updatedDepartment);

        // Act
        var result = await _service.UpdateAsync(departmentId, dto);

        // Assert
        result.Should().NotBeNull();
        _mockRepository.Verify(x => x.UpdateAsync(It.IsAny<GrcDepartment>()), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_WithNonExistentId_ShouldThrowNotFoundException()
    {
        // Arrange
        var departmentId = 999;
        var accountId = 1;
        var dto = CreateUpdateDto();

        _mockRepository
            .Setup(x => x.GetByIdAsync(departmentId, accountId))
            .ReturnsAsync((GrcDepartment?)null);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => _service.UpdateAsync(departmentId, dto));
        _mockRepository.Verify(x => x.UpdateAsync(It.IsAny<GrcDepartment>()), Times.Never);
    }

    [Fact]
    public async Task UpdateAsync_WithDuplicateName_ShouldThrowBadRequestException()
    {
        // Arrange
        var departmentId = 1;
        var accountId = 1;
        var dto = CreateUpdateDto();
        var existingDepartment = CreateTestDepartment(departmentId, accountId);

        _mockRepository
            .Setup(x => x.GetByIdAsync(departmentId, accountId))
            .ReturnsAsync(existingDepartment);

        _mockRepository
            .Setup(x => x.CodeExistsAsync(dto.DepartmentCode, accountId, departmentId))
            .ReturnsAsync(false);

        _mockRepository
            .Setup(x => x.ExistsAsync(dto.DepartmentName, dto.DepartmentCode, accountId, departmentId))
            .ReturnsAsync(true);

        // Act & Assert
        await Assert.ThrowsAsync<BadRequestException>(() => _service.UpdateAsync(departmentId, dto));
        _mockRepository.Verify(x => x.UpdateAsync(It.IsAny<GrcDepartment>()), Times.Never);
    }

    [Fact]
    public async Task UpdateAsync_WithDuplicateEmail_ShouldThrowBadRequestException()
    {
        // Arrange
        var departmentId = 1;
        var accountId = 1;
        var dto = CreateUpdateDto();
        var existingDepartment = CreateTestDepartment(departmentId, accountId);

        _mockRepository
            .Setup(x => x.GetByIdAsync(departmentId, accountId))
            .ReturnsAsync(existingDepartment);

        _mockRepository
            .Setup(x => x.CodeExistsAsync(dto.DepartmentCode, accountId, departmentId))
            .ReturnsAsync(false);

        _mockRepository
            .Setup(x => x.ExistsAsync(dto.DepartmentName, dto.DepartmentCode, accountId, departmentId))
            .ReturnsAsync(false);

        _mockRepository
            .Setup(x => x.EmailExistsAsync(dto.DepartmentEmail1, accountId, departmentId))
            .ReturnsAsync(true);

        // Act & Assert
        await Assert.ThrowsAsync<BadRequestException>(() => _service.UpdateAsync(departmentId, dto));
        _mockRepository.Verify(x => x.UpdateAsync(It.IsAny<GrcDepartment>()), Times.Never);
    }

    [Fact]
    public async Task UpdateAsync_WithDuplicateCode_ShouldThrowBadRequestException()
    {
        // Arrange
        var departmentId = 1;
        var accountId = 1;
        var dto = CreateUpdateDto();
        var existingDepartment = CreateTestDepartment(departmentId, accountId);

        _mockRepository
            .Setup(x => x.GetByIdAsync(departmentId, accountId))
            .ReturnsAsync(existingDepartment);

        _mockRepository
            .Setup(x => x.CodeExistsAsync(dto.DepartmentCode, accountId, departmentId))
            .ReturnsAsync(true);

        // Act & Assert
        await Assert.ThrowsAsync<BadRequestException>(() => _service.UpdateAsync(departmentId, dto));
        _mockRepository.Verify(x => x.UpdateAsync(It.IsAny<GrcDepartment>()), Times.Never);
    }

    #endregion

    #region DeleteAsync Tests

    [Fact]
    public async Task DeleteAsync_WithValidId_ShouldReturnTrue()
    {
        // Arrange
        var departmentId = 1;
        var accountId = 1;
        var existingDepartment = CreateTestDepartment(departmentId, accountId);

        _mockRepository
            .Setup(x => x.GetByIdAsync(departmentId, accountId))
            .ReturnsAsync(existingDepartment);

        _mockRepository
            .Setup(x => x.DeleteAsync(departmentId, accountId))
            .ReturnsAsync(true);

        // Act
        var result = await _service.DeleteAsync(departmentId);

        // Assert
        result.Should().BeTrue();
        _mockRepository.Verify(x => x.DeleteAsync(departmentId, accountId), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_WithNonExistentId_ShouldThrowNotFoundException()
    {
        // Arrange
        var departmentId = 999;
        var accountId = 1;

        _mockRepository
            .Setup(x => x.GetByIdAsync(departmentId, accountId))
            .ReturnsAsync((GrcDepartment?)null);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => _service.DeleteAsync(departmentId));
        _mockRepository.Verify(x => x.DeleteAsync(It.IsAny<int>(), It.IsAny<int>()), Times.Never);
    }

    #endregion
}
