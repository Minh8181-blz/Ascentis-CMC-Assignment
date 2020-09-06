using DeviceManager.DataAccess.Entities;
using DeviceManager.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviceManager.DataAccess.Implementations
{
    public class ElectricMeterDao : IElectricMeterDao
    {
        private readonly DeviceManagerContext _context;

        public ElectricMeterDao(DeviceManagerContext context)
        {
            _context = context;
        }

        public async Task<ElectricMeter> Add(ElectricMeter model)
        {
            var entry = await _context.ElectricMeters.AddAsync(model);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<IEnumerable<ElectricMeter>> All()
        {
            return await _context.ElectricMeters.ToListAsync();
        }

        public async Task<ElectricMeter> GetBySerialNumber(string serialNumber)
        {
            return await _context.ElectricMeters.FirstOrDefaultAsync(x => x.SerialNumber == serialNumber);
        }
    }
}
