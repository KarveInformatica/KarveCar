using KarveCommonInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Data;

namespace KarveCommon.Generic
{
    /// <summary>
    ///  This is a simple query filter to be used.
    /// </summary>
    public class QueryFilter : IQueryFilter
    {
        private string mappingName;
        private object filterValue;
        private PredicateType predicateType;
        /// <summary>
        ///  
        /// </summary>
        /// <param name="mappingName">Dto name to create the query</param>
        /// <param name="filterValue">Value to filter</param>
        /// <param name="predicateType">Specify if the predicate is and/or/not</param>
        public QueryFilter(string mappingName, object filterValue, PredicateType predicateType)
        {
            this.mappingName = mappingName;
            this.filterValue = filterValue;
            this.predicateType = predicateType;
        }

        public PredicateType PredicateType { get; set ; }
        public long Id { get ; set ; }
        public bool FirstTerm { get; set; }
        public string Resolve()
        {
            throw new NotImplementedException();
        }
    }
}
