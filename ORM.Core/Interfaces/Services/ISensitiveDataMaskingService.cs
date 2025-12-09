namespace ORM.Core.Interfaces.Services;

public interface ISensitiveDataMaskingService
{
    string MaskSensitiveData(string json);
    bool IsSensitiveField(string fieldName);
}
