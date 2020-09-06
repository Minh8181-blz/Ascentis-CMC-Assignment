using DeviceManager.DataAccess.Interfaces;
using DeviceManager.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeviceManager.Business.Interfaces;
using DeviceManager.Business.Models;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace DeviceManager.Business.Implementations
{
    public class WaterMeterBusiness : IWaterMeterBusiness
    {
        private readonly IWaterMeterDao _waterMeterDao;
        private readonly ILogger<WaterMeterBusiness> _logger;

        public WaterMeterBusiness(IWaterMeterDao waterMeterDao, ILogger<WaterMeterBusiness> logger)
        {
            _waterMeterDao = waterMeterDao;
            _logger = logger;
        }

        public async Task<OperationResultModel<WaterMeterDto>> Add(WaterMeterDto model)
        {
            var result = new OperationResultModel<WaterMeterDto>();
            try
            {
                bool existAlready = await _waterMeterDao.GetBySerialNumber(model.SerialNumber) != null;

                if (existAlready)
                {
                    result.SetMessage("The water meter is already registered");
                    return result;
                }

                var device = await _waterMeterDao.Add(new WaterMeter
                {
                    SerialNumber = model.SerialNumber,
                    FirmwareVersion = model.FirmwareVersion,
                    State = model.State
                });

                model.Id = device.Id;

                result
                    .SetStatus(true)
                    .SetMessage("Water meter has been registered successfully")
                    .SetData(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                result.SetMessage("Error creating an water meter");
            }
            return result;
        }

        public async Task<IEnumerable<WaterMeterDto>> All()
        {
            IEnumerable<WaterMeterDto> waterMeters = null;
            try
            {
                var devices = await _waterMeterDao.All();

                waterMeters = devices?.Select(x => new WaterMeterDto
                {
                    Id = x.Id,
                    SerialNumber = x.SerialNumber,
                    FirmwareVersion = x.FirmwareVersion,
                    State = x.State
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return waterMeters;
        }
    }
}
