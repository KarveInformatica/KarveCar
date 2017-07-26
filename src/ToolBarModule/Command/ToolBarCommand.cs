using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Command;
using ToolBarModule.ViewModel;

namespace ToolBarModule.Command
{
    public abstract class ToolBarCommand: AbstractCommand
    {
      //  private KarveToolBarViewModel ViewModel;

        public ToolBarCommand(KarveToolBarViewModel vm)
        {
            this.ViewModel = vm;
        }

        private KarveToolBarViewModel ViewModel { set; get; }
    }
}
