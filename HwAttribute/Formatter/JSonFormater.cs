using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace HwAttribute.Formatter
{
    class JSonFormater<T> where T : IEntity
    {
        
        public static StringBuilder JSonConverter(List<T> parameters)
        {
            var typeName = parameters[0].GetType().Name;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("{ "+'"'+ typeName + '"' + " : ");

            foreach (var parameter in parameters)
            {
                var data = JSonFormater<T>.JSonData(parameter);
                stringBuilder.AppendLine($"[ {data} ],");
            }
            StringBuilder json = new StringBuilder();
            string sb = stringBuilder.ToString().TrimEnd(',');
            json.Append(sb + " }");
            return json;
        }

        public static string JSonData(T paramater)
        {
            string output = JsonConvert.SerializeObject(paramater);
            return output;
        }

    }
}
