using DeviceManager.ConsoleApp.Models;
using System;

namespace DeviceManager.ConsoleApp.Handlers
{
    public class HelpCommandHandler
    {
        public void Handle()
        {
            Console.WriteLine("\t{0,-20}\t{1}", "Command", "Description\n");
            foreach (var command in ApplicationCommandList.Commands)
            {
                Console.WriteLine("\t{0,-20}\t{1}", command.Syntax, command.Description);
            }
            Console.Write("\n> ");
        }
    }
}
