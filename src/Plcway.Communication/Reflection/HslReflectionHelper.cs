using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Plcway.Communication.Core;

namespace Plcway.Communication.Reflection
{
	/// <summary>
	/// 反射的辅助类
	/// </summary>
	public class HslReflectionHelper
	{
		/// <summary>
		/// 从设备里读取支持Hsl特性的数据内容，该特性为<see cref="HslDeviceAddressAttribute" />，详细参考论坛的操作说明。
		/// </summary>
		/// <typeparam name="T">自定义的数据类型对象</typeparam>
		/// <param name="readWrite">读写接口的实现</param>
		/// <returns>包含是否成功的结果对象</returns>
		public static OperateResult<T> Read<T>(IReadWriteNet readWrite) where T : class, new()
		{
			Type typeFromHandle = typeof(T);
			object obj = typeFromHandle.Assembly.CreateInstance(typeFromHandle.FullName);
			PropertyInfo[] properties = typeFromHandle.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				object[] customAttributes = propertyInfo.GetCustomAttributes(typeof(HslDeviceAddressAttribute), inherit: false);
				if (customAttributes == null)
				{
					continue;
				}

				HslDeviceAddressAttribute? hslDeviceAddressAttribute = null;
				for (int j = 0; j < customAttributes.Length; j++)
				{
					HslDeviceAddressAttribute hslDeviceAddressAttribute2 = (HslDeviceAddressAttribute)customAttributes[j];
					if (hslDeviceAddressAttribute2.DeviceType != null && hslDeviceAddressAttribute2.DeviceType == readWrite.GetType())
					{
						hslDeviceAddressAttribute = hslDeviceAddressAttribute2;
						break;
					}
				}

				if (hslDeviceAddressAttribute == null)
				{
					for (int k = 0; k < customAttributes.Length; k++)
					{
						HslDeviceAddressAttribute hslDeviceAddressAttribute3 = (HslDeviceAddressAttribute)customAttributes[k];
						if (hslDeviceAddressAttribute3.DeviceType == null)
						{
							hslDeviceAddressAttribute = hslDeviceAddressAttribute3;
							break;
						}
					}
				}

				if (hslDeviceAddressAttribute == null)
				{
					continue;
				}

				Type propertyType = propertyInfo.PropertyType;
				if (propertyType == typeof(short))
				{
					OperateResult<short> operateResult = readWrite.ReadInt16(hslDeviceAddressAttribute.Address);
					if (!operateResult.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(operateResult);
					}
					propertyInfo.SetValue(obj, operateResult.Content, null);
				}
				else if (propertyType == typeof(short[]))
				{
					var operateResult2 = readWrite.ReadInt16(hslDeviceAddressAttribute.Address, (ushort)((hslDeviceAddressAttribute.Length <= 0) ? 1u : ((uint)hslDeviceAddressAttribute.Length)));
					if (!operateResult2.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(operateResult2);
					}
					propertyInfo.SetValue(obj, operateResult2.Content, null);
				}
				else if (propertyType == typeof(ushort))
				{
					OperateResult<ushort> operateResult3 = readWrite.ReadUInt16(hslDeviceAddressAttribute.Address);
					if (!operateResult3.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(operateResult3);
					}
					propertyInfo.SetValue(obj, operateResult3.Content, null);
				}
				else if (propertyType == typeof(ushort[]))
				{
					var operateResult4 = readWrite.ReadUInt16(hslDeviceAddressAttribute.Address, (ushort)((hslDeviceAddressAttribute.Length <= 0) ? 1u : ((uint)hslDeviceAddressAttribute.Length)));
					if (!operateResult4.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(operateResult4);
					}
					propertyInfo.SetValue(obj, operateResult4.Content, null);
				}
				else if (propertyType == typeof(int))
				{
					OperateResult<int> operateResult5 = readWrite.ReadInt32(hslDeviceAddressAttribute.Address);
					if (!operateResult5.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(operateResult5);
					}
					propertyInfo.SetValue(obj, operateResult5.Content, null);
				}
				else if (propertyType == typeof(int[]))
				{
					var operateResult6 = readWrite.ReadInt32(hslDeviceAddressAttribute.Address, (ushort)((hslDeviceAddressAttribute.Length <= 0) ? 1u : ((uint)hslDeviceAddressAttribute.Length)));
					if (!operateResult6.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(operateResult6);
					}
					propertyInfo.SetValue(obj, operateResult6.Content, null);
				}
				else if (propertyType == typeof(uint))
				{
					OperateResult<uint> operateResult7 = readWrite.ReadUInt32(hslDeviceAddressAttribute.Address);
					if (!operateResult7.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(operateResult7);
					}
					propertyInfo.SetValue(obj, operateResult7.Content, null);
				}
				else if (propertyType == typeof(uint[]))
				{
					OperateResult<uint[]> operateResult8 = readWrite.ReadUInt32(hslDeviceAddressAttribute.Address, (ushort)((hslDeviceAddressAttribute.Length <= 0) ? 1u : ((uint)hslDeviceAddressAttribute.Length)));
					if (!operateResult8.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(operateResult8);
					}
					propertyInfo.SetValue(obj, operateResult8.Content, null);
				}
				else if (propertyType == typeof(long))
				{
					OperateResult<long> operateResult9 = readWrite.ReadInt64(hslDeviceAddressAttribute.Address);
					if (!operateResult9.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(operateResult9);
					}
					propertyInfo.SetValue(obj, operateResult9.Content, null);
				}
				else if (propertyType == typeof(long[]))
				{
					OperateResult<long[]> operateResult10 = readWrite.ReadInt64(hslDeviceAddressAttribute.Address, (ushort)((hslDeviceAddressAttribute.Length <= 0) ? 1u : ((uint)hslDeviceAddressAttribute.Length)));
					if (!operateResult10.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(operateResult10);
					}
					propertyInfo.SetValue(obj, operateResult10.Content, null);
				}
				else if (propertyType == typeof(ulong))
				{
					OperateResult<ulong> operateResult11 = readWrite.ReadUInt64(hslDeviceAddressAttribute.Address);
					if (!operateResult11.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(operateResult11);
					}
					propertyInfo.SetValue(obj, operateResult11.Content, null);
				}
				else if (propertyType == typeof(ulong[]))
				{
					OperateResult<ulong[]> operateResult12 = readWrite.ReadUInt64(hslDeviceAddressAttribute.Address, (ushort)((hslDeviceAddressAttribute.Length <= 0) ? 1u : ((uint)hslDeviceAddressAttribute.Length)));
					if (!operateResult12.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(operateResult12);
					}
					propertyInfo.SetValue(obj, operateResult12.Content, null);
				}
				else if (propertyType == typeof(float))
				{
					OperateResult<float> operateResult13 = readWrite.ReadFloat(hslDeviceAddressAttribute.Address);
					if (!operateResult13.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(operateResult13);
					}
					propertyInfo.SetValue(obj, operateResult13.Content, null);
				}
				else if (propertyType == typeof(float[]))
				{
					OperateResult<float[]> operateResult14 = readWrite.ReadFloat(hslDeviceAddressAttribute.Address, (ushort)((hslDeviceAddressAttribute.Length <= 0) ? 1u : ((uint)hslDeviceAddressAttribute.Length)));
					if (!operateResult14.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(operateResult14);
					}
					propertyInfo.SetValue(obj, operateResult14.Content, null);
				}
				else if (propertyType == typeof(double))
				{
					OperateResult<double> operateResult15 = readWrite.ReadDouble(hslDeviceAddressAttribute.Address);
					if (!operateResult15.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(operateResult15);
					}
					propertyInfo.SetValue(obj, operateResult15.Content, null);
				}
				else if (propertyType == typeof(double[]))
				{
					OperateResult<double[]> operateResult16 = readWrite.ReadDouble(hslDeviceAddressAttribute.Address, (ushort)((hslDeviceAddressAttribute.Length <= 0) ? 1u : ((uint)hslDeviceAddressAttribute.Length)));
					if (!operateResult16.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(operateResult16);
					}
					propertyInfo.SetValue(obj, operateResult16.Content, null);
				}
				else if (propertyType == typeof(string))
				{
					OperateResult<string> operateResult17 = readWrite.ReadString(hslDeviceAddressAttribute.Address, (ushort)((hslDeviceAddressAttribute.Length <= 0) ? 1u : ((uint)hslDeviceAddressAttribute.Length)));
					if (!operateResult17.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(operateResult17);
					}
					propertyInfo.SetValue(obj, operateResult17.Content, null);
				}
				else if (propertyType == typeof(byte[]))
				{
					OperateResult<byte[]> operateResult18 = readWrite.Read(hslDeviceAddressAttribute.Address, (ushort)((hslDeviceAddressAttribute.Length <= 0) ? 1u : ((uint)hslDeviceAddressAttribute.Length)));
					if (!operateResult18.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(operateResult18);
					}
					propertyInfo.SetValue(obj, operateResult18.Content, null);
				}
				else if (propertyType == typeof(bool))
				{
					OperateResult<bool> operateResult19 = readWrite.ReadBool(hslDeviceAddressAttribute.Address);
					if (!operateResult19.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(operateResult19);
					}
					propertyInfo.SetValue(obj, operateResult19.Content, null);
				}
				else if (propertyType == typeof(bool[]))
				{
					OperateResult<bool[]> operateResult20 = readWrite.ReadBool(hslDeviceAddressAttribute.Address, (ushort)((hslDeviceAddressAttribute.Length <= 0) ? 1u : ((uint)hslDeviceAddressAttribute.Length)));
					if (!operateResult20.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(operateResult20);
					}
					propertyInfo.SetValue(obj, operateResult20.Content, null);
				}
			}

			return OperateResult.CreateSuccessResult((T)obj);
		}

		/// <summary>
		/// 从设备里读取支持Hsl特性的数据内容，该特性为<see cref="HslDeviceAddressAttribute" />，详细参考论坛的操作说明。
		/// </summary>
		/// <typeparam name="T">自定义的数据类型对象</typeparam>
		/// <param name="data">自定义的数据对象</param>
		/// <param name="readWrite">数据读写对象</param>
		/// <returns>包含是否成功的结果对象</returns>
		/// <exception cref="T:System.ArgumentNullException"></exception>
		public static OperateResult Write<T>(T data, IReadWriteNet readWrite) where T : class, new()
		{
			if (data == null)
			{
				throw new ArgumentNullException(nameof(data));
			}

			Type typeFromHandle = typeof(T);
			var properties = typeFromHandle.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			var array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				var customAttributes = propertyInfo.GetCustomAttributes<HslDeviceAddressAttribute>(false);
				if (!customAttributes.Any())
				{
					continue;
				}

				var hslDeviceAddressAttribute = customAttributes.FirstOrDefault(s => s.DeviceType == readWrite.GetType());
				if (hslDeviceAddressAttribute == null)
				{
					hslDeviceAddressAttribute = customAttributes.FirstOrDefault(s => s.DeviceType == null);
				}

				if (hslDeviceAddressAttribute == null)
				{
					continue;
				}

				Type propertyType = propertyInfo.PropertyType;
				if (propertyType == typeof(short))
				{
					short value = (short)propertyInfo.GetValue(data, null);
					OperateResult operateResult = readWrite.Write(hslDeviceAddressAttribute.Address, value);
					if (!operateResult.IsSuccess)
					{
						return operateResult;
					}
				}
				else if (propertyType == typeof(short[]))
				{
					short[] values = (short[])propertyInfo.GetValue(data, null);
					OperateResult operateResult2 = readWrite.Write(hslDeviceAddressAttribute.Address, values);
					if (!operateResult2.IsSuccess)
					{
						return operateResult2;
					}
				}
				else if (propertyType == typeof(ushort))
				{
					ushort value2 = (ushort)propertyInfo.GetValue(data, null);
					OperateResult operateResult3 = readWrite.Write(hslDeviceAddressAttribute.Address, value2);
					if (!operateResult3.IsSuccess)
					{
						return operateResult3;
					}
				}
				else if (propertyType == typeof(ushort[]))
				{
					ushort[] values2 = (ushort[])propertyInfo.GetValue(data, null);
					OperateResult operateResult4 = readWrite.Write(hslDeviceAddressAttribute.Address, values2);
					if (!operateResult4.IsSuccess)
					{
						return operateResult4;
					}
				}
				else if (propertyType == typeof(int))
				{
					int value3 = (int)propertyInfo.GetValue(data, null);
					OperateResult operateResult5 = readWrite.Write(hslDeviceAddressAttribute.Address, value3);
					if (!operateResult5.IsSuccess)
					{
						return operateResult5;
					}
				}
				else if (propertyType == typeof(int[]))
				{
					int[] values3 = (int[])propertyInfo.GetValue(data, null);
					OperateResult operateResult6 = readWrite.Write(hslDeviceAddressAttribute.Address, values3);
					if (!operateResult6.IsSuccess)
					{
						return operateResult6;
					}
				}
				else if (propertyType == typeof(uint))
				{
					uint value4 = (uint)propertyInfo.GetValue(data, null);
					OperateResult operateResult7 = readWrite.Write(hslDeviceAddressAttribute.Address, value4);
					if (!operateResult7.IsSuccess)
					{
						return operateResult7;
					}
				}
				else if (propertyType == typeof(uint[]))
				{
					uint[] values4 = (uint[])propertyInfo.GetValue(data, null);
					OperateResult operateResult8 = readWrite.Write(hslDeviceAddressAttribute.Address, values4);
					if (!operateResult8.IsSuccess)
					{
						return operateResult8;
					}
				}
				else if (propertyType == typeof(long))
				{
					long value5 = (long)propertyInfo.GetValue(data, null);
					OperateResult operateResult9 = readWrite.Write(hslDeviceAddressAttribute.Address, value5);
					if (!operateResult9.IsSuccess)
					{
						return operateResult9;
					}
				}
				else if (propertyType == typeof(long[]))
				{
					long[] values5 = (long[])propertyInfo.GetValue(data, null);
					OperateResult operateResult10 = readWrite.Write(hslDeviceAddressAttribute.Address, values5);
					if (!operateResult10.IsSuccess)
					{
						return operateResult10;
					}
				}
				else if (propertyType == typeof(ulong))
				{
					ulong value6 = (ulong)propertyInfo.GetValue(data, null);
					OperateResult operateResult11 = readWrite.Write(hslDeviceAddressAttribute.Address, value6);
					if (!operateResult11.IsSuccess)
					{
						return operateResult11;
					}
				}
				else if (propertyType == typeof(ulong[]))
				{
					ulong[] values6 = (ulong[])propertyInfo.GetValue(data, null);
					OperateResult operateResult12 = readWrite.Write(hslDeviceAddressAttribute.Address, values6);
					if (!operateResult12.IsSuccess)
					{
						return operateResult12;
					}
				}
				else if (propertyType == typeof(float))
				{
					float value7 = (float)propertyInfo.GetValue(data, null);
					OperateResult operateResult13 = readWrite.Write(hslDeviceAddressAttribute.Address, value7);
					if (!operateResult13.IsSuccess)
					{
						return operateResult13;
					}
				}
				else if (propertyType == typeof(float[]))
				{
					float[] values7 = (float[])propertyInfo.GetValue(data, null);
					OperateResult operateResult14 = readWrite.Write(hslDeviceAddressAttribute.Address, values7);
					if (!operateResult14.IsSuccess)
					{
						return operateResult14;
					}
				}
				else if (propertyType == typeof(double))
				{
					double value8 = (double)propertyInfo.GetValue(data, null);
					OperateResult operateResult15 = readWrite.Write(hslDeviceAddressAttribute.Address, value8);
					if (!operateResult15.IsSuccess)
					{
						return operateResult15;
					}
				}
				else if (propertyType == typeof(double[]))
				{
					double[] values8 = (double[])propertyInfo.GetValue(data, null);
					OperateResult operateResult16 = readWrite.Write(hslDeviceAddressAttribute.Address, values8);
					if (!operateResult16.IsSuccess)
					{
						return operateResult16;
					}
				}
				else if (propertyType == typeof(string))
				{
					string value9 = (string)propertyInfo.GetValue(data, null);
					OperateResult operateResult17 = readWrite.Write(hslDeviceAddressAttribute.Address, value9);
					if (!operateResult17.IsSuccess)
					{
						return operateResult17;
					}
				}
				else if (propertyType == typeof(byte[]))
				{
					byte[] value10 = (byte[])propertyInfo.GetValue(data, null);
					OperateResult operateResult18 = readWrite.Write(hslDeviceAddressAttribute.Address, value10);
					if (!operateResult18.IsSuccess)
					{
						return operateResult18;
					}
				}
				else if (propertyType == typeof(bool))
				{
					bool value11 = (bool)propertyInfo.GetValue(data, null);
					OperateResult operateResult19 = readWrite.Write(hslDeviceAddressAttribute.Address, value11);
					if (!operateResult19.IsSuccess)
					{
						return operateResult19;
					}
				}
				else if (propertyType == typeof(bool[]))
				{
					bool[] value12 = (bool[])propertyInfo.GetValue(data, null);
					OperateResult operateResult20 = readWrite.Write(hslDeviceAddressAttribute.Address, value12);
					if (!operateResult20.IsSuccess)
					{
						return operateResult20;
					}
				}
			}
			return OperateResult.CreateSuccessResult(data);
		}

		/// <summary>
		/// 使用表达式树的方式来给一个属性赋值
		/// </summary>
		/// <param name="propertyInfo">属性信息</param>
		/// <param name="obj">对象信息</param>
		/// <param name="objValue">实际的值</param>
		public static void SetPropertyExp<T, K>(PropertyInfo propertyInfo, T obj, K objValue)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "obj");
			ParameterExpression parameterExpression2 = Expression.Parameter(propertyInfo.PropertyType, "objValue");
			MethodCallExpression body = Expression.Call(parameterExpression, propertyInfo.GetSetMethod(), parameterExpression2);
			Expression<Action<T, K>> expression = Expression.Lambda<Action<T, K>>(body, new ParameterExpression[2] { parameterExpression, parameterExpression2 });
			expression.Compile()(obj, objValue);
		}

		/// <summary>
		/// 从设备里读取支持Hsl特性的数据内容，该特性为<see cref="T:HslCommunication.Reflection.HslDeviceAddressAttribute" />，详细参考论坛的操作说明。
		/// </summary>
		/// <typeparam name="T">自定义的数据类型对象</typeparam>
		/// <param name="readWrite">读写接口的实现</param>
		/// <returns>包含是否成功的结果对象</returns>
		public static async Task<OperateResult<T>> ReadAsync<T>(IReadWriteNet readWrite) where T : class, new()
		{
			Type type = typeof(T);
			object obj = type.Assembly.CreateInstance(type.FullName);
			var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			var array = properties;
			foreach (PropertyInfo property in array)
			{
				var attributes = property.GetCustomAttributes<HslDeviceAddressAttribute>(false);
				if (!attributes.Any())
				{
					continue;
				}

				var hslAttribute = attributes.FirstOrDefault(s => s.DeviceType == readWrite.GetType()); ;
				if (hslAttribute == null)
				{
					hslAttribute = attributes.FirstOrDefault(s => s.DeviceType == null);
				}

				if (hslAttribute == null)
				{
					continue;
				}

				Type propertyType = property.PropertyType;
				if (propertyType == typeof(short))
				{
					OperateResult<short> valueResult8 = await readWrite.ReadInt16Async(hslAttribute.Address);
					if (!valueResult8.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(valueResult8);
					}
					property.SetValue(obj, valueResult8.Content, null);
				}
				else if (propertyType == typeof(short[]))
				{
					OperateResult<short[]> valueResult9 = await readWrite.ReadInt16Async(hslAttribute.Address, (ushort)((hslAttribute.Length <= 0) ? 1u : ((uint)hslAttribute.Length)));
					if (!valueResult9.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(valueResult9);
					}
					property.SetValue(obj, valueResult9.Content, null);
				}
				else if (propertyType == typeof(ushort))
				{
					OperateResult<ushort> valueResult12 = await readWrite.ReadUInt16Async(hslAttribute.Address);
					if (!valueResult12.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(valueResult12);
					}
					property.SetValue(obj, valueResult12.Content, null);
				}
				else if (propertyType == typeof(ushort[]))
				{
					OperateResult<ushort[]> valueResult13 = await readWrite.ReadUInt16Async(hslAttribute.Address, (ushort)((hslAttribute.Length <= 0) ? 1u : ((uint)hslAttribute.Length)));
					if (!valueResult13.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(valueResult13);
					}
					property.SetValue(obj, valueResult13.Content, null);
				}
				else if (propertyType == typeof(int))
				{
					OperateResult<int> valueResult14 = await readWrite.ReadInt32Async(hslAttribute.Address);
					if (!valueResult14.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(valueResult14);
					}
					property.SetValue(obj, valueResult14.Content, null);
				}
				else if (propertyType == typeof(int[]))
				{
					OperateResult<int[]> valueResult17 = await readWrite.ReadInt32Async(hslAttribute.Address, (ushort)((hslAttribute.Length <= 0) ? 1u : ((uint)hslAttribute.Length)));
					if (!valueResult17.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(valueResult17);
					}
					property.SetValue(obj, valueResult17.Content, null);
				}
				else if (propertyType == typeof(uint))
				{
					OperateResult<uint> valueResult18 = await readWrite.ReadUInt32Async(hslAttribute.Address);
					if (!valueResult18.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(valueResult18);
					}
					property.SetValue(obj, valueResult18.Content, null);
				}
				else if (propertyType == typeof(uint[]))
				{
					OperateResult<uint[]> valueResult19 = await readWrite.ReadUInt32Async(hslAttribute.Address, (ushort)((hslAttribute.Length <= 0) ? 1u : ((uint)hslAttribute.Length)));
					if (!valueResult19.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(valueResult19);
					}
					property.SetValue(obj, valueResult19.Content, null);
				}
				else if (propertyType == typeof(long))
				{
					OperateResult<long> valueResult20 = await readWrite.ReadInt64Async(hslAttribute.Address);
					if (!valueResult20.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(valueResult20);
					}
					property.SetValue(obj, valueResult20.Content, null);
				}
				else if (propertyType == typeof(long[]))
				{
					OperateResult<long[]> valueResult16 = await readWrite.ReadInt64Async(hslAttribute.Address, (ushort)((hslAttribute.Length <= 0) ? 1u : ((uint)hslAttribute.Length)));
					if (!valueResult16.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(valueResult16);
					}
					property.SetValue(obj, valueResult16.Content, null);
				}
				else if (propertyType == typeof(ulong))
				{
					OperateResult<ulong> valueResult15 = await readWrite.ReadUInt64Async(hslAttribute.Address);
					if (!valueResult15.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(valueResult15);
					}
					property.SetValue(obj, valueResult15.Content, null);
				}
				else if (propertyType == typeof(ulong[]))
				{
					OperateResult<ulong[]> valueResult11 = await readWrite.ReadUInt64Async(hslAttribute.Address, (ushort)((hslAttribute.Length <= 0) ? 1u : ((uint)hslAttribute.Length)));
					if (!valueResult11.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(valueResult11);
					}
					property.SetValue(obj, valueResult11.Content, null);
				}
				else if (propertyType == typeof(float))
				{
					OperateResult<float> valueResult10 = await readWrite.ReadFloatAsync(hslAttribute.Address);
					if (!valueResult10.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(valueResult10);
					}
					property.SetValue(obj, valueResult10.Content, null);
				}
				else if (propertyType == typeof(float[]))
				{
					OperateResult<float[]> valueResult7 = await readWrite.ReadFloatAsync(hslAttribute.Address, (ushort)((hslAttribute.Length <= 0) ? 1u : ((uint)hslAttribute.Length)));
					if (!valueResult7.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(valueResult7);
					}
					property.SetValue(obj, valueResult7.Content, null);
				}
				else if (propertyType == typeof(double))
				{
					OperateResult<double> valueResult6 = await readWrite.ReadDoubleAsync(hslAttribute.Address);
					if (!valueResult6.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(valueResult6);
					}
					property.SetValue(obj, valueResult6.Content, null);
				}
				else if (propertyType == typeof(double[]))
				{
					OperateResult<double[]> valueResult5 = await readWrite.ReadDoubleAsync(hslAttribute.Address, (ushort)((hslAttribute.Length <= 0) ? 1u : ((uint)hslAttribute.Length)));
					if (!valueResult5.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(valueResult5);
					}
					property.SetValue(obj, valueResult5.Content, null);
				}
				else if (propertyType == typeof(string))
				{
					OperateResult<string> valueResult4 = await readWrite.ReadStringAsync(hslAttribute.Address, (ushort)((hslAttribute.Length <= 0) ? 1u : ((uint)hslAttribute.Length)));
					if (!valueResult4.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(valueResult4);
					}
					property.SetValue(obj, valueResult4.Content, null);
				}
				else if (propertyType == typeof(byte[]))
				{
					OperateResult<byte[]> valueResult3 = await readWrite.ReadAsync(hslAttribute.Address, (ushort)((hslAttribute.Length <= 0) ? 1u : ((uint)hslAttribute.Length)));
					if (!valueResult3.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(valueResult3);
					}
					property.SetValue(obj, valueResult3.Content, null);
				}
				else if (propertyType == typeof(bool))
				{
					OperateResult<bool> valueResult2 = await readWrite.ReadBoolAsync(hslAttribute.Address);
					if (!valueResult2.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(valueResult2);
					}
					property.SetValue(obj, valueResult2.Content, null);
				}
				else if (propertyType == typeof(bool[]))
				{
					OperateResult<bool[]> valueResult = await readWrite.ReadBoolAsync(hslAttribute.Address, (ushort)((hslAttribute.Length <= 0) ? 1u : ((uint)hslAttribute.Length)));
					if (!valueResult.IsSuccess)
					{
						return OperateResult.CreateFailedResult<T>(valueResult);
					}
					property.SetValue(obj, valueResult.Content, null);
				}
			}
			return OperateResult.CreateSuccessResult((T)obj);
		}

		/// <summary>
		/// 从设备里读取支持Hsl特性的数据内容，该特性为<see cref="T:HslCommunication.Reflection.HslDeviceAddressAttribute" />，详细参考论坛的操作说明。
		/// </summary>
		/// <typeparam name="T">自定义的数据类型对象</typeparam>
		/// <param name="data">自定义的数据对象</param>
		/// <param name="readWrite">数据读写对象</param>
		/// <returns>包含是否成功的结果对象</returns>
		/// <exception cref="T:System.ArgumentNullException"></exception>
		public static async Task<OperateResult> WriteAsync<T>(T data, IReadWriteNet readWrite) where T : class, new()
		{
			if (data == null)
			{
				throw new ArgumentNullException(nameof(data));
			}

			Type type = typeof(T);
			var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			var array = properties;
			foreach (PropertyInfo property in array)
			{
				var attributes = property.GetCustomAttributes<HslDeviceAddressAttribute>(false);
				if (!attributes.Any())
				{
					continue;
				}

				var hslAttribute = attributes.FirstOrDefault(s => s.DeviceType == readWrite.GetType()); ;
				if (hslAttribute == null)
				{
					hslAttribute = attributes.FirstOrDefault(s => s.DeviceType == null);
				}

				if (hslAttribute == null)
				{
					continue;
				}

				Type propertyType = property.PropertyType;
				if (propertyType == typeof(short))
				{
					OperateResult writeResult20 = await readWrite.WriteAsync(value: (short)property.GetValue(data, null), address: hslAttribute.Address);
					if (!writeResult20.IsSuccess)
					{
						return writeResult20;
					}
				}
				else if (propertyType == typeof(short[]))
				{
					OperateResult writeResult19 = await readWrite.WriteAsync(values: (short[])property.GetValue(data, null), address: hslAttribute.Address);
					if (!writeResult19.IsSuccess)
					{
						return writeResult19;
					}
				}
				else if (propertyType == typeof(ushort))
				{
					OperateResult writeResult18 = await readWrite.WriteAsync(value: (ushort)property.GetValue(data, null), address: hslAttribute.Address);
					if (!writeResult18.IsSuccess)
					{
						return writeResult18;
					}
				}
				else if (propertyType == typeof(ushort[]))
				{
					OperateResult writeResult17 = await readWrite.WriteAsync(values: (ushort[])property.GetValue(data, null), address: hslAttribute.Address);
					if (!writeResult17.IsSuccess)
					{
						return writeResult17;
					}
				}
				else if (propertyType == typeof(int))
				{
					OperateResult writeResult16 = await readWrite.WriteAsync(value: (int)property.GetValue(data, null), address: hslAttribute.Address);
					if (!writeResult16.IsSuccess)
					{
						return writeResult16;
					}
				}
				else if (propertyType == typeof(int[]))
				{
					OperateResult writeResult15 = await readWrite.WriteAsync(values: (int[])property.GetValue(data, null), address: hslAttribute.Address);
					if (!writeResult15.IsSuccess)
					{
						return writeResult15;
					}
				}
				else if (propertyType == typeof(uint))
				{
					OperateResult writeResult14 = await readWrite.WriteAsync(value: (uint)property.GetValue(data, null), address: hslAttribute.Address);
					if (!writeResult14.IsSuccess)
					{
						return writeResult14;
					}
				}
				else if (propertyType == typeof(uint[]))
				{
					OperateResult writeResult13 = await readWrite.WriteAsync(values: (uint[])property.GetValue(data, null), address: hslAttribute.Address);
					if (!writeResult13.IsSuccess)
					{
						return writeResult13;
					}
				}
				else if (propertyType == typeof(long))
				{
					OperateResult writeResult12 = await readWrite.WriteAsync(value: (long)property.GetValue(data, null), address: hslAttribute.Address);
					if (!writeResult12.IsSuccess)
					{
						return writeResult12;
					}
				}
				else if (propertyType == typeof(long[]))
				{
					OperateResult writeResult11 = await readWrite.WriteAsync(values: (long[])property.GetValue(data, null), address: hslAttribute.Address);
					if (!writeResult11.IsSuccess)
					{
						return writeResult11;
					}
				}
				else if (propertyType == typeof(ulong))
				{
					OperateResult writeResult10 = await readWrite.WriteAsync(value: (ulong)property.GetValue(data, null), address: hslAttribute.Address);
					if (!writeResult10.IsSuccess)
					{
						return writeResult10;
					}
				}
				else if (propertyType == typeof(ulong[]))
				{
					OperateResult writeResult9 = await readWrite.WriteAsync(values: (ulong[])property.GetValue(data, null), address: hslAttribute.Address);
					if (!writeResult9.IsSuccess)
					{
						return writeResult9;
					}
				}
				else if (propertyType == typeof(float))
				{
					OperateResult writeResult8 = await readWrite.WriteAsync(value: (float)property.GetValue(data, null), address: hslAttribute.Address);
					if (!writeResult8.IsSuccess)
					{
						return writeResult8;
					}
				}
				else if (propertyType == typeof(float[]))
				{
					OperateResult writeResult7 = await readWrite.WriteAsync(values: (float[])property.GetValue(data, null), address: hslAttribute.Address);
					if (!writeResult7.IsSuccess)
					{
						return writeResult7;
					}
				}
				else if (propertyType == typeof(double))
				{
					OperateResult writeResult6 = await readWrite.WriteAsync(value: (double)property.GetValue(data, null), address: hslAttribute.Address);
					if (!writeResult6.IsSuccess)
					{
						return writeResult6;
					}
				}
				else if (propertyType == typeof(double[]))
				{
					OperateResult writeResult5 = await readWrite.WriteAsync(values: (double[])property.GetValue(data, null), address: hslAttribute.Address);
					if (!writeResult5.IsSuccess)
					{
						return writeResult5;
					}
				}
				else if (propertyType == typeof(string))
				{
					OperateResult writeResult4 = await readWrite.WriteAsync(value: (string)property.GetValue(data, null), address: hslAttribute.Address);
					if (!writeResult4.IsSuccess)
					{
						return writeResult4;
					}
				}
				else if (propertyType == typeof(byte[]))
				{
					OperateResult writeResult3 = await readWrite.WriteAsync(value: (byte[])property.GetValue(data, null), address: hslAttribute.Address);
					if (!writeResult3.IsSuccess)
					{
						return writeResult3;
					}
				}
				else if (propertyType == typeof(bool))
				{
					OperateResult writeResult2 = await readWrite.WriteAsync(value: (bool)property.GetValue(data, null), address: hslAttribute.Address);
					if (!writeResult2.IsSuccess)
					{
						return writeResult2;
					}
				}
				else if (propertyType == typeof(bool[]))
				{
					OperateResult writeResult = await readWrite.WriteAsync(value: (bool[])property.GetValue(data, null), address: hslAttribute.Address);
					if (!writeResult.IsSuccess)
					{
						return writeResult;
					}
				}
			}
			return OperateResult.CreateSuccessResult(data);
		}

		internal static void SetPropertyObjectValue(PropertyInfo property, object obj, string value)
		{
			Type propertyType = property.PropertyType;
			if (propertyType == typeof(short))
			{
				property.SetValue(obj, short.Parse(value), null);
			}
			else if (propertyType == typeof(ushort))
			{
				property.SetValue(obj, ushort.Parse(value), null);
			}
			else if (propertyType == typeof(int))
			{
				property.SetValue(obj, int.Parse(value), null);
			}
			else if (propertyType == typeof(uint))
			{
				property.SetValue(obj, uint.Parse(value), null);
			}
			else if (propertyType == typeof(long))
			{
				property.SetValue(obj, long.Parse(value), null);
			}
			else if (propertyType == typeof(ulong))
			{
				property.SetValue(obj, ulong.Parse(value), null);
			}
			else if (propertyType == typeof(float))
			{
				property.SetValue(obj, float.Parse(value), null);
			}
			else if (propertyType == typeof(double))
			{
				property.SetValue(obj, double.Parse(value), null);
			}
			else if (propertyType == typeof(string))
			{
				property.SetValue(obj, value, null);
			}
			else if (propertyType == typeof(byte))
			{
				property.SetValue(obj, byte.Parse(value), null);
			}
			else if (propertyType == typeof(bool))
			{
				property.SetValue(obj, bool.Parse(value), null);
			}
			else
			{
				property.SetValue(obj, value, null);
			}
		}

		internal static void SetPropertyObjectValueArray(PropertyInfo property, object obj, string[] values)
		{
			Type propertyType = property.PropertyType;
			if (propertyType == typeof(short[]))
			{
				property.SetValue(obj, values.Select((string m) => short.Parse(m)).ToArray(), null);
			}
			else if (propertyType == typeof(List<short>))
			{
				property.SetValue(obj, values.Select((string m) => short.Parse(m)).ToList(), null);
			}
			else if (propertyType == typeof(ushort[]))
			{
				property.SetValue(obj, values.Select((string m) => ushort.Parse(m)).ToArray(), null);
			}
			else if (propertyType == typeof(List<ushort>))
			{
				property.SetValue(obj, values.Select((string m) => ushort.Parse(m)).ToList(), null);
			}
			else if (propertyType == typeof(int[]))
			{
				property.SetValue(obj, values.Select((string m) => int.Parse(m)).ToArray(), null);
			}
			else if (propertyType == typeof(List<int>))
			{
				property.SetValue(obj, values.Select((string m) => int.Parse(m)).ToList(), null);
			}
			else if (propertyType == typeof(uint[]))
			{
				property.SetValue(obj, values.Select((string m) => uint.Parse(m)).ToArray(), null);
			}
			else if (propertyType == typeof(List<uint>))
			{
				property.SetValue(obj, values.Select((string m) => uint.Parse(m)).ToList(), null);
			}
			else if (propertyType == typeof(long[]))
			{
				property.SetValue(obj, values.Select((string m) => long.Parse(m)).ToArray(), null);
			}
			else if (propertyType == typeof(List<long>))
			{
				property.SetValue(obj, values.Select((string m) => long.Parse(m)).ToList(), null);
			}
			else if (propertyType == typeof(ulong[]))
			{
				property.SetValue(obj, values.Select((string m) => ulong.Parse(m)).ToArray(), null);
			}
			else if (propertyType == typeof(List<ulong>))
			{
				property.SetValue(obj, values.Select((string m) => ulong.Parse(m)).ToList(), null);
			}
			else if (propertyType == typeof(float[]))
			{
				property.SetValue(obj, values.Select((string m) => float.Parse(m)).ToArray(), null);
			}
			else if (propertyType == typeof(List<float>))
			{
				property.SetValue(obj, values.Select((string m) => float.Parse(m)).ToList(), null);
			}
			else if (propertyType == typeof(double[]))
			{
				property.SetValue(obj, values.Select((string m) => double.Parse(m)).ToArray(), null);
			}
			else if (propertyType == typeof(double[]))
			{
				property.SetValue(obj, values.Select((string m) => double.Parse(m)).ToList(), null);
			}
			else if (propertyType == typeof(string[]))
			{
				property.SetValue(obj, values, null);
			}
			else if (propertyType == typeof(List<string>))
			{
				property.SetValue(obj, new List<string>(values), null);
			}
			else if (propertyType == typeof(byte[]))
			{
				property.SetValue(obj, values.Select((string m) => byte.Parse(m)).ToArray(), null);
			}
			else if (propertyType == typeof(List<byte>))
			{
				property.SetValue(obj, values.Select((string m) => byte.Parse(m)).ToList(), null);
			}
			else if (propertyType == typeof(bool[]))
			{
				property.SetValue(obj, values.Select((string m) => bool.Parse(m)).ToArray(), null);
			}
			else if (propertyType == typeof(List<bool>))
			{
				property.SetValue(obj, values.Select((string m) => bool.Parse(m)).ToList(), null);
			}
			else
			{
				property.SetValue(obj, values, null);
			}
		}
	}
}