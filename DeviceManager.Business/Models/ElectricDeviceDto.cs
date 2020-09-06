namespace DeviceManager.Business.Models
{
    public class ElectricDeviceDto
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string FirmwareVersion { get; set; }
        public string State { get; set; }
    }
}
