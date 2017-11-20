using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using KarveDataServices.DataTransferObject;
using Prism.Commands;
using Prism.Mvvm;

namespace MasterModule.Views.Vehicles.MockViewModels
{
    public class VehiculeSellingBuyingVm : BindableBase
    {
        private VehicleDto _vehicleDto = new VehicleDto();
        private string _buyerAssist = "";
        private string _sellerAssit = "";
        private string _supplierAssistQuery = "";
        private DelegateCommand<object> _delegateCommand;
        private List<UiMetaObject> _dataFieldCollection;
        private StringConstants _stringConstants = new StringConstants();
        /// <summary>
        /// Vehicle DataObject.
        /// </summary>
        public VehiculeSellingBuyingVm()
        {
            _delegateCommand = new DelegateCommand<object>(ItemIsChanged);
            InitalizeDto();

        }
        /// <summary>
        ///  DataObject
        /// </summary>
        public object DataObject
        {
            get => _vehicleDto;
            set { _vehicleDto = (VehicleDto)value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// Command to be changed.
        /// </summary>
        public ICommand ItemChangedCommand
        {
            get => _delegateCommand;
            set => _delegateCommand = (DelegateCommand<object>)value;
        }
        /// <summary>
        ///  Item changed.
        /// </summary>
        /// <param name="value">Name of the value changed.</param>
        public void ItemIsChanged(object value)
        {
            MessageBox.Show("Value Changed");
        }
        /// <summary>
        ///  Buyer Assist Query
        /// </summary>
        public string BuyerAssistQuery
        {
            get { return _buyerAssist; }
            set { _buyerAssist = value; }
        }
        /// <summary>
        /// Seller Assist Query
        /// </summary>
        public string SellerAssistQuery
        {
            get { return _sellerAssit; }
            set { _sellerAssit = value; }
        }
        /// <summary>
        ///  Supplier Assist Query.
        /// </summary>
        public string SupplierAssistQuery
        {
            get { return _supplierAssistQuery; }
            set { _supplierAssistQuery = value; }

        }
        /// <summary>
        ///  Data field collection.
        /// </summary>
        public List<UiMetaObject> DataFieldCollection
        {
            set
            {
                _dataFieldCollection = value;
                RaisePropertyChanged();
            }
            get { return _dataFieldCollection; }
        }
        public object StringConstants
        {
            set
            {
                _stringConstants = (StringConstants) value;
                RaisePropertyChanged();
            }
            get
            {
                return _stringConstants;
            }
        }
        /// <summary>
        /// Initialize DTO.
        /// </summary>
        private void InitalizeDto()
        {
            VehicleDto vehicleDto1 = new VehicleDto
            {
                PRECIO = 35000,
                COMPRADOR = "Carles Ruiz Floriach",
                FRAVEN = "12829893",
                PVP = 200000,
                VENDEDOR_VTA = "Yngvar Rossow"
            };
            System.TimeSpan nextSpan = new System.TimeSpan(36, 0, 0, 0);
            vehicleDto1.FFRA = DateTime.Today;
            vehicleDto1.FFRA.Value.Add(nextSpan);
            vehicleDto1.FTRAFB = DateTime.Today.Add(new System.TimeSpan(50, 0, 0, 0));
            vehicleDto1.FTRANS = DateTime.Today.Add(new System.TimeSpan(60, 0, 0, 0));
            vehicleDto1.FENTREGA_VEHI = DateTime.Today.Add(new System.TimeSpan(80, 0, 0, 0));
            vehicleDto1.IMPUESTO = 1500;
            vehicleDto1.TARTRANS = "Opcional";
            vehicleDto1.PFF = 2000;
            vehicleDto1.PFF_OPCIONES = 10;
            vehicleDto1.FMATRI = DateTime.Today.Add(new System.TimeSpan(50, 0, 0, 0));


            DataObject = vehicleDto1;
            List<UiMetaObject> dataFieldCollection = new List<UiMetaObject>
        {
                new UiMetaObject()
                {
                    DataSource = vehicleDto1,
                    DataSourcePath = "IMPUESTO" ,
                    ChangedItem=ItemChangedCommand,
                    LabelText = "Impuesto  Matricula"
                },
               new UiMetaObject()
               {
                    DataSource = vehicleDto1,
                    DataSourcePath = "TARTRANS" ,
                    ChangedItem=ItemChangedCommand,
                    LabelText = "Tarifa Transporte"
               },
              new UiMetaObject()
              {
                DataSource = vehicleDto1,
                    DataSourcePath = "PFF" ,
                    ChangedItem=ItemChangedCommand,
                    LabelText = "Precio Fabricacion"
              },
              new UiMetaObject()
              {
                  DataSource = vehicleDto1,
                  DataSourcePath = "PFF_OPCIONES" ,
                  ChangedItem=ItemChangedCommand,
                  LabelText = "Opciones Precio"
              },
              new UiMetaObject()
              {
                  DataSource = vehicleDto1,
                    DataSourcePath = "COMPRAFRA" ,
                    ChangedItem=ItemChangedCommand,
                    LabelText = "Numero Factura"
              },
              new UiMetaObject()
              {
                  DataSource = vehicleDto1,
                    DataSourcePath = "COSTE" ,
                    ChangedItem=ItemChangedCommand,
                    LabelText = "Precio Compra"
              },
              new UiMetaObject()
              {
                  DataSource = vehicleDto1,
                  DataSourcePath = "BONIFICA" ,
                  ChangedItem=ItemChangedCommand,
                  LabelText = "Bonifica"
              }
        };
            DataFieldCollection = dataFieldCollection;
            StringConstants = _stringConstants;
        }
    }
}
