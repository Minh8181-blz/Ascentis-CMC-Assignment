using DeviceManager.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviceManager.DataAccess.Interfaces
{
    public interface IGatewayDao
    {
        Task<Gateway> Add(Gateway model);

        Task<IEnumerable<Gateway>> All();
        Task<Gateway> GetBySerialNumber(string serialNumber);
    }
}
