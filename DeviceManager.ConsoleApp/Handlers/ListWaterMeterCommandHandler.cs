using DeviceManager.Business.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.ConsoleApp.Handlers
{
    public class ListWaterMeterCommandHandler
    {
        private readonly IWaterMeterBusiness _waterMeterBusiness;

        public ListWaterMeterCommandHandler(IWaterMeterBusiness waterMeterBusiness)
        {
            _waterMeterBusiness = waterMeterBusiness;
        }

        public async Task Handle()
        {
            Console.WriteLine("Retrieving...\n");
            var waterMeters = await _waterMeterBusiness.All();
            if (waterMeters != null && waterMeters.Any())
            {
                Console.WriteLine("{0,-10}\t{1,-20}\t{2,-20}\t{3,-20}", "Id", "Serial number", "Firmware version", "State");
                foreach (var device in waterMeters)
                {
                    Console.WriteLine("{0,-10}\t{1,-20}\t{2,-20}\t{3,-20}", device.Id, device.SerialNumber, device.FirmwareVersion, device.State);
                }
            }
            else
                Console.WriteLine("No water meters are registered");
            Console.Write("\n> ");
        }
    }
}
