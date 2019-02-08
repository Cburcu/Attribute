using System;
using System.Runtime.Serialization;

namespace HwAttribute
{
    [Serializable]
    internal class ColumnTypeNullException : Exception
    {
        public override string Message => "Column Type is null!";
    }
}