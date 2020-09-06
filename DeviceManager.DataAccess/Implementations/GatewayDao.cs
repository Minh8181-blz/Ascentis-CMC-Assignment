using DeviceManager.DataAccess.Entities;
using DeviceManager.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviceManager.DataAccess.Implementations
{
    public class GatewayDao : IGatewayDao
    {
        private readonly DeviceManagerContext _context;

        public GatewayDao(DeviceManagerContext context)
        {
            _context = context;
        }

        public async Task<Gateway> Add(Gateway model)
        {
            var entry = await _context.Gateways.AddAsync(model);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<IEnumerable<Gateway>> All()
        {
            return await _context.Gateways.ToListAsync();
        }

        public async Task<Gateway> GetBySerialNumber(string serialNumber)
        {
            return await _context.Gateways.FirstOrDefaultAsync(x => x.SerialNumber == serialNumber);
        }
    }
}
