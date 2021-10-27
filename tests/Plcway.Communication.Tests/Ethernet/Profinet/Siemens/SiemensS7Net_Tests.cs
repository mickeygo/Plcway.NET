using System;
using System.Text;
using Xunit;
using Plcway.Communication.Ethernet.Profinet.Siemens;
using Plcway.Abstract.Tests.Utils;

namespace Plcway.Communication.Tests.Ethernet.Profinet.Siemens
{
    /// <summary>
    /// 西门子 S7 协议测试 
    /// </summary>
    public class SiemensS7Net_Tests
    {
        private readonly double[] _doubleArray5 = new[] { 10.1, 21.2, 32.3, 43.4, 54.5 };

        // DB块寄存器地址读取
        // DB块寄存器地址格式：DB{X}.{XX}
        [Fact]
        public void Should_DB_Read_Test()
        {
            using var s7 = OpenAndConnectConn(true);

            var ret1 = s7.ReadInt16("DB1.11");
            Assert.True(ret1.IsSuccess, ret1.Message);
            Assert.True(ret1.Content == 11, ret1.Content.ToString());

            var ret2 = s7.ReadUInt16("DB1.12");
            Assert.True(ret2.IsSuccess, ret2.Message);
            Assert.True(ret2.Content == 12, ret2.Content.ToString());

            var ret3 = s7.ReadInt32("DB1.13");
            Assert.True(ret3.IsSuccess, ret3.Message);
            Assert.True(ret3.Content == 13, ret3.Content.ToString());

            var ret4 = s7.ReadUInt32("DB1.15");
            Assert.True(ret4.IsSuccess, ret4.Message);
            Assert.True(ret4.Content == 15, ret4.Content.ToString());

            var ret5 = s7.ReadInt64("DB1.17");
            Assert.True(ret5.IsSuccess, ret5.Message);
            Assert.True(ret5.Content == 17L, ret5.Content.ToString());

            var ret6 = s7.ReadUInt64("DB1.21");
            Assert.True(ret6.IsSuccess, ret6.Message);
            Assert.True(ret6.Content == 21UL, ret6.Content.ToString());

            var ret7 = s7.ReadFloat("DB1.25");
            Assert.True(ret7.IsSuccess, ret5.Message);
            Assert.True(Math.Round(ret7.Content, 2) == 25.01, ret7.Content.ToString());  // float 单精度浮点类型不能直接进行比较

            var ret8 = s7.ReadDouble("DB1.27");
            Assert.True(ret8.IsSuccess, ret8.Message);
            Assert.True(ret8.Content == 27.01, ret8.Content.ToString());

            // 读取字符串
            var ret9 = s7.ReadString("DB1.41", 8, Encoding.Unicode);
            Assert.True(ret9.IsSuccess, ret9.Message);
            Assert.True(ret9.Content == "abc123测试", ret9.Content);

            // 针对 WString 字符串类型，双字节类型
            var ret9_1 = s7.ReadWString("DB1.41");
            Assert.True(ret9_1.IsSuccess, ret9_1.Message);
            Assert.True(ret9_1.Content == "abc123测试", ret9_1.Content);

            // 批量读取
            var ret10 = s7.ReadDouble("DB1.51", 5);  // 从地址 51 开始，读取指定个数的数据
            Assert.True(ret10.IsSuccess, ret10.Message);
            Assert.True(CollectionHelper.ArrayDeepEqual(ret10.Content, _doubleArray5), string.Join(", ", ret10.Content));
        }

        [Fact]
        public void Should_DB_Write_Test()
        {
            using var s7 = OpenAndConnectConn(true);

            s7.Write("DB1.11", (short)11);
            s7.Write("DB1.12", (ushort)12);
            s7.Write("DB1.13", 13);
            s7.Write("DB1.15", (uint)15);
            s7.Write("DB1.17", 17L);
            s7.Write("DB1.21", 21UL);
            s7.Write("DB1.25", 25.01f);
            s7.Write("DB1.27", 27.01d);

            s7.Write("x=3;41", "abc123测试", Encoding.Unicode);

            s7.Write("x=3;51", _doubleArray5);  // 批量写入，从地址 51 开始
        }

        static SiemensS7Net OpenAndConnectConn(bool useLongConnect = false)
        {
            var modbus = new SiemensS7Net(SiemensPLCS.S1200, "127.0.0.1");
            if (useLongConnect)
            {
                var ret = modbus.ConnectServer(); // 使用长连接
                Assert.True(ret.IsSuccess, ret.Message);
            }

            return modbus;
        }
    }
}
