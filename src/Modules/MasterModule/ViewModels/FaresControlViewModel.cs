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
using KarveDataServices.DataTransferObject;

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
        private IEnumerable<FareDto> _sourceView;
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
        /// <summary>
        ///  Grid of the offices in the database.
        /// </summary>
        public IEnumerable<FareDto> SourceView
        {
            get => _sourceView;
            set { _sourceView = value; RaisePropertyChanged(); }
        }
        public override void StartAndNotify()
        {

        }

        public override void NewItem()
        {
        }


        protected override void SetTable(DataTable table)
        {
        }

        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
        }

        protected override void SetDataObject(object result)
        {
        }

        protected override string GetRouteName(string name)
        {
            return string.Empty;
        }

        public void IncomingPayload(DataPayLoad payload)
        {
        }
        public async override Task<bool> DeleteAsync(string primaryKey, DataPayLoad payLoad)
        {
            await Task.Delay(1000);
            return true;
        }

        public override void DisposeEvents()
        {
        }
    }
}
