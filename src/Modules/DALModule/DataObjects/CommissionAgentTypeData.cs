using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;

namespace DataAccessLayer.DataObjects
{
    public class CommissionAgentTypeData: ICommissionAgentTypeData
    {
        private TIPOCOMI _tipocomi;
        /// <summary>
        ///  code of the type
        /// </summary>
        public string Code
        {
          get { return _tipocomi.NUM_TICOMI; }
          set { _tipocomi.NUM_TICOMI = value; }
        }
        /// <summary>
        ///  typename
        /// </summary>
        public string Name {
            get { return _tipocomi.NOMBRE; }
            set { _tipocomi.NOMBRE = value; }
        }
       
        // obect value
        public object ObjectValue
        {
            get { return _tipocomi; }
            set { _tipocomi = (TIPOCOMI) value; }
        }
        public CommissionAgentTypeData()
        {
            _tipocomi = new TIPOCOMI();
        }
    }
}
