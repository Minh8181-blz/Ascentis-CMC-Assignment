using DeviceManager.Utilities.Implementations;
using DeviceManager.Utilities.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeviceManager.Utilities
{
    public class UtilitiesConfiguration
    {
        protected readonly IServiceCollection _services;
        protected readonly IConfiguration _configuration;

        public UtilitiesConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;
        }

        public void Configure()
        {
            _services.AddSingleton<IDeviceSpecsValidator, DeviceSpecsValidator>();
        }
    }
}
