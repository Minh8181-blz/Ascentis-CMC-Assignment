using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManager.Business.Models
{
    public class GatewayDto : ElectricDeviceDto
    {
        public string IP { get; set; }
        public int? Port { get; set; }
    }
}
