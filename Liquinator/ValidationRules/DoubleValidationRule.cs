using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Liquinator.ValidationRules {
    public class DoubleValidationRule : ValidationRule {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo) {
            double i;
            if (string.IsNullOrWhiteSpace((value ?? "").ToString())) {
                return new ValidationResult(false, "Field is required");
            } else if (!Double.TryParse((value ?? "").ToString(), out i)) {
                return new ValidationResult(false, "Is not a number.");
            } else {
                return ValidationResult.ValidResult;
            }
        }
    }
}
