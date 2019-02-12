using System;
using System.Collections.Generic;
using System.Text;
using HwAttribute.Formatter;

namespace HwAttribute
{
    public class QueryEngine<T> where T : IEntity
    {
        public StringBuilder Converter(string convertType, List<T> parameters)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string data = String.Empty; ;

            if (convertType == "xml")
            {
                //foreach (var parameter in parameters)
                //{
                    data = XmlFormatter<T>.XmlConverter(parameters);
                    stringBuilder.AppendLine(data);
                //}
            }
            else if (convertType == "json")
            {
                //foreach (var parameter in parameters)
                //{
                //    data = JSonFormater<T>.JSonConverter(parameter);
                //    stringBuilder.AppendLine(data);
                //}
                stringBuilder = JSonFormater<T>.JSonConverter(parameters);
            }
            else
            {
                // Db Script
                foreach (var parameter in parameters)
                {
                    data = ScriptFormatter<T>.CreateInsertScript(parameter);
                    stringBuilder.AppendLine(data);
                }
            }

            return stringBuilder;
        }
    }
}
