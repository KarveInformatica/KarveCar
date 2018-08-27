﻿using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Input;
using KarveDataServices.ViewObjects;

namespace MasterModule.Views.Vehicles.MockViewModels
{
    /// <summary>
    /// Mock Maintenance View Model.
    /// </summary>
    
    public class VehicleMaintenanceMockViewModel
    {

        private ObservableCollection<MaintainanceViewObject> _maintainanceDtos = new ObservableCollection<MaintainanceViewObject>()
        {
            new MaintainanceViewObject()
            {
                LastMaintananceDate = DateTime.MinValue,
                LastMaintananceKMs = "928393",
                MaintananceCode = "0000089",
                NextMaintananceDate = DateTime.Now,
                NextMaintananceKMs = "18298211",
                MaintananceName = "LastKMs",
                Observation = "Not in my name"
            }
        };

        /// <summary>
        ///  Open item.
        /// </summary>
        public ICommand OpenItem { set; get; }
        /// <summary>
        ///  Delegation changed rows command
        /// </summary>
        public ICommand DelegationChangedRowsCommand { set; get; }
        /// <summary>
        ///  Data Object
        /// </summary>
        public object DataObject { set; get; }
        /// <summary>
        /// MaintainanceCollection. This is a collection to maintain.
        /// </summary>
        public ObservableCollection<MaintainanceViewObject> MaintainanceCollection
        {
            set { _maintainanceDtos = value; }
            get { return _maintainanceDtos; }
        }

    }
}
