namespace Plcway.Framework.Transport.Hosting
{
    public class HostOptions
    {
        /// <summary>
        /// 扫描周期，单位毫秒。
        /// 当设置为 0 时，会实时请求 PLC 数据（周期越短，资源消耗越大）。
        /// </summary>
        public int Interval { get; set; }
    }
}
