using HwAttribute.Attributes;

namespace HwAttribute
{
    [Table(Name = "Kategoriler", Owner = "dbo")]
    class Category: IEntity
    {
        [Identity]
        public int Id { get; set; }

        [Column(Name = "KategoriAdi", Type = DbColumnType.NVarChar)]
        public string Name { get; set; }

        [Column(Name = "Stok")]
        public int Stock { get; set; }
    }
}
