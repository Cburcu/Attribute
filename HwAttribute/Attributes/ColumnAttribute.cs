using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwAttribute.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ColumnAttribute : Attribute
    {
        public string Name { get; set; }

        public DbColumnType Type { get; set; }
    }

    public enum DbColumnType
    {
        Double,
        Int,
        NVarChar,
        True,
        False
    }
}
