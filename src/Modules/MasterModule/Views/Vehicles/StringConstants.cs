using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterModule.Views.VehicleAssurance
{
    /// <summary>
    /// </summary>
    public sealed class StringConstants
    {
        // Image value 
        private const string ImageValue =
                  @"C:\Users\Usuario\Documents\CompraVenta\VehicleSelling\VehicleSelling\Images\search.png";
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

        /// <summary>
        ///  Agent
        /// </summary>
        public string Agent =>  AgentValue;
        /// <summary>
        ///  Image path
        /// </summary>
        public string Image => ImageValue;
        /// <summary>
        ///  Import 
        /// </summary>
        public  string Import => ImportValue;
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
