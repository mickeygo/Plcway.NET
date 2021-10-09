namespace Plcway.Communication.Profinet
{
    /// <summary>
    /// 操作结果
    /// </summary>
    public class OperateResult
    {
        /// <summary>
        /// 指示本次操作是否成功。
        /// </summary>
        public bool IsSuccess { get; protected set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public int ErrorCode { get; protected set; } = 10000;

        /// <summary>
        /// 错误描述
        /// </summary>
        public string Message { get; protected set; }

        /// <summary>
        /// 初始化一个新的<see cref="OperateResult"/>实例 <br/>
        /// 结果为 true.
        /// </summary>
        public OperateResult()
        {
            IsSuccess = true;
            Message = string.Empty;
        }

        /// <summary>
        /// 初始化一个新的<see cref="OperateResult"/>实例 <br/>
        /// 结果为 false.
        /// </summary>
        /// <param name="msg">错误消息</param>
        public OperateResult(string msg)
        {
            IsSuccess = false;
            Message = msg;
        }

        /// <summary>
        /// 初始化一个新的<see cref="OperateResult"/>实例 <br/>
        /// 结果为 false.
        /// </summary>
        /// <param name="errCode">错误代码</param>
        /// <param name="msg">错误消息</param>
        public OperateResult(int errCode, string msg) : this(msg)
        {
            IsSuccess = false;
            ErrorCode = errCode;
        }

        /// <summary>
        /// 创建一个新的<see cref="OperateResult"/>实例 <br/>
        /// 结果为 true.
        /// </summary>
        /// <param name="connent">结果内容</param>
        /// <returns></returns>
        public static OperateResult<T> CreateOk<T>(T connent)
        {
            return new OperateResult<T>(connent);
        }

        /// <summary>
        /// 创建一个新的<see cref="OperateResult"/>实例 <br/>
        /// 其中包含内容
        /// </summary>
        /// <param name="result">结果内容</param>
        /// <returns></returns>
        public static OperateResult<T> Create<T>(OperateResult result)
        {
            return new OperateResult<T>
            {
                IsSuccess = result.IsSuccess,
                ErrorCode = result.ErrorCode,
                Message = result.Message,
            };
        }
    }

    /// <summary>
    /// 操作结果的泛型类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OperateResult<T> : OperateResult
    {
        /// <summary>
        /// 内容
        /// </summary>
        public T? Content { get; }

        public OperateResult()
        {

        }

        /// <summary>
        /// 初始化一个新的<see cref="OperateResult"/>实例 <br/>
        /// 结果为 true.
        /// </summary>
        /// <param name="connent">结果内容</param>
        /// <returns></returns>
        public OperateResult(T connent) : base()
        {
            Content = connent;
        }
    }
}
