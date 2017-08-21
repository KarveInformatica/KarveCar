using System.Collections.ObjectModel;
using KarveCommon.Generic;

namespace DataAccessLayer
{
   /// <summary>
   /// 
   /// </summary>
    public class AccessoryDataAccessLayer : BaseDataMapper
    {

        public AccessoryDataAccessLayer(string name)
        {
            base.Id = name;
        }
        
        public override GenericObservableCollection GetItems()
        {
            return null;
        }

        public override void RemoveCollection<T>(ObservableCollection<T> collection)
        {
      
        }

        public override void SetItems(GenericObservableCollection collection)
        {
        }

        public override void StoreCollection<T>(ObservableCollection<T> collection)
        {
        }
    }
}
