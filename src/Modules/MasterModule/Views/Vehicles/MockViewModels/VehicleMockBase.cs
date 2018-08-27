using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KarveDataServices.ViewObjects;
using Prism.Mvvm;

namespace MasterModule.Views.Vehicles.MockViewModels
{
    class VehicleMockBase: BindableBase
    {
        protected VehicleViewObject VehicleViewObject = new VehicleViewObject();

        public VehicleMockBase()
        {
            InitDto();
        }
        private void InitDto()
        {
            VehicleViewObject.DANOS = "Ningun";
            VehicleViewObject.LEXTRAS = "Nada";
            VehicleViewObject.ACCESORIOS_VH = "None";
            VehicleViewObject.AVISO = "Entrega in 6 oras";
            DataObject = VehicleViewObject;
        }
        
        public object DataObject
        {
            get { return VehicleViewObject; }
            set { VehicleViewObject = (VehicleViewObject)value;
                RaisePropertyChanged(); }
        }
    }
}
