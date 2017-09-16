using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;


namespace DataAccessLayer
{
    /** The data access layer shall be updated to a template method pattern
     * in this way we can change the behaviour 
     */
    abstract class SupplierDataUpdater
    {

        public bool UpdateDataAccessLayer(DataPayLoad payload)
        {
            IDictionary<string, object> data = payload.DataMap;
            if (data != null)
            {
                //UpdateTables(data["supplierdataInfo"])
            }
            return true;
        }
    }
}
