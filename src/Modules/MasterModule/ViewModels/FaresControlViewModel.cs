using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using KarveCommon.Services;
using KarveDataServices;
using MasterModule.Common;
using Microsoft.Practices.Unity;
using Prism.Regions;
using System.Threading.Tasks;

namespace MasterModule.ViewModels
{
   /// <summary>
   ///  This is the fare control view model.
   /// It controls the fares.
   /// </summary>
    public class FaresControlViewModel : MasterControlViewModuleBase, IEventObserver
    {
        private UnityContainer _container;
        private IRegionManager _regionManager;

      
     

        /// <summary>
        ///  This is the fares control view model.
        /// </summary>
        public FaresControlViewModel(IConfigurationService configurationService,
            IEventManager eventManager,
            IDataServices services,
            UnityContainer container,
            IRegionManager regionManager) : base(configurationService, eventManager, services, regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public override void StartAndNotify()
        {
            throw new NotImplementedException();
        }

        public override void NewItem()
        {
            throw new NotImplementedException();
        }


        protected override void SetTable(DataTable table)
        {
            throw new NotImplementedException();
        }

        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            throw new NotImplementedException();
        }

        protected override void SetDataObject(object result)
        {
            throw new NotImplementedException();
        }

        protected override string GetRouteName(string name)
        {
            throw new NotImplementedException();
        }

        public void IncomingPayload(DataPayLoad payload)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteAsync(string primaryKey, DataPayLoad payLoad)
        {
            throw new NotImplementedException();
        }

        public override void DisposeEvents()
        {
            throw new NotImplementedException();
        }
    }
}
