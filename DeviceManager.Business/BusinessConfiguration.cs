using DeviceManager.Business.Implementations;
using DeviceManager.Business.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeviceManager.Business
{
    public class BusinessConfiguration
    {
        protected readonly IServiceCollection _services;
        protected readonly IConfiguration _configuration;

        public BusinessConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;
        }

        public void Configure()
        {
            _services.AddTransient<IElectricMeterBusiness, ElectricMeterBusiness>();
            _services.AddTransient<IWaterMeterBusiness, WaterMeterBusiness>();
            _services.AddTransient<IGatewayBusiness, GatewayBusiness>();
        }
    }
}
