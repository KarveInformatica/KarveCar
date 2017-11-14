using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using KarveControls.UIObjects;
using MasterModule.Common;
using MasterModule.Properties;

namespace MasterModule.UIObjects.Suppliers
{
    internal class UiMiddlePartPageBuilder : CommonPageBuilder,IUiPageBuilder
    {
        private const string Email = "EMAIL";

        private string[] MiddlePartsFields =
        {
            "NOMBRE", "NIF", "DIRECCION", "DIREC2" ,
            "CP", "POBLACION", "PROV", "NACIOPER",
            "TELEFONO", "FAX", "MOVIL", Email,
            "INTERNET", "PERSONA", "SUBLICEN", "OFICINA",
            "FBAJA", "FALTA", "NOTAS", "OBSERVA"
        };

        private UiEmailDataField.EmailCheckHandler _emailCheckHandler;

        public UiMiddlePartPageBuilder(UiEmailDataField.EmailCheckHandler emailCheckHandler)
        {
            EmailCheckHandler = emailCheckHandler;
        }

        public UiEmailDataField.EmailCheckHandler EmailCheckHandler
        {
            get { return _emailCheckHandler; }
            set { _emailCheckHandler = value; }
        }

        private IUiObject BuildProvinceDfSearchTextObject( string provinceDataField, UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery, UiDfObject.ChangedField changedField)
        {
            UiDualDfSearchTextObject dualSearchTextObject1 =
                new UiDualDfSearchTextObject(Resources.ProviderInfoViewModel_LoadLeftPart_Provincia,
                    UiConstants.LabelTextWidthDefault);
            dualSearchTextObject1.ButtonImage = MasterModuleConstants.ImagePath;
            dualSearchTextObject1.AssistDataFieldFirst = ProviderConstants.ZipKey;
            dualSearchTextObject1.AssistDataFieldSecond = ProviderConstants.ProvinceKey;
            dualSearchTextObject1.AssistTableName = ProviderConstants.ProvinceAssistTableName;
            dualSearchTextObject1.Height = UiConstants.TextboxHeight;
            dualSearchTextObject1.IsVisible = true;
            dualSearchTextObject1.PrimaryKey = ProviderConstants.PrimaryKey;
            dualSearchTextObject1.TableName = Resources.ProviderModule_Table1;
            dualSearchTextObject1.OnChangedField += changedField;
            dualSearchTextObject1.IsReadOnlySecond = true;
            dualSearchTextObject1.IsReadOnlyFirst = false;
            dualSearchTextObject1.DataFieldFirst = provinceDataField;
            dualSearchTextObject1.DataField = provinceDataField;
            dualSearchTextObject1.TextContentFirstWidth = UiConstants.TextBoxWidthSmall;
            dualSearchTextObject1.TextContentSecondWidth = UiConstants.TextBoxWidthDefault;
            dualSearchTextObject1.OnAssistQuery += assistQuery;
            return dualSearchTextObject1;
        }

        private IUiObject BuildOffice(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery, UiDfObject.ChangedField changedField)
        {

            UiMultipleDfObject multipleDfObject = new UiMultipleDfObject();

            UiDualDfSearchTextObject dualSearchTextObject1 =
                new UiDualDfSearchTextObject(Properties.Resources.ProviderInfoViewModel_Empresa,
                    UiConstants.LabelTextWidthDefault);
            dualSearchTextObject1.ButtonImage = MasterModuleConstants.ImagePath;
            dualSearchTextObject1.AssistDataFieldFirst = "CODIGO";
            dualSearchTextObject1.AssistDataFieldSecond = "NOMBRE";
            dualSearchTextObject1.AssistTableName = "SUBLICEN";
            dualSearchTextObject1.Height = UiConstants.TextboxHeight;
            dualSearchTextObject1.LabelText = ProviderConstants.LeftPartLabel[14];
            dualSearchTextObject1.IsVisible = true;
            dualSearchTextObject1.IsReadOnly = true;
            dualSearchTextObject1.PrimaryKey = "NUM_PROVEE";
            dualSearchTextObject1.TableName = "PROVEE1";
            dualSearchTextObject1.OnChangedField += changedField;
            dualSearchTextObject1.IsReadOnlySecond = false;
            dualSearchTextObject1.IsReadOnlyFirst = false;
            dualSearchTextObject1.TextContentFirstWidth = UiConstants.TextBoxWidthSmall;
            dualSearchTextObject1.TextContentSecondWidth = UiConstants.TextBoxWidthDefault;
            dualSearchTextObject1.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            dualSearchTextObject1.DataFieldFirst = MiddlePartsFields[14];
            dualSearchTextObject1.DataField = MiddlePartsFields[14];
            dualSearchTextObject1.OnAssistQuery += assistQuery;
          
            multipleDfObject.AddDataField(dualSearchTextObject1);
            
            UiDualDfSearchTextObject dualSearchTextObject2 =
                new UiDualDfSearchTextObject(Properties.Resources.ProviderInfoViewModel_Empresa,
                    UiConstants.LabelTextWidthDefault);
            dualSearchTextObject2.ButtonImage = MasterModuleConstants.ImagePath;
            dualSearchTextObject2.AssistDataFieldFirst = "CODIGO";
            dualSearchTextObject2.AssistDataFieldSecond = "NOMBRE";
            dualSearchTextObject2.AssistTableName = "OFICINAS";
            dualSearchTextObject2.Height = UiConstants.TextboxHeight;
            dualSearchTextObject2.LabelText = MiddlePartsFields[15];
            dualSearchTextObject2.IsVisible = true;
            dualSearchTextObject2.IsReadOnly = true;
            dualSearchTextObject2.TextContentFirstWidth = UiConstants.TextBoxWidthSmall;
            dualSearchTextObject2.TextContentSecondWidth = UiConstants.TextBoxWidthDefault;
            dualSearchTextObject2.PrimaryKey = "NUM_PROVEE";
            dualSearchTextObject2.TableName = "PROVEE1";
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
       
      
       

        private IUiObject BuildCpPoblacion(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery, UiDfObject.ChangedField changedField)
        {
            UiDoubleDfObject doubleDfObject = new UiDoubleDfObject();
            doubleDfObject.DataField = MiddlePartsFields[4];
            doubleDfObject.LabelText = ProviderConstants.LeftPartLabel[4];
            doubleDfObject.IsReadOnly = true;
            doubleDfObject.LabelVisible = true;
            doubleDfObject.TextContentWidth = UiConstants.TextBoxWidthDefault;
            doubleDfObject.Height = UiConstants.TextboxHeight;
            doubleDfObject.TableName = Resources.ProviderModule_Table1;
            doubleDfObject.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            doubleDfObject.IsReadOnly = false;
            doubleDfObject.IsReadOnlyRight = false;
            doubleDfObject.PrimaryKey = ProviderConstants.PrimaryKey;
            doubleDfObject.OnChangedField += changedField;
            doubleDfObject.AllowedEmpty = true;
            doubleDfObject.DataFieldRight = MiddlePartsFields[5];
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

        private IUiObject BuildDates(UiDfObject.ChangedField changedField)
        {
            UiMultipleDfObject dateMultipleDfObject = new UiMultipleDfObject();
            UiDatePicker startDate = new UiDatePicker();
            startDate.LabelText = ProviderConstants.LeftPartLabel[16];
            startDate.LabelVisible = true;
            startDate.DataField = MiddlePartsFields[16];
            startDate.Height =  UiConstants.TextboxHeight;
            startDate.Width = UiConstants.PickerWidth;
            startDate.OnChangedField += changedField;
            startDate.PrimaryKey = ProviderConstants.PrimaryKey;
            startDate.TableName = Resources.ProviderModule_Table1;
            startDate.ItemSource = new DataTable();
            startDate.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            dateMultipleDfObject.AddDataField(startDate);
            UiDatePicker startDate1 = new UiDatePicker();
            startDate1.LabelText = Resources.UiMiddlePartPageBuilder_BuildDates_FechaDeAlta;
            startDate1.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            startDate1.DataField = MiddlePartsFields[17];
            startDate1.Height = UiConstants.TextboxHeight;
            startDate1.Width = UiConstants.PickerWidth;
            startDate1.LabelVisible = true;
            startDate1.OnChangedField += changedField;
            startDate1.PrimaryKey = "NUM_PROVEE";
            startDate1.TableName = "PROVEE1";
            startDate1.ItemSource = new DataTable();
            dateMultipleDfObject.AddDataField(startDate1);
            return dateMultipleDfObject;
        }
        private UiDualDfSearchTextObject BuildPaisSearchTextObject(string paisDataField, 
            UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery, UiDfObject.ChangedField changedField)
        {
            UiDualDfSearchTextObject paisSearchTextObject = new UiDualDfSearchTextObject("Pais", UiConstants.LabelTextWidthDefault);
            paisSearchTextObject.ButtonImage = MasterModuleConstants.ImagePath;
            paisSearchTextObject.TableName = "PROVEE1";
            paisSearchTextObject.PrimaryKey = "NUM_PROVEE";
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

        public IUiObject BuildDataArea(UiDfObject.ChangedField changedField, string dataField, string dataLabel)
        {
            UiDataArea dataArea = new UiDataArea();
            dataArea.DataField = dataField;
            dataArea.LabelVisible = true;
            dataArea.LabelText = dataLabel;
            dataArea.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            dataArea.TextContentWidth = UiConstants.LabelTextWidthWide;
            dataArea.TableName = Resources.ProviderModule_Table1;
            dataArea.PrimaryKey = ProviderConstants.PrimaryKey;
            dataArea.ItemSource = new DataTable();
            return dataArea;
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
                dataDfObject.DataField = MiddlePartsFields[i];
                dataDfObject.LabelText = ProviderConstants.LeftPartLabel[i];
                dataDfObject.LabelVisible = true;
                dataDfObject.TextContentWidth = UiConstants.TextBoxWidthDefault;
                dataDfObject.Height = UiConstants.TextboxHeight;
                dataDfObject.TableName = "PROVEE1";
                dataDfObject.LabelTextWidth = UiConstants.LabelTextWidthDefault;
                dataDfObject.IsReadOnly = false;
                dataDfObject.PrimaryKey = "NUM_PROVEE";
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
            dataDfObject.DataField = MiddlePartsFields[fieldPos];
            dataDfObject.LabelText = ProviderConstants.LeftPartLabel[fieldPos];
            dataDfObject.LabelVisible = true;
            dataDfObject.TextContentWidth = UiConstants.TextBoxWidthDefault;
            dataDfObject.Height = UiConstants.TextboxHeight;
            dataDfObject.TableName = "PROVEE1";
            dataDfObject.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            dataDfObject.IsReadOnly = false;
            dataDfObject.PrimaryKey = "NUM_PROVEE";
            dataDfObject.OnChangedField += changedField;
            dataDfObject.AllowedEmpty = true;
            return dataDfObject;

        }
        public IDictionary<string, ObservableCollection<IUiObject>> BuildPageObjects(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery, UiDfObject.ChangedField changedField)
        {
            ObservableCollection<IUiObject> observableCollection = new ObservableCollection<IUiObject>();
            IDictionary<string, ObservableCollection<IUiObject>> dictionary = new Dictionary<string, ObservableCollection<IUiObject>>();
            IDictionary<string, string> currentParam = new Dictionary<string, string>();
            // add a name
            currentParam.Add("DataField", MiddlePartsFields[0]);
            currentParam.Add("Label", Resources.ProviderInfoViewModel_Nombre);
            currentParam.Add("Table", Resources.ProviderModule_Table1);
            currentParam.Add("PrimaryKey", ProviderConstants.PrimaryKey);
            //add a nif
            currentParam.Add("LabelRight", Resources.ProviderInfoViewModel_NIF);
            currentParam.Add("DataFieldRight", MiddlePartsFields[1]);

            IUiObject currentField = BuildDoubleDfObjectProviders(currentParam, changedField);
            observableCollection.Add(currentField);
            // Direcion1 
           
            currentParam["DataField"] = MiddlePartsFields[2];
            currentParam["Label"]= "Direccion";
            currentParam["Table"] = Resources.ProviderModule_Table1;
            currentParam["PrimaryKey"] = ProviderConstants.PrimaryKey;

            currentField = BuildDirection(currentParam, changedField);
            observableCollection.Add(currentField);
            currentParam["DataField"] = MiddlePartsFields[2];
            currentParam["Label"] = Resources.ProviderInfoViewModel_Dirección2;
            currentParam["Table"] = Resources.ProviderModule_Table1;
            currentParam["PrimaryKey"] = ProviderConstants.PrimaryKey;
            currentField = BuildDirection(currentParam, changedField);
            observableCollection.Add(currentField);
            // add a cp poblacion
            currentField = BuildCpPoblacion(assistQuery, changedField);
            observableCollection.Add(currentField);
            // build province
            currentField = BuildProvinceDfSearchTextObject(MiddlePartsFields[6], assistQuery, changedField);
            observableCollection.Add(currentField);
            currentField = BuildPaisSearchTextObject(MiddlePartsFields[7], assistQuery, changedField);
            observableCollection.Add(currentField);
            // add phone.
            currentField = BuildPhone(changedField);
            observableCollection.Add(currentField);
            // add internet.
            currentField = BuildField(12, changedField);
            observableCollection.Add(currentField);
            // add the current field.

            IDictionary<string, string> currentEmailParam = new Dictionary<string, string>();
            currentEmailParam.Add("DataField", Email);
            currentEmailParam.Add("Label", Resources.ProviderInfoViewModel_Email);
            currentEmailParam.Add("Table", Resources.ProviderModule_Table1);
            currentEmailParam.Add("PrimaryKey", ProviderConstants.PrimaryKey);
            currentField = BuildEmail(currentEmailParam,this.EmailCheckHandler, changedField);
            observableCollection.Add(currentField);
            // add persona
            currentField = BuildField(13, changedField);
            observableCollection.Add(currentField);
            currentField = BuildOffice(assistQuery, changedField);
            observableCollection.Add(currentField);
            // add dates
            currentField = BuildDates(changedField);
            observableCollection.Add(currentField);
            // add notes
            currentField = BuildDataArea(changedField, MiddlePartsFields[18], ProviderConstants.LeftPartLabel[18]);
            observableCollection.Add(currentField);
            // add observa
            currentField = BuildDataArea(changedField, MiddlePartsFields[19], ProviderConstants.LeftPartLabel[19]);
            observableCollection.Add(currentField);
            
            dictionary.Add(MasterModuleConstants.UiMiddlePartPage, observableCollection);
            return dictionary;

        }
    }
}