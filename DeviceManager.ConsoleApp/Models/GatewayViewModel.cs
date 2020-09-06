namespace DeviceManager.ConsoleApp.Models
{
    public class GatewayViewModel
    {
        public string SerialNumber { get; set; }
        public string FirmwareVersion { get; set; }
        public string State { get; set; }
        public string IP { get; set; }
        public int? Port { get; set; }
    }
}
