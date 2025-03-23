using System.ComponentModel;
using System.Reflection;
using UserApi.Enum;

namespace UserApi.Helper;

public class ErrorHelper
{
    public static string GetErrorMessage(ErrorEnum errorMessageEnum)
    {
        var fieldInfo = errorMessageEnum.GetType().GetField(errorMessageEnum.ToString());
        if (fieldInfo is null) return GetErrorMessage(ErrorEnum.Sup500UnknownError);

        var attribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>();
        return attribute is null ? GetErrorMessage(ErrorEnum.Sup500NoErrorDescription) : attribute.Description;
    }
}