using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;

namespace DataAccessLayer.Assist
{
    public class AssistResponseBase
    {
        protected IHelperDataServices HelperDataServices;

        public AssistResponseBase(IHelperDataServices helperDataServices)
        {
            HelperDataServices = helperDataServices;
        }
    }
}
