using System.Text;
using BenchmarkDotNet.Attributes;
using Plcway.Abstract.Tests.Utils;
using Plcway.Communication.Ethernet.Modbus;

namespace Plcway.Benchmarks.Communication.Modbus
{
    [MemoryDiagnoser]
    public class ModbusTcpNetBenchmark
    {
        private readonly double[] _doubleArray5 = new[] { 10.1, 21.2, 32.3, 43.4, 54.5 };

        private ModbusTcpNet _modbus;

        [Params(1000, 10000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            _modbus = new ModbusTcpNet("127.0.0.1");
        }

        [Benchmark]
        public bool RunMultiRead5()
        {
            var ret = _modbus.ReadDouble("x=3;51", 5);  // 从地址 51 开始，读取指定个数的数据
            return ret.IsSuccess && CollectionHelper.ArrayDeepEqual(ret.Content, _doubleArray5);
        }

        [Benchmark]
        public bool RunSignleReadString()
        {
            var ret = _modbus.ReadString("x=3;41", 8, Encoding.Unicode);
            return ret.IsSuccess && ret.Content == "abc123测试";
        }

        [Benchmark]
        public bool RunSignleReadDouble()
        {
            var ret = _modbus.ReadDouble("x=3;27");
            return ret.IsSuccess && ret.Content == 27.01;
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _modbus.Dispose();
        }
    }
}
