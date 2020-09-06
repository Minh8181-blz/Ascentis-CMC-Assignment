using DeviceManager.DataAccess.Implementations;
using DeviceManager.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeviceManager.DataAccess
{
    public class DataAccessConfiguration
    {
        protected readonly IServiceCollection _services;
        protected readonly IConfiguration _configuration;

        public DataAccessConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;
        }

        public void Configure()
        {
            _services.AddDbContext<DeviceManagerContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            _services.AddTransient<IElectricMeterDao, ElectricMeterDao>();
            _services.AddTransient<IWaterMeterDao, WaterMeterDao>();
            _services.AddTransient<IGatewayDao, GatewayDao>();
        }
    }
}
