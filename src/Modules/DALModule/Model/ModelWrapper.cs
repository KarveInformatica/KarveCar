using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Crud.Clients;
using KarveDataServices;

namespace DataAccessLayer.Model
{
    class ModelWrapper<Poco, HelperData>
    {
       IHelperData helperData = new HelperData();();
    }
}
