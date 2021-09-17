namespace Plcway.Communication.Protocols
{
    /// <summary>
    /// IIoTClient 接口
    /// </summary>
    public interface IIoTClient : IReaderWriter
    {
        /// <summary>
        /// 版本
        /// </summary>
        string Version { get; }

        /// <summary>
        /// 是否是连接的
        /// </summary>
        bool Connected { get; }

        /// <summary>
        /// 打开连接（如果已经是连接状态会先关闭再打开）
        /// </summary>
        /// <returns></returns>
        Result Open();

        /// <summary>
        /// 关闭连接
        /// </summary>
        /// <returns></returns>
        Result Close();

        /// <summary>
        /// 发送报文，并获取响应报文
        /// </summary>
        /// <param name="command">发送命令</param>
        /// <returns></returns>
        Result<byte[]> SendPackageSingle(byte[] command);
    }
}
