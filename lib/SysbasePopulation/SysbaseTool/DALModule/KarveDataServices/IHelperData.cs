using System.Collections.Generic;
using KarveDataServices.DataTransferObject;

namespace KarveDataServices
{

    /// <summary>
    ///  Helper interface for the magnifiers.
    /// </summary>
    public interface IHelperData : IHelperBase
    {
        /// <summary>
        ///  Activity Data Trasfer Object
        /// </summary>
        IEnumerable<ActividadDto> ActivityDto { set; get; }
        /// <summary>
        ///  Client Type Data Trasnfer Object
        /// </summary>
        IEnumerable<ClientTypeDto> ClientTypeDto { get; set; }
        /// <summary>
        ///  Credit Card Data Transfer Object.
        /// </summary>
        IEnumerable<CreditCardDto> CreditCardType { get; set; }
        /// <summary>
        ///  Origen Data Transfer Object
        /// </summary>
        IEnumerable<OrigenDto> OrigenDto { get; set; }
        /// <summary>
        ///  Broker Data Transfer Object
        /// </summary>
        IEnumerable<CommissionAgentSummaryDto> BrokerDto { get; set; }
        /// <summary>
        ///  ClientMarket Data Transfer Object
        /// </summary>
        IEnumerable<MercadoDto> ClientMarketDto { get; set; }
        // Reseller Data Transfer Obejct
        IEnumerable<ResellerDto> ResellerDto { get; set; }
        // Company Data Transfer Object
        IEnumerable<CompanyDto> CompanyDto { get; set; }
        /// <summary>
        /// Office Data Transfer Object.
        /// </summary>
        IEnumerable<OfficeDtos> OfficeDto { get; set; }
        /// <summary>
        ///  Business Data Transfer Object
        /// </summary>
        IEnumerable<BusinessDto> BusinessDto { get; set; }
        /// <summary>
        /// Channel Data Trasnfer object
        /// </summary>
        IEnumerable<ChannelDto> ChannelDto { get; set; }
        /// <summary>
        /// Budget Keys.
        /// </summary>
        IEnumerable<BudgetKeyDto> BudgetKeyDto { get; set; }
        /// <summary>
        /// ClientPaymentForm
        /// </summary>
       IEnumerable<PaymentFormDto> ClientPaymentForm { get; set; }
        /// <summary>
        /// InvoiceBlock
        /// </summary>
        IEnumerable<InvoiceBlockDto> InvoiceBlock { get; set; }
        /// <summary>
        ///  Rent usage.
        /// </summary>
        IEnumerable<RentingUseDto> RentUsageDto { get; set; }
        /// <summary>
        ///  Language Dto
        /// </summary>
        IEnumerable<LanguageDto> LanguageDto { get; set; }
        /// <summary>
        ///  Drivers Dto.
        /// </summary>
        IEnumerable<ClientSummaryDto> DriversDto { get; set; }
        /// <summary>
        /// ContactsDto.
        /// </summary>
        IEnumerable<ContactsDto> ContactsDto { get; set; }
    }

}
