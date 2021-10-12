namespace Plcway.Framework.Transport.Channels
{
    /// <summary>
    /// 渠道数据
    /// </summary>
    public class ChannalData
    {
        /// <summary>
        /// 渠道标签
        /// </summary>
        public string Tag { get; }

        // 地址
        // 值

        public ChannalData(string tag)
        {
            Tag = tag;
        }
    }
}
