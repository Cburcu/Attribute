using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HwAttribute.DataLoad;

namespace HwAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IEntity> products = LoadData.LoadProduct();
            List<IEntity> categories = LoadData.LoadCategory();
            StringBuilder stringBuilder = new StringBuilder();
            QueryEngine<IEntity> engineer = new QueryEngine<IEntity>();

            //stringBuilder.AppendLine(engineer.Converter("json", products).ToString());

            stringBuilder.AppendLine(engineer.Converter("xml", categories).ToString());

            File.WriteAllText("Products.txt", stringBuilder.ToString());
            Console.WriteLine(stringBuilder.ToString());

            Console.ReadLine();

        }
    }
}
