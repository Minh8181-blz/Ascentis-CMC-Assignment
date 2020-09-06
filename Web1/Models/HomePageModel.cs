using DeviceManager.Business.Models;
using DeviceManager.DataAccess.Entities;
using System.Collections.Generic;

namespace DeviceManager.Web.Models
{
    public class HomePageModel
    {
        public IEnumerable<ElectricMeter> ElectricMeters { get; set; }
        public ElectricMeterDto ElectricMeterRegisterModel { get; set; }
    }
}
