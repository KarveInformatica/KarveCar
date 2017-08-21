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
        
    }
}
