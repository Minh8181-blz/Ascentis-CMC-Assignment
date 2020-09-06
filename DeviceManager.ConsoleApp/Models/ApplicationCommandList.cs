using System.Collections.Generic;

namespace DeviceManager.ConsoleApp.Models
{
    public static class ApplicationCommandList
    {
        public static readonly ApplicationCommand ListElectricMeters = new ApplicationCommand(1, "list 1", "List all electric meters");
        public static readonly ApplicationCommand ListWaterMeters = new ApplicationCommand(2, "list 2", "List all water meters");
        public static readonly ApplicationCommand ListGateways = new ApplicationCommand(3, "list 3", "List all gateways");
        public static readonly ApplicationCommand CreateElectricMeter = new ApplicationCommand(4, "create 1", "Create an electric meter");
        public static readonly ApplicationCommand CreateWaterMeter = new ApplicationCommand(5, "create 2", "Create a water meter");
        public static readonly ApplicationCommand CreateGateway = new ApplicationCommand(6, "create 3", "Create a gateway");
        public static readonly ApplicationCommand Help = new ApplicationCommand(7, "help", "Get command list");
        public static readonly ApplicationCommand Exit = new ApplicationCommand(8, "exit", "Exit the application");

        public static readonly List<ApplicationCommand> Commands = new List<ApplicationCommand>
        {
            ListElectricMeters,
            ListWaterMeters,
            ListGateways,
            CreateElectricMeter,
            CreateWaterMeter,
            CreateGateway,
            Help,
            Exit
        };
    }
}
