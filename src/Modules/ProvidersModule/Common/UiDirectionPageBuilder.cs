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

        public const string PaymentDirectionsCollection = "PaymentDirectionsCollection";
        public const string ReclaimDirectionsCollection = "ReclaimDirectionsCollection";
        public const string OrderDirectionsCollection = "OrderCommunicationCollection";
        public const string DevolutionDirectionsCollection = "DevolutionDirectionCollection";
        private const string FirstDirectionDf = "FirstDirectionDf";
        private const string FirstTableDirectionDf = "FirstDirectionTable";
        private const string SecondDirectionDf = "SecondDirecitonDf";
        private const string SecondTableDirectionDf = "SecondDirectionTable";
        private const string CpDataField = "CPDataField";
        private const string CpDataTable = "CPDataTable";
        private const string CpAssistNameFirst = "CPAssistFirst";
        private const string CpAssistNameSecond = "CPAsssitSecond";
        private const string CityDataField = "CityDataField";
        private const string CityDataTable = "CityDataTable";
        private const string CpTableName = "CpTableName";
        private const string CpAssistDataFieldFirst = "CP";
        private const string CpAssistDataFieldSecond = "POBLACION";

        public UiDirectionPageBuilder()
        {
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
            ObservableCollection<IUiObject> paymentCollection = LoadDirections(assistQuery, changedField, dataTableInfoPayment);
            /*
            ObservableCollection<IUiObject> reclamacionesCollection = LoadDirections("Dirección de Reclamaciones", assistQuery, changedField);
            ObservableCollection<IUiObject> devolucionCollection = LoadDirections("Dirección de Devolución", assistQuery, changedField);
            */
            IDictionary<string, ObservableCollection<IUiObject>> dictionaryMap = new Dictionary<string, ObservableCollection<IUiObject>>();
            dictionaryMap.Add(PaymentDirectionsCollection, paymentCollection);
            //dictionaryMap.Add(ReclaimDirectionsCollection, reclamacionesCollection);
            //dictionaryMap.Add(DevolutionDirectionsCollection, devolucionCollection, dataTableInfoDevolution);
            return dictionaryMap;
        }

        private ObservableCollection<IUiObject> OrderCommunicationWay(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery,
            UiDfObject.ChangedField changedField)
        {
            ObservableCollection<IUiObject> collection = new ObservableCollection<IUiObject>();
            UiDualDfSearchTextObject viaDfSearch = new UiDualDfSearchTextObject("Via",UiConstants.LabelTextSmallDefault);
            viaDfSearch.DataFieldFirst = "VIA";
            viaDfSearch.ButtonImage = UiConstants.LabelTextSmallDefault;
            viaDfSearch.TableName = "PROVEE1";
            viaDfSearch.AssistDataFieldFirst = "NOMBRE";
            viaDfSearch.AssistDataFieldSecond = "CODIGO";
            viaDfSearch.AssistTableName = "VIAPROV";
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
            emailDfSearch.DataField = "EMAIL";
            emailDfSearch.ButtonImage = UiConstants.LabelTextSmallDefault;
            emailDfSearch.TableName = "PROVEE1";
            emailDfSearch.Height = UiConstants.TextboxHeight;
            emailDfSearch.ItemSource = new DataTable();
            emailDfSearch.PrimaryKey = "NUM_PROVEE";
            emailDfSearch.OnChangedField += changedField;
            collection.Add(emailDfSearch);
            return collection;
        }

        private ObservableCollection<IUiObject> LoadDirections(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery,
            UiDfObject.ChangedField changedField, IDictionary<string,string> dataDictionary)
        {
            ObservableCollection<IUiObject> collection = new ObservableCollection<IUiObject>();
            UiDfObject direccionDePago = new UiDfObject("Dirección", UiConstants.LabelTextWidthDefault);
            direccionDePago.DataField = dataDictionary[FirstDirectionDf];
            direccionDePago.TableName = dataDictionary[FirstTableDirectionDf]; ;
            direccionDePago.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            direccionDePago.LabelVisible = true;
            direccionDePago.Height = UiConstants.TextboxHeight;
            direccionDePago.TextContentWidth = "50";
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
            direccionDePago1.TextContentWidth = "50";
            direccionDePago1.OnChangedField += changedField;
            direccionDePago1.ItemSource = new DataTable();
            direccionDePago1.PrimaryKey = "NUM_PROVEE";
            direccionDePago1.AllowedEmpty = true;
            collection.Add(direccionDePago);
            UiDualDfSearchTextObject dualDfSearch = new UiDualDfSearchTextObject("CP", UiConstants.LabelTextSmallDefault);
            dualDfSearch.DataFieldFirst = dataDictionary[CpDataField];
            dualDfSearch.ButtonImage = UiConstants.LabelTextSmallDefault;
            dualDfSearch.TableName = dataDictionary[CpTableName];
            dualDfSearch.AssistDataFieldFirst = CpAssistDataFieldFirst;
            dualDfSearch.AssistDataFieldSecond = CpAssistDataFieldSecond;
            dualDfSearch.AssistTableName = "PROVEE1";
            dualDfSearch.Height = UiConstants.TextboxHeight;
            dualDfSearch.TextContentFirstWidth = UiConstants.TextBoxWidthSmall;
            dualDfSearch.TextContentSecondWidth = UiConstants.TextBoxWidthLarge;
            dualDfSearch.SourceView = new DataTable();
            dualDfSearch.ItemSource = new DataTable();
            dualDfSearch.PrimaryKey = "NUM_PROVEE";
            dualDfSearch.OnChangedField += changedField;
            dualDfSearch.OnAssistQuery += assistQuery;
            collection.Add(dualDfSearch);
            UiDualDfSearchTextObject provDfSearchTextObject = new UiDualDfSearchTextObject("Provincia", UiConstants.LabelTextWidthDefault);
            provDfSearchTextObject.DataFieldFirst = "PROV_PAGO";
            provDfSearchTextObject.ButtonImage = UiConstants.ImagePath;
            provDfSearchTextObject.TableName = "PROVEE1";
            provDfSearchTextObject.AssistDataFieldFirst = "SIGLAS";
            provDfSearchTextObject.AssistDataFieldSecond = "PROV";
            provDfSearchTextObject.AssistTableName = "PROVINCIA";
            provDfSearchTextObject.SourceView = new DataTable();
            provDfSearchTextObject.ItemSource = new DataTable();
            provDfSearchTextObject.PrimaryKey = "NUM_PROVEE";
            provDfSearchTextObject.OnChangedField += changedField;
            provDfSearchTextObject.OnAssistQuery += assistQuery;
            collection.Add(provDfSearchTextObject);
            UiDualDfSearchTextObject paisDfSearchTextObject = new UiDualDfSearchTextObject("Pais", UiConstants.LabelTextWidthDefault);
            paisDfSearchTextObject.DataFieldFirst = "PAIS_PAGO";
            paisDfSearchTextObject.ButtonImage = UiConstants.ImagePath;
            paisDfSearchTextObject.TableName = "PROVEE1";
            paisDfSearchTextObject.AssistDataFieldFirst = "SIGLAS";
            paisDfSearchTextObject.AssistDataFieldSecond = "PAIS";
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
            dfObject1.DataField = "TELF_PAGO";
            dfObject1.TableName = "PROVEE1";
            dfObject1.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            dfObject1.LabelVisible = true;
            dfObject1.Height = UiConstants.TextboxHeight;
            dfObject1.TextContentWidth = "50";
            dfObject1.OnChangedField += changedField;
            dfObject1.ItemSource = new DataTable();
            dfObject1.PrimaryKey = "NUM_PROVEE";
            dfObject1.AllowedEmpty = true;
            // Data field object 2
            UiDfObject dfObject2 = new UiDfObject("Fax", UiConstants.LabelTextWidthDefault);
            dfObject2.DataField = "FAX_PAGO";
            dfObject2.TableName = "PROVEE1";
            dfObject2.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            dfObject2.LabelVisible = true;
            dfObject2.Height = UiConstants.TextboxHeight;
            dfObject2.TextContentWidth = "50";
            dfObject2.OnChangedField += changedField;
            dfObject2.ItemSource = new DataTable();
            dfObject2.PrimaryKey = "NUM_PROVEE";
            dfObject2.AllowedEmpty = true;
            multipleDfObject.AddDataField(dfObject1);
            multipleDfObject.AddDataField(dfObject2);
            collection.Add(multipleDfObject);
            // data field persona.
            UiDfObject dfPersona = new UiDfObject("Persona", UiConstants.LabelTextWidthDefault);
            dfPersona.DataField = "PERSONA_PAGO";
            dfPersona.TableName = "PROVEE1";
            dfPersona.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            dfPersona.LabelVisible = true;
            dfPersona.Height = UiConstants.TextboxHeight;
            dfPersona.TextContentWidth = "50";
            dfPersona.OnChangedField += changedField;
            dfPersona.ItemSource = new DataTable();
            dfPersona.PrimaryKey = "NUM_PROVEE";
            dfPersona.AllowedEmpty = true;
            collection.Add(dfPersona);
            multipleDfObject.AddDataField(dfPersona);
            UiDfObject dfEmail = new UiEmailDataField();
            dfEmail.DataField = "EMAIL_PAGO";
            dfEmail.TableName = "PROVEE1";
            dfEmail.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            dfEmail.LabelVisible = true;
            dfEmail.Height = UiConstants.TextboxHeight;
            dfEmail.TextContentWidth = "50";
            dfEmail.OnChangedField += changedField;
            dfEmail.ItemSource = new DataTable();
            dfEmail.PrimaryKey = "NUM_PROVEE";
            dfEmail.AllowedEmpty = true;
            collection.Add(dfEmail);
            return collection;
        }
    }
}
