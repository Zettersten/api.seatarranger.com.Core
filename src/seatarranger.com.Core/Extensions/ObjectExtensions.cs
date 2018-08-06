using seatarranger.com.Core.Configurations;
using Newtonsoft.Json;

namespace seatarranger.com.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object entity)
        {
            return JsonConvert.SerializeObject(entity, JsonConfiguration.GetSerializerSettings());
        }
    }
}