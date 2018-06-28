using System.Collections.Generic;

namespace MasterModule.Views.Vehicles
{
    /// <summary>
    /// </summary>
    public sealed class StringConstants
    {


        private readonly string BuyerValue = KarveLocale.Properties.Resources.lbuyer;
        private string PriceValue = KarveLocale.Properties.Resources.dttcPrecio;
        private string BillNumberValue = KarveLocale.Properties.Resources.StringConstants_NumeroFactura;
        private string ResellerValue = KarveLocale.Properties.Resources.StringConstants_Vendedor;
        private string BillingDateValue = KarveLocale.Properties.Resources.StringConstants_FechaFactura;
        private string StretPriceValue = KarveLocale.Properties.Resources.StringConstants_PrecioParaVenta;
        private string TrafficRenounceValue = KarveLocale.Properties.Resources.StringConstants_BajaTrafico;
        private string AssuranceRenountValue = KarveLocale.Properties.Resources.StringConstants_BajaSeguro;
        private string BankTransferValue = KarveLocale.Properties.Resources.StringConstants_Transferencia;
        private string DeliveringDateValue = KarveLocale.Properties.Resources.StringConstants_FechaEntrega;
        private string SellVehiclesValue = KarveLocale.Properties.Resources.StringConstants_VentaVehiculo;
        private string VehicleBuyingValue = KarveLocale.Properties.Resources.StringConstants_CompraVehiculo;
        private string SupplierValue = KarveLocale.Properties.Resources.lproveedor;
        private string PreviousRegisterNumberValue = KarveLocale.Properties.Resources.StringConstants_MatriculaAnterior;
        private string PaymentWayValue = KarveLocale.Properties.Resources.lformadepago;
        private string RegisterDateValue = KarveLocale.Properties.Resources.StringConstants_FechaMatriculacion;
        private string BuyingDateValue = KarveLocale.Properties.Resources.StringConstants_FechaCompra;
        private string VehicleCopyValue = KarveLocale.Properties.Resources.lcopiavehiculo;
        private string SummaryValue = KarveLocale.Properties.Resources.StringConstants_Importe;

        public string ExpirationDate => KarveLocale.Properties.Resources.ExpirationDate;

        /// <summary>
        /// import value
        /// </summary>
        private string ImportValue =KarveLocale.Properties.Resources.StringConstants_Importe;
        /// <summary>
        ///  private assurance company value
        /// </summary>
        private string AssuranceCompanyValue = KarveLocale.Properties.Resources.StringConstants_CompDeSeguros;
        /// <summary>
        /// 
        /// </summary>
        private string InsurancePolicyValue = KarveLocale.Properties.Resources.StringConstants_Poliza;
        /// <summary>
        /// Insurance type value
        /// </summary>
        private string InsuranceTypeValue = KarveLocale.Properties.Resources.StringConstants_TipoSeguro;
        /// <summary>
        /// entry date value
        /// </summary>
        private string EntryDateValue = KarveLocale.Properties.Resources.StringConstants_FechaDeAlta;
        /// <summary>
        /// 
        /// </summary>
        private string LeavingDateValue = KarveLocale.Properties.Resources.StringConstants_FechaDeBaja;
        /// <summary>
        /// Vencimiento
        /// </summary>
        private string ExpirationDateValue = KarveLocale.Properties.Resources.StringConstants_Vencimiento;
        /// <summary>
        ///  Carta verde value
        /// </summary>
        private string CartaVerdeValue = KarveLocale.Properties.Resources.lcartaverde;
        /// <summary>
        ///  Observaciones
        /// </summary>
        private string Observaciones = KarveLocale.Properties.Resources.StringConstants_Observation;
        /// <summary>
        ///  Franquigia
        /// </summary>
        private  string ExemptionValue = KarveLocale.Properties.Resources.StringConstants_Franquigia;
        /// <summary>
        ///  Amount value
        /// </summary>
        private  string AmountValue = KarveLocale.Properties.Resources.limporte;
        /// <summary>
        ///  Payed value.
        /// </summary>
        private  string PayedValue = KarveLocale.Properties.Resources.lpagado;
        /// <summary>
        ///  Help desk value
        /// </summary>
        private string HelpDeskValue = KarveLocale.Properties.Resources.StringConstants_TelefonoAsist;
        /// <summary>
        ///  payement type
        /// </summary>
        private string PaymentTypeValue = KarveLocale.Properties.Resources.StringConstants_FormaDePago;
        /// <summary>
        ///  AgentValue
        /// </summary>
        private  string AgentValue = KarveLocale.Properties.Resources.StringConstants_Agente;

        private  string PrimaValue = KarveLocale.Properties.Resources.StringConstants_Prima;

        private static List<string> LocalizationList = new List<string>()
        {
            KarveLocale.Properties.Resources.StringConstants_TarjetaDeTransporte,
            KarveLocale.Properties.Resources.StringConstants_PrecioDeFabricacion,
            KarveLocale.Properties.Resources.StringConstants_ImpuestoMatriculacion,
            KarveLocale.Properties.Resources.lnumerofactura,
            KarveLocale.Properties.Resources.StringConstants_Precio,
            KarveLocale.Properties.Resources.StringConstants_Bonifica
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
