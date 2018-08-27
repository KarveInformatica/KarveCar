using System;
using System.Collections.Generic;
using KarveDataServices.ViewObjects;
using Prism.Mvvm;
using MasterModule.Views.Vehicles;

namespace MasterModule.Views.Vehicles.MockViewModels
{
    public class RevisionMaintenanceMockViewModel: BindableBase
    {
        private readonly VehicleViewObject _vehicleViewObject = new VehicleViewObject();
        private List<UiComposedFieldObject> _dataFieldCollection;
        private readonly List<UiComposedFieldObject> _defaultDataFieldCollection = new List<UiComposedFieldObject>
        {
                new UiComposedFieldObject()
                {
                    LabelSource="I.T.V", 
                    DataSourcePath1="FITV",
                    DataSourcePath2="FITV2",
                    DataSourcePath3="OBS_ITV"
                },
                new UiComposedFieldObject()
               {
                    LabelSource="Fecha Caducidad Transporte",
                    DataSourcePath1="ULT_TT",
                    DataSourcePath2="FCTARTRA",
                    DataSourcePath3="OBS_TT"
               },
              new UiComposedFieldObject()
              {
                  LabelSource="ADR",
                  DataSourcePath1="ULT_ADR",
                  DataSourcePath2="VTO_ADR",
                  DataSourcePath3="OBS_ADR"

              },
              new UiComposedFieldObject()
              {
                  LabelSource="Vtp ATP",
                  DataSourcePath1="ULT_ATP",
                  DataSourcePath2="VTO_ATP",
                  DataSourcePath3="OBS_ATP"
              },
              new UiComposedFieldObject()
              {
                  LabelSource="Extintor",
                  DataSourcePath1="FEXTINTOR",
                  DataSourcePath2="FEXTINTORCAD",
                  DataSourcePath3="OBS_EXT"

              },
              new UiComposedFieldObject()
              {
                  LabelSource="Tacografo",
                  DataSourcePath1="ULT_TAC",
                  DataSourcePath2="FREVITACO",
                  DataSourcePath3="OBS_TAC"

              },
              new UiComposedFieldObject()
              {
                  LabelSource="Termografo",
                  DataSourcePath1="ULT_TEMR",
                  DataSourcePath2="FREVTERM",
                  DataSourcePath3="OBS_TERM"
              },
              new UiComposedFieldObject()
              {
                  LabelSource="Fugas frio",
                  DataSourcePath1="ULT_FF",
                  DataSourcePath2="VTO_FF",
                  DataSourcePath3="OBS_FF"
              }
        };
        public RevisionMaintenanceMockViewModel()
        {
            _vehicleViewObject.FITV = DateTime.Now;
            _vehicleViewObject.FITV2 = DateTime.Now;
            _vehicleViewObject.OBS_ITV = "ItvObserva";
            _vehicleViewObject.ULT_TT = DateTime.Now;
            _vehicleViewObject.FCTARTRA = DateTime.Now;
            _vehicleViewObject.OBS_TT = "Observa";
            _vehicleViewObject.ULT_ADR = DateTime.Now;
            _vehicleViewObject.VTO_ADR = DateTime.Now;
            _vehicleViewObject.OBS_ADR = "Observa adr";
            _vehicleViewObject.ULT_ATP = DateTime.Now;
            _vehicleViewObject.VTO_ADR = DateTime.Now;
            _vehicleViewObject.OBS_ATP = "observa atp";
            _vehicleViewObject.FEXTINTOR = DateTime.Now;
            _vehicleViewObject.FEXTINTORCAD = DateTime.Now;
            _vehicleViewObject.OBS_EXT = "observa ext";
            _vehicleViewObject.ULT_TAC = DateTime.Now;
            _vehicleViewObject.FREVITACO = DateTime.Now;
            _vehicleViewObject.OBS_TAC = "observa taco";
            _vehicleViewObject.ULT_TEMR = DateTime.Now;
            _vehicleViewObject.FREVTERM = DateTime.Now;
            _vehicleViewObject.OBS_TERM = "observa term";
            _vehicleViewObject.ULT_FF = DateTime.Now;
            _vehicleViewObject.VTO_FF = DateTime.Now;
            _vehicleViewObject.OBS_FF = "observa ff";
            for (int i = 0; i < _dataFieldCollection.Count; ++i)
            {
                _dataFieldCollection[i].DataSource = _vehicleViewObject;
            }
        }
        /// <summary>
        ///  filed object for the list of revision.
        /// </summary>
        public object MetaObject
        {
            set
            {
                _dataFieldCollection = _defaultDataFieldCollection;
                RaisePropertyChanged();
            }
            get
            {
                return _dataFieldCollection;
            }
        }
    }
}
