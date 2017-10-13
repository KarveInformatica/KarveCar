using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterModule.Properties;

namespace MasterModule.Common
{
    internal class ProviderConstants
    {

        internal static string[] LeftPartLabel =
        {
            Resources.ProviderInfoViewModel_Nombre,
            Resources.ProviderInfoViewModel_NIF,
            Resources.ProviderInfoViewModel_LoadLeftPart_Dirección,
            Resources.ProviderInfoViewModel_Dirección2,
            Resources.ProviderInfoViewModel_LoadLeftPart_CP,
            Resources.ProviderInfoViewModel_Población,
            Resources.ProviderInfoViewModel_LoadLeftPart_Provincia,
            Resources.ProviderInfoViewModel_LoadLeftPart_Pais,
            Resources.ProviderInfoViewModel_Teléfono,
            Resources.ProviderInfoViewModel_Fax,
            Resources.ProviderInfoViewModel_Móvil,
            Resources.ProviderInfoViewModel_Email,
            Resources.ProviderInfoViewModel_Web,
            Resources.ProviderInfoViewModel_Contacto,
            Resources.ProviderInfoViewModel_Empresa,
            Resources.ProviderInfoViewModel_Oficina,
            Resources.ProviderInfoViewModel_FechaDeBaja,
            Resources.ProviderInfoViewModel_FechaDeAlta,
            Resources.ProviderInfoViewModel_Notas,
            Resources.ProviderInfoViewModel_Observaciones
        };

        
        internal static string[] UpperPartLabel =
        {
            Resources.ProviderInfoViewModel_Numero,
            Resources.ProviderInfoViewModel_NombreCommercial,
            Resources.ProviderInfoViewModel_NIF,
            Resources.ProviderInfoViewModel_TipoProv
        };
       
        internal static string[] AccountLeftCheckBoxNames =
        {
            Resources.ProviderConstants_GestiónDeAlbaranes, Resources.ProviderConstants_EsIntracomunitario, "Gestionar IVA Importación", "Margen No Automatico"
        };

        internal static string[] AccountRightCheckBoxNames =
        {
            "Albaranes Coste Transporte", "Exenciones en Op.Interiores", "Generar Autofactura de Mantenimiento"
        };
        internal const string PrimaryKey = "NUM_PROVEE";
        internal const string TipoProveAssistTableName = "TIPOPROVE";
        internal const string TipoProveAssistDataFieldFirst = "NUM_TIPROVE";
        internal const string TipoProveAssistDataFieldSecond = "NOMBRE";
        internal const string TipoProveDataFieldFirst = "TIPO";
        internal const string PaisKey = "NACIOPER";
        internal const string ProvinceKey = "PROV";
        internal const string ProvinceComponentKey = "PROVINCE";
        internal const string ZipKey = "SIGLAS";
        internal const string PaisComponentKey = "PAIS";
        internal const string ProvinceAssistTableName = "PROVINCIA";
        internal const string UiInvocingAccounts = "Accounts";
        internal const string UiLeasing = "LeasingObjects";
        internal const string UiInvocingData = "InvoicingData";
        internal const string UiInvoiceOptionPart1 = "UiInvoiceOption1";
        internal const string UiInvoiceOptionPart2 = "UiInvoiceOption2";
        internal const string UiPaymentDirectionsCollection = "PaymentDirectionsCollection";
        internal const string UiReclaimDirectionsCollection = "ReclaimDirectionsCollection";
        internal const string UiOrderDirectionsCollection = "OrderCommunicationCollection";
        internal const string UiDevolutionDirectionsCollection = "DevolutionDirectionCollection";
        internal const string UiIntracoAccount = "UiIntracoAccount";
        internal const string DelegationesPrimaryKeyValue = "cldIdDelega";
        internal const string DelegationDataBaseTable = "ProDelega";
    }
}
