using DeviceManager.Business.Interfaces;
using DeviceManager.Business.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManager.ConsoleApp.Handlers
{
    public class RegisterWaterMeterCommandHandler
    {
        private readonly IWaterMeterBusiness _waterMeterBusiness;
        private readonly ILogger<RegisterWaterMeterCommandHandler> _logger;

        public RegisterWaterMeterCommandHandler(
            IWaterMeterBusiness waterMeterBusiness,
            ILogger<RegisterWaterMeterCommandHandler> logger
        )
        {
            _waterMeterBusiness = waterMeterBusiness;
            _logger = logger;
        }

        public async Task Handle()
        {
            try
            {
                var waterMeterDto = GetInputModel();
                var result = await _waterMeterBusiness.Add(waterMeterDto);
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

        private WaterMeterDto GetInputModel()
        {
            WaterMeterDto waterMeterDto = new WaterMeterDto();
            Console.Write("\nSerial number: ");

            waterMeterDto.SerialNumber = Console.ReadLine();
            while (string.IsNullOrEmpty(waterMeterDto.SerialNumber))
            {
                Console.WriteLine("\nSerial number must not be empty");
                Console.Write("\nSerial number: ");
                waterMeterDto.SerialNumber = Console.ReadLine();
            }

            Console.Write("\nFirmware version: ");
            waterMeterDto.FirmwareVersion = Console.ReadLine();
            if (string.IsNullOrEmpty(waterMeterDto.FirmwareVersion))
                waterMeterDto.FirmwareVersion = null;

            Console.Write("\nState: ");
            waterMeterDto.State = Console.ReadLine();
            if (string.IsNullOrEmpty(waterMeterDto.State))
                waterMeterDto.State = null;

            Console.WriteLine("Registering...\n");

            return waterMeterDto;
        }
    }
}
