using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karve.DAL
{
    interface IDAL
    {
        IDBView<T> findView<T>(string Name);
        void insertView<T>(string Name, IDBView<T> view);
    }
}
