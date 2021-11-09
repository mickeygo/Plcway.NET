using BenchmarkDotNet.Running;
using Plcway.Benchmarks.Communication.Modbus;
using Plcway.Benchmarks.Communication.Profinet.Siemens;

namespace Plcway.Benchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkRunner.Run<ModbusTcpNetBenchmark>();
            BenchmarkRunner.Run<SiemensS7NetBenchmark>();
        }
    }
}
