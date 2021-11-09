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
        public void Should_DB_ReadOne_Test()
        {
            using var s7 = OpenAndConnectConn(true);

            var v1 = s7.ReadInt16("DB1.DBW0");  // DB55.DBD744
            Assert.True(v1.IsSuccess, v1.Message);
            Assert.True(v1.Content == 1, v1.Content.ToString());

            var v2 = s7.ReadInt16("DB1.0");
            Assert.True(v2.IsSuccess, v2.Message);
            Assert.True(v2.Content == 1, v2.Content.ToString());

            var v3 = s7.ReadInt16("DB1.8");
            Assert.True(v3.IsSuccess, v3.Message);
            Assert.True(v3.Content == 1, v3.Content.ToString());
        }

        [Fact]
        public void Should_DB_ReadString_Test()
        {
            using var s7 = OpenAndConnectConn(true);

            var v1 = s7.ReadWString("DB1.32");
            Assert.True(v1.IsSuccess, v1.Message);
            Assert.True(v1.Content == "abc123测试", v1.Content.ToString());
        }

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

            var opt1 = s7.Write("DB1.11", (short)11);
            Assert.True(opt1.IsSuccess, opt1.Message);
        }

        [Fact]
        public void Should_DB_WriteString_Test()
        {
            using var s7 = OpenAndConnectConn(true);
            var opt1 = s7.WriteWString("DB1.32", "abc123测试");  // 仅含有 ASCII 码字符串，可使用 Write 方法
            Assert.True(opt1.IsSuccess, opt1.Message);

            //var opt2 = s7.WriteWString("DB1.32", "abc");  // 测试同一字符串地址，后续写入部分值，会不会出现上一次部分值滞留的问题（经测试不会出现）
            //Assert.True(opt2.IsSuccess, opt2.Message);
        }

        static SiemensS7Net OpenAndConnectConn(bool useLongConnect = false)
        {
            var s7 = new SiemensS7Net(SiemensPLCS.S1200, "10.1.0.181");
            if (useLongConnect)
            {
                var ret = s7.ConnectServer(); // 使用长连接
                Assert.True(ret.IsSuccess, ret.Message);
            }

            return s7;
        }
    }
}
