using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PhotoAdder.ViewModel.Validators
{
    public class NumericValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            //throw new NotImplementedException();

            string numericRule = @"^-?\d+$";
            Regex numericRegex = new Regex(numericRule);

            if (!numericRegex.IsMatch(value.ToString()))
            {
                return new ValidationResult(false, "Please enter numeric value");
            }

            return ValidationResult.ValidResult;
        }
    }
}
