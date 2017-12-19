using MasterModule.Views.Vehicles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;

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

        private ObservableCollection<UiComposedFieldObject> RevisionCollection = new ObservableCollection<UiComposedFieldObject>()
        {
            new UiComposedFieldObject()
            {
                LabelSource="I.T.V",
                DataSourcePath1="FITV",
                DataSourcePath2="FITV2",
                DataSourcePath3="OBS_ITV",
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




        public ObservableCollection<UiComposedFieldObject> InitRevisionComposedFieldObjects()
        {
            for (int i = 0; i < RevisionCollection.Count; ++i)
            {
                RevisionCollection[i].ItemChangedCommand = ItemChangedCommand;
                RevisionCollection[i].DataSource = DataObject;
            }
            return RevisionCollection;
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
