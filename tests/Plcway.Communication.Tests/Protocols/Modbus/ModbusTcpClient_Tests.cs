using Plcway.Communication.Protocols.Modbus;
using Xunit;

namespace Plcway.Communication.Tests.Protocols.Modbus
{
    /// <summary>
    /// ModbusTcp 客户端测试
    /// </summary>
    public class ModbusTcpClient_Tests
    {
        [Fact]
        public void Should_ReadInt16_Test()
        {
            var client = new ModbusTcpClient("", 102);
            var result1 = client.ReadInt16(0, 0, 0);
            Assert.True(result1.IsSucceed);
            Assert.True(result1.Value == 0);
        }
    }
}
