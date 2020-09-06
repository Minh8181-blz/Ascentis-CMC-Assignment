using DeviceManager.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviceManager.Business.Interfaces
{
    public interface IWaterMeterBusiness
    {
        Task<OperationResultModel<WaterMeterDto>> Add(WaterMeterDto model);

        Task<IEnumerable<WaterMeterDto>> All();
    }
}
