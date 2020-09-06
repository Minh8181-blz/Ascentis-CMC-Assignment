using DeviceManager.Business.Interfaces;
using DeviceManager.Business.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DeviceManager.ConsoleApp.Handlers
{
    public class RegisterElectricMeterCommandHandler
    {
        private readonly IElectricMeterBusiness _electricMeterBusiness;
        private readonly ILogger<RegisterElectricMeterCommandHandler> _logger;

        public RegisterElectricMeterCommandHandler(
            IElectricMeterBusiness electricMeterBusiness,
            ILogger<RegisterElectricMeterCommandHandler> logger
        )
        {
            _electricMeterBusiness = electricMeterBusiness;
            _logger = logger;
        }

        public async Task Handle()
        {
            try
            {
                var electricMeterDto = GetInputModel();
                var result = await _electricMeterBusiness.Add(electricMeterDto);
                if (result.Success)
                {
                    Console.WriteLine("{0}\n", result.Message);
                    Console.WriteLine("\tId: {0}\n\tSerial number: {1}", result.Data.Id, result.Data.SerialNumber);
                    Console.WriteLine("\tFirmware Version: {0}\n\tState: {1}", result.Data.FirmwareVersion, result.Data.State);
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

        private ElectricMeterDto GetInputModel()
        {
            ElectricMeterDto electricMeterDto = new ElectricMeterDto();
            Console.Write("\nSerial number: ");

            electricMeterDto.SerialNumber = Console.ReadLine();
            while (string.IsNullOrEmpty(electricMeterDto.SerialNumber))
            {
                Console.WriteLine("\nSerial number must not be empty");
                Console.Write("\nSerial number: ");
                electricMeterDto.SerialNumber = Console.ReadLine();
            }

            Console.Write("\nFirmware version: ");
            electricMeterDto.FirmwareVersion = Console.ReadLine();
            if (string.IsNullOrEmpty(electricMeterDto.FirmwareVersion))
                electricMeterDto.FirmwareVersion = null;

            Console.Write("\nState: ");
            electricMeterDto.State = Console.ReadLine();
            if (string.IsNullOrEmpty(electricMeterDto.State))
                electricMeterDto.State = null;

            Console.WriteLine("Registering...\n");

            return electricMeterDto;
        }
    }
}
