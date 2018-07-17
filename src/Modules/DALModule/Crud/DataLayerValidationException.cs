using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataAccessLayer.Crud
{
    [Serializable]
    internal class DataLayerValidationException : System.Exception
    {
        private IList<string> errors;

        public DataLayerValidationException()
        {
        }

        public DataLayerValidationException(IList<string> errors)
        {
            this.errors = errors;
        }

        public DataLayerValidationException(string message) : base(message)
        {
        }

        public DataLayerValidationException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected DataLayerValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}