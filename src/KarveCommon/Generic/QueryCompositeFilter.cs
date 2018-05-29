using KarveCommonInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Data;

namespace KarveCommon.Generic
{
    public class QueryCompositeFilter : IQueryFilter
    {
        private IList<IQueryFilter> _children;
        public QueryCompositeFilter()
        {
            _children = new List<IQueryFilter>();
        }
        /// <summary>
        /// Set or Get an identifer 
        /// </summary>
        public long Id { get; set; }
        public PredicateType PredicateType { get ; set ; }
        /// <summary>
        ///  Add a new filter or replace if a filter with the same id works
        /// </summary>
        /// <param name="filter"></param>
        public void Add(IQueryFilter filter)
        {
            // check if exists. if it exists replace.
            var current = _children.Where<IQueryFilter>(x => x.Id == filter.Id);
            var value  = current.FirstOrDefault();
            if (value != null)
            {
                _children.Remove(value);
                _children.Add(filter);
            }
            else
            {
                _children.Add(filter);
            }
        }
        /// <summary>
        ///  Remove a filter
        /// </summary>
        /// <param name="filter">Current filter</param>
        /// <returns></returns>
        public IQueryFilter Remove(IQueryFilter filter)
        {
            var filterValues = _children.Where<IQueryFilter>(x => x.Id == filter.Id);
            var value = filterValues.FirstOrDefault();
            var current = _children.Remove(filter);
            return value;
        }
        /// <summary>
        /// This value resolve a query part.
        /// </summary>
        /// <returns></returns>
        public string Resolve()
        {
            StringBuilder queryBuilder = new StringBuilder();
            foreach(IQueryFilter filter in _children)
            {
                queryBuilder.Append(filter.Resolve());
            }
            return queryBuilder.ToString();
        }
    }
}
