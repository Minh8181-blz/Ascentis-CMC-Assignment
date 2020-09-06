using DeviceManager.Business.Interfaces;
using DeviceManager.Business.Models;
using DeviceManager.Utilities.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DeviceManager.ConsoleApp.Handlers
{
    public class RegisterGatewayCommandHandler
    {
        private readonly IGatewayBusiness _gatewayBusiness;
        private readonly IDeviceSpecsValidator _deviceSpecsValidator;
        private readonly ILogger<RegisterGatewayCommandHandler> _logger;

        public RegisterGatewayCommandHandler(
            IGatewayBusiness gatewayBusiness,
            IDeviceSpecsValidator deviceSpecsValidator,
            ILogger<RegisterGatewayCommandHandler> logger
        )
        {
            _gatewayBusiness = gatewayBusiness;
            _deviceSpecsValidator = deviceSpecsValidator;
            _logger = logger;
        }

        public async Task Handle()
        {
            try
            {
                var gatewayDto = GetInputModel();
                var result = await _gatewayBusiness.Add(gatewayDto);
                if (result.Success)
                {
                    Console.WriteLine("{0}\n", result.Message);
                    Console.WriteLine("\tId: {0}\n\tSerial number: {1}", result.Data.Id, result.Data.SerialNumber);
                    Console.WriteLine("\tFirmware Version: {0}\n\tState: {1}", result.Data.FirmwareVersion, result.Data.State);
                    Console.WriteLine("\tIP: {0}\n\tPort: {1}", result.Data.IP, result.Data.Port);
                }
                else
                    Console.WriteLine("Error: {0}", result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            Console.Write("\n> ");
        }

        private GatewayDto GetInputModel()
        {
            GatewayDto gatewayDto = new GatewayDto();
            Console.Write("\nSerial number: ");

            gatewayDto.SerialNumber = Console.ReadLine();
            while (string.IsNullOrEmpty(gatewayDto.SerialNumber))
            {
                Console.WriteLine("\nSerial number must not be empty");
                Console.Write("\nSerial number: ");
                gatewayDto.SerialNumber = Console.ReadLine();
            }

            Console.Write("\nFirmware version: ");
            gatewayDto.FirmwareVersion = Console.ReadLine();
            if (string.IsNullOrEmpty(gatewayDto.FirmwareVersion))
                gatewayDto.FirmwareVersion = null;

            Console.Write("\nState: ");
            gatewayDto.State = Console.ReadLine();
            if (string.IsNullOrEmpty(gatewayDto.State))
                gatewayDto.State = null;

            Console.Write("\nIP: ");
            gatewayDto.IP = Console.ReadLine();
            if (string.IsNullOrEmpty(gatewayDto.IP))
                gatewayDto.IP = null;

            if (gatewayDto.IP != null)
            {
                while (!_deviceSpecsValidator.IsValidIPv4Address(gatewayDto.IP) && !_deviceSpecsValidator.IsValidIPv6Address(gatewayDto.IP))
                {
                    Console.WriteLine("\nInvalid IP address");
                    Console.Write("\nIP: ");
                    gatewayDto.IP = Console.ReadLine();
                }
            }

            Console.Write("\nPort: ");
            string portInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(portInput))
            {
                bool validPort = int.TryParse(portInput, out int port) && _deviceSpecsValidator.IsValidPort(port);
                while (!validPort)
                {
                    Console.WriteLine("\nInvalid port number");
                    Console.Write("\nPort: ");
                    portInput = Console.ReadLine();
                    validPort = int.TryParse(portInput, out port) && _deviceSpecsValidator.IsValidPort(port);
                }

                gatewayDto.Port = port;
            }
            Console.WriteLine("Registering...\n");

            return gatewayDto;
        }
    }
}
