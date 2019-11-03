using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Api.Validators
{
    public class CountryCodeValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var inputValue = value as string;
            var r = new Regex("^[a-zA-Z]{2,3}$");

            return !string.IsNullOrEmpty(inputValue) && r.IsMatch(inputValue);
        }
    }
}