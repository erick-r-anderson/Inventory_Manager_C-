using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace InventorySystem
{
    public class DoubleValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            // ensures number is not empty
            string strValue = Convert.ToString(value);
            decimal price;

            if (value == null)
            {
                return new ValidationResult(false, $"Please enter a valid price");

            }
            else if (Decimal.TryParse(strValue, NumberStyles.Currency, CultureInfo.CurrentCulture, out price))
            {
                
                return new ValidationResult(true, null);

            }
            else
            {
                
                return new ValidationResult(false, $"please enter a valid price");
            }
        }
    }
}
