using System;

namespace DataAccessLayer
{
    public class DataLayerExecutionException: Exception
    {
        public DataLayerExecutionException() : base("Cannot save the data. Null data object")
        {   
        }
        public DataLayerExecutionException(string ex) : base(ex)
        {

        }
    }
}
