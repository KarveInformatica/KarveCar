using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    public class BaseDtoDefaultName : BaseDto, IDisposable
    {
       
        public override bool HasErrors
        {
            get
            {
                
                if ((Name != null) && (Name.Length > NameSize))
                {
                    ErrorList.Add(ConstantDataError.NameTooLong);
                    return true;
                }
                return false;
            }
        }
    }
}
