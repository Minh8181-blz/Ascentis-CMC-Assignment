using DeviceManager.Business.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.ConsoleApp.Handlers
{
    public class ListElectricMetersCommandHandler
    {
        private readonly IElectricMeterBusiness _electricMeterBusiness;

        public ListElectricMetersCommandHandler(IElectricMeterBusiness electricMeterBusiness)
        {
            _electricMeterBusiness = electricMeterBusiness;
        }

        public async Task Handle()
        {
            Console.WriteLine("Retrieving...\n");
            var electricMeters = await _electricMeterBusiness.All();
            if (electricMeters != null && electricMeters.Any())
            {
                Console.WriteLine("{0,-10}\t{1,-20}\t{2,-20}\t{3,-20}", "Id", "Serial number", "Firmware version", "State");
                foreach (var device in electricMeters)
                {
                    Console.WriteLine("{0,-10}\t{1,-20}\t{2,-20}\t{3,-20}", device.Id, device.SerialNumber, device.FirmwareVersion, device.State);
                }
            }
            else
                Console.WriteLine("No electric meters are registered");
            Console.Write("\n> ");
        }
    }
}
