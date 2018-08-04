using api.seatarranger.com.Core.Configurations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.seatarranger.com.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object entity)
        {
            return JsonConvert.SerializeObject(entity, JsonConfiguration.GetSerializerSettings());
        }
    }
}
