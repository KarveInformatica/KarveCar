﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveControls;
using KarveDataServices.ViewObjects;
using MasterModule.Common;
using MasterModule.UIObjects.CommissionAgents;

namespace MasterModule.ViewModels
{
    /// <summary>
    /// CommissionAgentInfoViewModel
    /// </summary>
    internal sealed partial class CommissionAgentInfoViewModel : MasterInfoViewModuleBase, IEventObserver
    {

        private static ObservableCollection<UiDfSearch> UpdateItemControl()
        {
            ObservableCollection<UiDfSearch> dualDfSearchBoxes = new ObservableCollection<UiDfSearch>()
            {
                new UiDfSearch(KarveLocale.Properties.Resources.StringConstants_Vendedor)
                {
                    AssistTableName = "VENDEDOR",
                    AssistDataFieldFirst = "NUM_VENDE",
                    AssistDataFieldSecond = "NOMBRE",
                    DataField = "VENDE_COMI",
                    DataFieldFirst = "VENDE_COMI",
                    TextContentFirstWidth = "50",
                    TextContentSecondWidth = "30",
                    TableName = "COMISIO",
                    AssistProperties = "Code,Name",
                    SourceView =  new ObservableCollection<ResellerViewObject>(),
                    LabelVisible = true,
                   
                    ButtonImage = MasterModuleConstants.ImagePath,
                    IsReadOnlyFirst = true
                } ,
                new UiDfSearch(KarveLocale.Properties.Resources.StringConstants_Mercado)
                {
                    AssistTableName = "MARKET_ASSIST",
                    AssistDataFieldFirst = "CODIGO",
                    AssistDataFieldSecond = "NOMBRE",
                    DataAllowed = DataType.Any,
                    DataField = "MERCADO",
                    TextContentFirstWidth = "50",
                    TextContentSecondWidth = "350",
                    AssistProperties = "Code,Name",
                    SourceView = new object(),
                    DataSource = new object(),
                    LabelVisible = true,
                    ButtonImage = MasterModuleConstants.ImagePath,
                    IsReadOnlySecond = true
                },
                new UiDfSearch(KarveLocale.Properties.Resources.StringConstants_Negocio)
                {
                    AssistTableName="BUSINESS_ASSIST",
                    AssistDataFieldFirst = "CODIGO",
                    AssistDataFieldSecond = "NOMBRE",
                    AssistProperties = "Code,Name",
                    DataAllowed = DataType.Any,
                    DataField = "NEGOCIO",
                    SourceView = new DataTable(),
                    DataSource = new object(),
                    TextContentFirstWidth = "50",
                    TextContentSecondWidth = "350",
                    LabelVisible = true,
                    ButtonImage = MasterModuleConstants.ImagePath,
                    IsReadOnlyFirst = true
                },
                new UiDfSearch(KarveLocale.Properties.Resources.StringConstants_Canal)
                {
                    DataField = "CANAL",
                    AssistTableName = "CHANNEL_TYPE",
                    AssistDataFieldFirst = "CODIGO",
                    AssistDataFieldSecond = "NOMBRE",
                    TextContentFirstWidth = "50",
                    TextContentSecondWidth = "350",
                    AssistProperties = "Code,Name",
                    DataAllowed = DataType.Any,
                    SourceView = new DataTable(),
                    DataSource = new object(),
                    LabelVisible = true,
                    ButtonImage = MasterModuleConstants.ImagePath,
                    IsReadOnlySecond = true
                },
                new UiDfSearch(KarveLocale.Properties.Resources.StringConstants_ClavePpto)
                {
                    DataField = "CLAVEPPTO",
                    AssistTableName = "CLIENT_BUDGET",
                    AssistDataFieldFirst = "COD_CLAVE",
                    AssistDataFieldSecond = "NOMBRE",
                    AssistProperties = "Code,Name",
                    DataAllowed = DataType.Any,
                    TextContentFirstWidth = "50",
                    TextContentSecondWidth = "350",
                    SourceView = new DataTable(),
                    DataSource = new object(),
                    LabelVisible = true,
                    ButtonImage = MasterModuleConstants.ImagePath,
                    IsReadOnlySecond = true
                },
                new UiDfSearch(KarveLocale.Properties.Resources.StringConstants_Origen)
                {
                    DataField = "ORIGEN_COMI",
                    AssistTableName = "ORIGIN_ASSIST",
                    AssistDataFieldFirst = "NUM_ORIGEN",
                    AssistDataFieldSecond = "NOMBRE",
                    TextContentFirstWidth = "50",
                    TextContentSecondWidth = "350",
                    DataAllowed = DataType.Any,
                    AssistProperties = "Code,Name",
                    SourceView =  new DataTable(),
                    DataSource = new object(),
                    LabelVisible = true,
                    ButtonImage = MasterModuleConstants.ImagePath,
                    IsReadOnlySecond = true
                },
                new UiDfSearch(KarveLocale.Properties.Resources.StringConstants_ZonaOfi)
                {
                    DataField = "ZONAOFI",
                    AssistTableName = "OFFICE_ZONE_ASSIST",
                    AssistDataFieldFirst = "COD_ZONAOFI",
                    AssistDataFieldSecond = "NOM_ZONA",
                    TextContentFirstWidth = "50",
                    TextContentSecondWidth = "300",
                    AssistProperties = "Codigo,Nombre,Plaza",
                    SourceView = new DataTable(),
                    DataSource = new object(),
                    ButtonImage = MasterModuleConstants.ImagePath,
                    LabelVisible = true,
                    IsReadOnlySecond = true
                }
            };
           
            return dualDfSearchBoxes;
        }
        private ObservableCollection<UiDfSearch> _leftSideDualDfSearchBoxes = UpdateItemControl();
        
    }
}
