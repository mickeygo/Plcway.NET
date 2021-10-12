using System;
using System.Collections.Concurrent;

namespace Plcway.Framework.Transport.Channels
{
    /// <summary>
    /// 数据触发器状态机 <br/>
    /// 记录读取标识位的状态，用于比对当前与上一状态，判断当前标识是否需要处理。
    /// </summary>
    public class TriggerState : TriggerState<bool>
    {

    }

    /// <summary>
    /// 数据触发器状态机 <br/>
    /// 记录读取标识位的状态，用于比对当前与上一状态，判断当前标识是否需要处理。
    /// </summary>
    public class TriggerState<T> where T : notnull
    {
        private readonly ConcurrentDictionary<string, StateValue<T>> _stateMap = new();

        /// <summary>
        /// 
        /// </summary>
        public Func<T, bool>? ResetFunc;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public StateValue<T> Get(string key)
        {
            if (_stateMap.TryGetValue(key, out var value))
            {
                return value;
            }
            return default;
        }

        /// <summary>
        /// 更改状态值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Change(string key, StateValue<T> value)
        {
            _stateMap.AddOrUpdate(key, value, (_, _) => value);
        }
    }

    public class StateValue<T> where T : notnull
    {
        /// <summary>
        /// 状态值
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// 是否有被重置。
        /// 当该点的上次数据和当前数据相同时，用于判断两次扫描期间数据是否有重置过，防止在两个扫描周期内数据未响应的情况下出现重发的现象。
        /// </summary>
        public bool HasReset { get; set; }

        /// <summary>
        /// 值变动时间
        /// </summary>
        public DateTime ChangedTimestamp { get; set; }
    }
}
