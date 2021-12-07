using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_RestFull.Exceptions
{
    public class _Exceptions :Exception
    {
        public _Exceptions(string message) : base(message)
        {
        }
    }
}
