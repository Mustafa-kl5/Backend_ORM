using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using ORM.Core.Interfaces.Services;

namespace ORM.Application.Services;

public class SensitiveDataMaskingService : ISensitiveDataMaskingService
{
    private readonly HashSet<string> _sensitiveKeywords;
    private const string MaskValue = "***MASKED***";

    public SensitiveDataMaskingService(IConfiguration configuration)
    {
        // Load sensitive keywords from configuration or use defaults
        var keywordsConfig = configuration.GetSection("ActivityLogging:SensitiveKeywords").GetChildren();
        var keywords = keywordsConfig.Select(x => x.Value).Where(v => !string.IsNullOrEmpty(v)).Select(v => v!).ToList();
        
        _sensitiveKeywords = keywords.Any() 
            ? new HashSet<string>(keywords, StringComparer.OrdinalIgnoreCase)
            : new HashSet<string>(GetDefaultSensitiveKeywords(), StringComparer.OrdinalIgnoreCase);
    }

    public string MaskSensitiveData(string json)
    {
        if (string.IsNullOrEmpty(json))
            return json;

        try
        {
            var jsonDoc = JsonDocument.Parse(json);
            var maskedObject = MaskJsonElement(jsonDoc.RootElement);
            return JsonSerializer.Serialize(maskedObject);
        }
        catch
        {
            // If parsing fails, return original
            return json;
        }
    }

    public bool IsSensitiveField(string fieldName)
    {
        return _sensitiveKeywords.Any(keyword => 
            fieldName.Contains(keyword, StringComparison.OrdinalIgnoreCase));
    }

    private object? MaskJsonElement(JsonElement element)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Object:
                var obj = new Dictionary<string, object?>();
                foreach (var property in element.EnumerateObject())
                {
                    if (IsSensitiveField(property.Name))
                    {
                        obj[property.Name] = MaskValue;
                    }
                    else
                    {
                        obj[property.Name] = MaskJsonElement(property.Value);
                    }
                }
                return obj;

            case JsonValueKind.Array:
                return element.EnumerateArray()
                    .Select(MaskJsonElement)
                    .ToList();

            case JsonValueKind.String:
                return element.GetString();

            case JsonValueKind.Number:
                if (element.TryGetInt64(out long longValue))
                    return longValue;
                return element.GetDouble();

            case JsonValueKind.True:
                return true;

            case JsonValueKind.False:
                return false;

            case JsonValueKind.Null:
                return null;

            default:
                return element.ToString();
        }
    }

    private static List<string> GetDefaultSensitiveKeywords()
    {
        return new List<string>
        {
            "password",
            "passwd",
            "pwd",
            "token",
            "secret",
            "key",
            "apikey",
            "api_key",
            "accesstoken",
            "access_token",
            "refreshtoken",
            "refresh_token",
            "jwt",
            "bearer",
            "authorization",
            "pin",
            "ssn",
            "social_security",
            "creditcard",
            "credit_card",
            "cardnumber",
            "card_number",
            "cvv",
            "cvc",
            "securitycode",
            "security_code",
            "privatekey",
            "private_key"
        };
    }
}
