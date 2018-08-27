using System.Collections.Generic;
using KarveDataServices.ViewObjects;

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
        IEnumerable<ActividadViewObject> ActivityDto { set; get; }
        /// <summary>
        ///  Client Type Data Trasnfer Object
        /// </summary>
        IEnumerable<ClientTypeViewObject> ClientTypeDto { get; set; }
        /// <summary>
        ///  Credit Card Data Transfer Object.
        /// </summary>
        IEnumerable<CreditCardViewObject> CreditCardType { get; set; }
        /// <summary>
        ///  Origen Data Transfer Object
        /// </summary>
        IEnumerable<OrigenViewObject> OrigenDto { get; set; }
        /// <summary>
        ///  Broker Data Transfer Object
        /// </summary>
        IEnumerable<CommissionAgentSummaryViewObject> BrokerDto { get; set; }
        /// <summary>
        ///  ClientMarket Data Transfer Object
        /// </summary>
        IEnumerable<MarketViewObject> ClientMarketDto { get; set; }
        // Reseller Data Transfer Obejct
        IEnumerable<ResellerViewObject> ResellerDto { get; set; }
        // Company Data Transfer Object
        IEnumerable<CompanyViewObject> CompanyDto { get; set; }
        /// <summary>
        /// Office Data Transfer Object.
        /// </summary>
        IEnumerable<OfficeViewObject> OfficeDto { get; set; }
        /// <summary>
        ///  Business Data Transfer Object
        /// </summary>
        IEnumerable<BusinessViewObject> BusinessDto { get; set; }
        /// <summary>
        /// Channel Data Trasnfer object
        /// </summary>
        IEnumerable<ChannelViewObject> ChannelDto { get; set; }
        /// <summary>
        /// Budget Keys.
        /// </summary>
        IEnumerable<BudgetKeyViewObject> BudgetKeyDto { get; set; }
        /// <summary>
        /// ClientPaymentForm
        /// </summary>
       IEnumerable<PaymentFormViewObject> ClientPaymentForm { get; set; }
        /// <summary>
        /// InvoiceBlock
        /// </summary>
        IEnumerable<InvoiceBlockViewObject> InvoiceBlock { get; set; }
        /// <summary>
        ///  Rent usage.
        /// </summary>
        IEnumerable<RentingUseViewObject> RentUsageDto { get; set; }
        /// <summary>
        ///  Language Dto
        /// </summary>
        IEnumerable<LanguageViewObject> LanguageDto { get; set; }
        /// <summary>
        ///  Drivers Dto.
        /// </summary>
        IEnumerable<ClientSummaryViewObject> DriversDto { get; set; }
        /// <summary>
        /// ContactsViewObject.
        /// </summary>
        IEnumerable<ContactsViewObject> ContactsDto { get; set; }
    }

}
