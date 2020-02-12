using CV.Agents;
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

        public object DeserializeJson(string json, Type _type)
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };

                var list = JsonConvert.DeserializeObject(json, _type, settings);


                //var truc = list[0] as Rabbit;
                //var machin = list[0] as Tree;

                return list;
            }
        
            catch (Exception ex)
            {
           //     Console.WriteLine(ex.Message + json);
                return null;
            }
        }
    }
}
