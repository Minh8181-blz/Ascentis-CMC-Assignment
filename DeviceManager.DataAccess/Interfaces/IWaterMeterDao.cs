using DeviceManager.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviceManager.DataAccess.Interfaces
{
    public interface IWaterMeterDao
    {
        Task<WaterMeter> Add(WaterMeter model);

        Task<IEnumerable<WaterMeter>> All();
        Task<WaterMeter> GetBySerialNumber(string serialNumber);
    }
}
