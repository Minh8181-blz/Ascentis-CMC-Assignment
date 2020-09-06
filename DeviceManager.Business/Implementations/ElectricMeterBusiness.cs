using DeviceManager.DataAccess.Interfaces;
using DeviceManager.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeviceManager.Business.Interfaces;
using System;
using Microsoft.Extensions.Logging;
using DeviceManager.Business.Models;
using System.Linq;

namespace DeviceManager.Business.Implementations
{
    public class ElectricMeterBusiness : IElectricMeterBusiness
    {
        private readonly IElectricMeterDao _electricMeterDao;
        private readonly ILogger<ElectricMeterBusiness> _logger;

        public ElectricMeterBusiness(IElectricMeterDao electricMeterDao, ILogger<ElectricMeterBusiness> logger)
        {
            _electricMeterDao = electricMeterDao;
            _logger = logger;
        }

        public async Task<OperationResultModel<ElectricMeterDto>> Add(ElectricMeterDto model)
        {
            var result = new OperationResultModel<ElectricMeterDto>();
            try
            {
                bool existAlready = await _electricMeterDao.GetBySerialNumber(model.SerialNumber) != null;

                if (existAlready)
                {
                    result.SetMessage("The electric meter is already registered");
                    return result;
                } 

                var device = await _electricMeterDao.Add(new ElectricMeter {
                    SerialNumber = model.SerialNumber,
                    FirmwareVersion = model.FirmwareVersion,
                    State = model.State
                });

                model.Id = device.Id;

                result
                    .SetStatus(true)
                    .SetMessage("Electric meter has been registered successfully")
                    .SetData(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                result.SetMessage("Error creating an electric meter");
            }
            return result;
        }

        public async Task<IEnumerable<ElectricMeterDto>> All()
        {
            IEnumerable<ElectricMeterDto> electricMeters = null;
            try
            {
                var devices = await _electricMeterDao.All();

                electricMeters = devices?.Select(x => new ElectricMeterDto
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

            return electricMeters;
        }
    }
}
