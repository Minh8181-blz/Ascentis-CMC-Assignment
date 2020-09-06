using DeviceManager.Business.Implementations;
using DeviceManager.Business.Interfaces;
using DeviceManager.Business.Models;
using DeviceManager.DataAccess;
using DeviceManager.DataAccess.Implementations;
using DeviceManager.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DeviceManager.UnitTests
{
    public class CreateGatewayTest
    {
        private ServiceProvider ServiceProvider { get; set; }
        public CreateGatewayTest()
        {
            var services = new ServiceCollection();

            string connectionStr = "Server=ADMIN\\SQLEXPRESS;Database=device_manager;User ID=devuser;Password=dev123;Integrated Security=true;";
            services.AddDbContext<DeviceManagerContext>(options =>
                options.UseSqlServer(connectionStr));

            services.AddTransient<IGatewayDao, GatewayDao>();
            services.AddLogging(configure => configure.AddDebug());
            services.AddTransient<IGatewayBusiness, GatewayBusiness>();

            ServiceProvider = services.BuildServiceProvider();
        }

        [Fact]
        public async Task TestCreateSucess()
        {
            IGatewayBusiness gatewayBusiness = ServiceProvider.GetService<IGatewayBusiness>();

            GatewayDto gateway = new GatewayDto
            {
                SerialNumber = DateTime.Now.Ticks.ToString(),
                FirmwareVersion = "Test firmware version",
                State = "Test state"
            };

            var result = await gatewayBusiness.Add(gateway);
            Assert.True(result.Success, result.Message);
            Assert.True(result.Data.Id > 0);
        }

        [Fact]
        public async Task TestCreateFailureDueToDuplicateSerial()
        {
            IGatewayBusiness gatewayBusiness = ServiceProvider.GetService<IGatewayBusiness>();
            string serial = DateTime.Now.Ticks.ToString();

            GatewayDto gateway = new GatewayDto
            {
                SerialNumber = serial,
                FirmwareVersion = "Test firmware version",
                State = "Test state"
            };

            var result = await gatewayBusiness.Add(gateway);
            Assert.True(result.Success, result.Message);
            Assert.True(result.Data.Id > 0);

            GatewayDto duplicate = new GatewayDto
            {
                SerialNumber = serial,
                FirmwareVersion = "Test firmware version 1",
                State = "Test state 1"
            };

            result = await gatewayBusiness.Add(duplicate);
            Assert.False(result.Success, result.Message);
        }
    }
}
