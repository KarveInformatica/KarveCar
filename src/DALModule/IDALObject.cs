using System;
using System.Collections.ObjectModel;
using System.Data;
using KarveCommon.Generic;

namespace DataAccessLayer
{
    public interface IDalObject
    {
        Type DalType { get; set; }
        string Id { get; }
        GenericObservableCollection GetItems();
        void SetItems(GenericObservableCollection collection);
        void StoreCollection<T>(ObservableCollection<T> collection);
        void RemoveCollection<T>(ObservableCollection<T> collection);
    }
}