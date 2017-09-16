using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;

namespace DataAccessLayer
{
    public class HelperDataServicesImplementation : IHelperDataServices
    {
        public Task<DataSet> GetAsyncCountriesAndProvinces()
        {
            throw new NotImplementedException();
        }
    }
}
