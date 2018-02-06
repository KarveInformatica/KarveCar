using System;

namespace KarveCommon.Errors
{
    [Serializable]
    class KarveCommonException : System.Exception
    {
        public KarveCommonException(string message) : base(message)
        {
        }
    }
}
