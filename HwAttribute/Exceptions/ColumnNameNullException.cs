using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwAttribute.Exceptions
{
    public class ColumnNameNullException: Exception
    {
        public override string Message => "Column Name is null!";
    }
}
