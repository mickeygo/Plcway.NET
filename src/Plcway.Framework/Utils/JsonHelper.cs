using Newtonsoft.Json;

namespace Plcway.Framework.Utils
{
    internal static class JsonHelper
    {
        /// <summary>
        /// JSON 序列化
        /// </summary>
        /// <param name="obj">要序列化的对象</param>
        /// <returns></returns>
        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// JSON 反序列化
        /// </summary>
        /// <typeparam name="T">要反序列化的类型</typeparam>
        /// <param name="value">要反序列的字符串</param>
        /// <returns></returns>
        public static T? Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
