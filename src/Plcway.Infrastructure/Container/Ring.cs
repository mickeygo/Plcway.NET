using System;
using System.Threading;

namespace Plcway.Infrastructure.Container
{
    /// <summary>
    /// 环形数组结果
    /// </summary>
    public class Ring<T>
    {
        private readonly T[] _entries;
        private int _head;
        private int _tail;
        private int _total;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="capacity ">数组大小</param>
        public Ring(int capacity)
        {
            _entries = new T[capacity];
        }

        public T? Pop()
        {
            int tail = _tail;
            T? t = default;
            if (Volatile.Read(ref _total) == 0)
            {
                return t;
            }

            var v = _entries[tail];
            _entries[tail] = t;
            Interlocked.Decrement(ref _total);
            Interlocked.Increment(ref _tail);

            return v;
        }

        public bool Push(T obj)
        {
            int head = _head;
            if (Volatile.Read(ref _total) == _entries.Length)
            {
                return false;
            }

            _entries[head] = obj;
            MoveNext(ref _head);

            Interlocked.Increment(ref _total);

            return true;
        }

        public void Clear(Action<T> action)
        {
            while (true)
            {
                var obj = Pop();
                if (obj == null)
                {
                    break;
                }

                action?.Invoke(obj);
            }
        }

        private void MoveNext(ref int index)
        {
            int num = index + 1;
            if (num == _entries.Length)
            {
                num = 0;
            }
            index = num;
        }
    }
}
