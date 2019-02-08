using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HwAttribute.Attributes;

namespace HwAttribute
{
    [Table(Name = "Kategoriler", Owner = "dbo")]
    class Category: IProperty
    {
        [Identity]
        public int Id { get; set; }

        [Column(Name = "KategoriAdi", Type = DbColumnType.NVarChar)]
        public string Name { get; set; }

        [Column(Name = "Stok", Type = DbColumnType.Int)]
        public int Stock { get; set; }
    }
}
