using System.Threading;

namespace Plcway.Communication.Transport.Channels
{
    /// <summary>
    /// 事务Id生成器。
    /// </summary>
    internal class TransactionGenerator
    {
        private static long transactionId = 0;

        /// <summary>
        /// 生成新的 Id。每次执行后，返回值都会累增1。
        /// </summary>
        /// <returns></returns>
        public static long Generate()
        {
            return Interlocked.Increment(ref transactionId);
        }
    }
}
