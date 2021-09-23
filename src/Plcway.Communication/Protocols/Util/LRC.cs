using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Plcway.Communication.Protocols.Util
{
    /// <summary>
    /// LRC验证
    /// </summary>
    public static class LRC
    {
        /// <summary>
        /// 获取 LRC
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] GetLRC(byte[] value)
        {
            if (value == null)
            {
                return Array.Empty<byte>();
            }

            int sum = 0;
            for (int i = 0; i < value.Length; i++)
            {
                sum += value[i];
            }

            sum %= 256;
            sum = 256 - sum;

            byte[] LRC = new[] { (byte)sum };
            return value.Concat(LRC).ToArray();
        }

        /// <summary>
        /// 校验 LRC
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool CheckLRC(byte[] value)
        {
            Contract.Requires(value != null && value.Length > 0);

            int length = value.Length;
            byte[] buffer = new byte[length - 1];
            Array.Copy(value, 0, buffer, 0, buffer.Length);

            byte[] LRCbuf = GetLRC(buffer);
            if (LRCbuf[length - 1] == value[length - 1])
            {
                return true;
            }

            return false;
        }
    }
}
