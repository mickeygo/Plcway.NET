using System;
using System.Collections.Concurrent;

namespace Plcway.Communication.Transport.Channels
{
    public class IntSignalState : SignalState<int>
    {

    }

    public class BoolSignalState : SignalState<bool>
    {

    }

    /// <summary>
    /// 数据状态机 <br/>
    /// 记录读取标识位的状态，用于比对当前与上一状态，判断当前标识是否需要处理。
    /// </summary>
    public class SignalState<T> where T : notnull
    {
        private readonly ConcurrentDictionary<string, T> _stateMap = new();

        /// <summary>
        /// 
        /// </summary>
        public Func<T, bool>? ResetFunc;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get(string key)
        {
            if (_stateMap.TryGetValue(key, out var value))
            {
                return value;
            }
            return default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Change(string key, T value)
        {
            _stateMap.AddOrUpdate(key, value, (_, _) => value);
        }
    }
}
