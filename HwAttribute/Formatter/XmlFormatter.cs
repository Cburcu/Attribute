using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace HwAttribute.Formatter
{
    class XmlFormatter<T> where T : IEntity
    {
        public static string XmlConverter(List<T> parameters)
        {
            // jsondan ayrılmalı
            //string json = JsonConvert.SerializeObject(parameter);
            //var json = JSonFormater<T>.JSonConverter(parameters);
            //XmlNode doc = JsonConvert.DeserializeXmlNode(json.ToString());
            //return doc.ToString();
            var type = parameters.GetType();
            var typeName = parameters[0].GetType().Name;
            
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
            var xml = "";
            var sww = new StringWriter();
            XmlWriter writer = XmlWriter.Create(sww);

            //foreach (var parameter in parameters)
            //{
                xmlSerializer.Serialize(writer, parameters);
                xml = sww.ToString();
            //}

            return xml;
        }
    }
}
