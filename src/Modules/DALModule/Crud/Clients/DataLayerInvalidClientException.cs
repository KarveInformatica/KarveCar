using System.Collections.Generic;
namespace DataAccessLayer.Crud.Clients
{
    class DataLayerInvalidClientException: System.Exception
    {
        public DataLayerInvalidClientException(IList<string> errors)
        {
        }
    }
}
