using System.Diagnostics.Contracts;

namespace Plcway.Communication.Protocols.Util
{
    /// <summary>
    /// CRC16验证
    /// </summary>
    public static class CRC16
    {
        /// <summary>
        /// 验证CRC16校验码
        /// </summary>
        /// <param name="value">校验数据</param>
        /// <param name="poly">多项式码</param>
        /// <param name="crcInit">校验码初始值</param>
        /// <returns></returns>
        public static bool CheckCRC16(byte[] value, ushort poly = 0xA001, ushort crcInit = 0xFFFF)
        {
            Contract.Requires(value != null && value.Length > 0);

            var crc16 = GetCRC16(value, poly, crcInit);
            if (crc16[^2] == crc16[^1] && crc16[^1] == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 计算CRC16校验码
        /// </summary>
        /// <param name="value">校验数据</param>
        /// <param name="poly">多项式码</param>
        /// <param name="crcInit">校验码初始值</param>
        /// <returns></returns>
        public static byte[] GetCRC16(byte[] value, ushort poly = 0xA001, ushort crcInit = 0xFFFF)
        {
            Contract.Requires(value != null && value.Length > 0);

            ushort crc = crcInit;
            for (int i = 0; i < value.Length; i++)
            {
                crc = (ushort)(crc ^ (value[i]));
                for (int j = 0; j < 8; j++)
                {
                    crc = (crc & 1) != 0 ? (ushort)((crc >> 1) ^ poly) : (ushort)(crc >> 1);
                }
            }

            byte hi = (byte)((crc & 0xFF00) >> 8);  //高位置
            byte lo = (byte)(crc & 0x00FF);         //低位置

            byte[] buffer = new byte[value.Length + 2];
            value.CopyTo(buffer, 0);
            buffer[^1] = hi;  // buffer.Length - 1
            buffer[^2] = lo;  // buffer.Length - 2
            return buffer;
        }
    }
}
