using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaunchingVillage
{
    public class JsonConverter
    {
        public string WriteToJson(Object obj)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            
            return JsonConvert.SerializeObject(obj, settings);
        }


        public string WriteToJson(IEnumerable<Object> obj)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };

            return JsonConvert.SerializeObject(obj, settings);
        }
    }
}
