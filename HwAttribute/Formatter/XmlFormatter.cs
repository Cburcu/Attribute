using System.Collections.Generic;
using System.Xml;
using Newtonsoft.Json;

namespace HwAttribute.Formatter
{
    class XmlFormatter<T> where T : IEntity
    {
        public static string XmlConverter(List<T> parameters)
        {
            //string json = JsonConvert.SerializeObject(parameter);
            var json = JSonFormater<T>.JSonConverter(parameters);
            XmlNode doc = JsonConvert.DeserializeXmlNode(json.ToString());
            return doc.ToString();
        }
    }
}
