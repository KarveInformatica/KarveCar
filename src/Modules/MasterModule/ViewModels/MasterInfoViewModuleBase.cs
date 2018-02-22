using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KarveCommon.Services;
using MasterModule.Common;
using Prism.Regions;
using KarveDataServices;
using System.Windows;
using KarveCommon.Generic;

namespace MasterModule.ViewModels
{

    /// <summary>
    ///  This base claass simply override the things that are not needed for the Info Viewmodels.
    /// </summary>
    public abstract class MasterInfoViewModuleBase : MasterViewModuleBase
    {
        private bool _canDelete = true;

        // TODO: let see for the SRP
        public MasterInfoViewModuleBase(IEventManager eventManager,
                                        IConfigurationService configurationService,
                                        IDataServices dataServices, IRegionManager manager) : base(configurationService, eventManager, dataServices, manager)
        {
            _canDelete = true;
        }

        public override async Task<bool> DeleteAsync(string primaryKey, DataPayLoad payLoad)
        {
            await Task.Delay(1);
            return false;
        }

        public override void NewItem()
        {
        }

        public override void StartAndNotify()
        {

        }
        protected DataPayLoad BuildDataPayload(IDictionary<string, object> eventDictionary)
        {
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.Subsystem = DataSubSystem.VehicleSubsystem;
            if (string.IsNullOrEmpty(payLoad.PrimaryKeyValue))
            {
                payLoad.PrimaryKeyValue = PrimaryKeyValue;
                payLoad.PayloadType = DataPayLoad.Type.Update;
            }
            if (eventDictionary.ContainsKey("DataObject"))
            {
                if (eventDictionary["DataObject"] == null)
                {
                    MessageBox.Show("DataObject is null.");
                }
                var data = eventDictionary["DataObject"];
                if (eventDictionary.ContainsKey("Field"))
                {
                    var name = eventDictionary["Field"] as string;
                    GenericObjectHelper.PropertySetValue(data, name, eventDictionary["ChangedValue"]);
                }
                payLoad.DataObject = data;
                eventDictionary["DataObject"] = data;
                payLoad.DataDictionary = eventDictionary;
            }
            return payLoad;
        }
        protected override string GetRouteName(string name)
        {
            return "";
        }
        /// <summary>
        ///  Specify if we can delete a region
        /// </summary>
        public override bool CanDeleteRegion
        {
            set { _canDelete = value; }
            get { return _canDelete; }
        }

        protected override void SetDataObject(object result)
        {
        }
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
        }

        protected override void SetTable(DataTable table)
        {
        }

        protected IDictionary<string, string> ViewModelQueries { get; set; }
    }

}