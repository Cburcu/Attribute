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
            var type = parameters[0].GetType();

            XmlSerializer xmlSerializer = new XmlSerializer(type);
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));

            var xml = "";
            var sww = new StringWriter();
            //XmlWriter writer = XmlWriter.Create(sww);

            xmlSerializer.Serialize(sww, parameters);
            //xmlSerializer.Serialize(writer, parameters);


            //TextWriter xml_write = new StreamWriter("file.xml");
            //xmlSerializer.Serialize(xml_write, parameters);

            xml = sww.ToString();

            return xml;
        }
    }
}
