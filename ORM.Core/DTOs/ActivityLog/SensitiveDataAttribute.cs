namespace ORM.Core.DTOs.ActivityLog;

/// <summary>
/// Marks a property as containing sensitive data that should be masked in activity logs
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class SensitiveDataAttribute : Attribute
{
}
