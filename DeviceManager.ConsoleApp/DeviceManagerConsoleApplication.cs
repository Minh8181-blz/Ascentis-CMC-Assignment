using DeviceManager.ConsoleApp.Models;
using DeviceManager.ConsoleApp.Handlers;
using System;
using System.Threading.Tasks;

namespace DeviceManager.ConsoleApp
{
    public class DeviceManagerConsoleApplication
    {
        private readonly ListElectricMetersCommandHandler _listElectricMetersCommandHandler;
        private readonly ListWaterMeterCommandHandler _listWaterMeterCommandHandler;
        private readonly ListGatewayCommandHandler _listGatewayCommandHandler;
        private readonly RegisterElectricMeterCommandHandler _registerElectricMeterCommandHandler;
        private readonly RegisterWaterMeterCommandHandler _registerWaterMeterCommandHandler;
        private readonly RegisterGatewayCommandHandler _registerGatewayProcessor;
        private readonly HelpCommandHandler _helpCommandHandler;
        private readonly UnknownCommandHandler _unknownCommandHandler;

        private readonly ApplicationState ApplicationState;

        public DeviceManagerConsoleApplication(
            ListElectricMetersCommandHandler listElectricMetersCommandHandler,
            ListWaterMeterCommandHandler listWaterMeterCommandHandler,
            ListGatewayCommandHandler listGatewayCommandHandler,
            RegisterGatewayCommandHandler registerGatewayProcessor,
            RegisterElectricMeterCommandHandler registerElectricMeterCommandHandler,
            RegisterWaterMeterCommandHandler registerWaterMeterCommandHandler,
            HelpCommandHandler helpCommandHandler,
            UnknownCommandHandler unknownCommandHandler
        )
        {
            _listElectricMetersCommandHandler = listElectricMetersCommandHandler;
            _listWaterMeterCommandHandler = listWaterMeterCommandHandler;
            _listGatewayCommandHandler = listGatewayCommandHandler;
            _registerGatewayProcessor = registerGatewayProcessor;
            _registerElectricMeterCommandHandler = registerElectricMeterCommandHandler;
            _registerWaterMeterCommandHandler = registerWaterMeterCommandHandler;
            _helpCommandHandler = helpCommandHandler;
            _unknownCommandHandler = unknownCommandHandler;

            ApplicationState = new ApplicationState();
        }

        public async Task Run()
        {
            PrintHeadlines();

            string commandstr;
            do
            {
                commandstr = Console.ReadLine().Trim();
                if (commandstr == ApplicationCommandList.Help.Syntax)
                    _helpCommandHandler.Handle();
                else if (commandstr == ApplicationCommandList.ListElectricMeters.Syntax)
                    await _listElectricMetersCommandHandler.Handle();
                else if (commandstr == ApplicationCommandList.ListWaterMeters.Syntax)
                    await _listWaterMeterCommandHandler.Handle();
                else if (commandstr == ApplicationCommandList.ListGateways.Syntax)
                    await _listGatewayCommandHandler.Handle();
                else if (commandstr == ApplicationCommandList.CreateElectricMeter.Syntax)
                    await _registerElectricMeterCommandHandler.Handle();
                else if (commandstr == ApplicationCommandList.CreateWaterMeter.Syntax)
                    await _registerWaterMeterCommandHandler.Handle();
                else if (commandstr == ApplicationCommandList.CreateGateway.Syntax)
                    await _registerGatewayProcessor.Handle();
                else if (commandstr == ApplicationCommandList.Exit.Syntax)
                    ApplicationState.StopApplication();
                else
                    _unknownCommandHandler.Handle();
            }
            while (ApplicationState.Running);
        }

        private void PrintHeadlines()
        {
            Console.WriteLine("--- DEVICE MANAGER ---\n");
            Console.WriteLine("Type 'help' to view the command list");
            Console.Write("\n> ");
        }
    }
}
