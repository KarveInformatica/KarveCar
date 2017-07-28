using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public override bool RemoveCollection<T>(ObservableCollection<T> collection)
        {
            return true;
        }

        public override void SetItems(GenericObservableCollection collection)
        {
        }

        public override bool StoreCollection<T>(ObservableCollection<T> collection)
        {
            return true;
        }
    }
}
