using Syncfusion.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCommonInterfaces
{
    public interface IQueryFilter
    {
        /// <summary>
        ///  Kind of predicate for the query. AND/OR/NOT
        /// </summary>
        PredicateType PredicateType {set; get;}
        /// <summary>
        ///  Long identifier.
        /// </summary>
        long Id { set; get; }
        /// <summary>
        ///  Resolve the query and it build.
        /// </summary>
        /// <returns></returns>
        string Resolve();

    }
}
