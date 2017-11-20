using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KarveDataServices.DataTransferObject;
using Prism.Mvvm;

namespace MasterModule.Views.Vehicles.MockViewModels
{
    class VehicleMockBase: BindableBase
    {
        protected VehicleDto VehicleDto = new VehicleDto();

        public VehicleMockBase()
        {
            InitDto();
        }
        private void InitDto()
        {
            VehicleDto.DANOS = "Ningun";
            VehicleDto.LEXTRAS = "Nada";
            VehicleDto.ACCESORIOS_VH = "None";
            VehicleDto.AVISO = "Entrega in 6 oras";
            DataObject = VehicleDto;
        }
        
        public object DataObject
        {
            get { return VehicleDto; }
            set { VehicleDto = (VehicleDto)value;
                RaisePropertyChanged(); }
        }
    }
}
