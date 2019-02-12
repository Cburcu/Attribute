using System;

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
        Bool
    }
}
