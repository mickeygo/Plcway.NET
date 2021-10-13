using System.ComponentModel;
using System.Reflection;

namespace Plcway.Communication
{
    /// <summary>
    /// 错误代码
    /// </summary>
    public enum ErrorCode : int
    {
        [Description("Success")]
        Success = 10000,

        [Description("未知错误")]
        UnknownError = 10001,

        [Description("连接失败")]
        ConnectedFailed = 10101,

        [Description("连接超时")]
        ConnectTimeout = 10102,

        [Description("套接字传送数据异常")]
        SocketIOException = 10201,

        [Description("同步数据发送异常")]
        SocketSendException = 10202,

        [Description("指令头接收异常")]
        SocketHeadReceiveException = 10203,

        [Description("内容数据接收异常")]
        SocketContentReceiveException = 10204,

        [Description("对方内容数据接收异常")]
        SocketContentRemoteReceiveException = 10205,

        [Description("异步接受传入的连接尝试")]
        SocketAcceptCallbackException = 10206,

        [Description("重新异步接受传入的连接尝试")]
        SocketReAcceptCallbackException = 10207,

        [Description("异步数据发送出错")]
        SocketSendAsyncException = 10208,

        [Description("异步数据结束挂起发送出错")]
        SocketEndSendException = 10209,

        [Description("异步数据发送出错")]
        SocketReceiveException = 10210,

        [Description("异步数据结束接收指令头出错")]
        SocketEndReceiveException = 10211,

        [Description("远程主机强迫关闭了一个现有的连接")]
        SocketRemoteCloseException = 10212,
    }

    public static class ErrorCodeExtensions
    {
        /// <summary>
        /// 错误代码描述信息，格式为："[code] desc" 
        /// </summary>
        /// <param name="source">错误代码枚举对象</param>
        /// <returns></returns>
        public static string Desc(this ErrorCode source)
        {
            var fi = source.GetType().GetField(source.ToString());
            var attr = fi!.GetCustomAttribute<DescriptionAttribute>(false);
            if (attr == null)
            {
                return $"[{(int)source}]";
            }
            return $"[{(int)source}] {attr.Description}";
        }
    }
}
