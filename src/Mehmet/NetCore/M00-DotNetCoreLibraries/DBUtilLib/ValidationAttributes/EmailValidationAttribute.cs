using System.ComponentModel.DataAnnotations;
using static CSD.Util.RegexUtilities;


namespace CSD.ValidationAttributes
{
    class EmailValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value) => IsValidEmail(value.ToString());
    }
}
