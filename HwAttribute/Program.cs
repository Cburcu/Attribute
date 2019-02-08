using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>()
            {
                new Product{ProductId = 1, Title= "Caffee", ListPrice = 5, ProductCategory = "İçecek"},
                new Product{ProductId = 2, Title = "Tea", ListPrice = 2.5, ProductCategory = "İçecek"},
                new Product{ProductId = 3, Title = "Hot Chocolate", ListPrice = 10, ProductCategory = "İçecek"}
            };

            List<Category> categories = new List<Category>()
            {
                new Category{Id = 1, Name = "Kitap", Stock = 89 },
                new Category{ Id = 2, Name = "Kırtasiye", Stock = 2324}
            };

            StringBuilder stringBuilder = new StringBuilder();
            QueryEngine<IProperty> engineer = new QueryEngine<IProperty>();
            foreach (var product in products)
            {
                stringBuilder.AppendLine(engineer.CreateInsertScript(product));
            }

            foreach (var category in categories)
            {
                stringBuilder.AppendLine(engineer.CreateInsertScript(category));
            }
            
            File.WriteAllText("Products.txt", stringBuilder.ToString());
            Console.WriteLine(stringBuilder.ToString());

            Console.ReadLine();

        }
    }
}
