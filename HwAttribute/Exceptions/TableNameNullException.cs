using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwAttribute.Exceptions
{
    class TableNameNullException : Exception
    {
        public override string Message => "Table Name is null!";
    }
}
