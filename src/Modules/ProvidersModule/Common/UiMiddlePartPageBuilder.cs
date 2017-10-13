using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using KarveControls.UIObjects;
using ProvidersModule.Properties;
using KarveControls;

namespace ProvidersModule.Common
{
    internal class UiMiddlePartPageBuilder : IUiPageBuilder
    {
        private string[] MiddlePartsFields =
        {
            "NOMBRE", "NIF", "DIRECCION", "DIREC2" ,
            "CP", "POBLACION", "PROV", "NACIOPER",
            "TELEFONO", "FAX", "MOVIL", "EMAIL",
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
            dualSearchTextObject1.ButtonImage = ProviderConstants.ImagePath;
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
            dualSearchTextObject1.TextContentFirstWidth = UiConstants.TextBoxWidthDefault;
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
            dualSearchTextObject1.ButtonImage = UiConstants.ImagePath;
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
            dualSearchTextObject2.ButtonImage = UiConstants.ImagePath;
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
        private IUiObject BuildEmail(UiEmailDataField.EmailCheckHandler requestHandler, UiDfObject.ChangedField changedField)
        {
            UiEmailDataField dataDfObject = new UiEmailDataField();
            DataTable table = new DataTable();
            dataDfObject.ItemSource = table;
            dataDfObject.ButtonImage = ProviderConstants.EmailImagePath;
            dataDfObject.DataField = MiddlePartsFields[11];
            dataDfObject.LabelText = ProviderConstants.LeftPartLabel[11];
            dataDfObject.DataAllowed = CommonControl.DataType.Email;
            dataDfObject.LabelVisible = true;
            dataDfObject.TextContentWidth = UiConstants.TextBoxWidthDefault;
            dataDfObject.Height = UiConstants.TextboxHeight;
            dataDfObject.TableName = Resources.ProviderModule_Table1;
            dataDfObject.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            dataDfObject.IsReadOnly = false;
            dataDfObject.PrimaryKey = ProviderConstants.PrimaryKey;
            dataDfObject.OnChangedField += changedField;
            dataDfObject.AllowedEmpty = true;
            dataDfObject.EmailEventHandler += requestHandler;
            return dataDfObject;
        }
        private IUiObject BuildDirection(IList<string> fieldList, UiDfObject.ChangedField changedField)
        {
            UiDfObject dataDfObject = new UiDfObject();
            dataDfObject.DataField = fieldList[0];
            dataDfObject.LabelText = fieldList[1];
            dataDfObject.LabelVisible = true;
            dataDfObject.TextContentWidth = UiConstants.TextBoxWidthLarge;
            dataDfObject.Height =  UiConstants.TextboxHeight;
            dataDfObject.TableName = Properties.Resources.ProviderModule_Table1;
            dataDfObject.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            dataDfObject.IsReadOnly = false;
            dataDfObject.ItemSource = new DataTable();
            dataDfObject.IsVisible = true;
            dataDfObject.PrimaryKey = ProviderConstants.PrimaryKey;
            dataDfObject.OnChangedField += changedField;
            dataDfObject.AllowedEmpty = true;
            return dataDfObject;
        }
        private IUiObject BuildDoubleDfObjectProviders(IList<string> fieldList, UiDfObject.ChangedField changedField)
        {
            if (fieldList.Count < 4)
            {
                return null;
            }
            UiDoubleDfObject doubleDfObject = new UiDoubleDfObject();
            doubleDfObject.DataField = fieldList[0];
            doubleDfObject.LabelText = fieldList[1];
            doubleDfObject.LabelVisible = true;
            doubleDfObject.TextContentWidth = UiConstants.TextBoxWidthLarge;
            doubleDfObject.Height = UiConstants.TextboxHeight;
            doubleDfObject.TableName = Resources.ProviderModule_Table1;
            doubleDfObject.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            doubleDfObject.IsReadOnly = false;
            doubleDfObject.IsReadOnlyRight = false;
            doubleDfObject.PrimaryKey = ProviderConstants.PrimaryKey;
            doubleDfObject.OnChangedField += changedField;
            doubleDfObject.AllowedEmpty = true;
            doubleDfObject.DataFieldRight = fieldList[2];
            doubleDfObject.LabelTextRight = fieldList[3];
            doubleDfObject.LabelTextWidthRight = UiConstants.LabelTextWidthDefault;
            doubleDfObject.LabelVisibleRight = true;
            doubleDfObject.TextContentWidthRight = UiConstants.LabelTextWidthDefault;
            doubleDfObject.HeightRight = UiConstants.TextboxHeight;
            return doubleDfObject;
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
            paisSearchTextObject.ButtonImage = ProviderConstants.ImagePath;
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
            // Nombre y Nif.
            IUiObject currentField = null;
            IList<string> fields = new List<string>();
            fields.Add(MiddlePartsFields[0]);
            fields.Add(ProviderConstants.LeftPartLabel[0]);
            fields.Add(MiddlePartsFields[1]);
            fields.Add(ProviderConstants.LeftPartLabel[1]);
            currentField = BuildDoubleDfObjectProviders(fields, changedField);
            observableCollection.Add(currentField);
            // Direcion1 
            IList<string> directionFields = new List<string>();
            directionFields.Add(MiddlePartsFields[2]);
            directionFields.Add(ProviderConstants.LeftPartLabel[2]);
            currentField = BuildDirection(directionFields, changedField);
            observableCollection.Add(currentField);
            directionFields.Clear();
            // Direction2.
            directionFields.Add(MiddlePartsFields[3]);
            directionFields.Add(ProviderConstants.LeftPartLabel[3]);
            currentField = BuildDirection(directionFields, changedField);
            observableCollection.Add(currentField);
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
            currentField = BuildEmail(this.EmailCheckHandler, changedField);
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
            
            dictionary.Add(ProviderConstants.UiMiddlePartPage, observableCollection);
            return dictionary;

        }
    }
}