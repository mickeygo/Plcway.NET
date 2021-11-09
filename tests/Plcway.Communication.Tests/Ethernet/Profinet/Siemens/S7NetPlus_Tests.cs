using Xunit;
using S7.Net;

namespace Plcway.Communication.Tests.Ethernet.Profinet.Siemens
{
    public class S7NetPlus_Tests
    {
        static Plc ConnectPlc(string ip)
        {
            return new Plc(CpuType.S71200, ip, 0, 1);
        }

        [Fact]
        public void Should_DB_ReadOne_Test()
        {
            var s7 = ConnectPlc("10.1.0.181");
            try
            {
                s7.Open();

                var v1 = (ushort)s7.Read("DB1.DBW0");
                Assert.True(v1 == 1, v1.ToString());

                var v2 = (ushort)s7.Read("DB1.DBW8");
                Assert.True(v2 == 1, v2.ToString());
            }
            finally
            {
                if (s7.IsConnected)
                {
                    s7.Close();
                }
            }
        }

        [Fact]
        public void Should_DB_WriteOne_Test()
        {
            var s7 = ConnectPlc("10.1.0.181");
            try
            {
                s7.Open();

                s7.Write("DB1.DBW0", (ushort)1);
                s7.Write("DB1.DBW8", (ushort)1);

                s7.Write("DB2.DBB32", "abc123测试");
            }
            finally
            {
                if (s7.IsConnected)
                {
                    s7.Close();
                }
            }
        }
    }
}
