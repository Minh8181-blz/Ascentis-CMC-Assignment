using DeviceManager.Utilities.Implementations;
using DeviceManager.Utilities.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace DeviceManager.UnitTests
{
    public class DeviceSpecsTest
    {
        private ServiceProvider ServiceProvider { get; set; }
        public DeviceSpecsTest()
        {
            var services = new ServiceCollection();
            services.AddTransient<IDeviceSpecsValidator, DeviceSpecsValidator>();

            ServiceProvider = services.BuildServiceProvider();
        }

        [Fact]
        public void TestIpv4()
        {
            IDeviceSpecsValidator deviceSpecsValidator = ServiceProvider.GetService<IDeviceSpecsValidator>();

            Assert.True(deviceSpecsValidator.IsValidIPv4Address("122.33.5.56"));

            Assert.True(deviceSpecsValidator.IsValidIPv4Address("127.0.0.1"));

            Assert.False(deviceSpecsValidator.IsValidIPv4Address(null));

            Assert.False(deviceSpecsValidator.IsValidIPv4Address(""));

            Assert.False(deviceSpecsValidator.IsValidIPv4Address("1"));

            Assert.False(deviceSpecsValidator.IsValidIPv4Address("12.4"));

            Assert.False(deviceSpecsValidator.IsValidIPv4Address("12.7.4"));

            Assert.False(deviceSpecsValidator.IsValidIPv4Address("12.563.21.3"));

            Assert.False(deviceSpecsValidator.IsValidIPv4Address("256.0.21.56"));

            Assert.False(deviceSpecsValidator.IsValidIPv4Address("f1ac:5242:1b9b:fcf1:de3a:2391:f8e8:fd5a"));
        }

        [Fact]
        public void TestIpv6()
        {
            IDeviceSpecsValidator deviceSpecsValidator = ServiceProvider.GetService<IDeviceSpecsValidator>();

            Assert.True(deviceSpecsValidator.IsValidIPv6Address("f1ac:5242:1b9b:fcf1:de3a:2391:f8e8:fd5a"));

            Assert.True(deviceSpecsValidator.IsValidIPv6Address("04b2:0dd8:f211:2efd:64cc:6bbb:7d08:91cc"));

            Assert.True(deviceSpecsValidator.IsValidIPv6Address("2001:0db8:85a3:0000:0000:8a2e:0370:7334"));

            Assert.True(deviceSpecsValidator.IsValidIPv6Address("2001:0db8:85a3::8a2e:0370:7334"));

            Assert.False(deviceSpecsValidator.IsValidIPv6Address(null));

            Assert.False(deviceSpecsValidator.IsValidIPv6Address(""));

            Assert.False(deviceSpecsValidator.IsValidIPv6Address("8a2e"));

            Assert.False(deviceSpecsValidator.IsValidIPv6Address("2001:0db8"));

            Assert.False(deviceSpecsValidator.IsValidIPv6Address("64cc:6bbb:7d08:91cc"));

            Assert.False(deviceSpecsValidator.IsValidIPv6Address("12.563.21.3"));

            Assert.False(deviceSpecsValidator.IsValidIPv6Address("04b2:0dd8:f211:2efd:64cc:6bbb:7d08:91cc:425d"));

            Assert.False(deviceSpecsValidator.IsValidIPv6Address("122.33.5.56"));
        }

        [Fact]
        public void TestPortNumber()
        {
            IDeviceSpecsValidator deviceSpecsValidator = ServiceProvider.GetService<IDeviceSpecsValidator>();

            Assert.True(deviceSpecsValidator.IsValidPort(1));

            Assert.True(deviceSpecsValidator.IsValidPort(10));

            Assert.False(deviceSpecsValidator.IsValidPort(0));

            Assert.False(deviceSpecsValidator.IsValidPort(-1));
        }
    }
}
