using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karve.DAL
{
    public abstract class BasicDBView<T> : IDBView<T>
    {
        /// <summary>
        ///  QueryDictionary is an hashmap of queries.
        ///  Each query is stored in a xml file and loaded at boottime
        /// </summary>
        protected Dictionary<string, Query> _queryDictionary;
        public abstract string Name { get; set; }
        public abstract void ExecuteWork(string queryId);
        public abstract IList<T> FetchData();
        public abstract IDBView<T> MergeViews(IDBView<T> first, IDBView<T> second);
        public abstract void StoreData(IList<T> data);
    }
}
