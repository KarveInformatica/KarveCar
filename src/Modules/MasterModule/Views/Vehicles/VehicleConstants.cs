using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterModule.Views.VehicleSelling
{
    /// <summary>
    ///  Vehicle Constants.
    /// </summary>
    public sealed class VehicleConstants
    {
        private const string ImageValue =
            @".\Images\search.png";

        private const string BuyerValue = "Comprador";
        private const string PriceValue = "Precio";
        private const string BillNumberValue = "Numero Factura";
        private const string ResellerValue = "Vendedor";
        private const string BillingDateValue = "Fecha Factura";
        private const string StretPriceValue = "Precio Para Venta";
        private const string TrafficRenounceValue = "Baja Trafico";
        private const string AssuranceRenountValue = "Baja Seguro";
        private const string BankTransferValue = "Transferencia";
        private const string DeliveringDateValue = "Fecha Entrega";
        private const string SellVehiclesValue = "Venta Vehiculo";
        private const string VehicleBuyingValue = "Compra Vehiculo";
        private const string SupplierValue = "Proveedor";
        private const string PreviousRegisterNumberValue = "Matricula anterior";
        private const string PaymentWayValue = "Forma de Pago";
        private const string RegisterDateValue = "Fecha matriculacion";
        private const string BuyingDateValue = "Fecha compra";
        private const string VehicleCopyValue = "Copia Vehiculo";
        private const string SummaryValue = "Importe";
       

        private static List<string> LocalizationList = new List<string>()
        {
            "Tarjeta de Transporte",
            "Precio de Fabricacion",
            "ImpuestoMatriculacion",
            "Num.Factura",
            "Precio",
            "Bonifica"
        };

        /// <summary>
        /// ImagePath Value.
        /// </summary>
        public static string ImagePath => ImageValue;
        /// <summary>
        ///  Vehicule buyer
        /// </summary>
        public static string Buyer => BuyerValue;
        /// <summary>
        ///  Vehicle price
        /// </summary>
        public static string Price => PriceValue;
        /// <summary>
        ///  Vehicle bill number
        /// </summary>
        public static string BillNumber => BillNumberValue;
        /// <summary>
        ///  Vehicle reseller
        /// </summary>
        public static string Reseller => ResellerValue;
        /// <summary>
        ///  Vehicle billing date
        /// </summary>
        public static string BillingDate => BillingDateValue;
        /// <summary>
        ///  Vehicle stree price
        /// </summary>
        public static string StretPrice => StretPriceValue;
        /// <summary>
        ///  Vehilce renounce
        /// </summary>
        public static string TrafficRenounce => TrafficRenounceValue;
        /// <summary>
        ///  Vehicle assurance
        /// </summary>
        public static string AssuranceRenount => AssuranceRenountValue;
        /// <summary>
        ///  Vehicle bank transfer
        /// </summary>
        public static string BankTransfer => BankTransferValue;
        /// <summary>
        ///  Vehicle delivering date
        /// </summary>
        public static string DeliveringDate => DeliveringDateValue;
        /// <summary>
        ///  Vehicle selling
        /// </summary>
        public static string SellVehicles => SellVehiclesValue;
        /// <summary>
        ///  Veihicle buying header
        /// </summary>
        public static string VehicleBuying => VehicleBuyingValue;
        /// <summary>
        ///  Supplier value
        /// </summary>
        public static string Supplier => SupplierValue;
        /// <summary>
        ///  Previous car register number
        /// </summary>
        public static string PreviousRegisterNumber => PreviousRegisterNumberValue;
        /// <summary>
        ///  Previous payment way
        /// </summary>
        public static string PaymentWay => PaymentWayValue;
        /// <summary>
        ///  Previous register date
        /// </summary>
        public static string RegisterDate => RegisterDateValue;
        /// <summary>
        ///  Previous buying date
        /// </summary>
        public static string BuyingDate => BuyingDateValue;
        /// <summary>
        ///  Summary 
        /// </summary>
        public static string Summary => SummaryValue;
        /// <summary>
        ///  VehicleCopy
        /// </summary>
        public static string VehicleCopy => VehicleCopyValue;

    }
}
