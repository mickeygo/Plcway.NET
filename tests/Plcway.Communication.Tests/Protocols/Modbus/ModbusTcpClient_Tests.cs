using System.Collections.Generic;
using Plcway.Communication.Protocols;
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
            var client = new ModbusTcpClient("127.0.0.1", 502);
            var result1 = client.ReadInt16(1, 1, 3);
            Assert.True(result1.IsSucceed, result1.Err);
            Assert.True(result1.Value == 1, result1.Value.ToString());
        }

        [Fact]
        public void Should_WriteInt16_Test()
        {
            var client = new ModbusTcpClient("127.0.0.1", 502);
            var result2 = client.Write("11", (ushort)3, 1, 16);
            Assert.True(result2.IsSucceed, result2.Err);
        }

        [Fact]
        public void Should_ReadString_Test()
        {
            var client = new ModbusTcpClient("127.0.0.1", 502);
            var result1 = client.ReadString("21", 1, 3);
            Assert.True(result1.IsSucceed, result1.Err);
            Assert.True(result1.Value == "abc123", result1.Value.ToString());
        }

        [Fact]
        public void Should_WriteString_Test()
        {
            var client = new ModbusTcpClient("127.0.0.1", 502);
            var result2 = client.Write("21", "abc123", 1, 16);
            Assert.True(result2.IsSucceed, result2.Err);
        }

        /// <summary>
        /// 批量读取
        /// </summary>
        [Fact]
        public void Should_ReadMulti_Test()
        {
            var list = new List<ModbusInput>
            {
                new ModbusInput()
                {
                    Address = "2",
                    DataType = DataTypeEnum.Int16,
                    FunctionCode = 3,
                    StationNumber = 1
                },
                new ModbusInput()
                {
                    Address = "3",
                    DataType = DataTypeEnum.Int16,
                    FunctionCode = 3,
                    StationNumber = 1
                },
                new ModbusInput()
                {
                    Address = "5",
                    DataType = DataTypeEnum.Int16,
                    FunctionCode = 3,
                    StationNumber = 1
                },
                new ModbusInput()
                {
                    Address = "9",
                    DataType = DataTypeEnum.Int16,
                    FunctionCode = 3,
                    StationNumber = 1
                },
                new ModbusInput()
                {
                    Address = "20",
                    DataType = DataTypeEnum.Int16,
                    FunctionCode = 3,
                    StationNumber = 1
                },
                new ModbusInput()
                {
                    Address = "21",
                    DataType = DataTypeEnum.Int16,
                    FunctionCode = 3,
                    StationNumber = 1
                },
                new ModbusInput()
                {
                    Address = "22",
                    DataType = DataTypeEnum.Int16,
                    FunctionCode = 3,
                    StationNumber = 1
                },
                new ModbusInput()
                {
                    Address = "23",
                    DataType = DataTypeEnum.Int16,
                    FunctionCode = 3,
                    StationNumber = 1
                },
                new ModbusInput()
                {
                    Address = "24",
                    DataType = DataTypeEnum.Int16,
                    FunctionCode = 3,
                    StationNumber = 1
                },
                new ModbusInput()
                {
                    Address = "25",
                    DataType = DataTypeEnum.Int16,
                    FunctionCode = 3,
                    StationNumber = 1
                },
                new ModbusInput()
                {
                    Address = "26",
                    DataType = DataTypeEnum.Int16,
                    FunctionCode = 3,
                    StationNumber = 1
                },
                new ModbusInput()
                {
                    Address = "27",
                    DataType = DataTypeEnum.Int16,
                    FunctionCode = 3,
                    StationNumber = 1
                },
                new ModbusInput()
                {
                    Address = "28",
                    DataType = DataTypeEnum.Int16,
                    FunctionCode = 3,
                    StationNumber = 1
                }
            };

            var client = new ModbusTcpClient("127.0.0.1", 502);
            var result = client.BatchRead(list);
            Assert.True(result.IsSucceed, result.Err);
        }
    }
}
