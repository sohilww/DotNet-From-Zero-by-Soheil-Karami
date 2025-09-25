using System.ComponentModel.DataAnnotations;
using Framework.Core;

namespace CilinicAppointmentSystem.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class NationalityCodeValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null)
            return false;

        if (value is not string)
            return false;
        return NationalityCodeValidator.IsValid(value as string);
    }
}