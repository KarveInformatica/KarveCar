using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCar.Navigation
{
    public class KarveNavigatorFactory
    {
        /// <summary>
        /// Generate a new navigator. A KarveNavigator is an helper for navigating from a view to another view 
        /// allowing the communication with the toolbar. It allows a creation of data.
        /// </summary>
        /// <param name="dataServices">DataService. It has been used in this case for creating a new view with a new item</param>
        /// <param name="regionManager">RegionManager. It has been used in this case for navigating to the tabregion.</param>
        /// <param name="eventManager">EventManager. It has been used for sending messaging to the navigated subsystem with a new item.</param>
        /// <param name="dialogService">DialogService. It has been used for spotting an error.</param>
        /// <returns></returns>
        public static IKarveNavigator GetKarveNavigator(IDataServices dataServices, IRegionManager regionManager, IEventManager eventManager, IDialogService dialogService)
        {
            return new KarveNavigator(dataServices, regionManager, eventManager, dialogService);
        }
    }
}
