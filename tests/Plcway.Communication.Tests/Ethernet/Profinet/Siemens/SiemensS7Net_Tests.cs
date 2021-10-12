using Plcway.Communication.Ethernet.Profinet.Siemens;
using Xunit;

namespace Plcway.Communication.Tests.Ethernet.Profinet.Siemens
{
    /// <summary>
    /// 西门子 S7 协议测试 
    /// </summary>
    public class SiemensS7Net_Tests
    {
        [Fact]
        public void Should_Write_Test()
        {
            using var s7 = new SiemensS7Net(SiemensPLCS.S1200, "");
            
        }
    }
}
