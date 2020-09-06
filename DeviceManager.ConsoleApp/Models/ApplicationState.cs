using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManager.ConsoleApp.Models
{
    public class ApplicationState
    {
        public bool Running { get; private set; }

        public ApplicationState()
        {
            Running = true;
        }

        public void StopApplication()
        {
            Running = false;
        }
    }
}
