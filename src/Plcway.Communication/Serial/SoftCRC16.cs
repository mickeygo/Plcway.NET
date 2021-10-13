using System;

namespace Plcway.Communication.Serial
{
	/// <summary>
	/// 用于CRC16验证的类，提供了标准的验证方法，可以方便快速的对数据进行CRC校验
	/// </summary>
	/// <remarks>
	/// 本类提供了几个静态的方法，用来进行CRC16码的计算和验证的，多项式码可以自己指定配置，但是预置的寄存器为0xFF 0xFF
	/// </remarks>
	public class SoftCRC16
	{
		/// <summary>
		/// 来校验对应的接收数据的CRC校验码，默认多项式码为0xA001
		/// </summary>
		/// <param name="value">需要校验的数据，带CRC校验码</param>
		/// <returns>返回校验成功与否</returns>
		public static bool CheckCRC16(byte[] value)
		{
			return CheckCRC16(value, 160, 1);
		}

		/// <summary>
		/// 指定多项式码来校验对应的接收数据的CRC校验码
		/// </summary>
		/// <param name="value">需要校验的数据，带CRC校验码</param>
		/// <param name="CH">多项式码高位</param>
		/// <param name="CL">多项式码低位</param>
		/// <returns>返回校验成功与否</returns>
		public static bool CheckCRC16(byte[] value, byte CH, byte CL)
		{
			if (value == null || value.Length < 2)
			{
				return false;
			}

			int num = value.Length;
			byte[] array = new byte[num - 2];
			Array.Copy(value, 0, array, 0, array.Length);
			byte[] array2 = CRC16(array, CH, CL);
			if (array2[num - 2] == value[num - 2] && array2[num - 1] == value[num - 1])
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// 获取对应的数据的CRC校验码，默认多项式码为0xA001
		/// </summary>
		/// <param name="value">需要校验的数据，不包含CRC字节</param>
		/// <returns>返回带CRC校验码的字节数组，可用于串口发送</returns>
		public static byte[] CRC16(byte[] value)
		{
			return CRC16(value, 160, 1);
		}

		/// <summary>
		/// 通过指定多项式码来获取对应的数据的CRC校验码
		/// </summary>
		/// <param name="value">需要校验的数据，不包含CRC字节</param>
		/// <param name="CL">多项式码地位</param>
		/// <param name="CH">多项式码高位</param>
		/// <param name="preH">预置的高位值</param>
		/// <param name="preL">预置的低位值</param>
		/// <returns>返回带CRC校验码的字节数组，可用于串口发送</returns>
		public static byte[] CRC16(byte[] value, byte CH, byte CL, byte preH = byte.MaxValue, byte preL = byte.MaxValue)
		{
			byte[] array = new byte[value.Length + 2];
			value.CopyTo(array, 0);
			byte b = preL;
			byte b2 = preH;
			for (int i = 0; i < value.Length; i++)
			{
				b = (byte)(b ^ value[i]);
				for (int j = 0; j <= 7; j++)
				{
					byte b3 = b2;
					byte b4 = b;
					b2 = (byte)(b2 >> 1);
					b = (byte)(b >> 1);
					if ((b3 & 1) == 1)
					{
						b = (byte)(b | 0x80u);
					}
					if ((b4 & 1) == 1)
					{
						b2 = (byte)(b2 ^ CH);
						b = (byte)(b ^ CL);
					}
				}
			}
			array[^2] = b;
			array[^1] = b2;
			return array;
		}
	}
}
