using DeviceManager.Web.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.Web.Models
{
    public class GatewayViewModel
    {
        [Required(ErrorMessage = "Serial number is required")]
        public string SerialNumber { get; set; }
        public string FirmwareVersion { get; set; }
        public string State { get; set; }
        [IpAddressValidation(ErrorMessage = "Please fill a valid IP address")]
        public string IP { get; set; }
        [PortValidation(ErrorMessage = "Please fill a valid port number")]
        public int? Port { get; set; }
    }
}
