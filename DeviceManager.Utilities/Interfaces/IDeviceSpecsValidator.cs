namespace DeviceManager.Utilities.Interfaces
{
    public interface IDeviceSpecsValidator
    {
        public bool IsValidIPv4Address(string address);
        public bool IsValidIPv6Address(string address);
        public bool IsValidPort(int port);
    }
}
