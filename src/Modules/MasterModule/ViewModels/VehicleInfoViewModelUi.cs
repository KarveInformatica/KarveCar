using MasterModule.Views.Vehicles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterModule.ViewModels
{
    /// <summary>
    ///  This is the part of the collection of items to be exposed into the view.
    /// </summary>

    public partial class VehicleInfoViewModel
    {

        private StringConstants _stringConstants = new StringConstants();
        // constants of a string for the view model
        public object StringConstants
        {
            set
            {
                _stringConstants = (StringConstants)value;
                RaisePropertyChanged();
            }
            get
            {
                return _stringConstants;
            }
        }
        // collection to be rendered.
        public ObservableCollection<UiMetaObject> DataFieldCollection
        {
            set { _value = InitDataField(); }
            get { return _value; }
        }

        private ObservableCollection<UiMetaObject> InitLabels()
        {
            ObservableCollection<UiMetaObject> metaObjects = new ObservableCollection<UiMetaObject>()
            {
                new UiMetaObject
                {
                    DataSource = DataObject,
                    DataSourcePath = "RENUEVA_CIRC_1",
                    LabelText = "Renovación 1",
                    ChangedItem = ItemChangedCommand
                },
                new UiMetaObject
                {
                    DataSource = DataObject,
                    DataSourcePath = "RENUEVA_CIRC_2",
                    LabelText = "Renovación 2",
                    ChangedItem = ItemChangedCommand
                },
                new UiMetaObject
                {
                    DataSource = DataObject,
                    DataSourcePath = "RENUEVA_CIRC_2",
                    LabelText = "Renovación 3",
                    ChangedItem = ItemChangedCommand
                }
            };
            return metaObjects;
        }

        public ObservableCollection<UiMetaObject> InitDataField()
        {
            ObservableCollection<UiMetaObject> dataFieldCollection = new ObservableCollection<UiMetaObject>()
            {
                new UiMetaObject()
                {
                    DataSource = DataObject,
                    DataSourcePath = "IMPUESTO",
                    ChangedItem = ItemChangedCommand,
                    LabelText = "Impuesto  Matricula"

                },
                new UiMetaObject()
                {
                    DataSource = DataObject,
                    DataSourcePath = "TARTRANS",
                    ChangedItem = ItemChangedCommand,
                    LabelText = "Tarifa Transporte"
                },
                new UiMetaObject()
                {
                    DataSource = DataObject,
                    DataSourcePath = "PFF",
                    ChangedItem = ItemChangedCommand,
                    LabelText = "Precio Fabricacion"
                },
                new UiMetaObject()
                {
                    DataSource = DataObject,
                    DataSourcePath = "PFF_OPCIONES",
                    ChangedItem = ItemChangedCommand,
                    LabelText = "Opciones Precio"
                },
                new UiMetaObject()
                {
                    DataSource = DataObject,
                    DataSourcePath = "COMPRAFRA",
                    ChangedItem = ItemChangedCommand,
                    LabelText = "Numero Factura"
                },
                new UiMetaObject()
                {
                    DataSource = DataObject,
                    DataSourcePath = "COSTE",
                    ChangedItem = ItemChangedCommand,
                    LabelText = "Precio Compra"
                },
                new UiMetaObject()
                {
                    DataSource = DataObject,
                    DataSourcePath = "BONIFICA",
                    ChangedItem = ItemChangedCommand,
                    LabelText = "Bonifica"
                }
            };
            return dataFieldCollection;
        }

        public ObservableCollection<UiComposedObject>  MetaDataObject
        {
            set
            {

                _metaObject = value; 
                RaisePropertyChanged();
            }
            get { return _metaObject; }
        }

        public ObservableCollection<UiComposedObject> InitAssuranceObject()
        {

            for (int i = 0; i < expirationAssurance.Count; ++i)
            {
                expirationAssurance[i].DataSource = DataObject;
                expirationAssurance[i].ItemCommandChanged = ItemChangedCommand;
            }
            return expirationAssurance;

            //    StringConstants = _stringConstants;
        }
        // fields for the expiration control.
        private ObservableCollection<UiComposedObject> expirationAssurance =
            new ObservableCollection<UiComposedObject>()
        {
            new UiComposedObject()
            {
                DataSourcePath1="Value.FPago1",
                DataSourcePath2="Value.IMPSEG1",
                DataText = "Value.IMPSEG1",
                DataSourcePath3="Pagado1"

            },
            new UiComposedObject()
            {
                DataSourcePath1="Value.FPago2",
                DataText = "Value.IMPSEG2",
                DataSourcePath2 ="Value.IMPSEG2",
                DataSourcePath3="Value.Pagado2"
            },
            new UiComposedObject()
            {
                DataSourcePath1="Value.FPago3",
                DataSourcePath2="Value.IMPSEG3",
                DataText = "Value.IMPSEG3",
                DataSourcePath3="Value.Pagado3"
            },
            new UiComposedObject()
            {
                DataSourcePath1="Value.FPago4",
                DataSourcePath2="Value.IMPSEG4",
                DataText = "Value.IMPSEG4",
                DataSourcePath3="Value.Pagado4"
            }

        };

        private ObservableCollection<UiMetaObject> _value;
        private ObservableCollection<UiComposedObject> _metaObject;
    }
}
