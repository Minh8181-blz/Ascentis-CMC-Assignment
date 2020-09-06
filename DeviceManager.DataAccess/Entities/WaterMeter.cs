namespace DeviceManager.DataAccess.Entities
{
    public class WaterMeter
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string FirmwareVersion { get; set; }
        public string State { get; set; }
    }
}
