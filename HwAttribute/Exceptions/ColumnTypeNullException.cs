using System;

namespace HwAttribute
{
    [Serializable]
    internal class ColumnTypeNullException : Exception
    {
        public override string Message => "Column Type is null!";
    }
}