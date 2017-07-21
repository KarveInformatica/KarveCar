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
        void SetUniqueItems(GenericObservableCollection collection);
        Type DalType { get; set; }
    }
}