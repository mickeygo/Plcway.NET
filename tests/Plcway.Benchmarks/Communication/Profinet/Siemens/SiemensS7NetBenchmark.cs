using BenchmarkDotNet.Attributes;
using Plcway.Communication.Ethernet.Profinet.Siemens;

namespace Plcway.Benchmarks.Communication.Profinet.Siemens
{
    //|           Method |     Mean |    Error |   StdDev | Allocated |
    //|   ----------------- |---------:|---------:|---------:|----------:|
    //|    RunWriteInt16 | 12.61 ms | 0.247 ms | 0.494 ms |      1 KB |
    //| RunReadMultiFor5 | 12.85 ms | 0.255 ms | 0.459 ms |      1 KB |
    //|   RunReadWString | 25.50 ms | 0.502 ms | 0.782 ms |      2 KB |
    //|  RunWriteWString | 25.58 ms | 0.510 ms | 1.240 ms |      2 KB |

    /// <summary>
    ///|           Method |     Mean |    Error |   StdDev | Allocated | <br/>
    ///|   ----------------- |---------:|---------:|---------:|----------:| <br/>
    ///|    RunWriteInt16 | 12.61 ms | 0.247 ms | 0.494 ms |      1 KB | <br/>
    ///| RunReadMultiFor5 | 12.85 ms | 0.255 ms | 0.459 ms |      1 KB | <br/>
    ///|   RunReadWString | 25.50 ms | 0.502 ms | 0.782 ms |      2 KB | <br/>
    ///|  RunWriteWString | 25.58 ms | 0.510 ms | 1.240 ms |      2 KB | <br/>
    ///
    ///注：对于字符串的读取和写入，内部会在动作执行之前读取地址部分值并判断能否进行操作。考虑如何避免先预读操作。
    /// </summary>
    [MemoryDiagnoser]
    public class SiemensS7NetBenchmark
    {
        private SiemensS7Net _s7;

        [GlobalSetup]
        public void Setup()
        {
            _s7 = new SiemensS7Net(SiemensPLCS.S1200, "10.1.0.181");
            _s7.ConnectServer();
        }

        [Benchmark]
        public void RunWriteInt16()
        {
            _s7.Write("DB1.0", (short)1);
        }

        [Benchmark]
        public void RunReadMultiFor5()
        {
            _s7.ReadInt16("DB1.0", 6);
        }

        [Benchmark]
        public void RunReadWString()
        {
            _s7.ReadWString("DB1.32");
        }

        [Benchmark]
        public void RunWriteWString()
        {
            _s7.WriteWString("DB1.32", "abc123测试");
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _s7.Dispose();
        }
    }
}
