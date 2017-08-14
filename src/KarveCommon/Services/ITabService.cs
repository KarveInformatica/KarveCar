using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KarveCommon.Services
{
    public interface ITabService
    {
        void AddUserControl(string name, UserControl ctrl);
        void RemoveUserControl(string name);
    }
}
