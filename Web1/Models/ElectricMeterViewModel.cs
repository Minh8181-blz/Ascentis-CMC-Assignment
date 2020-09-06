using System.ComponentModel.DataAnnotations;

namespace DeviceManager.Web.Models
{
    public class ElectricMeterViewModel
    {
        [Required(ErrorMessage = "Serial number is required")]
        public string SerialNumber { get; set; }
        public string FirmwareVersion { get; set; }
        public string State { get; set; }
    }
}
