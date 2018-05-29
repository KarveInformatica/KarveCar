using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCommon.Generic
{
    /// <summary>
    ///  This is a composite filter
    /// </summary>
    class QueryCompositeFilter : IQueryFilter
    {
        private List<IQueryFilter> _filterList;
        private long _id;

        public QueryCompositeFilter()
        {
            _filterList = new List<IQueryFilter>();
            _id = QueryIdentifier.NewId();
        }
        // Get the identifier of the filter

        public long Id => _id;
        // Add a filter.
        public void Add(IQueryFilter queryFilter)
        {
            _filterList.Add(queryFilter);
        }
        /// <summary>
        ///  I should add or remove a query filter
        /// </summary>
        /// <param name="queryFilter"></param>
        public void Remove(IQueryFilter queryFilter)
        {
            var filter = _filterList.Where<IQueryFilter>(x => x.Id == queryFilter.Id).FirstOrDefault();
            _filterList.Remove(filter);
        }
        /// <summary>
        ///  I should resolve a string
        /// </summary>
        /// <returns></returns>
        public string Resolve()
        {
            StringBuilder builder = new StringBuilder();
            foreach(var filter in _filterList)
            {
                string value = filter.Resolve();
                builder.Append(value);
            }
            return builder.ToString();
        }
        
    }
}
