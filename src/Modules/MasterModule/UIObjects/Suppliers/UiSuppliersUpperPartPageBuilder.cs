using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using KarveControls.UIObjects;
using MasterModule.Common;
using MasterModule.Properties;

namespace MasterModule.UIObjects.Suppliers
{
    class UiSuppliersUpperPartPageBuilder: IUiPageBuilder
    {
        private string[] UpperPartFields =
        {
            "NUM_PROVEE", "COMERCIAL", "NIF",  "TIPO"
        };

        private IUiObject BuildUiSupplierTypeObject(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery, UiDfObject.ChangedField changedField)
        {
            UiDualDfSearchTextObject dfSearchTextObject = new UiDualDfSearchTextObject("Tipo.Prove", UiConstants.LabelTextWidthDefault);
            dfSearchTextObject.ButtonImage = MasterModuleConstants.ImagePath;
            dfSearchTextObject.TableName = "PROVEE1";
            dfSearchTextObject.PrimaryKey = ProviderConstants.PrimaryKey;
            dfSearchTextObject.AssistTableName = ProviderConstants.TipoProveAssistTableName;
            dfSearchTextObject.AssistDataFieldFirst = ProviderConstants.TipoProveAssistDataFieldFirst;
            dfSearchTextObject.AssistDataFieldSecond = ProviderConstants.TipoProveAssistDataFieldSecond;
            dfSearchTextObject.DataField = ProviderConstants.TipoProveDataFieldFirst;
            dfSearchTextObject.DataFieldFirst = ProviderConstants.TipoProveDataFieldFirst;
            dfSearchTextObject.Height = UiConstants.TextboxHeight;
            dfSearchTextObject.LabelTextWidth = UiConstants.LabelTextWidthDefault;
            dfSearchTextObject.TextContentFirstWidth = UiConstants.TextBoxWidthSmall;
            dfSearchTextObject.TextContentSecondWidth = UiConstants.TextBoxWidthDefault;
            dfSearchTextObject.IsReadOnlyFirst = true;
            dfSearchTextObject.IsReadOnlySecond = false;
            dfSearchTextObject.SourceView = new DataTable();
            dfSearchTextObject.OnChangedField += changedField;
            dfSearchTextObject.OnAssistQuery += assistQuery;
            return dfSearchTextObject;
        }
       
        public IDictionary<string, ObservableCollection<IUiObject>> BuildPageObjects(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery, UiDfObject.ChangedField changedField)
        {
            ObservableCollection<IUiObject> observableCollection = new ObservableCollection<IUiObject>();
            IDictionary<string, ObservableCollection<IUiObject>> collect = new Dictionary<string, ObservableCollection<IUiObject>>();

           
            for (int i = 0; i < UpperPartFields.Length - 1; ++i)
            {
                UiDfObject dataUiDfObject = new UiDfObject();
                dataUiDfObject.LabelText = ProviderConstants.UpperPartLabel[i];
                dataUiDfObject.DataField = UpperPartFields[i];
                dataUiDfObject.LabelTextWidth = UiConstants.LabelTextWidthDefault;
                dataUiDfObject.TextContentWidth = UiConstants.TextBoxWidthDefault;
                dataUiDfObject.Height = UiConstants.TextboxHeight;
                dataUiDfObject.TableName = "PROVEE1";
                dataUiDfObject.PrimaryKey = ProviderConstants.PrimaryKey;
                dataUiDfObject.OnChangedField += changedField;
                dataUiDfObject.AllowedEmpty = true;
                dataUiDfObject.IsReadOnly = (dataUiDfObject.DataField == UpperPartFields[0]);              
                dataUiDfObject.IsVisible = true;
                if (dataUiDfObject.DataField == UpperPartFields[0])
                {
                    dataUiDfObject.TextContentWidth = UiConstants.TextBoxWidthSmall;
                    
                }
                if (dataUiDfObject.DataField == UpperPartFields[1])
                {
                    dataUiDfObject.LabelTextWidth = UiConstants.LabelTextWidthDefault;
                    dataUiDfObject.TableName = "PROVEE2"; 
                }
                else if (dataUiDfObject.DataField == UpperPartFields[2])
                {
                    dataUiDfObject.TextContentWidth = UiConstants.TextBoxWidthSmall;
                }
                DataTable table = new DataTable();
                dataUiDfObject.ItemSource = table;
                observableCollection.Add(dataUiDfObject);
            }
            IUiObject objectType = BuildUiSupplierTypeObject(assistQuery, changedField);
            observableCollection.Add(objectType);
            collect.Add(MasterModuleConstants.UiUpperPart, observableCollection);
            return collect;
        }
    }
}
