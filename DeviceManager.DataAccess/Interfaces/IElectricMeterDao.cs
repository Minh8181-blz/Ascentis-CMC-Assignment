using DeviceManager.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviceManager.DataAccess.Interfaces
{
    public interface IElectricMeterDao
    {
        Task<ElectricMeter> Add(ElectricMeter model);

        Task<IEnumerable<ElectricMeter>> All();

        Task<ElectricMeter> GetBySerialNumber(string serialNumber);
    }
}
