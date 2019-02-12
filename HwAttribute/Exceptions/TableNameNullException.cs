using System;

namespace HwAttribute.Exceptions
{
    class TableNameNullException : Exception
    {
        public override string Message => "Table Name is null!";
    }
}
