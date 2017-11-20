using System.Collections.Generic;

namespace MasterModule.Views.Vehicles
{
    /// <summary>
    /// </summary>
    public sealed class StringConstants
    {


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
        /// <summary>
        /// import value
        /// </summary>
        private const string ImportValue = "Importe";
        /// <summary>
        ///  private assurance company value
        /// </summary>
        private const string AssuranceCompanyValue = "Comp.de seguros";
        /// <summary>
        /// 
        /// </summary>
        private const string InsurancePolicyValue = "Poliza";
        /// <summary>
        /// Insurance type value
        /// </summary>
        private const string InsuranceTypeValue = "Tipo seguro";
        /// <summary>
        /// entry date value
        /// </summary>
        private const string EntryDateValue = "Fecha de Alta";
        /// <summary>
        /// 
        /// </summary>
        private const string LeavingDateValue = "Fecha de Baja";
        /// <summary>
        /// Vencimiento
        /// </summary>
        private const string ExpirationDateValue = "Vencimiento";
        /// <summary>
        ///  Carta verde value
        /// </summary>
        private const string CartaVerdeValue = "Carta Verde";
        /// <summary>
        ///  Observaciones
        /// </summary>
        private const string Observaciones = "Observation";
        /// <summary>
        ///  Franquigia
        /// </summary>
        private const string ExemptionValue = "Franquigia";
        /// <summary>
        ///  Amount value
        /// </summary>
        private const string AmountValue = "Importe";
        /// <summary>
        ///  Payed value.
        /// </summary>
        private const string PayedValue = "Pagado";
        /// <summary>
        ///  Help desk value
        /// </summary>
        private const string HelpDeskValue = "Telefono Asist.";
        /// <summary>
        ///  payement type
        /// </summary>
        private const string PaymentTypeValue = "Forma de pago";
        /// <summary>
        ///  AgentValue
        /// </summary>
        private const string AgentValue = "Agente";

        private const string PrimaValue = "Prima";

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
        ///  Vehicule buyer
        /// </summary>
        public string Buyer => BuyerValue;
        /// <summary>
        ///  Vehicle price
        /// </summary>
        public string Price => PriceValue;
        /// <summary>
        ///  Vehicle bill number
        /// </summary>
        public string BillNumber => BillNumberValue;
        /// <summary>
        ///  Vehicle reseller
        /// </summary>
        public string Reseller => ResellerValue;
        /// <summary>
        ///  Vehicle billing date
        /// </summary>
        public string BillingDate => BillingDateValue;
        /// <summary>
        ///  Vehicle stree price
        /// </summary>
        public  string StretPrice => StretPriceValue;
        /// <summary>
        ///  Vehilce renounce
        /// </summary>
        public string TrafficRenounce => TrafficRenounceValue;
        /// <summary>
        ///  Vehicle assurance
        /// </summary>
        public  string AssuranceRenount => AssuranceRenountValue;
        /// <summary>
        ///  Vehicle bank transfer
        /// </summary>
        public  string BankTransfer => BankTransferValue;
        /// <sumary>
        ///  Vehicle delivering date
        /// </summary>
        public string DeliveringDate => DeliveringDateValue;
        /// <summary>
        ///  Vehicle selling
        /// </summary>
        public string SellVehicles => SellVehiclesValue;
        /// <summary>
        ///  Veihicle buying header
        /// </summary>
        public string VehicleBuying => VehicleBuyingValue;
        /// <summary>
        ///  Supplier value
        /// </summary>
        public string Supplier => SupplierValue;
        /// <summary>
        ///  Previous car register number
        /// </summary>
        public string PreviousRegisterNumber => PreviousRegisterNumberValue;
        /// <summary>
        ///  Previous payment way
        /// </summary>
        public string PaymentWay => PaymentWayValue;
        /// <summary>
        ///  Previous register date
        /// </summary>
        public string RegisterDate => RegisterDateValue;
        /// <summary>
        ///  Previous buying date
        /// </summary>
        public string BuyingDate => BuyingDateValue;
        /// <summary>
        ///  Summary 
        /// </summary>
        public string Summary => SummaryValue;
        /// <summary>
        ///  VehicleCopy
        /// </summary>
        public string VehicleCopy => VehicleCopyValue;

        /// <summary>
        ///  Agent
        /// </summary>
        public string Agent => AgentValue;
        /// <summary>
        ///  Import 
        /// </summary>
        public string Import => ImportValue;
        /// <summary>
        ///  Assurance company.
        /// </summary>
        public string AssuranceCompany => AssuranceCompanyValue;
        /// <suerry>
        ///  Assurance company.
        /// </summary>
        public string InsurancePolicy => InsurancePolicyValue;
        /// <summary>
        /// locale
        /// </summary>
        public string InsuranceType => InsuranceTypeValue;
        /// <summary>
        /// locale entry date
        /// </summary>
        public string EntryDate => EntryDateValue;
        /// <summary>
        ///  amount of data
        /// </summary>
        public string Amount => AmountValue;
        /// <summary>
        ///  payed data
        /// </summary>
        public string Payed => PayedValue;
        /// <summary>
        ///  help desk value
        /// </summary>
        public string HelpDesk => HelpDeskValue;
        /// <summary>
        ///  payment data
        /// </summary>
        public string PaymentType => PaymentTypeValue;
        /// <summary>
        /// Prima
        /// </summary>
        public string Prima => PrimaValue;
    }
}
