using DeviceManager.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviceManager.Business.Interfaces
{
    public interface IGatewayBusiness
    {
        Task<OperationResultModel<GatewayDto>> Add(GatewayDto model);

        Task<IEnumerable<GatewayDto>> All();
    }
}
