using System;
using System.Collections.Generic;
using Plcway.Communication.Core;

namespace Plcway.Communication.Basic
{
	/// <summary>
	/// 一个高效的数组管理类，用于高效控制固定长度的数组实现
	/// </summary>
	/// <typeparam name="T">泛型类型</typeparam>
	public class SharpList<T>
	{
		private T[] array;

		private readonly int capacity = 2048;

		private readonly int count;

        private int lastIndex;

        private readonly SimpleHybirdLock hybirdLock;

		/// <summary>
		/// 获取数组的个数
		/// </summary>
		public int Count => count;

		/// <summary>
		/// 获取或设置指定索引的位置的数据
		/// </summary>
		/// <param name="index">索引位置</param>
		/// <returns>数据值</returns>
		public T this[int index]
		{
			get
			{
				if (index < 0)
				{
					throw new IndexOutOfRangeException("Index must larger than zero");
				}
				if (index >= count)
				{
					throw new IndexOutOfRangeException("Index must smaller than array length");
				}

				T val;
				hybirdLock.Enter();
				val = (lastIndex >= count) ? array[index + lastIndex - count] : array[index];
				hybirdLock.Leave();
				return val;
			}
			set
			{
				if (index < 0)
				{
					throw new IndexOutOfRangeException("Index must larger than zero");
				}
				if (index >= count)
				{
					throw new IndexOutOfRangeException("Index must smaller than array length");
				}

				hybirdLock.Enter();
				if (lastIndex < count)
				{
					array[index] = value;
				}
				else
				{
					array[index + lastIndex - count] = value;
				}
				hybirdLock.Leave();
			}
		}

		/// <summary>
		/// 实例化一个对象，需要指定数组的最大数据对象
		/// </summary>
		/// <param name="count">数据的个数</param>
		/// <param name="appendLast">是否从最后一个数添加</param>
		public SharpList(int count, bool appendLast = false)
		{
			if (count > 8192)
			{
				capacity = 4096;
			}
			array = new T[capacity + count];
			hybirdLock = new SimpleHybirdLock();
			this.count = count;
			if (appendLast)
			{
				lastIndex = count;
			}
		}

		/// <summary>
		/// 新增一个数据值
		/// </summary>
		/// <param name="value">数据值</param>
		public void Add(T value)
		{
			hybirdLock.Enter();
			if (lastIndex < capacity + count)
			{
				array[lastIndex++] = value;
			}
			else
			{
				T[] destinationArray = new T[capacity + count];
				Array.Copy(array, capacity, destinationArray, 0, count);
				array = destinationArray;
				lastIndex = count;
			}
			hybirdLock.Leave();
		}

		/// <summary>
		/// 批量的增加数据
		/// </summary>
		/// <param name="values">批量数据信息</param>
		public void Add(IEnumerable<T> values)
		{
			foreach (T value in values)
			{
				Add(value);
			}
		}

		/// <summary>
		/// 获取数据的数组值
		/// </summary>
		/// <returns>数组值</returns>
		public T[] ToArray()
		{
			T[] array;
			hybirdLock.Enter();
			if (lastIndex < count)
			{
				array = new T[lastIndex];
				Array.Copy(this.array, 0, array, 0, lastIndex);
			}
			else
			{
				array = new T[count];
				Array.Copy(this.array, lastIndex - count, array, 0, count);
			}
			hybirdLock.Leave();
			return array;
		}

		public override string ToString()
		{
			return $"SharpList<{typeof(T)}>[{capacity}]";
		}
	}
}