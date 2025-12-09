using ORM.Application.Common.Exceptions;
using ORM.Application.Common.Localization;
using ORM.Core.DTOs.ActivityLog;
using ORM.Core.DTOs.Department;
using ORM.Core.Interfaces.Repositories;
using ORM.Core.Interfaces.Services;
using ORM.Domain.Entities;

namespace ORM.Application.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _repository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IActivityLogService _activityLogService;
    private readonly ILocalizationService _localization;

    public DepartmentService(
        IDepartmentRepository repository,
        ICurrentUserService currentUserService,
        IActivityLogService activityLogService,
        ILocalizationService localization)
    {
        _repository = repository;
        _currentUserService = currentUserService;
        _activityLogService = activityLogService;
        _localization = localization;
    }

    public async Task<List<DepartmentDto>> GetAllAsync()
    {
        var accountId = _currentUserService.AccountId ?? throw new UnauthorizedException("Account ID not found");
        var departments = await _repository.GetAllAsync(accountId);

        return departments.Select(MapToDto).ToList();
    }

    public async Task<DepartmentDto?> GetByIdAsync(int departmentId)
    {
        var accountId = _currentUserService.AccountId ?? throw new UnauthorizedException("Account ID not found");
        var department = await _repository.GetByIdAsync(departmentId, accountId);

        return department != null ? MapToDto(department) : null;
    }

    public async Task<List<DepartmentDto>> GetByCountryAsync(int countryId)
    {
        var accountId = _currentUserService.AccountId ?? throw new UnauthorizedException("Account ID not found");
        var departments = await _repository.GetByCountryAsync(countryId, accountId);

        return departments.Select(MapToDto).ToList();
    }

    public async Task<List<DepartmentDto>> GetBySectorAsync(int sectorId)
    {
        var accountId = _currentUserService.AccountId ?? throw new UnauthorizedException("Account ID not found");
        var departments = await _repository.GetBySectorAsync(sectorId, accountId);

        return departments.Select(MapToDto).ToList();
    }

    public async Task<DepartmentDto> CreateAsync(CreateDepartmentDto dto)
    {
        var accountId = _currentUserService.AccountId ?? throw new UnauthorizedException("Account ID not found");
        var userId = _currentUserService.UserId ?? throw new UnauthorizedException("User ID not found");
        
        // Check for duplicate department code (must be unique)
        var codeExists = await _repository.CodeExistsAsync(dto.DepartmentCode, accountId);
        if (codeExists)
        {
            var errorMessage = _localization.Get(MessageKeys.DepartmentCodeDuplicate);
            
            await _activityLogService.LogActivityAsync(
                EventType.DataCreated,
                ActionType.Write,
                false,
                errorMessage,
                nameof(GrcDepartment),
                null,
                null,
                null,
                null,
                sourceSystemId: 1,
                sourceModuleId: 7);
            
            throw new BadRequestException(errorMessage);
        }

        // Check for duplicate department name with same code
        var nameAndCodeExists = await _repository.ExistsAsync(dto.DepartmentName, dto.DepartmentCode, accountId);
        if (nameAndCodeExists)
        {
            var errorMessage = _localization.Get(MessageKeys.DepartmentDuplicate);
            
            await _activityLogService.LogActivityAsync(
                EventType.DataCreated,
                ActionType.Write,
                false,
                errorMessage,
                nameof(GrcDepartment),
                null,
                null,
                null,
                null,
                sourceSystemId: 1,
                sourceModuleId: 7);
            
            throw new BadRequestException(errorMessage);
        }

        // Check for duplicate email
        var emailExists = await _repository.EmailExistsAsync(dto.DepartmentEmail1, accountId);
        if (emailExists)
        {
            var errorMessage = _localization.Get(MessageKeys.DepartmentEmailDuplicate);
            
            await _activityLogService.LogActivityAsync(
                EventType.DataCreated,
                ActionType.Write,
                false,
                errorMessage,
                nameof(GrcDepartment),
                null,
                null,
                null,
                null,
                sourceSystemId: 1,
                sourceModuleId: 7);
            
            throw new BadRequestException(errorMessage);
        }

        // Get user context to retrieve CountryId
        var userContext = await _currentUserService.GetUserContextAsync();
        var countryId = userContext?.CountryId;

        var department = new GrcDepartment
        {
            DepartmentName = dto.DepartmentName,
            DepartmentEmail1 = dto.DepartmentEmail1,
            DepartmentEmail2 = dto.DepartmentEmail2,
            DepartmentCode = dto.DepartmentCode,
            CountryId = countryId,
            SectorId = null,
            AccountId = accountId,
            CreatedBy = userId,
            CreationDate = DateTime.UtcNow
        };

        var created = await _repository.CreateAsync(department);

        // Log activity
        await _activityLogService.LogEntityCreatedAsync(
            created,
            EventType.DataCreated,
            sourceSystemId: 1,
            sourceModuleId: 7);

        return MapToDto(created);
    }

    public async Task<DepartmentDto> UpdateAsync(int departmentId, UpdateDepartmentDto dto)
    {
        var accountId = _currentUserService.AccountId ?? throw new UnauthorizedException("Account ID not found");
        var userId = _currentUserService.UserId ?? throw new UnauthorizedException("User ID not found");
        
        var department = await _repository.GetByIdAsync(departmentId, accountId);
        if (department == null)
        {
            throw new NotFoundException(_localization.Get(MessageKeys.DepartmentNotFound));
        }

        // Check for duplicate department code (must be unique, excluding current)
        var codeExists = await _repository.CodeExistsAsync(dto.DepartmentCode, accountId, departmentId);
        if (codeExists)
        {
            var errorMessage = _localization.Get(MessageKeys.DepartmentCodeDuplicate);
            
            await _activityLogService.LogActivityAsync(
                EventType.DataUpdated,
                ActionType.Write,
                false,
                errorMessage,
                nameof(GrcDepartment),
                departmentId.ToString(),
                null,
                null,
                null,
                sourceSystemId: 1,
                sourceModuleId: 7);
            
            throw new BadRequestException(errorMessage);
        }

        // Check for duplicate department name with same code (excluding current)
        var nameAndCodeExists = await _repository.ExistsAsync(dto.DepartmentName, dto.DepartmentCode, accountId, departmentId);
        if (nameAndCodeExists)
        {
            var errorMessage = _localization.Get(MessageKeys.DepartmentDuplicate);
            
            await _activityLogService.LogActivityAsync(
                EventType.DataUpdated,
                ActionType.Write,
                false,
                errorMessage,
                nameof(GrcDepartment),
                departmentId.ToString(),
                null,
                null,
                null,
                sourceSystemId: 1,
                sourceModuleId: 7);
            
            throw new BadRequestException(errorMessage);
        }

        // Check for duplicate email (excluding current)
        var emailExists = await _repository.EmailExistsAsync(dto.DepartmentEmail1, accountId, departmentId);
        if (emailExists)
        {
            var errorMessage = _localization.Get(MessageKeys.DepartmentEmailDuplicate);
            
            await _activityLogService.LogActivityAsync(
                EventType.DataUpdated,
                ActionType.Write,
                false,
                errorMessage,
                nameof(GrcDepartment),
                departmentId.ToString(),
                null,
                null,
                null,
                sourceSystemId: 1,
                sourceModuleId: 7);
            
            throw new BadRequestException(errorMessage);
        }

        // Get user context to retrieve CountryId
        var userContext = await _currentUserService.GetUserContextAsync();
        var countryId = userContext?.CountryId;

        // Store old values for logging
        var oldDepartment = new GrcDepartment
        {
            DepartmentId = department.DepartmentId,
            DepartmentName = department.DepartmentName,
            DepartmentEmail1 = department.DepartmentEmail1,
            DepartmentEmail2 = department.DepartmentEmail2,
            DepartmentCode = department.DepartmentCode,
            CountryId = department.CountryId,
            SectorId = department.SectorId
        };

        // Update properties
        department.DepartmentName = dto.DepartmentName;
        department.DepartmentEmail1 = dto.DepartmentEmail1;
        department.DepartmentEmail2 = dto.DepartmentEmail2;
        department.DepartmentCode = dto.DepartmentCode;
        department.CountryId = countryId;
        department.SectorId = null;
        department.LastUpdatedBy = userId;
        department.LastUpdateDate = DateTime.UtcNow;

        var updated = await _repository.UpdateAsync(department);

        // Log activity
        await _activityLogService.LogEntityUpdatedAsync(
            oldDepartment,
            updated,
            EventType.DataUpdated,
            sourceSystemId: 1,
            sourceModuleId: 7);

        return MapToDto(updated);
    }

    public async Task<bool> DeleteAsync(int departmentId)
    {
        var accountId = _currentUserService.AccountId ?? throw new UnauthorizedException("Account ID not found");
        
        var department = await _repository.GetByIdAsync(departmentId, accountId);
        if (department == null)
        {
            throw new NotFoundException(_localization.Get(MessageKeys.DepartmentNotFound));
        }

        try
        {
            var deleted = await _repository.DeleteAsync(departmentId, accountId);

            if (deleted)
            {
                // Log activity
                await _activityLogService.LogEntityDeletedAsync(
                    department,
                    EventType.DataDeleted,
                    sourceSystemId: 1,
                    sourceModuleId: 7);
            }

            return deleted;
        }
        catch (Exception ex)
        {
            // Check if it's a foreign key constraint violation
            var errorMessage = ex.InnerException?.Message ?? ex.Message;
            if (errorMessage.Contains("REFERENCE constraint", StringComparison.OrdinalIgnoreCase) ||
                errorMessage.Contains("FK_", StringComparison.OrdinalIgnoreCase) ||
                errorMessage.Contains("foreign key", StringComparison.OrdinalIgnoreCase))
            {
                throw new ApiException(
                    _localization.Get(MessageKeys.DepartmentHasRelatedRecords),
                    400);
            }
            
            // Re-throw if it's not a foreign key constraint issue
            throw;
        }
    }

    private static DepartmentDto MapToDto(GrcDepartment department)
    {
        return new DepartmentDto
        {
            DepartmentId = department.DepartmentId,
            DepartmentName = department.DepartmentName,
            DepartmentEmail1 = department.DepartmentEmail1,
            DepartmentEmail2 = department.DepartmentEmail2,
            DepartmentCode = department.DepartmentCode,
            CountryId = department.CountryId,
            CountryName = department.Country?.CountryName,
            SectorId = department.SectorId,
            SectorName = department.Sector?.Description,
            AccountId = department.AccountId,
            CreatedBy = department.CreatedBy,
            CreationDate = department.CreationDate,
            LastUpdatedBy = department.LastUpdatedBy,
            LastUpdateDate = department.LastUpdateDate
        };
    }
}
