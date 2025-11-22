using Backend_ORM.Infrastructure.Entities;

namespace Backend_ORM.Core.Interfaces.Repositories;

/// <summary>
/// Repository interface for SubProcess (OrmProcessSubject) operations
/// </summary>
public interface ISubProcessRepository
{
    Task<(List<OrmProcessSubject> subProcesses, int totalCount)> GetSubProcessesAsync(
        int accountId,
        int? processId,
        int pageNumber,
        int pageSize,
        string sortBy,
        string sortDir);

    Task<OrmProcessSubject?> GetSubProcessByIdAsync(int accountId, int id);

    Task<bool> SubProcessExistsAsync(int accountId, int processId, string description, int? excludeId = null);

    Task<int> CreateSubProcessAsync(OrmProcessSubject subProcess);

    Task<bool> UpdateSubProcessAsync(OrmProcessSubject subProcess);

    Task<bool> DeleteSubProcessAsync(int accountId, int id);

    Task<bool> HasProcessDetailsAsync(int accountId, int subjectId);
}
