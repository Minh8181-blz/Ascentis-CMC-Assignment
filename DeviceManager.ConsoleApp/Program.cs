using DeviceManager.Business;
using DeviceManager.ConsoleApp.Handlers;
using DeviceManager.DataAccess;
using DeviceManager.Utilities;
using DeviceManager.Utilities.Implementations;
using DeviceManager.Utilities.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DeviceManager.ConsoleApp
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        public static IConfiguration Configuration { get; private set; }

        static async Task Main(string[] args)
        {
            RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();
            await scope.ServiceProvider.GetRequiredService<DeviceManagerConsoleApplication>().Run();
            DisposeServices();
        }

        private static void RegisterServices()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            var services = new ServiceCollection();

            services.AddLogging(configure => configure.AddDebug()); // to be replaced by another logging provider
            services.AddSingleton<IDeviceSpecsValidator, DeviceSpecsValidator>();

            (new UtilitiesConfiguration(services, Configuration)).Configure();
            (new DataAccessConfiguration(services, Configuration)).Configure();
            (new BusinessConfiguration(services, Configuration)).Configure();

            services.AddScoped<ListElectricMetersCommandHandler>();
            services.AddScoped<ListWaterMeterCommandHandler>();
            services.AddScoped<ListGatewayCommandHandler>();

            services.AddScoped<RegisterElectricMeterCommandHandler>();
            services.AddScoped<RegisterWaterMeterCommandHandler>();
            services.AddScoped<RegisterGatewayCommandHandler>();

            services.AddScoped<HelpCommandHandler>();
            services.AddScoped<UnknownCommandHandler>();

            services.AddScoped<DeviceManagerConsoleApplication>();

            _serviceProvider = services.BuildServiceProvider(true);
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable disposable )
            {
                disposable.Dispose();
            }
        }
    }
}
