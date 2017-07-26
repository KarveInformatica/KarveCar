using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDalLocator
    {
        IDalObject FindDalObject(string name);
    }
}
