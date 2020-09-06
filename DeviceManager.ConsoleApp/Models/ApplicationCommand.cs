using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManager.ConsoleApp.Models
{
    public class ApplicationCommand
    {
        public int Id { get; set; }
        public string Syntax { get; set; }
        public string Description { get; set; }

        public ApplicationCommand(int id, string syntax, string description)
        {
            Id = id;
            Syntax = syntax;
            Description = description;
        }
    }
}
