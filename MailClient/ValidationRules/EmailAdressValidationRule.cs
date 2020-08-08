using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace MailClient.ValidationRules
{
    class EmailAdressValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
           
            
            if (!(value is string address)) return new ValidationResult(false, "Некорректные данные");
            if (string.IsNullOrEmpty(address)) return ValidationResult.ValidResult;
            if (!Regex.IsMatch(address, @"[a-zA-Z]\w*@\w+\.\w+"))
                return new ValidationResult(false, "Введен некорректный адресс");
            return ValidationResult.ValidResult;
        }
    }
}
