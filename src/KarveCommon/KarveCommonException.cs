using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCommon
{
    class KarveCommonException : Exception
    {
        public KarveCommonException(string message) : base(message)
        {
        }
    }
}
