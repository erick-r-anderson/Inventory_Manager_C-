using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace InventorySystem
{
    class IntValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            // ensures number is not empty
            string strValue = Convert.ToString(value);
            bool canValidate = true;

            if (value == null)
            {
              
                return new ValidationResult(false, $"Please enter a number");
            }

            foreach (char c in strValue)
            {
                if (!char.IsDigit(c))
                {
                    canValidate = false;
                    
                }
            }
            if (canValidate)
            {
                
                return new ValidationResult(true, null);
            }
            else
            {
                
                return new ValidationResult(false, $"please enter only numbers");
            }
        }
    }
}



