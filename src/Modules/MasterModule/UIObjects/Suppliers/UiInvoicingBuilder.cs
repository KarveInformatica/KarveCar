using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using KarveControls;
using KarveControls.UIObjects;
using MasterModule.Common;
using MasterModule.Properties;

namespace MasterModule.UIObjects.Suppliers
{
    class UiInvoicingBuilder: IUiPageBuilder
    {
        private string[] AccountLeftCheckBoxField =
        {
            "PALBARAN", "INTRACO", "GESTION_IVA_IMPORTA", "NOAUTOMARGEN"
        };
        private string[] TableLeftCheckBox =
        {
            "PROVEE2","PROVEE2","PROVEE1","PROVEE1"
        };
        private string[] AccountRightCheckBoxField =
        {
            "PROALB_COSTE_TRANSP", "EXENCIONES_INT", "AUTOFAC_MANTE"
        };
        private string[] TableRightCheckBox =
        {
            "PROVEE1", "PROVEE1", "PROVEE1"
        };

        public IDictionary<string, ObservableCollection<IUiObject>> BuildPageObjects(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery, UiDfObject.ChangedField changedField)
        {
            IDictionary<string, ObservableCollection<IUiObject>> accountDictionary = new Dictionary<string, ObservableCollection<IUiObject>>();
            accountDictionary[ProviderConstants.UiInvocingAccounts] = LoadAccounts(assistQuery, changedField);
            accountDictionary[ProviderConstants.UiLeasing] = LoadLeasingUiObjects(assistQuery, changedField);
            accountDictionary[ProviderConstants.UiInvocingData] = LoadInvocingData(assistQuery, changedField);
            accountDictionary[ProviderConstants.UiInvoiceOptionPart1] = LoadAccountCheckBoxes(changedField, AccountLeftCheckBoxField,
                ProviderConstants.AccountLeftCheckBoxNames, TableLeftCheckBox);
            accountDictionary[ProviderConstants.UiInvoiceOptionPart2] = LoadAccountCheckBoxes(changedField, AccountRightCheckBoxField,
                ProviderConstants.AccountRightCheckBoxNames, TableRightCheckBox);
            accountDictionary[ProviderConstants.UiIntracoAccount] = LoadIntraco(assistQuery, changedField);
            return accountDictionary;
        }

        // remove hardcoded fields.

        private ObservableCollection<IUiObject> LoadAccountCheckBoxes(UiDfObject.ChangedField changedField, 
            string[] checkBoxesFields, 
            string[] checkBoxesLabel, 
            string[] tableCheckBox)
        {
            ObservableCollection<IUiObject> checkBoxes = new ObservableCollection<IUiObject>();

            for (int i = 0; i < checkBoxesFields.Length; ++i)
            {
                UiDataFieldCheckBox uiDataFieldCheck = new UiDataFieldCheckBox();
                uiDataFieldCheck.DataField = checkBoxesFields[i];
                uiDataFieldCheck.ItemSource = new DataTable();
                uiDataFieldCheck.OnChangedField += changedField;
                uiDataFieldCheck.TableName = tableCheckBox[i];
                uiDataFieldCheck.TextContentWidth = UiConstants.TextBoxWidthDefault;
                uiDataFieldCheck.LabelVisible = true;
                uiDataFieldCheck.Height = UiConstants.TextboxHeight;
                uiDataFieldCheck.PrimaryKey = ProviderConstants.PrimaryKey;
                uiDataFieldCheck.Content = checkBoxesLabel[i];
                uiDataFieldCheck.AllowedEmpty = true;
                uiDataFieldCheck.IsReadOnly = false;
                checkBoxes.Add(uiDataFieldCheck);
            }
            return checkBoxes;
        }
        

        private ObservableCollection<IUiObject> LoadInvocingData(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery,
            UiDfObject.ChangedField changedField)
        {
            ObservableCollection<IUiObject> invoicingObjects = new ObservableCollection<IUiObject>();

            UiDualDfSearchTextObject paymentSearchBox = new UiDualDfSearchTextObject(Resources.UiInvoicingBuilder_LoadInvocingData_FormaDePago, UiConstants.LabelTextWidthDefault);
            paymentSearchBox.DataFieldFirst = "FORPA";
            paymentSearchBox.TableName = "PROVEE2";
            paymentSearchBox.AssistTableName = "FORMAS";
            paymentSearchBox.AssistDataFieldFirst = "CODIGO";
            paymentSearchBox.AssistDataFieldSecond = "NOMBRE";
            paymentSearchBox.TextContentFirstWidth = UiConstants.TextBoxWidthSmall;
            paymentSearchBox.TextContentSecondWidth = UiConstants.TextBoxWidthDefault;
            paymentSearchBox.Height = UiConstants.TextboxHeight;
            paymentSearchBox.SourceView = new DataTable();
            paymentSearchBox.ItemSource = new DataTable();
            paymentSearchBox.PrimaryKey = "NUM_PROVEE";
            paymentSearchBox.OnChangedField += changedField;
            paymentSearchBox.ButtonImage = MasterModule.ImagePath;
            paymentSearchBox.DataField = "FORPA";
            paymentSearchBox.OnAssistQuery += assistQuery;
            invoicingObjects.Add(paymentSearchBox);

            UiMultipleDfObject payementPlaces = new UiMultipleDfObject();
            UiDfObject dataDfObject = new UiDfObject();
            dataDfObject.LabelText = Resources.ProviderInfoViewModel_LoadAccountLeft_PlazoDePago;
            dataDfObject.DataField = "PLAZO";
            dataDfObject.TableName = "PROVEE2";
            dataDfObject.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            dataDfObject.LabelVisible = true;
            dataDfObject.Height = UiConstants.TextboxHeight;
            dataDfObject.TextContentWidth = "50";
            dataDfObject.OnChangedField += changedField;
            dataDfObject.ItemSource = new DataTable();
            dataDfObject.PrimaryKey = "NUM_PROVEE";
            dataDfObject.AllowedEmpty = true;
            payementPlaces.AddDataField(dataDfObject);
            // plazo de pago 2.

            UiDfObject dataDfObject2 = new UiDfObject();
            dataDfObject2.DataField = "PLAZO2";
            dataDfObject2.TableName = "PROVEE2";
            dataDfObject2.LabelVisible = false;
            dataDfObject2.Height = UiConstants.TextboxHeight;
            dataDfObject2.TextContentWidth = "50";
            dataDfObject2.OnChangedField += changedField;
            dataDfObject2.PrimaryKey = "NUM_PROVEE";
            dataDfObject2.AllowedEmpty = true;
            dataDfObject2.ItemSource = new DataTable();
            payementPlaces.AddDataField(dataDfObject2);
            // plazo de pago 3.
            UiDfObject dataDfObject3 = new UiDfObject();
            dataDfObject3.DataField = "PLAZO3";
            dataDfObject3.TableName = "PROVEE2";
            dataDfObject2.LabelVisible = false;
            dataDfObject3.Height = UiConstants.TextboxHeight;
            dataDfObject3.TextContentWidth = "50";
            dataDfObject3.OnChangedField += changedField;
            dataDfObject3.PrimaryKey = "NUM_PROVEE";
            dataDfObject3.AllowedEmpty = true;
            dataDfObject3.ItemSource = new DataTable();

            payementPlaces.AddDataField(dataDfObject3);
            // dias de pago
            UiDfObject payDfObject = new UiDfObject("Dias de pago", UiConstants.LabelTextWidthDefault);
            payDfObject.DataField = "DIA";
            payDfObject.TableName = "PROVEE2";
            payDfObject.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            payDfObject.LabelVisible = true;
            payDfObject.Height = UiConstants.TextboxHeight;
            payDfObject.TextContentWidth = "50";
            payDfObject.IsVisible = true;
            payDfObject.OnChangedField += changedField;
            payDfObject.PrimaryKey = "NUM_PROVEE";
            payDfObject.AllowedEmpty = true;
            payementPlaces.AddDataField(payDfObject);
            UiDfObject payDfObject1 = new UiDfObject();
            payDfObject1.DataField = "DIA2";
            payDfObject1.TableName = "PROVEE2";
            payDfObject1.ItemSource = new DataTable();
            payDfObject.IsVisible = true;
            payDfObject1.LabelVisible = false;
            payDfObject1.Height = UiConstants.TextboxHeight;
            payDfObject1.TextContentWidth = "50";
            payDfObject1.OnChangedField += changedField;
            payDfObject1.PrimaryKey = "NUM_PROVEE";
            payDfObject1.AllowedEmpty = true;
            payementPlaces.AddDataField(payDfObject1);
            UiDfObject payDfObject2 = new UiDfObject();
            payDfObject2.DataField = "DIA3";
            payDfObject2.TableName = "PROVEE2";
            payDfObject2.LabelVisible = false;
            payDfObject.IsVisible = true;
            payDfObject2.Height = UiConstants.TextboxHeight;
            payDfObject2.TextContentWidth = "50";
            payDfObject2.OnChangedField += changedField;
            payDfObject2.PrimaryKey = "NUM_PROVEE";
            payDfObject2.AllowedEmpty = true;
            payementPlaces.AddDataField(payDfObject2);
            invoicingObjects.Add(payementPlaces);



            UiMultipleDfObject saleRowMultipleDfObject = new UiMultipleDfObject();
            saleRowMultipleDfObject.TableName = "PROVEE2";
            UiDfObject saleDfObject = new UiDfObject("Descuento", UiConstants.LabelTextWidthDefault);
            saleDfObject.DataField = "DTO";
            saleDfObject.TableName = "PROVEE2";
            saleDfObject.Height = UiConstants.TextboxHeight;
            saleDfObject.ItemSource = new DataTable();
            saleDfObject.PrimaryKey = "NUM_PROVEE";
            saleDfObject.OnChangedField += changedField;
            saleDfObject.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            saleDfObject.LabelVisible = true;
            saleDfObject.Height = UiConstants.TextboxHeight;
            saleDfObject.TextContentWidth = UiConstants.TextBoxWidthSmall;
            saleRowMultipleDfObject.AddDataField(saleDfObject);

            UiDfObject readyPayment = new UiDfObject("Pronto Pago", UiConstants.LabelTextWidthDefault);
            readyPayment.DataField = "PP";
            readyPayment.TableName = "PROVEE2";
            readyPayment.ItemSource = new DataTable();
            readyPayment.PrimaryKey = "NUM_PROVEE";
            readyPayment.OnChangedField += changedField;
            readyPayment.ItemSource = new DataTable();
            readyPayment.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            readyPayment.LabelVisible = true;
            readyPayment.Height = UiConstants.TextboxHeight;
            readyPayment.TextContentWidth = UiConstants.TextBoxWidthSmall;
            saleRowMultipleDfObject.AddDataField(readyPayment);

            UiDfObject readyPayment1 = new UiDfObject("Tipo Iva", UiConstants.LabelTextWidthDefault);
            readyPayment1.DataField = "TIPOIVA";
            readyPayment1.TableName = "PROVEE1";
            readyPayment1.ItemSource = new DataTable();
            readyPayment1.PrimaryKey = "NUM_PROVEE";
            readyPayment1.OnChangedField += changedField;
            readyPayment1.ItemSource = new DataTable();
            readyPayment1.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            readyPayment1.LabelVisible = true;
            readyPayment1.Height = UiConstants.TextboxHeight;
            readyPayment1.TextContentWidth = UiConstants.TextBoxWidthSmall;
            saleRowMultipleDfObject.AddDataField(readyPayment1);

            invoicingObjects.Add(saleRowMultipleDfObject);
            // mese vacaciones 1

            UiMultipleDfObject vacaciones = new UiMultipleDfObject();


            UiDualDfSearchTextObject vacationMonth1 = new UiDualDfSearchTextObject("Mes vacaciones", UiConstants.LabelTextWidthDefault);
            vacationMonth1.DataFieldFirst = "MESVACA";
            vacationMonth1.TableName = "PROVEE1";
            vacationMonth1.AssistTableName = "MESES";
            vacationMonth1.AssistDataFieldFirst = "NUMERO_MES";
            vacationMonth1.AssistDataFieldSecond = "MES";
            vacationMonth1.Height = UiConstants.TextboxHeight;
            vacationMonth1.SourceView = new DataTable();
            vacationMonth1.ItemSource = new DataTable();
            vacationMonth1.PrimaryKey = "NUM_PROVEE";
            vacationMonth1.OnChangedField += changedField;
            vacationMonth1.ButtonImage = MasterModule.ImagePath;
            vacationMonth1.DataField = "MESVACA";
            vacationMonth1.OnAssistQuery += assistQuery;
            vacationMonth1.TextContentFirstWidth = UiConstants.TextBoxWidthSmall;
            vacationMonth1.TextContentSecondWidth = UiConstants.TextBoxWidthSmall;
            
            vacaciones.AddDataField(vacationMonth1);

            UiDualDfSearchTextObject vacationMonth2 = new UiDualDfSearchTextObject("Segundo Mes", UiConstants.LabelTextWidthDefault);
            vacationMonth2.DataFieldFirst = "MESVACA2";
            vacationMonth2.TableName = "PROVEE1";
            vacationMonth2.AssistTableName = "MESES";
            vacationMonth2.AssistDataFieldFirst = "NUMERO_MES";
            vacationMonth2.AssistDataFieldSecond = "MES";
            vacationMonth2.Height = UiConstants.TextboxHeight;
            vacationMonth2.SourceView = new DataTable();
            vacationMonth2.ItemSource = new DataTable();
            vacationMonth2.PrimaryKey = "NUM_PROVEE";
            vacationMonth2.OnChangedField += changedField;
            vacationMonth2.ButtonImage = MasterModule.ImagePath;
            vacationMonth2.DataField = "MESVACA2";
            vacationMonth2.OnAssistQuery += assistQuery;
            vacaciones.AddDataField(vacationMonth2);
            invoicingObjects.Add(vacaciones);


            UiDfObject cuenta = new UiDfObject("Cuenta Bancaria", UiConstants.LabelTextWidthDefault);
            cuenta.DataAllowed = ControlExt.DataType.BankAccount;
            cuenta.DataField = "CC";
            cuenta.TableName = "PROVEE1";
            cuenta.ItemSource = new DataTable();
            cuenta.LabelVisible = true;
            cuenta.Height = UiConstants.TextboxHeight;
            cuenta.TextContentWidth = UiConstants.TextBoxWidthLarge;
            cuenta.OnChangedField += changedField;
            invoicingObjects.Add(cuenta);

            UiDfObject cuenta1 = new UiDfObject("IBAN", UiConstants.LabelTextWidthDefault);
            cuenta1.DataAllowed = ControlExt.DataType.BankAccount;
            cuenta1.DataField = "IBAN";
            cuenta1.TableName = "PROVEE1";
            cuenta1.DataAllowed = ControlExt.DataType.IbanField;
            cuenta1.ItemSource = new DataTable();
            cuenta1.LabelVisible = true;
            cuenta1.Height = UiConstants.TextboxHeight;
            cuenta1.TextContentWidth = UiConstants.TextBoxWidthLarge;
            cuenta1.OnChangedField += changedField;
            invoicingObjects.Add(cuenta1);

            UiMultipleDfObject uiBancosDfObject = new UiMultipleDfObject();

            UiDualDfSearchTextObject uiDualDfSearch = new UiDualDfSearchTextObject("Banco",UiConstants.LabelTextWidthDefault);
            uiDualDfSearch.ButtonImage = MasterModule.ImagePath;
            uiDualDfSearch.AssistDataFieldFirst = "CODBAN";
            uiDualDfSearch.AssistDataFieldSecond = "NOMBRE";
            uiDualDfSearch.AssistTableName = "BANCO";
            uiDualDfSearch.Height = UiConstants.TextboxHeight;
            uiDualDfSearch.IsVisible = true;
            uiDualDfSearch.TextContentFirstWidth = UiConstants.TextBoxWidthSmall;
            uiDualDfSearch.TextContentSecondWidth = UiConstants.TextBoxWidthDefault;
            uiDualDfSearch.PrimaryKey = "NUM_PROVEE";
            uiDualDfSearch.TableName = "PROVEE1";
            uiDualDfSearch.OnChangedField += changedField;
            uiDualDfSearch.IsReadOnlySecond = true;
            uiDualDfSearch.IsReadOnlyFirst = false;
            uiDualDfSearch.LabelVisible = true;
            uiDualDfSearch.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            uiDualDfSearch.DataFieldFirst = "BANCO";
            uiDualDfSearch.DataField = "BANCO";
            uiDualDfSearch.ItemSource = new DataTable();
            uiDualDfSearch.SourceView = new DataTable();
            uiDualDfSearch.OnAssistQuery += assistQuery;
            uiBancosDfObject.AddDataField(uiDualDfSearch);
            UiDfObject swifDfObject = new UiDfObject("SWIFT", UiConstants.LabelTextWidthDefault);
            swifDfObject.DataAllowed = ControlExt.DataType.Swift;
            swifDfObject.DataField = "SWIFT";
            swifDfObject.TableName = "PROVEE1";
            swifDfObject.ItemSource = new DataTable();
            swifDfObject.LabelVisible = true;
            swifDfObject.Height = UiConstants.TextboxHeight;
            swifDfObject.TextContentWidth = UiConstants.TextBoxWidthSmall;
            swifDfObject.OnChangedField += changedField;
            uiBancosDfObject.AddDataField(swifDfObject);
            invoicingObjects.Add(uiBancosDfObject);
            UiMultipleDfObject uiIdiomaDivisDfObject = new UiMultipleDfObject();

            UiDualDfSearchTextObject uiIdioma = new UiDualDfSearchTextObject("Idioma", UiConstants.LabelTextWidthDefault);
            uiIdioma.ButtonImage = MasterModule.ImagePath;
            uiIdioma.AssistDataFieldFirst = "CODIGO";
            uiIdioma.AssistDataFieldSecond = "NOMBRE";
            uiIdioma.AssistTableName = "IDIOMAS";
            uiIdioma.Height = UiConstants.TextboxHeight;
            uiIdioma.IsVisible = true;
            uiIdioma.PrimaryKey = "NUM_PROVEE";
            uiIdioma.TableName = "PROVEE1";
            uiIdioma.OnChangedField += changedField;
            uiIdioma.IsReadOnlySecond = true;
            uiIdioma.IsReadOnlyFirst = false;
            uiIdioma.LabelVisible = true;
            uiIdioma.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            uiIdioma.DataFieldFirst = "IDIOMA_PR1";
            uiIdioma.DataField = "IDIOMA_PR1";
            uiIdioma.ItemSource = new DataTable();
            uiIdioma.SourceView = new DataTable();
            uiIdioma.OnAssistQuery += assistQuery;
            uiIdioma.TextContentFirstWidth = UiConstants.TextBoxWidthSmall;
            uiIdioma.TextContentSecondWidth = UiConstants.TextBoxWidthDefault;
            uiIdiomaDivisDfObject.AddDataField(uiIdioma);
            UiDualDfSearchTextObject uiDivisa = new UiDualDfSearchTextObject("Divisa", UiConstants.LabelTextWidthDefault);
            uiDivisa.ButtonImage = MasterModule.ImagePath;
            uiDivisa.AssistDataFieldFirst = "CODIGO";
            uiDivisa.AssistDataFieldSecond = "NOMBRE";
            uiDivisa.AssistTableName = "DIVISAS";
            uiDivisa.Height = UiConstants.TextboxHeight;
            uiDivisa.IsVisible = true;
            uiDivisa.PrimaryKey = "NUM_PROVEE";
            uiDivisa.TableName = "PROVEE2";
            uiDivisa.OnChangedField += changedField;
            uiDivisa.IsReadOnlySecond = true;
            uiDivisa.IsReadOnlyFirst = false;
            uiDivisa.LabelVisible = true;
            uiDivisa.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            uiDivisa.DataFieldFirst = "DIVISA";
            uiDivisa.DataField = "DIVISA";
            uiDivisa.ItemSource = new DataTable();
            uiDivisa.SourceView = new DataTable();
            uiDivisa.OnAssistQuery += assistQuery;
            uiIdiomaDivisDfObject.AddDataField(uiDivisa);
            invoicingObjects.Add(uiIdiomaDivisDfObject);
            return invoicingObjects;
        }


        public ObservableCollection<IUiObject> LoadLeasingUiObjects(
            UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery, UiDfObject.ChangedField changedField)
        {
            ObservableCollection<IUiObject> observableCollection = new ObservableCollection<IUiObject>();

            UiDualDfSearchTextObject cuentaCp = new UiDualDfSearchTextObject(Resources.ProviderInfoViewModel_LoadAccountLeft_CuentaCP, UiConstants.LabelTextWidthDefault);
            cuentaCp.DataFieldFirst = "CTACP";
            cuentaCp.TableName = "PROVEE1";
            cuentaCp.AssistTableName = "CU1";
            cuentaCp.AssistDataFieldFirst = "CODIGO";
            cuentaCp.AssistDataFieldSecond = "DESCRIP";
            cuentaCp.Height = UiConstants.TextboxHeight;
            cuentaCp.TextContentFirstWidth = UiConstants.TextBoxWidthSmall;
            cuentaCp.TextContentSecondWidth =UiConstants.TextBoxWidthDefault;
            cuentaCp.SourceView = new DataTable();
            cuentaCp.ItemSource = new DataTable();
            cuentaCp.PrimaryKey = "NUM_PROVEE";
            cuentaCp.OnChangedField += changedField;
            cuentaCp.ButtonImage = MasterModule.ImagePath;
            cuentaCp.DataField = "CTACP";
            cuentaCp.OnAssistQuery += assistQuery;
            //leasingBoxMultipleObject.AddDataField(cuentaCp);
            observableCollection.Add(cuentaCp);
            UiDualDfSearchTextObject cuentaLp = new UiDualDfSearchTextObject(Resources.UiInvoicingBuilder_LoadLeasingUiObjects_CuentaLP, UiConstants.LabelTextWidthDefault);
            cuentaLp.DataFieldFirst = "CTALP";
            cuentaLp.TableName = "PROVEE1";
            cuentaLp.AssistTableName = "CU1";
            cuentaLp.AssistDataFieldFirst = "CODIGO";
            cuentaLp.AssistDataFieldSecond = "DESCRIP";
            cuentaLp.Height = UiConstants.TextboxHeight;
            cuentaLp.TextContentFirstWidth = UiConstants.TextBoxWidthSmall;
            cuentaLp.TextContentSecondWidth = UiConstants.TextBoxWidthLarge;
            cuentaLp.SourceView = new DataTable();
            cuentaLp.ItemSource = new DataTable();
            cuentaLp.PrimaryKey = "NUM_PROVEE";
            cuentaLp.OnChangedField += changedField;
            cuentaLp.ButtonImage = MasterModule.ImagePath;
            cuentaLp.DataField = "CTALP";
            cuentaLp.OnAssistQuery += assistQuery;
            observableCollection.Add(cuentaLp);
            /*
            UiDataFieldCheckBox uiDataFieldCheck = new UiDataFieldCheckBox();
            uiDataFieldCheck.TableName = "PROVEE1";
            uiDataFieldCheck.DataField = "PROVEELEAS";
            uiDataFieldCheck.ItemSource = new DataTable();
            uiDataFieldCheck.OnChangedField += changedField;
            uiDataFieldCheck.TextContentWidth = UiConstants.TextBoxWidthDefault;
            uiDataFieldCheck.LabelVisible = true;
            uiDataFieldCheck.Height = UiConstants.TextboxHeight;
            uiDataFieldCheck.PrimaryKey = "NUM_PROVEE";
            uiDataFieldCheck.Content = "Es proveedor de leasing";
            uiDataFieldCheck.AllowedEmpty = true;
            uiDataFieldCheck.IsReadOnly = false;
            observableCollection.Add(uiDataFieldCheck);
            */
            return observableCollection;
        }

        public ObservableCollection<IUiObject> LoadIntraco(
            UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery, UiDfObject.ChangedField changedField)
        {
            ObservableCollection<IUiObject> observableCollection = new ObservableCollection<IUiObject>();

            UiDualDfSearchTextObject cuentaSoportado = new UiDualDfSearchTextObject(Resources.UiInvoicingBuilder_LoadIntraco_CtaSoportado, UiConstants.LabelTextWidthDefault);
            cuentaSoportado.DataFieldFirst = "CTAINTRACOP";
            cuentaSoportado.TableName = "PROVEE1";
            cuentaSoportado.AssistTableName = "CU1";
            cuentaSoportado.AssistDataFieldFirst = "CODIGO";
            cuentaSoportado.AssistDataFieldSecond = "DESCRIP";
            cuentaSoportado.Height = UiConstants.TextboxHeight;
            cuentaSoportado.TextContentFirstWidth = UiConstants.TextBoxWidthSmall;
            cuentaSoportado.TextContentSecondWidth = UiConstants.TextBoxWidthLarge;
            cuentaSoportado.SourceView = new DataTable();
            cuentaSoportado.ItemSource = new DataTable();
            cuentaSoportado.PrimaryKey = "NUM_PROVEE";
            cuentaSoportado.OnChangedField += changedField;
            cuentaSoportado.ButtonImage = MasterModule.ImagePath;
            cuentaSoportado.DataField = "CTAINTRACOP";
            cuentaSoportado.OnAssistQuery += assistQuery;
            observableCollection.Add(cuentaSoportado);            

            //intacoBoxMultipleObject.AddDataField(cuentaSoportado);
            UiDualDfSearchTextObject cuentaRepercutido = new UiDualDfSearchTextObject("Cta.Repercutido", UiConstants.LabelTextWidthDefault);
            cuentaRepercutido.DataFieldFirst = "CTAINTRACOPREP";
            cuentaRepercutido.TableName = "PROVEE1";
            cuentaRepercutido.AssistTableName = "CU1";
            cuentaRepercutido.AssistDataFieldFirst = "CODIGO";
            cuentaRepercutido.AssistDataFieldSecond = "DESCRIP";
            cuentaRepercutido.Height = UiConstants.TextboxHeight;
            cuentaRepercutido.TextContentFirstWidth = UiConstants.TextBoxWidthSmall;
            cuentaRepercutido.TextContentSecondWidth = UiConstants.TextBoxWidthLarge;
            cuentaRepercutido.SourceView = new DataTable();
            cuentaRepercutido.ItemSource = new DataTable();
            cuentaRepercutido.PrimaryKey = "NUM_PROVEE";
            cuentaRepercutido.OnChangedField += changedField;
            cuentaRepercutido.ButtonImage = MasterModule.ImagePath;
            cuentaRepercutido.DataField = "CTAINTRACOPREP";
            cuentaRepercutido.OnAssistQuery += assistQuery;
            observableCollection.Add(cuentaRepercutido);
            return observableCollection;
        }
        public ObservableCollection<IUiObject> LoadAccounts(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery, UiDfObject.ChangedField changedField)
        {
            ObservableCollection<IUiObject> observableCollection = new ObservableCollection<IUiObject>();

            UiMultipleDfObject accountDfObject1 = new UiMultipleDfObject();
            UiDfObject prefixDfObject = new UiDfObject(Resources.UiInvoicingBuilder_LoadAccounts_Prefijo, UiConstants.LabelTextWidthDefault);
            prefixDfObject.DataField = "PREFIJO";
            prefixDfObject.TableName = "PROVEE2";
            prefixDfObject.LabelVisible = true;
            prefixDfObject.Height = UiConstants.TextboxHeight;
            prefixDfObject.TextContentWidth = UiConstants.TextBoxWidthSmall;
            prefixDfObject.OnChangedField += changedField;
            prefixDfObject.PrimaryKey = "NUM_PROVEE";
            prefixDfObject.AllowedEmpty = true;
            prefixDfObject.ItemSource = new DataTable();
            accountDfObject1.AddDataField(prefixDfObject);
            /*
              UiDfObject balance = new UiDfObject("Saldo", LabelTextWidthDefault);
              balance.DataField = "";
              balance.TableName = "";
              prefixDfObject.LabelVisible = true;
              prefixDfObject.Height = TextboxHeight;
              prefixDfObject.TextContentWidth = TextBoxWidthSmall;
              prefixDfObject.OnChangedField += OnChangedField;
              prefixDfObject.PrimaryKey = "NUM_PROVEE";
              prefixDfObject.AllowedEmpty = true;
              prefixDfObject.ItemSource = new DataTable();
              accountDfObject1.AddDataField(balance);
            */
            UiDualDfSearchTextObject cuentaContable = new UiDualDfSearchTextObject("Cuenta Contable", UiConstants.LabelTextWidthDefault);
            cuentaContable.DataFieldFirst = "CONTABLE";
            cuentaContable.TableName = "PROVEE2";
            cuentaContable.AssistTableName = "CU1";
            cuentaContable.AssistDataFieldFirst = "CODIGO";
            cuentaContable.AssistDataFieldSecond = "DESCRIP";
            cuentaContable.Height = UiConstants.TextboxHeight;
            cuentaContable.TextContentFirstWidth = UiConstants.TextBoxWidthSmall;
            cuentaContable.TextContentSecondWidth = UiConstants.TextBoxWidthLarge;
            cuentaContable.SourceView = new DataTable();
            cuentaContable.ItemSource = new DataTable();
            cuentaContable.PrimaryKey = "NUM_PROVEE";
            cuentaContable.OnChangedField += changedField;
            cuentaContable.ButtonImage = MasterModule.ImagePath;
            cuentaContable.DataField = "CONTABLE";
            cuentaContable.OnAssistQuery += assistQuery;
            accountDfObject1.AddDataField(cuentaContable);
            observableCollection.Add(accountDfObject1);

            UiDualDfSearchTextObject cuentaGasto = new UiDualDfSearchTextObject("Cuenta Gasto",UiConstants.LabelTextWidthDefault);
            cuentaGasto.DataFieldFirst = "CUGASTO";
            cuentaGasto.TableName = "PROVEE2";
            cuentaGasto.AssistTableName = "CU1";
            cuentaGasto.AssistDataFieldFirst = "CODIGO";
            cuentaGasto.AssistDataFieldSecond = "DESCRIP";
            cuentaGasto.Height = UiConstants.TextboxHeight;
            cuentaGasto.TextContentFirstWidth = UiConstants.TextBoxWidthSmall;
            cuentaGasto.TextContentSecondWidth = UiConstants.TextBoxWidthLarge;
            cuentaGasto.SourceView = new DataTable();
            cuentaGasto.ItemSource = new DataTable();
            cuentaGasto.PrimaryKey = "NUM_PROVEE";
            cuentaGasto.OnChangedField += changedField;
            cuentaGasto.ButtonImage = MasterModule.ImagePath;
            cuentaGasto.DataField = "CONTABLE";
            cuentaGasto.OnAssistQuery += assistQuery;
            observableCollection.Add(cuentaGasto);
            // cuenta retencion
            UiDualDfSearchTextObject retentionAccount = new UiDualDfSearchTextObject("Cuenta Retencion", UiConstants.LabelTextWidthDefault);
            retentionAccount.DataFieldFirst = "RETENCION";
            retentionAccount.TableName = "PROVEE2";
            retentionAccount.AssistTableName = "CU1";
            retentionAccount.AssistDataFieldFirst = "CODIGO";
            retentionAccount.AssistDataFieldSecond = "DESCRIP";
            retentionAccount.Height = UiConstants.TextboxHeight;
            retentionAccount.TextContentFirstWidth = UiConstants.TextBoxWidthSmall;
            retentionAccount.TextContentSecondWidth = UiConstants.TextBoxWidthLarge;
            retentionAccount.SourceView = new DataTable();
            retentionAccount.ItemSource = new DataTable();
            retentionAccount.PrimaryKey = "NUM_PROVEE";
            retentionAccount.OnChangedField += changedField;
            retentionAccount.ButtonImage = MasterModule.ImagePath;
            retentionAccount.DataField = "CONTABLE";
            retentionAccount.OnAssistQuery += assistQuery;
            observableCollection.Add(retentionAccount);
            // cuenta pago
            UiDualDfSearchTextObject cuentaPago = new UiDualDfSearchTextObject("Cuenta Pago", UiConstants.LabelTextWidthDefault);
            cuentaPago.DataFieldFirst = "CTAPAGO";
            cuentaPago.TableName = "PROVEE1";
            cuentaPago.AssistTableName = "CU1";
            cuentaPago.AssistDataFieldFirst = "CODIGO";
            cuentaPago.AssistDataFieldSecond = "DESCRIP";
            cuentaPago.Height = UiConstants.TextboxHeight;
            cuentaPago.TextContentFirstWidth = UiConstants.TextBoxWidthSmall;
            cuentaPago.TextContentSecondWidth = UiConstants.TextBoxWidthLarge;
            cuentaPago.SourceView = new DataTable();
            cuentaPago.ItemSource = new DataTable();
            cuentaPago.PrimaryKey = "NUM_PROVEE";
            cuentaPago.OnChangedField += changedField;
            cuentaPago.ButtonImage = MasterModule.ImagePath;
            cuentaPago.DataField = "CTAPAGO";
            cuentaPago.OnAssistQuery += assistQuery;
            observableCollection.Add(cuentaPago);
            return observableCollection;
        }

    }
}
