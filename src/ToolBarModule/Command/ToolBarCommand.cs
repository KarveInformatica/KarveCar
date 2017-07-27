using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Command;

namespace ToolBarModule.Command
{
    public abstract class ToolBarCommand: AbstractCommand
    {
        private KarveToolBarViewModel viewModel;

        public ToolBarCommand(KarveToolBarViewModel vm)
        {
            this.viewModel = vm;
        }

        private KarveToolBarViewModel ViewModel { set; get; }
    }
}
