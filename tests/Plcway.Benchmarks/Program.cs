using BenchmarkDotNet.Running;
using Plcway.Benchmarks.Communication.Modbus;

namespace Plcway.Benchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ModbusTcpNetBenchmark>();
        }
    }
}
