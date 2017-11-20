using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataTransferObject;
using Prism.Mvvm;

namespace MasterModule.Views.Vehicles.MockViewModels
{
    public class ExpireDataMockViewModel: BindableBase
    {

        private VehicleDto _vehicleDto = new VehicleDto();

        private StringConstants _stringConstants = new StringConstants();


        private List<UiComposedObject> listOfObject = new List<UiComposedObject>()
        {
            new UiComposedObject()
            {
                DataSourcePath1="FPago1",
                DataSourcePath2="IMPSEG1",
                DataSourcePath3="Pagado1"

            },
            new UiComposedObject()
            {
                DataSourcePath1="FPago2",
                DataSourcePath2="IMPSEG2",
                DataSourcePath3="Pagado2"
            },
            new UiComposedObject()
            {
                DataSourcePath1="FPago3",
                DataSourcePath2="IMPSEG3",
                DataSourcePath3="Pagado3"
            },
            new UiComposedObject()
            {
                DataSourcePath1="FPago4",
                DataSourcePath2="IMPSEG4",
                DataSourcePath3="Pagado4"
            }

        };
        public ExpireDataMockViewModel()
        {
            InitData();
        }
        /// <summary>
        ///  Data object.
        /// </summary>
        public void InitData()
        {
            for (int i = 0; i< listOfObject.Count; ++i)
            {
                listOfObject[i].DataSource = _vehicleDto;
            }
            MetaDataObject = listOfObject;
            StringConstants = _stringConstants;

        }

        /// <summary>
       ///  This is a data object.
       /// </summary>
       /// 
        public object MetaDataObject
        {
            get
            {
                return listOfObject;
            }
            set
            {
                listOfObject = (List<UiComposedObject>)value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Constant strings for locale.
        /// </summary>
        public object StringConstants
        {
            get
            {
                return _stringConstants;
            }
            set
            {
                _stringConstants = (StringConstants)value;
                RaisePropertyChanged();
            }
        }
    }
}
