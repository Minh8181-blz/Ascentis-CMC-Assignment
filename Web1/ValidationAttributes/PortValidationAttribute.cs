using DeviceManager.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.Web.ValidationAttributes
{
    public class PortValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int? port = value as int?;
            if (!port.HasValue)
                return ValidationResult.Success;

            var service = (IDeviceSpecsValidator)validationContext
                         .GetService(typeof(IDeviceSpecsValidator));

            if (service.IsValidPort(port.Value))
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage);
        }
    }
}
