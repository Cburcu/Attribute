using System;

namespace HwAttribute.Exceptions
{
    public class ColumnNameNullException: Exception
    {
        public override string Message => "Column Name is null!";
    }
}
