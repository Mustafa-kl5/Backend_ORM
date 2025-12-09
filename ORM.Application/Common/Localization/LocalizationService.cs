using Microsoft.AspNetCore.Http;

namespace ORM.Application.Common.Localization;

/// <summary>
/// Localization service implementation supporting English and Arabic
/// </summary>
public class LocalizationService : ILocalizationService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly Dictionary<string, Dictionary<string, string>> _messages;

    public LocalizationService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        _messages = InitializeMessages();
    }

    public string CurrentLanguage
    {
        get
        {
            var acceptLanguage = _httpContextAccessor.HttpContext?.Request.Headers["Accept-Language"].ToString();

            if (string.IsNullOrEmpty(acceptLanguage))
                return "en";

            // Check if Arabic is requested
            if (acceptLanguage.Contains("ar", StringComparison.OrdinalIgnoreCase))
                return "ar";

            return "en";
        }
    }

    public string Get(string key)
    {
        var lang = CurrentLanguage;

        if (_messages.TryGetValue(lang, out var langMessages))
        {
            if (langMessages.TryGetValue(key, out var message))
                return message;
        }

        // Fallback to English
        if (_messages.TryGetValue("en", out var enMessages))
        {
            if (enMessages.TryGetValue(key, out var message))
                return message;
        }

        return key; // Return key if no translation found
    }

    public string Get(string key, params object[] args)
    {
        var message = Get(key);
        try
        {
            return string.Format(message, args);
        }
        catch
        {
            return message;
        }
    }

    private Dictionary<string, Dictionary<string, string>> InitializeMessages()
    {
        return new Dictionary<string, Dictionary<string, string>>
        {
            ["en"] = new Dictionary<string, string>
            {
                // Auth Messages
                [MessageKeys.LoginSuccess] = "Login successful",
                [MessageKeys.LogoutSuccess] = "Logged out successfully",
                [MessageKeys.TokenRefreshed] = "Token refreshed successfully",
                [MessageKeys.InvalidCredentials] = "Invalid username or password",
                [MessageKeys.AccountLocked] = "Your account has been locked. Please contact administrator.",
                [MessageKeys.AccountDeactivated] = "Your account has been deactivated. Please contact administrator.",
                [MessageKeys.InvalidToken] = "Invalid or expired token",
                [MessageKeys.InvalidRefreshToken] = "Invalid refresh token",
                [MessageKeys.AuthenticationRequired] = "Authentication required. Please provide a valid token.",
                [MessageKeys.AccessDenied] = "You do not have permission to access this resource.",

                // User Messages
                [MessageKeys.UserNotFound] = "User not found",
                [MessageKeys.UserCreated] = "User created successfully",
                [MessageKeys.UserUpdated] = "User updated successfully",
                [MessageKeys.UserDeleted] = "User deleted successfully",

                // Common Messages
                [MessageKeys.OperationSuccess] = "Operation completed successfully",
                [MessageKeys.OperationFailed] = "Operation failed",
                [MessageKeys.NotFound] = "Resource not found",
                [MessageKeys.ValidationError] = "Validation error occurred",
                [MessageKeys.InternalServerError] = "An internal server error occurred. Please try again later.",
                [MessageKeys.BadRequest] = "Bad request. Please check your input.",
                [MessageKeys.Unauthorized] = "Unauthorized access",
                [MessageKeys.Forbidden] = "Access forbidden",
                [MessageKeys.Conflict] = "Resource conflict occurred",

                // Validation Messages
                [MessageKeys.RequiredField] = "The field '{0}' is required",
                [MessageKeys.InvalidEmail] = "Invalid email format",
                [MessageKeys.InvalidFormat] = "Invalid format for field '{0}'",
                [MessageKeys.MinLength] = "The field '{0}' must be at least {1} characters",
                [MessageKeys.MaxLength] = "The field '{0}' must not exceed {1} characters",

                // Calendar Holiday Messages
                [MessageKeys.CalendarHolidayDuplicate] = "A holiday with the same description and overlapping dates already exists",
                [MessageKeys.CalendarHolidayNotFound] = "Calendar holiday not found",
                [MessageKeys.CalendarHolidayCreated] = "Calendar holiday created successfully",
                [MessageKeys.CalendarHolidayUpdated] = "Calendar holiday updated successfully",
                [MessageKeys.CalendarHolidayDeleted] = "Calendar holiday deleted successfully",

                // Department Messages
                [MessageKeys.DepartmentDuplicate] = "A department with the same name already exists",
                [MessageKeys.DepartmentCodeDuplicate] = "Department code already exists",
                [MessageKeys.DepartmentEmailDuplicate] = "The email address is already assigned to another department",
                [MessageKeys.DepartmentNotFound] = "Department not found",
                [MessageKeys.DepartmentCreated] = "Department created successfully",
                [MessageKeys.DepartmentUpdated] = "Department updated successfully",
                [MessageKeys.DepartmentDeleted] = "Department deleted successfully",
                [MessageKeys.DepartmentHasRelatedRecords] = "Cannot delete department because it is linked to other resources (branches, divisions, employees, etc.). Please remove or reassign these related records first."
            },

            ["ar"] = new Dictionary<string, string>
            {
                // Auth Messages
                [MessageKeys.LoginSuccess] = "تم تسجيل الدخول بنجاح",
                [MessageKeys.LogoutSuccess] = "تم تسجيل الخروج بنجاح",
                [MessageKeys.TokenRefreshed] = "تم تحديث الرمز بنجاح",
                [MessageKeys.InvalidCredentials] = "اسم المستخدم أو كلمة المرور غير صحيحة",
                [MessageKeys.AccountLocked] = "تم قفل حسابك. يرجى التواصل مع المسؤول.",
                [MessageKeys.AccountDeactivated] = "تم تعطيل حسابك. يرجى التواصل مع المسؤول.",
                [MessageKeys.InvalidToken] = "رمز غير صالح أو منتهي الصلاحية",
                [MessageKeys.InvalidRefreshToken] = "رمز التحديث غير صالح",
                [MessageKeys.AuthenticationRequired] = "المصادقة مطلوبة. يرجى تقديم رمز صالح.",
                [MessageKeys.AccessDenied] = "ليس لديك صلاحية للوصول إلى هذا المورد.",

                // User Messages
                [MessageKeys.UserNotFound] = "المستخدم غير موجود",
                [MessageKeys.UserCreated] = "تم إنشاء المستخدم بنجاح",
                [MessageKeys.UserUpdated] = "تم تحديث المستخدم بنجاح",
                [MessageKeys.UserDeleted] = "تم حذف المستخدم بنجاح",

                // Common Messages
                [MessageKeys.OperationSuccess] = "تمت العملية بنجاح",
                [MessageKeys.OperationFailed] = "فشلت العملية",
                [MessageKeys.NotFound] = "المورد غير موجود",
                [MessageKeys.ValidationError] = "حدث خطأ في التحقق",
                [MessageKeys.InternalServerError] = "حدث خطأ داخلي في الخادم. يرجى المحاولة مرة أخرى لاحقاً.",
                [MessageKeys.BadRequest] = "طلب غير صالح. يرجى التحقق من المدخلات.",
                [MessageKeys.Unauthorized] = "وصول غير مصرح به",
                [MessageKeys.Forbidden] = "الوصول محظور",
                [MessageKeys.Conflict] = "حدث تعارض في الموارد",

                // Validation Messages
                [MessageKeys.RequiredField] = "الحقل '{0}' مطلوب",
                [MessageKeys.InvalidEmail] = "صيغة البريد الإلكتروني غير صالحة",
                [MessageKeys.InvalidFormat] = "صيغة غير صالحة للحقل '{0}'",
                [MessageKeys.MinLength] = "يجب أن يكون الحقل '{0}' على الأقل {1} حرفاً",
                [MessageKeys.MaxLength] = "يجب ألا يتجاوز الحقل '{0}' {1} حرفاً",

                // Calendar Holiday Messages
                [MessageKeys.CalendarHolidayDuplicate] = "توجد إجازة بنفس الوصف وتواريخ متداخلة بالفعل",
                [MessageKeys.CalendarHolidayNotFound] = "إجازة التقويم غير موجودة",
                [MessageKeys.CalendarHolidayCreated] = "تم إنشاء إجازة التقويم بنجاح",
                [MessageKeys.CalendarHolidayUpdated] = "تم تحديث إجازة التقويم بنجاح",
                [MessageKeys.CalendarHolidayDeleted] = "تم حذف إجازة التقويم بنجاح",

                // Department Messages
                [MessageKeys.DepartmentDuplicate] = "يوجد قسم بنفس الاسم بالفعل",
                [MessageKeys.DepartmentCodeDuplicate] = "رمز القسم موجود بالفعل",
                [MessageKeys.DepartmentEmailDuplicate] = "عنوان البريد الإلكتروني مستخدم بالفعل من قبل قسم آخر",
                [MessageKeys.DepartmentNotFound] = "القسم غير موجود",
                [MessageKeys.DepartmentCreated] = "تم إنشاء القسم بنجاح",
                [MessageKeys.DepartmentUpdated] = "تم تحديث القسم بنجاح",
                [MessageKeys.DepartmentDeleted] = "تم حذف القسم بنجاح",
                [MessageKeys.DepartmentHasRelatedRecords] = "لا يمكن حذف القسم لأنه مرتبط بموارد أخرى (فروع، أقسام فرعية، موظفين، إلخ). يرجى إزالة أو إعادة تعيين هذه السجلات المرتبطة أولاً."
            }
        };
    }
}
