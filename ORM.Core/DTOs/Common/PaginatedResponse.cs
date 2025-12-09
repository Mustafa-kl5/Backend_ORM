namespace ORM.Core.DTOs.Common;

/// <summary>
/// Pagination metadata
/// </summary>
public class PaginationMeta
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
    public bool HasNext { get; set; }
    public bool HasPrevious { get; set; }
}

/// <summary>
/// Paginated API response for list endpoints
/// </summary>
/// <typeparam name="T">Type of items in the list</typeparam>
public class PaginatedResponse<T>
{
    public bool Success { get; set; }
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
    public IEnumerable<T> Data { get; set; } = new List<T>();
    public PaginationMeta? Pagination { get; set; }
    public List<string> Errors { get; set; } = new();
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
