using Newtonsoft.Json;
using seatarranger.com.Core.Configurations;

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