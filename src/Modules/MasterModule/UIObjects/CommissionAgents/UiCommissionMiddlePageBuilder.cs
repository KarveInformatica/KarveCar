using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using KarveControls.UIObjects;
using MasterModule.Common;
using MasterModule.Properties;

namespace MasterModule.UIObjects.CommissionAgents
{
    class UiCommissionMiddlePageBuilder: CommonPageBuilder,IUiPageBuilder
    {
        private string[] LeftPartsFields =
        {
            "NOMBRE", "NIF", "DIRECCION" ,
            "CP", "POBLACION", "PROVINCIA", "NACIOPER",
            "TELEFONO", "FAX", "MOVIL", "EMAIL",
            "INTERNET", "PERSONA", "SUBLICEN", "OFICINA",
            "BAJA_COMI", "ALTA_COMI", "OBSERVA", "IDIOMA"
        };
      
        private string[] RightPartsFields =
        {
            "VENDE_COMI", "MERCADO", "NEGOCIO" ,
            "CANAL", "POBLACION", "PROV", "NACIOPER",
            "TELEFONO", "FAX", "MOVIL", "EMAIL",
            "INTERNET", "PERSONA", "SUBLICEN", "OFICINA",
            "BAJA_COMI", "ALTA_COMI", "OBSERVA", "IDIOMA"
        };


        private UiEmailDataField.EmailCheckHandler _emailCheckHandler;

        public UiCommissionMiddlePageBuilder(UiEmailDataField.EmailCheckHandler emailCheckHandler)
        {
            EmailCheckHandler = emailCheckHandler;
        }

        public UiEmailDataField.EmailCheckHandler EmailCheckHandler
        {
            get { return _emailCheckHandler; }
            set { _emailCheckHandler = value; }
        }

        public IDictionary<string, ObservableCollection<IUiObject>> BuildPageObjects(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery, UiDfObject.ChangedField changedField)
        {
            IDictionary<string, ObservableCollection<IUiObject>> pageObjects = new Dictionary<string, ObservableCollection<IUiObject>>();
            pageObjects[MasterModule.UiLeftPartPage] = BuildLeftPartCollection(assistQuery, changedField);
            pageObjects[MasterModule.UiRightPartPage] = BuildRightPartObjects(assistQuery, changedField);
            return pageObjects;
        }

        public IUiObject BuildPhone(UiDfObject.ChangedField changedField)
        {

            UiMultipleDfObject multipleDfObject = new UiMultipleDfObject();
            int i = 8;
            for (int k = 0; k < 3; ++k)
            {
                UiDfObject dataDfObject = new UiDfObject();
                DataTable table = new DataTable();
                dataDfObject.ItemSource = table;
                dataDfObject.DataField = RightPartsFields[i];
                dataDfObject.LabelText = ProviderConstants.LeftPartLabel[i];
                dataDfObject.LabelVisible = true;
                dataDfObject.TextContentWidth = UiConstants.TextBoxWidthDefault;
                dataDfObject.Height = UiConstants.TextboxHeight;
                dataDfObject.TableName = "COMISIO";
                dataDfObject.LabelTextWidth = UiConstants.LabelTextWidthDefault;
                dataDfObject.IsReadOnly = false;
                dataDfObject.PrimaryKey = "NUM_COMI";
                dataDfObject.OnChangedField += changedField;
                dataDfObject.AllowedEmpty = true;
                multipleDfObject.AddDataField(dataDfObject);
                i++;
            }
            return multipleDfObject;
        }


        private IUiObject BuildField(int fieldPos, UiDfObject.ChangedField changedField)
        {
            UiDfObject dataDfObject = new UiDfObject();
            DataTable table = new DataTable();
            dataDfObject.ItemSource = table;
            dataDfObject.DataField = LeftPartsFields[fieldPos];
            dataDfObject.LabelText = ProviderConstants.LeftPartLabel[fieldPos];
            dataDfObject.LabelVisible = true;
            dataDfObject.TextContentWidth = UiConstants.TextBoxWidthDefault;
            dataDfObject.Height = UiConstants.TextboxHeight;
            dataDfObject.TableName = "COMISIO";
            dataDfObject.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            dataDfObject.IsReadOnly = false;
            dataDfObject.PrimaryKey = "NUM_COMI";
            dataDfObject.OnChangedField += changedField;
            dataDfObject.AllowedEmpty = true;
            return dataDfObject;
        }

        private IUiObject BuildOffice(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery, UiDfObject.ChangedField changedField)
        {

            UiMultipleDfObject multipleDfObject = new UiMultipleDfObject();

            UiDualDfSearchTextObject dualSearchTextObject1 =
                new UiDualDfSearchTextObject(Properties.Resources.ProviderInfoViewModel_Empresa,
                    UiConstants.LabelTextWidthDefault);
            dualSearchTextObject1.ButtonImage = UiConstants.ImagePath;
            dualSearchTextObject1.AssistDataFieldFirst = "CODIGO";
            dualSearchTextObject1.AssistDataFieldSecond = "NOMBRE";
            dualSearchTextObject1.AssistTableName = "SUBLICEN";
            dualSearchTextObject1.Height = UiConstants.TextboxHeight;
            dualSearchTextObject1.LabelText = ProviderConstants.LeftPartLabel[14];
            dualSearchTextObject1.IsVisible = true;
            dualSearchTextObject1.IsReadOnly = true;
            dualSearchTextObject1.PrimaryKey = "NUM_COMI";
            dualSearchTextObject1.TableName = "COMISIO";
            dualSearchTextObject1.OnChangedField += changedField;
            dualSearchTextObject1.IsReadOnlySecond = false;
            dualSearchTextObject1.IsReadOnlyFirst = false;
            dualSearchTextObject1.TextContentFirstWidth = UiConstants.TextBoxWidthSmall;
            dualSearchTextObject1.TextContentSecondWidth = UiConstants.TextBoxWidthDefault;
            dualSearchTextObject1.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            dualSearchTextObject1.DataFieldFirst = LeftPartsFields[14];
            dualSearchTextObject1.DataField = LeftPartsFields[14];
            dualSearchTextObject1.OnAssistQuery += assistQuery;
            multipleDfObject.AddDataField(dualSearchTextObject1);
            UiDualDfSearchTextObject dualSearchTextObject2 =
                new UiDualDfSearchTextObject(Properties.Resources.ProviderInfoViewModel_Empresa,
                    UiConstants.LabelTextWidthDefault);
            dualSearchTextObject2.ButtonImage = UiConstants.ImagePath;
            dualSearchTextObject2.AssistDataFieldFirst = "CODIGO";
            dualSearchTextObject2.AssistDataFieldSecond = "NOMBRE";
            dualSearchTextObject2.AssistTableName = "OFICINAS";
            dualSearchTextObject2.Height = UiConstants.TextboxHeight;
            dualSearchTextObject2.LabelText = LeftPartsFields[15];
            dualSearchTextObject2.IsVisible = true;
            dualSearchTextObject2.IsReadOnly = true;
            dualSearchTextObject2.TextContentFirstWidth = UiConstants.TextBoxWidthSmall;
            dualSearchTextObject2.TextContentSecondWidth = UiConstants.TextBoxWidthDefault;
            dualSearchTextObject2.PrimaryKey = "NUM_COMI";
            dualSearchTextObject2.TableName = "COMISIO";
            dualSearchTextObject2.OnChangedField += changedField;
            dualSearchTextObject2.IsReadOnlySecond = true;
            dualSearchTextObject2.IsReadOnlyFirst = false;
            dualSearchTextObject2.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            dualSearchTextObject2.DataFieldFirst = "OFICINA";
            dualSearchTextObject2.DataField = "OFICINA";
            dualSearchTextObject2.OnAssistQuery += assistQuery;
            multipleDfObject.AddDataField(dualSearchTextObject2);
            return multipleDfObject;
        }

        public ObservableCollection<IUiObject> BuildLeftPartCollection(
            UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery, 
            UiDfObject.ChangedField changedField)
        {
            ObservableCollection<IUiObject> observableCollection = new ObservableCollection<IUiObject>();
            IDictionary<string, ObservableCollection<IUiObject>> dictionary = new Dictionary<string, ObservableCollection<IUiObject>>();
            
            // Nombre y Nif.
            IUiObject currentField = null;
            IDictionary<string, string> nameNifDictionary = new Dictionary<string, string>();
            nameNifDictionary["DataField"] = LeftPartsFields[0];
            nameNifDictionary["DataFieldRight"] = LeftPartsFields[1];
            nameNifDictionary["TableName"] = "COMISIO";
            nameNifDictionary["PrimaryKey"] = "NUM_COMI";
            nameNifDictionary["LabelRight"] = ProviderConstants.LeftPartLabel[0];
            nameNifDictionary["Label"] = ProviderConstants.LeftPartLabel[1];
            currentField = BuildDoubleDfObjectProviders(nameNifDictionary, changedField);
            observableCollection.Add(currentField);
            // Direccion
            IDictionary<string, string> dirDictionary = new Dictionary<string, string>();
            dirDictionary["DataField"] = LeftPartsFields[2];
            dirDictionary["Label"] = ProviderConstants.LeftPartLabel[2];
            dirDictionary["PrimaryKey"] = "NUM_COMI";
            nameNifDictionary["TableName"] = "COMISIO";
            currentField = BuildDirection(dirDictionary, changedField);
            observableCollection.Add(currentField);
           // Codigo postal y poblacion
            currentField = BuildCpPoblacion(assistQuery, changedField);
            observableCollection.Add(currentField);
            // Provincia
            currentField = BuildProvinceDfSearchTextObject("PROVINCIA", assistQuery, changedField);
            observableCollection.Add(currentField);
            // Country
            currentField = BuildPaisSearchTextObject("NACIOPER", assistQuery, changedField);
            observableCollection.Add(currentField);
            // Telefono
            currentField = BuildPhone(changedField);
            observableCollection.Add(currentField);
            // Web
            currentField = BuildField(12, changedField);
            observableCollection.Add(currentField);
            // Email
            IDictionary<string, string> fields = new Dictionary<string, string>();
            fields["DataField"] = "EMAIL";
            fields["Label"] = "Email";
            fields["PrimaryKey"] = "NUM_COMI";
            fields["Table"] = "COMISIO";
            currentField = BuildEmail(fields, EmailCheckHandler, changedField);
            observableCollection.Add(currentField);
                // Persona
            currentField = BuildField(13, changedField);
            observableCollection.Add(currentField);
            // Officina
            currentField = BuildOffice(assistQuery, changedField);
            observableCollection.Add(currentField);
            // Dates.
            currentField = BuildDates(changedField);
            observableCollection.Add(currentField);
            // add notes
            currentField = BuildDataArea(changedField, LeftPartsFields[18], ProviderConstants.LeftPartLabel[18]);
            observableCollection.Add(currentField);
         
            return observableCollection;
        }

        private IUiObject BuildDates(UiDfObject.ChangedField changedField)
        {
            UiMultipleDfObject dateMultipleDfObject = new UiMultipleDfObject();
            UiDatePicker startDate = new UiDatePicker();
            startDate.LabelText = ProviderConstants.LeftPartLabel[16];
            startDate.LabelVisible = true;
            startDate.DataField = LeftPartsFields[16];
            startDate.Height = UiConstants.TextboxHeight;
            startDate.Width = UiConstants.PickerWidth;
            startDate.OnChangedField += changedField;
            startDate.PrimaryKey ="NUM_COMI";
            startDate.TableName = "COMISIO";
            startDate.ItemSource = new DataTable();
            startDate.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            dateMultipleDfObject.AddDataField(startDate);
            UiDatePicker startDate1 = new UiDatePicker();
            startDate1.LabelText = Resources.UiMiddlePartPageBuilder_BuildDates_FechaDeAlta;
            startDate1.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            startDate1.DataField = LeftPartsFields[17];
            startDate1.Height = UiConstants.TextboxHeight;
            startDate1.Width = UiConstants.PickerWidth;
            startDate1.LabelVisible = true;
            startDate1.OnChangedField += changedField;
            startDate1.PrimaryKey = "NUM_COMI";
            startDate1.TableName = "COMISIO";
            startDate1.ItemSource = new DataTable();
            dateMultipleDfObject.AddDataField(startDate1);
            return dateMultipleDfObject;
        }
        public IUiObject BuildDataArea(UiDfObject.ChangedField changedField, string dataField, string dataLabel)
        {
            UiDataArea dataArea = new UiDataArea();
            dataArea.DataField = dataField;
            dataArea.LabelVisible = true;
            dataArea.LabelText = dataLabel;
            dataArea.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            dataArea.TableName = "COMISIO";
            dataArea.PrimaryKey = ProviderConstants.PrimaryKey;
            dataArea.ItemSource = new DataTable();
            return dataArea;
        }


        private UiDualDfSearchTextObject BuildPaisSearchTextObject(string paisDataField,
            UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery, UiDfObject.ChangedField changedField)
        {
            UiDualDfSearchTextObject paisSearchTextObject = new UiDualDfSearchTextObject("Pais", UiConstants.LabelTextWidthDefault);
            paisSearchTextObject.ButtonImage = MasterModule.ImagePath;
            paisSearchTextObject.TableName = "NUM_COMI";
            paisSearchTextObject.PrimaryKey = "COMISIO";
            paisSearchTextObject.AssistTableName = "PAIS";
            paisSearchTextObject.AssistDataFieldFirst = "SIGLAS";
            paisSearchTextObject.AssistDataFieldSecond = "PAIS";
            paisSearchTextObject.DataField = paisDataField;
            paisSearchTextObject.DataFieldFirst = paisDataField;
            paisSearchTextObject.Height = UiConstants.TextboxHeight;
            paisSearchTextObject.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            paisSearchTextObject.TextContentFirstWidth = UiConstants.TextBoxWidthDefault;
            paisSearchTextObject.TextContentSecondWidth = "150";
            paisSearchTextObject.IsReadOnlyFirst = false;
            paisSearchTextObject.IsReadOnlySecond = false;
            paisSearchTextObject.SourceView = new DataTable();
            paisSearchTextObject.OnChangedField += changedField;
            paisSearchTextObject.OnAssistQuery += assistQuery;
            return paisSearchTextObject;
        }
        private IUiObject BuildProvinceDfSearchTextObject(string provinceDataField, UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery, UiDfObject.ChangedField changedField)
        {
            UiDualDfSearchTextObject dualSearchTextObject1 =
                new UiDualDfSearchTextObject(Resources.ProviderInfoViewModel_LoadLeftPart_Provincia,
                    UiConstants.LabelTextWidthDefault);
            dualSearchTextObject1.ButtonImage = MasterModule.ImagePath;
            dualSearchTextObject1.AssistDataFieldFirst = ProviderConstants.ZipKey;
            dualSearchTextObject1.AssistDataFieldSecond = ProviderConstants.ProvinceKey;
            dualSearchTextObject1.AssistTableName = ProviderConstants.ProvinceAssistTableName;
            dualSearchTextObject1.Height = UiConstants.TextboxHeight;
            dualSearchTextObject1.IsVisible = true;
            dualSearchTextObject1.PrimaryKey = "NUM_COMI";
            dualSearchTextObject1.TableName = "COMISIO";
            dualSearchTextObject1.OnChangedField += changedField;
            dualSearchTextObject1.IsReadOnlySecond = true;
            dualSearchTextObject1.IsReadOnlyFirst = false;
            dualSearchTextObject1.DataFieldFirst = provinceDataField;
            dualSearchTextObject1.DataField = provinceDataField;
            dualSearchTextObject1.TextContentFirstWidth = UiConstants.TextBoxWidthDefault;
            dualSearchTextObject1.TextContentSecondWidth = UiConstants.TextBoxWidthDefault;
            dualSearchTextObject1.OnAssistQuery += assistQuery;
            return dualSearchTextObject1;
        }

        private IUiObject BuildCpPoblacion(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery, UiDfObject.ChangedField changedField)
        {
            UiDoubleDfObject doubleDfObject = new UiDoubleDfObject();
            doubleDfObject.DataField = LeftPartsFields[4];
            doubleDfObject.LabelText = ProviderConstants.LeftPartLabel[4];
            doubleDfObject.IsReadOnly = true;
            doubleDfObject.LabelVisible = true;
            doubleDfObject.TextContentWidth = UiConstants.TextBoxWidthDefault;
            doubleDfObject.Height = UiConstants.TextboxHeight;
            doubleDfObject.TableName = "COMISIO";
            doubleDfObject.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            doubleDfObject.IsReadOnly = false;
            doubleDfObject.IsReadOnlyRight = false;
            doubleDfObject.PrimaryKey = "NUM_COMI";
            doubleDfObject.OnChangedField += changedField;
            doubleDfObject.AllowedEmpty = true;
            doubleDfObject.DataFieldRight = LeftPartsFields[5];
            doubleDfObject.LabelTextRight = ProviderConstants.LeftPartLabel[5];
            doubleDfObject.LabelTextWidthRight = UiConstants.LabelTextWidthDefault;
            doubleDfObject.LabelVisibleRight = true;
            doubleDfObject.TextContentWidthRight = UiConstants.TextBoxWidthDefault;
            doubleDfObject.HeightRight = UiConstants.TextboxHeight;
            DataTable table = new DataTable();
            doubleDfObject.ItemSource = table;
            doubleDfObject.ItemSourceRight = table;
            return doubleDfObject;
        }
        /// <summary>
        ///  This build up a collection of object to be rendered and binded with the data templates.
        /// </summary>
        /// <param name="assistQuery"></param>
        /// <param name="changedField"></param>
        /// <returns></returns>
        public ObservableCollection<IUiObject> BuildRightPartObjects(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery, UiDfObject.ChangedField changedField)
        {
            ObservableCollection<IUiObject> rightPageCollection = new ObservableCollection<IUiObject>();
            UiDualDfSearchTextObject uiVendedor = new UiDualDfSearchTextObject("Vendedor", UiConstants.LabelTextWidthDefault);
            uiVendedor.OnAssistQuery += assistQuery;
            uiVendedor.OnChangedField += changedField;
            uiVendedor.DataFieldFirst = RightPartsFields[0];
            uiVendedor.TableName = "COMISIO";
            uiVendedor.AssistTableName = "VENDEDOR";
            uiVendedor.AssistDataFieldFirst = "NUM_VENDE";
            uiVendedor.AssistDataFieldSecond = "NOMBRE";
            rightPageCollection.Add(uiVendedor);
            UiDualDfSearchTextObject uiMarket = new UiDualDfSearchTextObject("Mercado", UiConstants.LabelTextWidthDefault);
            uiMarket.OnAssistQuery += assistQuery;
            uiMarket.OnChangedField += changedField;
            uiMarket.DataFieldFirst = RightPartsFields[1];
            uiMarket.AssistDataFieldFirst = "CODIGO";
            uiMarket.AssistDataFieldSecond = "NOMBRE";
            uiMarket.TableName = "COMISO";
            uiMarket.AssistTableName = "MERCADO";
            rightPageCollection.Add(uiMarket);
            UiDualDfSearchTextObject uiBusiness = new UiDualDfSearchTextObject("Negocio", UiConstants.LabelTextWidthDefault);
            uiBusiness.OnAssistQuery += assistQuery;
            uiBusiness.OnChangedField += changedField;
            uiBusiness.DataField = "NEGOCIO";
            uiBusiness.AssistDataFieldFirst = "CODIGO";
            uiBusiness.AssistDataFieldSecond = "NOMBRE";
            uiBusiness.TableName = "COMISIO";
            uiBusiness.AssistTableName = "NEGOCIO";
            rightPageCollection.Add(uiBusiness);
            UiDualDfSearchTextObject uiCanal = new UiDualDfSearchTextObject("Canal", UiConstants.LabelTextWidthDefault);
            uiCanal.OnAssistQuery += assistQuery;
            uiCanal.OnChangedField += changedField;
            uiCanal.DataFieldFirst = "CANAL";
            uiCanal.AssistDataFieldFirst = "CODIGO";
            uiCanal.AssistDataFieldSecond = "NOMBRE";
            uiCanal.AssistTableName = "CANAL";
            uiCanal.TableName = "COMISIO";
            rightPageCollection.Add(uiCanal);
            UiDualDfSearchTextObject uiClavePto = new UiDualDfSearchTextObject("Clave PPto", UiConstants.LabelTextWidthDefault);
            uiClavePto.OnAssistQuery += assistQuery;
            uiClavePto.OnChangedField += changedField;
            uiClavePto.DataFieldFirst = "CLAVEPPTO";
            uiClavePto.AssistTableName = "CLAVEPTO";
            uiClavePto.AssistDataFieldFirst = "COD_CLAVE";
            uiClavePto.AssistDataFieldSecond = "NOMBRE";
            uiClavePto.TableName = "COMISIO";
            rightPageCollection.Add(uiClavePto);
            UiDualDfSearchTextObject uiOrigen = new UiDualDfSearchTextObject("Origen", UiConstants.LabelTextWidthDefault);
            uiOrigen.OnAssistQuery += assistQuery;
            uiOrigen.OnChangedField += changedField;
            uiOrigen.DataFieldFirst = "ORIGEN_COMI";
            uiOrigen.AssistTableName = "ORIGEN";
            uiOrigen.AssistDataFieldFirst = "NUM_ORIGEN";
            uiOrigen.AssistDataFieldSecond = "NOMBRE";
            uiOrigen.TableName = "COMISIO";
            rightPageCollection.Add(uiOrigen);
            UiDualDfSearchTextObject officeZone = new UiDualDfSearchTextObject("Zona Ofi.", UiConstants.LabelTextWidthDefault);
            officeZone.OnAssistQuery += assistQuery;
            officeZone.OnChangedField += changedField;
            officeZone.DataFieldFirst = "ZONA_OFI";
            officeZone.AssistTableName = "ZONAS";
            officeZone.AssistDataFieldFirst = "NUM_ZONA";
            officeZone.AssistDataFieldSecond = "NOMBRE";
            officeZone.TableName = "COMISIO";
            rightPageCollection.Add(officeZone);
            UiDataArea alert = new UiDataArea();
            alert.DataField = "AVISO";
            alert.OnChangedField += changedField;
            alert.TableName = "COMISIO";
            rightPageCollection.Add(alert);
            return rightPageCollection;
        }
    }
}
