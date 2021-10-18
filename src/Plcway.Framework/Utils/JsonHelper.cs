using Newtonsoft.Json;

namespace Plcway.Framework.Utils
{
    internal static class JsonHelper
    {
        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
