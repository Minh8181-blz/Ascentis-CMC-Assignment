using DeviceManager.Business.Models;
using DeviceManager.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviceManager.Business.Interfaces
{
    public interface IElectricMeterBusiness
    {
        Task<OperationResultModel<ElectricMeterDto>> Add(ElectricMeterDto model);
        Task<IEnumerable<ElectricMeterDto>> All();
    }
}
