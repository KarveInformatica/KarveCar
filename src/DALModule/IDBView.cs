using System.Collections.Generic;

namespace Karve.DAL
{
    public interface IDBView<T>
    {
        string Name { get; set; }
        //a DB view is the result of DB operation
        IList<T> FetchData();
        void StoreData(IList<T> data);
        IDBView<T> MergeViews(IDBView<T> first, IDBView<T> second);
        void ExecuteWork(string queryId);
    }
}