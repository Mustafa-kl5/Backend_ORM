namespace ORM.Application.Common.Responses;

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

    public PaginationMeta(int currentPage, int pageSize, int totalCount)
    {
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalCount = totalCount;
        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        HasNext = CurrentPage < TotalPages;
        HasPrevious = CurrentPage > 1;
    }
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
    public PaginationMeta Pagination { get; set; } = null!;
    public List<string> Errors { get; set; } = new();
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public static PaginatedResponse<T> SuccessResponse(
        IEnumerable<T> data,
        int currentPage,
        int pageSize,
        int totalCount,
        string message = "Data retrieved successfully")
    {
        return new PaginatedResponse<T>
        {
            Success = true,
            StatusCode = 200,
            Message = message,
            Data = data,
            Pagination = new PaginationMeta(currentPage, pageSize, totalCount),
            Errors = new List<string>()
        };
    }

    public static PaginatedResponse<T> FailResponse(string message, int statusCode = 400, List<string>? errors = null)
    {
        return new PaginatedResponse<T>
        {
            Success = false,
            StatusCode = statusCode,
            Message = message,
            Data = new List<T>(),
            Pagination = new PaginationMeta(0, 0, 0),
            Errors = errors ?? new List<string>()
        };
    }
}

/// <summary>
/// Pagination request parameters
/// </summary>
public class PaginationRequest
{
    private int _pageNumber = 1;
    private int _pageSize = 10;
    private const int MaxPageSize = 100;

    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = value < 1 ? 1 : value;
    }

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value < 1 ? 10 : value;
    }

    public string? SortBy { get; set; }
    public bool SortDescending { get; set; } = false;
    public string? SearchTerm { get; set; }
}
