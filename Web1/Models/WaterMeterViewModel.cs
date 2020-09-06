using System.ComponentModel.DataAnnotations;

namespace DeviceManager.Web.Models
{
    public class WaterMeterViewModel
    {
        [Required(ErrorMessage = "Serial number is required")]
        public string SerialNumber { get; set; }
        public string FirmwareVersion { get; set; }
        public string State { get; set; }
    }
}
