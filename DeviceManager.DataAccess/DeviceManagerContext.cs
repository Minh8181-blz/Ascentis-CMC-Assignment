using DeviceManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeviceManager.DataAccess
{
    public class DeviceManagerContext : DbContext
    {
        public DeviceManagerContext(DbContextOptions<DeviceManagerContext> options) : base(options)
        {
        }

        public DbSet<ElectricMeter> ElectricMeters { get; set; }
        public DbSet<WaterMeter> WaterMeters { get; set; }
        public DbSet<Gateway> Gateways { get; set; }
    }
}
