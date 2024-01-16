using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics.CodeAnalysis;

namespace Custom.Components
{
    public class CustomInputSelect<Tvalue> : InputSelect<Tvalue>
    {
        protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out Tvalue result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            if(typeof(Tvalue) == typeof(int))
            {
                if(int.TryParse(value, out var resultInt))
                {
                    result = (Tvalue)(object)resultInt;
                    validationErrorMessage = null;
                    return true;
                }
                else
                {
                    result = default;
                    validationErrorMessage = $"The selected value {value} is not a valid number.";
                    return false;
                }
            }
            else
            {
                return base.TryParseValueFromString(value, out result,
                    out validationErrorMessage);
            }
        }
    }
}
