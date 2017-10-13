using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Prism.Mvvm;
using MasterModule.ViewModels;
using Prism.Regions;
using System.Windows.Input;
using Prism.Commands;
using KarveDataServices.DataObjects;
using KarveCommon.Services;
using System.Windows;

namespace MasterModule.ViewModels
{
    public class SupplierViewModel: TabViewModelBase
    {
        private ISupplierDataServices _supplierDataServices;
        private IDataServices _dataServices;
        private DataTable _supplierDataTable;
        private readonly IRegionManager _regionManager;
        public ICommand SelectedIndexCommand { set; get; }
        private IEventManager _eventManager;
       
        public DataTable SummaryDataTable
        {
            set { _supplierDataTable = value; RaisePropertyChanged(); }
            get { return _supplierDataTable; }
        }

    
        public SupplierViewModel(IRegionManager manager, IDataServices dataServices, IEventManager ev)
        {
             Header = TabViewModelBase.SUPPLIERS;
            _dataServices = dataServices;
            _regionManager = manager;
            _eventManager = ev;
        }
    
    }
}
