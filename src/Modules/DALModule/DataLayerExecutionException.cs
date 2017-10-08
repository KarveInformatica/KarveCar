using System;

namespace DataAccessLayer
{
    public class DataLayerExecutionException: System.Exception
    {
        public DataLayerExecutionException() : base("Cannot save the data. Null data object")
        {   
        }
        public DataLayerExecutionException(string ex) : base(ex)
        {

        }
    }
}
