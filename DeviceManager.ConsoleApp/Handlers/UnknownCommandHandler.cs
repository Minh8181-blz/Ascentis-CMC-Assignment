using System;

namespace DeviceManager.ConsoleApp.Handlers
{
    public class UnknownCommandHandler
    {
        public void Handle()
        {
            Console.WriteLine("\n Error: unknown command");
            Console.Write("\n> ");
        }
    }
}
