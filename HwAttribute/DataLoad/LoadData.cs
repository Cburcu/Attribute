using System.Collections.Generic;

namespace HwAttribute.DataLoad
{
    class LoadData
    {
        public static List<IEntity> LoadProduct()
        {
            List<IEntity> products = new List<IEntity>()
            {
                new Product{ProductId = 1, Title= "Caffee", ListPrice = 5, ProductCategory = "İçecek", InStock = true},
                new Product{ProductId = 2, Title = "Tea", ListPrice = 2.5, ProductCategory = "İçecek", InStock = false},
                new Product{ProductId = 3, Title = "Hot Chocolate", ListPrice = 10, ProductCategory = "İçecek", InStock = true}
            };
            return products;
        }

        public static List<IEntity> LoadCategory()
        {
            List<IEntity> categories = new List<IEntity>()
            {
                new Category{Id = 1, Name = "Kitap", Stock = 89 },
                new Category{ Id = 2, Name = "Kırtasiye", Stock = 2324}
            };
            return categories;
        }
    }
}
