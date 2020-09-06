using DeviceManager.Utilities.Interfaces;
using System.Net;
using System.Net.Sockets;

namespace DeviceManager.Utilities.Implementations
{
    public class DeviceSpecsValidator : IDeviceSpecsValidator
    {
        public bool IsValidIPv4Address(string address)
        {
            if (IPAddress.TryParse(address, out IPAddress ip))
            {
                if (ip.AddressFamily != AddressFamily.InterNetwork)
                    return false;

                if (address.Length <= 6 || !address.Contains("."))
                    return false;

                string[] s = address.Split('.');
                if (s.Length == 4 && s[0].Length > 0 && s[1].Length > 0 && s[2].Length > 0 && s[3].Length > 0)
                    return true;
            }

            return false;
        }

        public bool IsValidIPv6Address(string address)
        {
            if (IPAddress.TryParse(address, out IPAddress ip))
            {
                if (ip.AddressFamily != AddressFamily.InterNetworkV6)
                    return false;

                if (address.Contains(":") && address.Length > 15)
                    return true;
            }

            return false;
        }

        public bool IsValidPort(int port)
        {
            return port > 0;
        }
    }
}
