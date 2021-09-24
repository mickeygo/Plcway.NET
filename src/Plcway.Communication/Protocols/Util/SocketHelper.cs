using System.Diagnostics.Contracts;
using System.Net.Sockets;

namespace Plcway.Communication.Protocols.Util
{
    /// <summary>
    /// Socket 帮助类
    /// </summary>
    public static class SocketHelper
    {
        /// <summary>
        /// 安全关闭
        /// </summary>
        /// <param name="socket">socket对象</param>
        public static void SafeClose(this Socket socket)
        {
            Contract.Requires(socket != null);

            try
            {
                if (socket.Connected)
                {
                    socket.Shutdown(SocketShutdown.Both);//正常关闭连接
                }
            }
            catch { }

            try
            {
                socket.Close();
            }
            catch { }
        }
    }
}
