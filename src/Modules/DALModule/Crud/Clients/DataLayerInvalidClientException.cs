using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataAccessLayer.Crud.Clients
{
    /// <summary>
    ///  Exception during the validation before the saving.
    /// </summary>
    [Serializable]
    public class DataLayerInvalidClientException : System.Exception
    {
        private IList<string> errors;

        public DataLayerInvalidClientException()
        {
            errors = new List<string>();
        }

        public DataLayerInvalidClientException(IList<string> errors)
        {
            this.errors = errors;
        }

        public DataLayerInvalidClientException(string message) : base(message)
        {
        }

        public DataLayerInvalidClientException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected DataLayerInvalidClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}