using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karve.DAL
{
    /// <summary>
    /// Class that implements the repository for each DB view.
    /// Each DataBase view has a Name (i.e UserView) and an object.
    /// </summary>
    public class DALModule : IDAL
    {
        private IDictionary<string, object> _dalStorage = new Dictionary<string,object>();
        IDBView<T> IDAL.findView<T>(string Name)
        {
           return (IDBView<T>) _dalStorage[Name];
        }

        void IDAL.insertView<T>(string Name, IDBView<T> view)
        {
            _dalStorage.Add(Name, view);
        }
    }
}
