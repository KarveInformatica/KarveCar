using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;
using Prism;
using Prism.Mvvm;
using Prism.Regions;

namespace HelperModule.ViewModels
{
    class VehicleToolsViewModel : BaseHelperViewModel
    {
        public override void OnExitCommand(object value)
        {
        }

        public override void OnHelpCommand()
        {
        }
        public override void OnSaveCommand(object value)
        {
        }
        public VehicleToolsViewModel(IDataServices dataServices, IRegionManager region, IEventManager eventManager) : base(dataServices, region, eventManager)
        {
        }
    }
}
