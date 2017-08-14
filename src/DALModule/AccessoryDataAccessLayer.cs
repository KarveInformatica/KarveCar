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
        
    }
}
