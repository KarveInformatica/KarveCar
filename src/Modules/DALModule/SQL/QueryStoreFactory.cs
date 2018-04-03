using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.SQL
{
    /// <summary>
    /// Factory of a query store.
    /// A query store is a place where all query are located.
    /// </summary>
    public class QueryStoreFactory
    {
        /// <summary>
        ///  This returns a query store.
        /// </summary>
        /// <returns>Return a new query store.</returns>
        public IQueryStore GetQueryStore()
        {
            return new QueryStore();
        }
    }
}
