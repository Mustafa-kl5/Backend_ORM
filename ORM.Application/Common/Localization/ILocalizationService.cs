namespace ORM.Application.Common.Localization;

/// <summary>
/// Localization service interface
/// </summary>
public interface ILocalizationService
{
    /// <summary>
    /// Get localized message by key
    /// </summary>
    string Get(string key);

    /// <summary>
    /// Get localized message by key with parameters
    /// </summary>
    string Get(string key, params object[] args);

    /// <summary>
    /// Get current language code
    /// </summary>
    string CurrentLanguage { get; }
}
