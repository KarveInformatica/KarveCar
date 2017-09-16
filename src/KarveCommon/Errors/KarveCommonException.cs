using System;

namespace KarveCommon.Errors
{
    class KarveCommonException : System.Exception
    {
        public KarveCommonException(string message) : base(message)
        {
        }
    }
}
