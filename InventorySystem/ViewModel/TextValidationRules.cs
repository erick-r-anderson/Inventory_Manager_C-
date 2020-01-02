using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace InventorySystem
{
    public class TextValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            // ensures tex is not empty
            string strValue = Convert.ToString(value);
            bool canValidate = false;

            if (string.IsNullOrEmpty(strValue))
            {
                
                return new ValidationResult(false, $"Please enter a name");
            }
            
            foreach (char c in strValue)
                {
                    if (char.IsLetter(c))
                    {
                        
                        canValidate = true;
                    }
                }
            return canValidate ? new ValidationResult(true, null) : new ValidationResult(false, $"Name must contain letters");

        }

    }
}

    
