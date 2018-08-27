﻿using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using KarveCommon.Services;
using KarveDataServices;
using MasterModule.Common;
using Microsoft.Practices.Unity;
using Prism.Regions;
using System.Threading.Tasks;
using KarveDataServices.ViewObjects;

namespace MasterModule.ViewModels
{
   /// <summary>
   ///  This is the fare control view model.
   /// It controls the fares.
   /// </summary>
    internal sealed class FaresControlViewModel : MasterControlViewModuleBase, IEventObserver
    {

        private UnityContainer _container;
        private IRegionManager _regionManager;
        private IEnumerable<FareViewObject> _sourceView;
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
        public IEnumerable<FareViewObject> SourceView
        {
            get => _sourceView;
            set { _sourceView = value; RaisePropertyChanged(); }
        }
        

        protected override void NewItem()
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

        public override void IncomingPayload(DataPayLoad payload)
        {
        }
        public override async Task<bool> DeleteAsync(string primaryKey, DataPayLoad payLoad)
        {
            await Task.Delay(1000);
            return true;
        }

        protected override void OnPagedEvent(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void DisposeEvents()
        {
        }

        protected override void SetResult<T>(IEnumerable<T> result)
        {
            throw new NotImplementedException();
        }

        protected override void LoadMoreItems(uint count, int baseIndex)
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
