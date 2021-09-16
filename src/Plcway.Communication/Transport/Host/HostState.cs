namespace Plcway.Communication.Transport.Host
{
    /// <summary>
    /// 主机状态
    /// </summary>
    public enum HostState
    {
        /// <summary>
        /// 初始化
        /// </summary>
        Init = 0,

        /// <summary>
        /// 运行中
        /// </summary>
        Running = 1,

        /// <summary>
        /// 已停止
        /// </summary>
        Stopped = 2,

        /// <summary>
        /// 主机关闭
        /// </summary>
        Shutdown = 3,
    }
}
