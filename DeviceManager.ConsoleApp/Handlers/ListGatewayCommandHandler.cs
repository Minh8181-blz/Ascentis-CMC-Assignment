using DeviceManager.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManager.ConsoleApp.Handlers
{
    public class ListGatewayCommandHandler
    {
        private readonly IGatewayBusiness _gatewayBusiness;

        public ListGatewayCommandHandler(IGatewayBusiness gatewayBusiness)
        {
            _gatewayBusiness = gatewayBusiness;
        }

        public async Task Handle()
        {
            Console.WriteLine("Retrieving...\n");
            var gateways = await _gatewayBusiness.All();
            if (gateways != null && gateways.Any())
            {
                Console.WriteLine("{0,-10}\t{1,-20}\t{2,-20}\t{3,-20}\t{4,-20}\t{5,-20}", "Id", "Serial number", "Firmware version", "State", "IP", "Port");
                foreach (var device in gateways)
                {
                    Console.WriteLine("{0,-10}\t{1,-20}\t{2,-20}\t{3,-20}\t{4,-20}\t{5,-20}", device.Id, device.SerialNumber, device.FirmwareVersion, device.State, device.IP, device.Port);
                }
            }
            else
                Console.WriteLine("No gateways are registered");
            Console.Write("\n> ");
        }
    }
}
