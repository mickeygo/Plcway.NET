using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Plcway.Framework.Transport.Channels;
using Plcway.Framework.Utils;

namespace Plcway.Framework.Transport.Hosting
{
    /// <summary>
    /// PLC 主机
    /// </summary>
    public class PlcHost : IHost
    {
        private readonly HostOptions _hostOptions;
        private readonly IPipelineChannel _pipelineChannel;
        private readonly ILogger _logger;

        private readonly CancellationTokenSource _stopCts = new();
        private bool _hasRun;
        private bool _isShutdown;

        public HostState State { get; private set; } = HostState.Init;

        public PlcHost(IOptions<HostOptions> hostOptions, IPipelineChannel pipelineChannel, ILogger<PlcHost> logger)
        {
            _hostOptions = hostOptions.Value;
            _pipelineChannel = pipelineChannel;
            _logger = logger;
        }

        public Task RunAsync(CancellationToken cancellationToken = default)
        {
            if (_hasRun)
            {
                throw new InvalidOperationException("[Host] server has run.");
            }

            _hasRun = true;

            if (State == HostState.Running)
            {
                return Task.CompletedTask;
            }

            State = HostState.Running;
            var cancelCts = CancellationTokenSource.CreateLinkedTokenSource(_stopCts.Token, cancellationToken);

            _ = Task.Run(async () => await AcceptAsync(cancelCts.Token), cancelCts.Token);
            _ = Task.Run(async () => await CallbackAsync(cancelCts.Token), cancelCts.Token);
            
            return Task.CompletedTask;
        }

        public void Start()
        {
            if (State == HostState.Stopped)
            {
                State = HostState.Running;
            }
        }

        public void Stop()
        {
            if (State == HostState.Running)
            {
                State = HostState.Stopped;
            }
        }

        public void Shutdown()
        {
            if (_isShutdown)
            {
                return;
            }
            _isShutdown = true;

            State = HostState.Shutdown;
            _stopCts.Cancel();

            _pipelineChannel.Puller.Writer.TryComplete();
            _pipelineChannel.Pusher.Writer.TryComplete();
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        private async Task AcceptAsync(CancellationToken cancellationToken = default)
        {
            // think：处于 Stop 状态时，可使用 ManualResetEvent 来阻塞线程执行。
            while (!cancellationToken.IsCancellationRequested)
            {
                if (_hostOptions.Interval > 0)
                {
                    await Task.Delay(_hostOptions.Interval, cancellationToken);  // 延迟
                }

                // 主机非运行状态时，不会去读取请求数据
                if (State != HostState.Running)
                {
                    continue;
                }

                var ctx = BuildChannelContext();

                // TODO: 思考，是否要阻塞，直到通道有可用的数据空间？
                //if (await _pipelineChannel.Puller.Writer.WaitToWriteAsync(cancellationToken))
                //{
                //}

                if (!_pipelineChannel.Puller.Writer.TryWrite(ctx))  // think，当 channel 满了时是否要丢弃数据？
                {
                    _logger.LogError($"[Host] Try write to PullerChannel fail, transId:{ctx.TransactionId}, request:{JsonHelper.Serialize(ctx.Request)}");
                    continue;
                }
            }
        }

        /// <summary>
        /// 回写数据
        /// </summary>
        /// <returns></returns>
        private async Task CallbackAsync(CancellationToken cancellationToken = default)
        {
            // 回调请求，这里和主机状态无关
            while (await _pipelineChannel.Pusher.Reader.WaitToReadAsync(cancellationToken))
            {
                if (!_pipelineChannel.Pusher.Reader.TryRead(out var ctx))
                {
                    _logger.LogError("[Host] Read data from PusherChannel to callback fail");
                    continue;
                }

                await HandleCallback(ctx);
            }
        }

        public void Dispose()
        {
            Shutdown();
            GC.SuppressFinalize(this);
        }

        #region privates

        private ChannelContext BuildChannelContext()
        {
            // TODO: 构建请求的数据上下文

            return new ChannelContext(TransactionGenerator.Generate(), null, null, null);
        }

        private Task HandleCallback(ChannelContext ctx)
        {
            // TODO: 处理回调的数据
            // 多任务方式并行处理，但必须保证 Task 的数量在可控范围，防止 Task 无限增加导致

            return Task.CompletedTask;
        }

        #endregion
    }
}
