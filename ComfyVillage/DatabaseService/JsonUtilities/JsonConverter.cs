using AgentUtitilies;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseService
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

        public IEnumerable<IAgent> DeserializeJson(string json)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };

            var list = JsonConvert.DeserializeObject(json, typeof(IEnumerable<IAgent>),settings);


            //var truc = list[0] as Rabbit;
            //var machin = list[0] as Tree;

            return list as IEnumerable<IAgent>;
        }
    }
}
