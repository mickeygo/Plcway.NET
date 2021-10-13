using System;
using System.Text;
using Xunit;
using Plcway.Communication.Ethernet.Modbus;

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

            var ret1 = modbus.ReadInt16("x=3;11");
            Assert.True(ret1.IsSuccess, ret1.Message);
            Assert.True(ret1.Content == 11, ret1.Content.ToString());

            var ret2 = modbus.ReadUInt16("x=3;12");
            Assert.True(ret2.IsSuccess, ret2.Message);
            Assert.True(ret2.Content == 12, ret2.Content.ToString());

            var ret3 = modbus.ReadInt32("x=3;13");
            Assert.True(ret3.IsSuccess, ret3.Message);
            Assert.True(ret3.Content == 13, ret3.Content.ToString());

            var ret4 = modbus.ReadUInt32("x=3;15");
            Assert.True(ret4.IsSuccess, ret4.Message);
            Assert.True(ret4.Content == 15, ret4.Content.ToString());

            var ret5 = modbus.ReadInt64("x=3;17");
            Assert.True(ret5.IsSuccess, ret5.Message);
            Assert.True(ret5.Content == 17L, ret5.Content.ToString());

            var ret6 = modbus.ReadUInt64("x=3;21");
            Assert.True(ret6.IsSuccess, ret6.Message);
            Assert.True(ret6.Content == 21UL, ret6.Content.ToString());

            var ret7 = modbus.ReadFloat("x=3;25");
            Assert.True(ret7.IsSuccess, ret5.Message);
            Assert.True(Math.Round(ret7.Content, 2) == 25.01, ret7.Content.ToString());  // float 单精度浮点类型不能直接进行比较

            var ret8 = modbus.ReadDouble("x=3;27");
            Assert.True(ret8.IsSuccess, ret8.Message);
            Assert.True(ret8.Content == 27.01, ret8.Content.ToString());

            // 读取字符串
            var ret9 = modbus.ReadString("x=3;41", 8, Encoding.Unicode);
            Assert.True(ret9.IsSuccess, ret9.Message);
            Assert.True(ret9.Content == "abc123测试", ret9.Content);

            // 批量读取
            var ret10 = modbus.ReadDouble("x=3;51", 5);
            Assert.True(ret10.IsSuccess, ret10.Message);
            Assert.True(ArrayDeepEqual(ret10.Content, doubles), string.Join(", ", ret10.Content));
        }

        private readonly double[] doubles = new[] { 10.1, 21.2, 32.3, 43.4, 54.5 };

        [Fact]
        public void Should_Write_Test()
        {
            using var modbus = new ModbusTcpNet("127.0.0.1");
            modbus.Write("x=3;11", (short)11);
            modbus.Write("x=3;12", (ushort)12);
            modbus.Write("x=3;13", 13);
            modbus.Write("x=3;15", (uint)15);
            modbus.Write("x=3;17", 17L);
            modbus.Write("x=3;21", 21UL);
            modbus.Write("x=3;25", 25.01f);
            modbus.Write("x=3;27", 27.01d);

            modbus.Write("x=3;41", "abc123测试", Encoding.Unicode);

            modbus.Write("x=3;51", doubles);  // 批量写入
        }

        static bool ArrayDeepEqual<T>(T[] arr1, T[] arr2) where T : IComparable
        {
            if (arr1.Length != arr2.Length)
            {
                return false;
            }

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i].CompareTo(arr2[i]) != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
