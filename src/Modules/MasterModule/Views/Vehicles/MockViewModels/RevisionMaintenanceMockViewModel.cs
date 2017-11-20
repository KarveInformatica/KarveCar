using System;
using System.Collections.Generic;
using KarveDataServices.DataTransferObject;
using MasterModule.Views.VehicleAssurance.MockViewModels;
using Prism.Mvvm;

namespace MasterModule.Views.Vehicles.MockViewModels
{
    public class RevisionMaintenanceMockViewModel: BindableBase
    {
        private readonly VehicleDto _vehicleDto = new VehicleDto();
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
            _vehicleDto.FITV = DateTime.Now;
            _vehicleDto.FITV2 = DateTime.Now;
            _vehicleDto.OBS_ITV = "ItvObserva";
            _vehicleDto.ULT_TT = DateTime.Now;
            _vehicleDto.FCTARTRA = DateTime.Now;
            _vehicleDto.OBS_TT = "Observa";
            _vehicleDto.ULT_ADR = DateTime.Now;
            _vehicleDto.VTO_ADR = DateTime.Now;
            _vehicleDto.OBS_ADR = "Observa adr";
            _vehicleDto.ULT_ATP = DateTime.Now;
            _vehicleDto.VTO_ADR = DateTime.Now;
            _vehicleDto.OBS_ATP = "observa atp";
            _vehicleDto.FEXTINTOR = DateTime.Now;
            _vehicleDto.FEXTINTORCAD = DateTime.Now;
            _vehicleDto.OBS_EXT = "observa ext";
            _vehicleDto.ULT_TAC = DateTime.Now;
            _vehicleDto.FREVITACO = DateTime.Now;
            _vehicleDto.OBS_TAC = "observa taco";
            _vehicleDto.ULT_TEMR = DateTime.Now;
            _vehicleDto.FREVTERM = DateTime.Now;
            _vehicleDto.OBS_TERM = "observa term";
            _vehicleDto.ULT_FF = DateTime.Now;
            _vehicleDto.VTO_FF = DateTime.Now;
            _vehicleDto.OBS_FF = "observa ff";
            for (int i = 0; i < _dataFieldCollection.Count; ++i)
            {
                _dataFieldCollection[i].DataSource = _vehicleDto;
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
