using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataTransferObject;
using Prism.Mvvm;

namespace MasterModule.Views.VehicleAssurance.MockViewModels
{
    public class RevisionMaintenanceMockViewModel: BindableBase
    {
        private VehicleDto vehicleDto = new VehicleDto();
        List<UiComposedMetaObject> _dataFieldCollection;

        private List<UiComposedMetaObject> dataFieldCollection = new List<UiComposedMetaObject>
        {
                new UiComposedMetaObject()
                {
                    LabelSource="I.T.V", 
                    DataSourcePath1="FITV",
                    DataSourcePath2="FITV2",
                    DataSourcePath3="OBS_ITV"
                },
                new UiComposedMetaObject()
               {
                    LabelSource="Fecha Caducidad Transporte",
                    DataSourcePath1="ULT_TT",
                    DataSourcePath2="FCTARTRA",
                    DataSourcePath3="OBS_TT"
               },
              new UiComposedMetaObject()
              {
                  LabelSource="ADR",
                  DataSourcePath1="ULT_ADR",
                  DataSourcePath2="VTO_ADR",
                  DataSourcePath3="OBS_ADR"

              },
              new UiComposedMetaObject()
              {
                  LabelSource="Vtp ATP",
                  DataSourcePath1="ULT_ATP",
                  DataSourcePath2="VTO_ATP",
                  DataSourcePath3="OBS_ATP"
              },
              new UiComposedMetaObject()
              {
                  LabelSource="Extintor",
                  DataSourcePath1="FEXTINTOR",
                  DataSourcePath2="FEXTINTORCAD",
                  DataSourcePath3="OBS_EXT"

              },
              new UiComposedMetaObject()
              {
                  LabelSource="Tacografo",
                  DataSourcePath1="ULT_TAC",
                  DataSourcePath2="FREVITACO",
                  DataSourcePath3="OBS_TAC"

              },
              new UiComposedMetaObject()
              {
                  LabelSource="Termografo",
                  DataSourcePath1="ULT_TEMR",
                  DataSourcePath2="FREVTERM",
                  DataSourcePath3="OBS_TERM"
              },
              new UiComposedMetaObject()
              {
                  LabelSource="Fugas frio",
                  DataSourcePath1="ULT_FF",
                  DataSourcePath2="VTO_FF",
                  DataSourcePath3="OBS_FF"
              }
        };
        public RevisionMaintenanceMockViewModel()
        {
            vehicleDto.FITV = DateTime.Now;
            vehicleDto.FITV2 = DateTime.Now;
            vehicleDto.OBS_ITV = "ItvObserva";
            vehicleDto.ULT_TT = DateTime.Now;
            vehicleDto.FCTARTRA = DateTime.Now;
            vehicleDto.OBS_TT = "Observa";
            vehicleDto.ULT_ADR = DateTime.Now;
            vehicleDto.VTO_ADR = DateTime.Now;
            vehicleDto.OBS_ADR = "Observa adr";
            vehicleDto.ULT_ATP = DateTime.Now;
            vehicleDto.VTO_ADR = DateTime.Now;
            vehicleDto.OBS_ATP = "observa atp";
            vehicleDto.FEXTINTOR = DateTime.Now;
            vehicleDto.FEXTINTORCAD = DateTime.Now;
            vehicleDto.OBS_EXT = "observa ext";
            vehicleDto.ULT_TAC = DateTime.Now;
            vehicleDto.FREVITACO = DateTime.Now;
            vehicleDto.OBS_TAC = "observa taco";
            vehicleDto.ULT_TEMR = DateTime.Now;
            vehicleDto.FREVTERM = DateTime.Now;
            vehicleDto.OBS_TERM = "observa term";
            vehicleDto.ULT_FF = DateTime.Now;
            vehicleDto.VTO_FF = DateTime.Now;
            vehicleDto.OBS_FF = "observa ff";
            for (int i = 0; i < dataFieldCollection.Count; ++i)
            {
                dataFieldCollection[i].DataSource = vehicleDto;
            }
        }
        public object MetaObject
        {
            set
            {
                _dataFieldCollection = dataFieldCollection;
                RaisePropertyChanged();
            }
            get
            {
                return _dataFieldCollection;
            }
        }
    }
}
