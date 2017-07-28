using System;
using System.Collections.ObjectModel;
using KarveCommon.Generic;

namespace DataAccessLayer
{
    public interface IDalObject
    {
        string Id { get; }
        GenericObservableCollection GetItems();
        void SetItems(GenericObservableCollection collection);
        Type DalType { get; set; }
        bool StoreCollection<T>(ObservableCollection<T> collection);
        bool RemoveCollection<T>(ObservableCollection<T> collection);
    }
}