using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveControls.UIObjects;

namespace ProvidersModule.Common
{
    /// <summary>
    ///  This is the builder needed for the collection page.
    /// </summary>
    public class UiDirectionPageBuilder: IUiPageBuilder
    {
        private const string FirstDirectionDf = "FirstDirectionDf";
        private const string FirstTableDirectionDf = "FirstDirectionTable";
        private const string SecondDirectionDf = "SecondDirecitonDf";
        private const string SecondTableDirectionDf = "SecondDirectionTable";
        private const string CpDataField = "CPDataField";
        private const string CpTableName = "CpTableName";
        private const string CpAssistDataFieldFirst = "CP";
        private const string CpAssistDataFieldSecond = "POBLACION";
        private const string ProvDataField = "ProvDataField";
        private const string ProvTableName = "ProvTableName"; 
        private const string ProvAssistDataFieldFirst = "ProvAssistDataFieldFirst";
        private const string ProvAssistDataFieldSecond = "ProvAssistDataFieldSecond";
        private const string ProvAssitTableName = "ProvinciaAssistTableName";
        private const string PaisDataField = "PaisDataField";
        private const string PaisTableName = "PaisTableName";
        private const string TelefonoDataField = "TelefonoDataField";
        private const string TelefonoTableName = "TelefonoTableName";
        private const string FaxDataField = "FaxDataField";
        private const string FaxTableName = "FaxTableName";
        private const string PersonaDataField = "PersonaDataField";
        private const string PersonaTableName = "PersonaTableName";
        private const string EmailDataField = "EmailDataField";
        private const string EmailTableName = "EmailTableName";
        private const string PobDataField = "PoblacionDataField";
        private const string PobTableName = "PoblacionTableName";
        private UiEmailDataField.EmailCheckHandler _emailCheckHandler;


        public UiDirectionPageBuilder(UiEmailDataField.EmailCheckHandler emailLookupRequestHandler)
        {
           _emailCheckHandler = emailLookupRequestHandler;
        }

        public UiEmailDataField.EmailCheckHandler EmailCheckHandler
        {
            get { return _emailCheckHandler; }
            set { _emailCheckHandler = value; }
        }

        /// <summary>
        ///  This method build a part of the page.
        /// </summary>
        /// <param name="assistQuery">Assinst query handler used for the lookup.</param>
        /// <param name="changedField">Field to be changed.</param>
        /// <returns></returns>
        public IDictionary<string, ObservableCollection<IUiObject>>  BuildPageObjects(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery,
            UiDfObject.ChangedField changedField)
        {
            IDictionary<string, string> dataTableInfoPayment = new Dictionary<string,string>();
            dataTableInfoPayment[FirstDirectionDf] = "DIR_PAGO";
            dataTableInfoPayment[FirstTableDirectionDf] = "PROVEE1";
            dataTableInfoPayment[SecondDirectionDf] = "DIR2_PAGO";
            dataTableInfoPayment[SecondTableDirectionDf] = "PROVEE1";
            dataTableInfoPayment[CpDataField] = "CP_PAGO";
            dataTableInfoPayment[CpTableName] = "PROVEE1";
            dataTableInfoPayment[ProvDataField] = "PROV_PAGO";
            dataTableInfoPayment[ProvTableName] = "PROVEE1";
            dataTableInfoPayment[ProvAssitTableName] = "PROVINCIA";
            dataTableInfoPayment[ProvAssistDataFieldFirst] = "SIGLAS";
            dataTableInfoPayment[ProvAssistDataFieldSecond] = "PROV";

            dataTableInfoPayment[PobDataField] = "POB_PAGO";
            dataTableInfoPayment[PobTableName] = "PROVEE1";

            dataTableInfoPayment[PaisDataField] = "PAIS_PAGO";
            dataTableInfoPayment[PaisTableName] = "PROVEE1";
            dataTableInfoPayment[TelefonoDataField] = "TELF_PAGO";
            dataTableInfoPayment[TelefonoTableName] = "PROVEE1";
            dataTableInfoPayment[FaxDataField] = "FAX_PAGO";
            dataTableInfoPayment[FaxTableName] = "PROVEE1";
            dataTableInfoPayment[PersonaDataField] = "PERSONA_PAGO";
            dataTableInfoPayment[PersonaTableName] = "PROVEE1";
            dataTableInfoPayment[EmailDataField] = "MAIL_PAGO";
            dataTableInfoPayment[EmailTableName] = "PROVEE1";


            ObservableCollection<IUiObject> paymentCollection = LoadDirections(ref assistQuery, ref changedField, dataTableInfoPayment);
            IDictionary<string, string> dataTableInfoReclaim = new Dictionary<string, string>();
            dataTableInfoReclaim[ProvAssitTableName] = "PROVINCIA";
            dataTableInfoReclaim[ProvAssistDataFieldFirst] = "SIGLAS";
            dataTableInfoReclaim[ProvAssistDataFieldSecond] = "PROV";

            dataTableInfoReclaim[FirstDirectionDf] = "DIR_RECLAMA";
            dataTableInfoReclaim[FirstTableDirectionDf] = "PROVEE1";
            dataTableInfoReclaim[SecondDirectionDf] = "DIR2_RECLAMA";
            dataTableInfoReclaim[SecondTableDirectionDf] = "PROVEE1";
            dataTableInfoReclaim[CpDataField] = "CP_RECLAMA";
            dataTableInfoReclaim[CpTableName] = "PROVEE1";
            dataTableInfoReclaim[ProvDataField] = "PROV_RECLAMA";
            dataTableInfoReclaim[ProvTableName] = "PROVEE1";
            dataTableInfoReclaim[ProvAssitTableName] = "PROVINCIA";
            dataTableInfoReclaim[PobDataField] = "POB_RECLAMA";
            dataTableInfoReclaim[PobTableName] = "PROVEE1";
            dataTableInfoReclaim[PaisDataField] = "PAIS_RECLAMA";
            dataTableInfoReclaim[PaisTableName] = "PROVEE1";
            dataTableInfoReclaim[TelefonoDataField] = "TELF_RECLAMA";
            dataTableInfoReclaim[TelefonoTableName] = "PROVEE1";
            dataTableInfoReclaim[FaxDataField] = "FAX_RECLAMA";
            dataTableInfoReclaim[FaxTableName] = "PROVEE1";
            dataTableInfoReclaim[PersonaDataField] = "PERSONA_RECLAMA";
            dataTableInfoReclaim[PersonaTableName] = "PROVEE1";
            dataTableInfoReclaim[EmailDataField] = "MAIL_RECLAMA";
            dataTableInfoReclaim[EmailTableName] = "PROVEE1";
            ObservableCollection<IUiObject> reclamacionesCollection = LoadDirections(ref assistQuery, ref changedField, dataTableInfoReclaim);

            IDictionary<string, string> dataTableInfoDevolve = new Dictionary<string, string>();
            dataTableInfoDevolve[FirstDirectionDf] = "DIR_DEVO";
            dataTableInfoDevolve[FirstTableDirectionDf] = "PROVEE1";
            dataTableInfoDevolve[ProvAssistDataFieldFirst] = "SIGLAS";
            dataTableInfoDevolve[ProvAssistDataFieldSecond] = "PROV";
            dataTableInfoDevolve[SecondDirectionDf] = "DIR2_DEVO";
            dataTableInfoDevolve[SecondTableDirectionDf] = "PROVEE1";
            dataTableInfoDevolve[CpDataField] = "CP_DEVO";
            dataTableInfoDevolve[CpTableName] = "PROVEE1";
            dataTableInfoDevolve[ProvDataField] = "PROV_DEVO";
            dataTableInfoDevolve[ProvTableName] = "PROVEE1";
            dataTableInfoDevolve[ProvAssitTableName] = "PROVINCIA";
            dataTableInfoDevolve[PobTableName] = "PROVEE1";
            dataTableInfoDevolve[PobDataField] = "POB_DEVO";
            dataTableInfoDevolve[PaisDataField] = "PAIS_DEVO";
            dataTableInfoDevolve[PaisTableName] = "PROVEE1";
            dataTableInfoDevolve[TelefonoDataField] = "TELF_DEVO";
            dataTableInfoDevolve[TelefonoTableName] = "PROVEE1";
            dataTableInfoDevolve[FaxDataField] = "FAX_DEVO";
            dataTableInfoDevolve[FaxTableName] = "PROVEE1";
            dataTableInfoDevolve[PersonaDataField] = "PERSONA_DEVO";
            dataTableInfoDevolve[PersonaTableName] = "PROVEE1";
            dataTableInfoDevolve[EmailDataField] = "MAIL_DEVO";
            dataTableInfoDevolve[EmailTableName] = "PROVEE1";


            ObservableCollection<IUiObject> devolucionCollection = LoadDirections(ref assistQuery, ref changedField, dataTableInfoDevolve);
            ObservableCollection<IUiObject> orderCommunicationWay = OrderCommunicationWay(assistQuery, changedField);
            IDictionary<string, ObservableCollection<IUiObject>> dictionaryMap = new Dictionary<string, ObservableCollection<IUiObject>>();
            dictionaryMap.Add(ProviderConstants.UiPaymentDirectionsCollection, paymentCollection);
            dictionaryMap.Add(ProviderConstants.UiReclaimDirectionsCollection, reclamacionesCollection);
            dictionaryMap.Add(ProviderConstants.UiDevolutionDirectionsCollection, devolucionCollection);
            dictionaryMap.Add(ProviderConstants.UiOrderDirectionsCollection, orderCommunicationWay);
   
            return dictionaryMap;
        }


        private ObservableCollection<IUiObject> OrderCommunicationWay(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery,
            UiDfObject.ChangedField changedField)
        {
            ObservableCollection<IUiObject> collection = new ObservableCollection<IUiObject>();
            UiDualDfSearchTextObject viaDfSearch = new UiDualDfSearchTextObject(ProvidersModule.Properties.Resources.UiDirectionPageBuilder_OrderCommunicationWay_Via,UiConstants.LabelTextWidthDefault);
            viaDfSearch.DataFieldFirst = "VIA";
            viaDfSearch.TableName = "PROVEE1";
            viaDfSearch.AssistDataFieldFirst = "NOMBRE";
            viaDfSearch.AssistDataFieldSecond = "CODIGO";
            viaDfSearch.AssistTableName = "VIASPEDIPRO";
            viaDfSearch.ButtonImage = UiConstants.ImagePath;
            viaDfSearch.Height = UiConstants.TextboxHeight;
            viaDfSearch.TextContentFirstWidth = UiConstants.TextBoxWidthSmall;
            viaDfSearch.TextContentSecondWidth = UiConstants.TextBoxWidthLarge;
            viaDfSearch.SourceView = new DataTable();
            viaDfSearch.ItemSource = new DataTable();
            viaDfSearch.PrimaryKey = "NUM_PROVEE";
            viaDfSearch.OnChangedField += changedField;
            viaDfSearch.OnAssistQuery += assistQuery;
            // UiDfObject direccionDePago = new UiDfObject(title, UiConstants.LabelTextWidthDefault);
            collection.Add(viaDfSearch);
            UiEmailDataField emailDfSearch = new UiEmailDataField();
            emailDfSearch.LabelText = "Email";
            emailDfSearch.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            emailDfSearch.TextContentWidth = UiConstants.TextBoxWidthDefault;
            emailDfSearch.DataField = "EMAIL";
            emailDfSearch.ButtonImage = UiConstants.EmailImagePath;
            emailDfSearch.TableName = "PROVEE1";
            emailDfSearch.Height = UiConstants.TextboxHeight;
            emailDfSearch.ItemSource = new DataTable();
            emailDfSearch.PrimaryKey = "NUM_PROVEE";
            emailDfSearch.OnChangedField += changedField;
            emailDfSearch.EmailEventHandler += _emailCheckHandler;
            collection.Add(emailDfSearch);

            UiDualDfSearchTextObject fechaEntregaDfSearch = new UiDualDfSearchTextObject("F.Entrega", UiConstants.LabelTextWidthDefault);
            fechaEntregaDfSearch.DataFieldFirst = "FORMA_ENVIO";
            fechaEntregaDfSearch.ButtonImage = UiConstants.ImagePath;
            fechaEntregaDfSearch.TableName = "PROVEE1";
            fechaEntregaDfSearch.AssistDataFieldFirst = "NOMBRE";
            fechaEntregaDfSearch.AssistDataFieldSecond = "CODIGO";
            fechaEntregaDfSearch.AssistTableName = "FORMAS_PEDENT";
            fechaEntregaDfSearch.Height = UiConstants.TextboxHeight;
        
            fechaEntregaDfSearch.TextContentFirstWidth = UiConstants.TextBoxWidthSmall;
            fechaEntregaDfSearch.TextContentSecondWidth = UiConstants.TextBoxWidthLarge;
            fechaEntregaDfSearch.SourceView = new DataTable();
            fechaEntregaDfSearch.ItemSource = new DataTable();
            fechaEntregaDfSearch.PrimaryKey = "NUM_PROVEE";
            fechaEntregaDfSearch.OnChangedField += changedField;
            fechaEntregaDfSearch.OnAssistQuery += assistQuery;
            // UiDfObject direccionDePago = new UiDfObject(title, UiConstants.LabelTextWidthDefault);
            collection.Add(fechaEntregaDfSearch);

            UiDualDfSearchTextObject sellConditionDfSearch = new UiDualDfSearchTextObject("Condición Venta", UiConstants.LabelTextWidthDefault);
            sellConditionDfSearch.DataFieldFirst = "CONDICION_VENTA";
            sellConditionDfSearch.ButtonImage = UiConstants.ImagePath;
            sellConditionDfSearch.TableName = "PROVEE1";
            sellConditionDfSearch.AssistDataFieldFirst = "NOMBRE";
            sellConditionDfSearch.AssistDataFieldSecond = "CODIGO";
            sellConditionDfSearch.AssistTableName = "TL_CONDICION_PRECIO";
            sellConditionDfSearch.Height = UiConstants.TextboxHeight;
            sellConditionDfSearch.TextContentFirstWidth = UiConstants.TextBoxWidthSmall;
            sellConditionDfSearch.TextContentSecondWidth = UiConstants.TextBoxWidthLarge;
            sellConditionDfSearch.SourceView = new DataTable();
            sellConditionDfSearch.ItemSource = new DataTable();
            sellConditionDfSearch.PrimaryKey = "NUM_PROVEE";
            sellConditionDfSearch.OnChangedField += changedField;
            sellConditionDfSearch.OnAssistQuery += assistQuery;
            // UiDfObject direccionDePago = new UiDfObject(title, UiConstants.LabelTextWidthDefault);
            collection.Add(sellConditionDfSearch);
            UiDataArea deliveringArea = new UiDataArea();
            deliveringArea.LabelVisible = true;
            deliveringArea.LabelTextWidth = UiConstants.LabelTextWidthWide;
            deliveringArea.PrimaryKey = ProviderConstants.PrimaryKey;
            deliveringArea.ItemSource = new DataTable();
            deliveringArea.LabelText = "Lugares de Entrega";
            deliveringArea.DataField = "DIRENVIO6";
            deliveringArea.TableName = "PROVEE1";
            deliveringArea.Height = UiConstants.TextboxHeight;
            deliveringArea.TextContentWidth = UiConstants.TextBoxWidthDefault;
            collection.Add(deliveringArea);
            return collection;
        }

        private ObservableCollection<IUiObject> LoadDirections(ref UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery,
            ref UiDfObject.ChangedField changedField, IDictionary<string,string> dataDictionary)
        {
            ObservableCollection<IUiObject> collection = new ObservableCollection<IUiObject>();
            UiDfObject direccionDePago = new UiDfObject("Dirección", UiConstants.LabelTextWidthDefault);
            direccionDePago.DataField = dataDictionary[FirstDirectionDf];
            direccionDePago.TableName = dataDictionary[FirstTableDirectionDf]; ;
            direccionDePago.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            direccionDePago.LabelVisible = true;
            direccionDePago.Height = UiConstants.TextboxHeight;
            direccionDePago.TextContentWidth = UiConstants.TextBoxWidthWide;
            direccionDePago.OnChangedField += changedField;
            direccionDePago.ItemSource = new DataTable();
            direccionDePago.PrimaryKey = "NUM_PROVEE";
            direccionDePago.AllowedEmpty = true;
            collection.Add(direccionDePago);
            UiDfObject direccionDePago1 = new UiDfObject("Segunda Dirección", UiConstants.LabelTextWidthDefault);
            direccionDePago1.DataField = dataDictionary[SecondDirectionDf];
            direccionDePago1.TableName = dataDictionary[SecondTableDirectionDf];
            direccionDePago1.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            direccionDePago1.LabelVisible = true;
            direccionDePago1.Height = UiConstants.TextboxHeight;
            direccionDePago1.TextContentWidth = UiConstants.TextBoxWidthDefault;
            direccionDePago1.OnChangedField += changedField;
            direccionDePago1.ItemSource = new DataTable();
            direccionDePago1.PrimaryKey = "NUM_PROVEE";
            direccionDePago1.AllowedEmpty = true;
            collection.Add(direccionDePago1);
            UiDualDfSearchTextObject dualDfSearch = new UiDualDfSearchTextObject("CP", UiConstants.LabelTextWidthDefault);
            dualDfSearch.DataFieldFirst = dataDictionary[CpDataField];
            dualDfSearch.DataField = dataDictionary[CpDataField];
                
            dualDfSearch.ButtonImage = UiConstants.ImagePath;
            dualDfSearch.TableName = dataDictionary[CpTableName];
            dualDfSearch.AssistDataFieldFirst = CpAssistDataFieldFirst;
            dualDfSearch.AssistDataFieldSecond = CpAssistDataFieldSecond;
            dualDfSearch.AssistTableName = "PROVEE1";
            dualDfSearch.Height = UiConstants.TextboxHeight;
            dualDfSearch.IsReadOnlySecond = true;
            dualDfSearch.TextContentFirstWidth = UiConstants.TextBoxWidthSmall;
            dualDfSearch.TextContentSecondWidth = UiConstants.TextBoxWidthLarge;
            dualDfSearch.SourceView = new DataTable();
            dualDfSearch.ItemSource = new DataTable();
            dualDfSearch.PrimaryKey = "NUM_PROVEE";
            dualDfSearch.OnChangedField += changedField;
            dualDfSearch.OnAssistQuery += assistQuery;
            collection.Add(dualDfSearch);
            UiDualDfSearchTextObject provDfSearchTextObject = new UiDualDfSearchTextObject("Provincia", UiConstants.LabelTextWidthDefault);
            provDfSearchTextObject.DataFieldFirst = dataDictionary[ProvDataField];
            provDfSearchTextObject.ButtonImage = UiConstants.ImagePath;
            provDfSearchTextObject.TableName = dataDictionary[ProvTableName];
            provDfSearchTextObject.TextContentFirstWidth = UiConstants.TextBoxWidthSmall;
            provDfSearchTextObject.TextContentSecondWidth = UiConstants.TextBoxWidthLarge;
            provDfSearchTextObject.AssistDataFieldFirst =  dataDictionary[ProvAssistDataFieldFirst];
            provDfSearchTextObject.AssistDataFieldSecond =  dataDictionary[ProvAssistDataFieldSecond];
            provDfSearchTextObject.IsReadOnlySecond = true;
            provDfSearchTextObject.AssistTableName = "PROVINCIA";
            provDfSearchTextObject.SourceView = new DataTable();
            provDfSearchTextObject.ItemSource = new DataTable();
            provDfSearchTextObject.PrimaryKey = "NUM_PROVEE";
            provDfSearchTextObject.OnChangedField += changedField;
            provDfSearchTextObject.OnAssistQuery += assistQuery;
            collection.Add(provDfSearchTextObject);
            UiDualDfSearchTextObject paisDfSearchTextObject = new UiDualDfSearchTextObject("Pais", UiConstants.LabelTextWidthDefault);
            paisDfSearchTextObject.DataFieldFirst = dataDictionary[PaisDataField];
            paisDfSearchTextObject.ButtonImage = UiConstants.ImagePath;
            paisDfSearchTextObject.TableName = dataDictionary[PaisTableName];
            paisDfSearchTextObject.AssistDataFieldFirst = "SIGLAS";
            paisDfSearchTextObject.AssistDataFieldSecond = "PAIS";
            paisDfSearchTextObject.TextContentFirstWidth = UiConstants.TextBoxWidthSmall;
            paisDfSearchTextObject.TextContentSecondWidth = UiConstants.TextBoxWidthLarge;
            paisDfSearchTextObject.IsReadOnlySecond = true;
            paisDfSearchTextObject.AssistTableName = "PAIS";
            paisDfSearchTextObject.SourceView = new DataTable();
            paisDfSearchTextObject.ItemSource = new DataTable();
            paisDfSearchTextObject.PrimaryKey = "NUM_PROVEE";
            paisDfSearchTextObject.OnChangedField += changedField;
            paisDfSearchTextObject.OnAssistQuery += assistQuery;
            collection.Add(paisDfSearchTextObject);

            UiMultipleDfObject multipleDfObject = new UiMultipleDfObject();
            // Data Field object 1
            UiDfObject dfObject1 = new UiDfObject("Telefonos", UiConstants.LabelTextWidthDefault);
            dfObject1.DataField = dataDictionary[TelefonoDataField];
            dfObject1.TableName = dataDictionary[TelefonoTableName];
            dfObject1.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            dfObject1.LabelVisible = true;
            dfObject1.Height = UiConstants.TextboxHeight;
            dfObject1.TextContentWidth = UiConstants.TextBoxWidthDefault;
            dfObject1.OnChangedField += changedField;
            dfObject1.ItemSource = new DataTable();
            dfObject1.PrimaryKey = "NUM_PROVEE";
            dfObject1.AllowedEmpty = true;
            // Data field object 2
            UiDfObject dfObject2 = new UiDfObject("Fax", UiConstants.LabelTextWidthDefault);
            dfObject2.DataField = dataDictionary[FaxDataField];
            dfObject2.TableName = dataDictionary[FaxTableName];
            dfObject2.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            dfObject2.LabelVisible = true;
            dfObject2.Height = UiConstants.TextboxHeight;
            dfObject2.TextContentWidth = UiConstants.TextBoxWidthDefault;
            dfObject2.OnChangedField += changedField;
            dfObject2.ItemSource = new DataTable();
            dfObject2.PrimaryKey = "NUM_PROVEE";
            dfObject2.AllowedEmpty = true;
            multipleDfObject.AddDataField(dfObject1);
            multipleDfObject.AddDataField(dfObject2);
            collection.Add(multipleDfObject);
            // data field persona.
            UiDfObject dfPersona = new UiDfObject("Persona", UiConstants.LabelTextWidthDefault);
            dfPersona.DataField = dataDictionary[PersonaDataField];
            dfPersona.TableName = dataDictionary[PersonaTableName];
            dfPersona.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            dfPersona.LabelVisible = true;
            dfPersona.Height = UiConstants.TextboxHeight;
            dfPersona.TextContentWidth = UiConstants.TextBoxWidthDefault;
            dfPersona.OnChangedField += changedField;
            dfPersona.ItemSource = new DataTable();
            dfPersona.PrimaryKey = "NUM_PROVEE";
            dfPersona.AllowedEmpty = true;
            collection.Add(dfPersona);
            UiEmailDataField dfEmail = new UiEmailDataField();
            dfEmail.LabelText = "Email";
            dfEmail.ButtonImage = UiConstants.EmailImagePath;
            dfEmail.DataField = dataDictionary[EmailDataField];
            dfEmail.TableName = dataDictionary[EmailTableName];
            dfEmail.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            dfEmail.LabelVisible = true;
            dfEmail.Height = UiConstants.TextboxHeight;
            dfEmail.TextContentWidth = UiConstants.TextBoxWidthDefault;
            dfEmail.OnChangedField += changedField;
            dfEmail.ItemSource = new DataTable();
            dfEmail.PrimaryKey = "NUM_PROVEE";
            dfEmail.AllowedEmpty = true;
            collection.Add(dfEmail);
            return collection;
        }
    }
}
