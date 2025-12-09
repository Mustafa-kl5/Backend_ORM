namespace ORM.Application.Common.Localization;

/// <summary>
/// Message keys for localization
/// </summary>
public static class MessageKeys
{
    // Auth Messages
    public const string LoginSuccess = "Auth.LoginSuccess";
    public const string LogoutSuccess = "Auth.LogoutSuccess";
    public const string TokenRefreshed = "Auth.TokenRefreshed";
    public const string InvalidCredentials = "Auth.InvalidCredentials";
    public const string AccountLocked = "Auth.AccountLocked";
    public const string AccountDeactivated = "Auth.AccountDeactivated";
    public const string InvalidToken = "Auth.InvalidToken";
    public const string InvalidRefreshToken = "Auth.InvalidRefreshToken";
    public const string AuthenticationRequired = "Auth.AuthenticationRequired";
    public const string AccessDenied = "Auth.AccessDenied";

    // User Messages
    public const string UserNotFound = "User.NotFound";
    public const string UserCreated = "User.Created";
    public const string UserUpdated = "User.Updated";
    public const string UserDeleted = "User.Deleted";

    // Common Messages
    public const string OperationSuccess = "Common.OperationSuccess";
    public const string OperationFailed = "Common.OperationFailed";
    public const string NotFound = "Common.NotFound";
    public const string ValidationError = "Common.ValidationError";
    public const string InternalServerError = "Common.InternalServerError";
    public const string BadRequest = "Common.BadRequest";
    public const string Unauthorized = "Common.Unauthorized";
    public const string Forbidden = "Common.Forbidden";
    public const string Conflict = "Common.Conflict";

    // Validation Messages
    public const string RequiredField = "Validation.RequiredField";
    public const string InvalidEmail = "Validation.InvalidEmail";
    public const string InvalidFormat = "Validation.InvalidFormat";
    public const string MinLength = "Validation.MinLength";
    public const string MaxLength = "Validation.MaxLength";

    // Calendar Holiday Messages
    public const string CalendarHolidayDuplicate = "CalendarHoliday.Duplicate";
    public const string CalendarHolidayNotFound = "CalendarHoliday.NotFound";
    public const string CalendarHolidayCreated = "CalendarHoliday.Created";
    public const string CalendarHolidayUpdated = "CalendarHoliday.Updated";
    public const string CalendarHolidayDeleted = "CalendarHoliday.Deleted";

    // Department Messages
    public const string DepartmentDuplicate = "Department.Duplicate";
    public const string DepartmentCodeDuplicate = "Department.CodeDuplicate";
    public const string DepartmentEmailDuplicate = "Department.EmailDuplicate";
    public const string DepartmentNotFound = "Department.NotFound";
    public const string DepartmentCreated = "Department.Created";
    public const string DepartmentUpdated = "Department.Updated";
    public const string DepartmentDeleted = "Department.Deleted";
    public const string DepartmentHasRelatedRecords = "Department.HasRelatedRecords";
}
