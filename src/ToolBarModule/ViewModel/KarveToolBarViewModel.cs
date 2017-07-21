using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using KarveCommon;
using KarveCommon.Command;
using Prism.Mvvm;
using ToolBarModule.Command;

namespace ToolBarModule.ViewModel
{
    public class KarveToolBarViewModel: BindableBase
    {
        private ICareKeeperService _careKeeper;
        public KarveToolBarViewModel(ICareKeeperService careKeeperService)
        {
            this._careKeeper = careKeeperService;
        }

        internal void SaveCommand(CommandWrapper cw)
        {
            throw new NotImplementedException();
        }

        internal bool Undo()
        {
            throw new NotImplementedException();
        }

        internal void DeleteItem(CommandWrapper wrapper)
        {
            throw new NotImplementedException();
        }
        public ToolBarCommand CancelCommand { set; get; }
       
    }
   
}
