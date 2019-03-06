using System;
using HwAttribute.Attributes;

namespace HwAttribute
{
    [Serializable]
    [Table(Name = "Kategoriler", Owner = "dbo")]
    public class Category: IEntity
    {
        [Identity]
        public int Id { get; set; }

        [Column(Name = "KategoriAdi", Type = DbColumnType.NVarChar)]
        public string Name { get; set; }

        [Column(Name = "Stok")]
        public int Stock { get; set; }
    }
}
