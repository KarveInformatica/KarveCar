using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommonInterfaces;

namespace DataAccessLayer.SQL
{
    /// <summary>
    ///  A composable store is a query store that it allows 
    /// </summary>
    internal class ComposableStore: QueryStore, IComposableStore 
    {
        private IQueryStore _store;
        private StringBuilder _builder;
        private string _query;

        /// <summary>
        ///  ComposableStore is a decorator for a query store.
        /// </summary>
        /// <param name="store">Store to be composed.</param>
        public ComposableStore(IQueryStore store)
        {
            _store = store;
            _builder = new StringBuilder();
        }
        /// <summary>
        ///  Composability BuildQuery
        /// </summary>
        /// <returns>return a new query.</returns>
        public override string BuildQuery()
        {
            var value = _builder.ToString();
            var currentString = string.Empty;
            var store  = _store.BuildQuery();
            return store;   
        }
       /// <summary>
       ///  Clears a store
       /// </summary>
       /// <returns>The interface itself for creating a query.</returns>
        public override IQueryStore Clear()
        {
            _store.Clear();
            _builder.Clear();
            return this;
        }
        /// <summary>
        ///  Compose a query with where and likes and returns a composable interface.
        ///  Currently it delete the query value of the previous
        /// </summary>
        /// <param name="queryBooking">Kind of the query booking</param>
        /// <returns>A composable query</returns>
        public override IComposableStore Compose(QueryType queryBooking)
        {
            if (_dictionary.ContainsKey(queryBooking))
            {
                base.AddParam(queryBooking);
                _query = base.BuildQuery();
                _query = _query.TrimEnd(';');
                _builder.Append(_query);
                _builder.Append(" ");
            }
            return this;
        }

        /// <summary>
        ///  Compose a query with like.
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        /// <param name="value">Value of the property</param>
        /// <returns></returns>
        public IComposableStore Like(string propertyName, string value)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("Property to be assigned cannot be null or empty");
            }
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Value to be assigned cannot be null or empty");
            }
            // string interpolation
            var complete = $"WHERE {propertyName}  LIKE {value} ";
            _builder.Append(complete);
            return this;
        }

        public IComposableStore Like(IQueryFilter value)
        {

            throw new NotImplementedException();
        }
        public IComposableStore Where(string value)
        {
            _builder.Append(" WHERE ");
            _builder.Append(value);
            return this;
        }
        public IComposableStore Where(IQueryFilter filyer)
        {
            throw new NotImplementedException();
        }
    }
}
