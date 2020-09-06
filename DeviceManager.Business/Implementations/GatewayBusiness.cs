using DeviceManager.DataAccess.Interfaces;
using DeviceManager.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeviceManager.Business.Interfaces;
using DeviceManager.Business.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace DeviceManager.Business.Implementations
{
    public class GatewayBusiness : IGatewayBusiness
    {
        private readonly IGatewayDao _gatewayDao;
        private readonly ILogger<GatewayBusiness> _logger;

        public GatewayBusiness(IGatewayDao gatewayDao, ILogger<GatewayBusiness> logger)
        {
            _gatewayDao = gatewayDao;
            _logger = logger;
        }

        public async Task<OperationResultModel<GatewayDto>> Add(GatewayDto model)
        {
            var result = new OperationResultModel<GatewayDto>();
            try
            {
                bool existAlready = await _gatewayDao.GetBySerialNumber(model.SerialNumber) != null;

                if (existAlready)
                {
                    result.SetMessage("The gateway is already registered");
                    return result;
                }

                var device = await _gatewayDao.Add(new Gateway
                {
                    SerialNumber = model.SerialNumber,
                    FirmwareVersion = model.FirmwareVersion,
                    State = model.State,
                    IP = model.IP,
                    Port = model.Port
                });

                model.Id = device.Id;

                result
                    .SetStatus(true)
                    .SetMessage("Gateway has been registered successfully")
                    .SetData(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                result.SetMessage("Error creating a gateway");
            }
            return result;
        }

        public async Task<IEnumerable<GatewayDto>> All()
        {
            IEnumerable<GatewayDto> gateways = null;
            try
            {
                var devices = await _gatewayDao.All();

                gateways = devices?.Select(x => new GatewayDto
                {
                    Id = x.Id,
                    SerialNumber = x.SerialNumber,
                    FirmwareVersion = x.FirmwareVersion,
                    State = x.State,
                    IP = x.IP,
                    Port = x.Port
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return gateways;
        }
    }
}
