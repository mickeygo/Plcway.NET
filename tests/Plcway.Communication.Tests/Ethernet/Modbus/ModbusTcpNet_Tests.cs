using Plcway.Communication.Ethernet.Modbus;
using Xunit;

namespace Plcway.Communication.Tests.Ethernet.Modbus
{
    /// <summary>
    /// ModbusTcpNet 测试类
    /// </summary>
    public class ModbusTcpNet_Tests
    {
        [Fact]
        public void Should_Read_Test()
        {
            using var modbus = new ModbusTcpNet("127.0.0.1");
            var ret1 = modbus.ReadInt16("2");
            Assert.True(ret1.IsSuccess, ret1.Message);
            var v1 = ret1.Content;
            Assert.True(v1 == 12, v1.ToString());
        }

        [Fact]
        public void Should_Write_Test()
        {
            using var modbus = new ModbusTcpNet("127.0.0.1");
            modbus.Write("2", 12);
        }
    }
}
