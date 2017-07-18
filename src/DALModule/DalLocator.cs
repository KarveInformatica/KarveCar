using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DalLocator
    {
        private IDictionary<string, IDalObject> dalObjects = new Dictionary<string, IDalObject>();

        private static DalLocator _locator = null;
        public static DalLocator GetInstance()
        {
            if (_locator == null )
            {
                _locator = new DalLocator();
            }
            return _locator;
        }
        public IDalObject FindDalObject(string name)
        {
            IDalObject result;
            dalObjects.TryGetValue(name, out result);
            return result;
        }
        private DalLocator()
        {
            BanksDataAccessLayer banksDataAccessLayer = new BanksDataAccessLayer();
            dalObjects.Add(banksDataAccessLayer.Id, banksDataAccessLayer);
        }
    }
}
