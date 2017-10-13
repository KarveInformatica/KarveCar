using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using KarveControls.UIObjects;
using MasterModule.Common;
using MasterModule.Properties;

namespace MasterModule.UIObjects.CommissionAgents
{

    class UiCommissionAgentUpperPartBuilder: IUiPageBuilder
    {
            private readonly string[] _upperPartFields =
            {
                "NUM_COMI", "PERSONA", "NIF", "TIPOCOMI"
            };

            private readonly string[] _upperPartLabel =
            {
                "Numero", "Persona", "Nif", "Tipo Comm."
            };

            private IUiObject BuildUiCommissionTypeObject(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery, UiDfObject.ChangedField changedField)
            {
                UiDualDfSearchTextObject dfSearchTextObject = new UiDualDfSearchTextObject("Tipo.Comissionista", UiConstants.LabelTextWidthDefault);
                dfSearchTextObject.ButtonImage = MasterModule.ImagePath;
                dfSearchTextObject.TableName = Properties.Resources.CommissionAgentModule_Table1;
                dfSearchTextObject.PrimaryKey = CommissionAgentConstants.PrimaryKey;
                dfSearchTextObject.AssistTableName = CommissionAgentConstants.TipoAssistTableName;
                dfSearchTextObject.AssistDataFieldFirst = CommissionAgentConstants.TipoAssistDataFieldFirst;
                dfSearchTextObject.AssistDataFieldSecond = CommissionAgentConstants.TipoAssistDataFieldSecond;
                dfSearchTextObject.DataField = CommissionAgentConstants.TipoDataFieldFirst;
                dfSearchTextObject.DataFieldFirst = CommissionAgentConstants.TipoDataFieldFirst;
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
            /// <summary>
            /// Build the upper part for the commission agent.
            /// </summary>
            /// <param name="assistQuery">Assist query event handler</param>
            /// <param name="changedField">Changed Field event handler</param>
            /// <returns></returns>
            public IDictionary<string, ObservableCollection<IUiObject>> BuildPageObjects(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery, UiDfObject.ChangedField changedField)
            {
                ObservableCollection<IUiObject> observableCollection = new ObservableCollection<IUiObject>();
                IDictionary<string, ObservableCollection<IUiObject>> collect = new Dictionary<string, ObservableCollection<IUiObject>>();

                for (int i = 0; i < _upperPartFields.Length - 1; ++i)
                {
                    UiDfObject dataUiDfObject = new UiDfObject();
                    dataUiDfObject.LabelText = _upperPartLabel[i];
                    dataUiDfObject.DataField = _upperPartFields[i];
                    dataUiDfObject.LabelTextWidth = UiConstants.LabelTextWidthDefault;
                    dataUiDfObject.TextContentWidth = UiConstants.TextBoxWidthDefault;
                    dataUiDfObject.Height = UiConstants.TextboxHeight;
                    dataUiDfObject.TableName = Resources.CommissionAgentModule_Table1;
                    dataUiDfObject.PrimaryKey = CommissionAgentConstants.PrimaryKey;
                    dataUiDfObject.OnChangedField += changedField;
                    dataUiDfObject.AllowedEmpty = true;
                    dataUiDfObject.IsReadOnly = (dataUiDfObject.DataField == _upperPartFields[0]);
                    dataUiDfObject.IsVisible = true;
                    if (dataUiDfObject.DataField == _upperPartFields[0])
                    {
                        dataUiDfObject.TextContentWidth = UiConstants.TextBoxWidthSmall;

                    }
                    if (dataUiDfObject.DataField == _upperPartFields[1])
                    {
                        dataUiDfObject.LabelTextWidth = UiConstants.LabelTextWidthDefault;
                        dataUiDfObject.TableName = Resources.CommissionAgentModule_Table1;
                    }
                    else if (dataUiDfObject.DataField == _upperPartFields[2])
                    {
                        dataUiDfObject.TextContentWidth = UiConstants.TextBoxWidthSmall;
                    }
                    DataTable table = new DataTable();
                    dataUiDfObject.ItemSource = table;
                    observableCollection.Add(dataUiDfObject);
                }
                IUiObject objectType = BuildUiCommissionTypeObject(assistQuery, changedField);
                observableCollection.Add(objectType);
                collect.Add(MasterModule.UiUpperPart, observableCollection);
                return collect;
            }
        }
}
