using DeviceManager.Utilities.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DeviceManager.Web.ValidationAttributes
{
    public class IpAddressValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string ip = value as string;
            if (ip == null)
                return ValidationResult.Success;

            var service = (IDeviceSpecsValidator)validationContext
                         .GetService(typeof(IDeviceSpecsValidator));
            
            if (service.IsValidIPv4Address(ip) || service.IsValidIPv6Address(ip))
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage);
        }
    }
}
