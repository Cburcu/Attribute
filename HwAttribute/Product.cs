using HwAttribute.Attributes;

namespace HwAttribute
{
    [Table(Name = "Urun", Owner = "dbo")]
    public class Product : IProperty
    {
        [Identity]
        public int ProductId { get; set; }
        [Column(Name = "UrunAdi", Type = DbColumnType.NVarChar)]
        public string Title { get; set; }
        [Column(Name = "Fiyat", Type = DbColumnType.Double)]
        public double ListPrice { get; set; }
        [Column(Name = "Kategori")]
        public string ProductCategory { get; set; }

    }
}
