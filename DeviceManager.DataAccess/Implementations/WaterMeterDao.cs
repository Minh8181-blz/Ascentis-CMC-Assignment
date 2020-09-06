using DeviceManager.DataAccess.Entities;
using DeviceManager.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviceManager.DataAccess.Implementations
{
    public class WaterMeterDao : IWaterMeterDao
    {
        private readonly DeviceManagerContext _context;

        public WaterMeterDao(DeviceManagerContext context)
        {
            _context = context;
        }

        public async Task<WaterMeter> Add(WaterMeter model)
        {
            var entry = await _context.WaterMeters.AddAsync(model);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<IEnumerable<WaterMeter>> All()
        {
            return await _context.WaterMeters.ToListAsync();
        }

        public async Task<WaterMeter> GetBySerialNumber(string serialNumber)
        {
            return await _context.WaterMeters.FirstOrDefaultAsync(x => x.SerialNumber == serialNumber);
        }
    }
}
