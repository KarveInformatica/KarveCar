﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SQL
{
    public enum QueryType
    {
        QueryCity,
        QueryMarket,
        QueryCompany,
        QueryLanguage,
        QueryCreditCard,
        QueryZone,
        QueryOfficeZone,
        QuerySeller,
        QueryOffice,
        QueryActivity,
        QueryProvince,
        QueryPaymentForm,
        QueryChannel,
        QueryClientType,
        QueryRentingUse,
        QueryClientSummary,
        QueryClientDelegations,
        QueryClient1,
        QueryClient2,
        QueryClientById,
        DeleteClientContacts,
        DeleteClientBranches,
        DeleteClientVisits,
        QueryPagedClient,
        QueryClientPagedSummary,
        QueryCompanyPaged,
        QueryCompanySummary,
        QueryCountry,
        QueryOffices,
        QueryOfficeSummary,
        QueryOfficeSummaryByCompany,
        HolidaysByOffice,
        HolidaysDate,
        QueryCurrency,
        QueryVehicleSummary,
        QuerySupplierSummary,
        QueryVehicleSummaryPaged,
        QuerySupplierSummaryPaged,
        QuerySupplierById,
        QueryBrokerSummary,
        QueryBroker,
        QuerySellerSummary,
        QueryInvoiceSummary,
        QueryInvoiceSummaryExtended,
        QueryInvoiceSummaryPaged,
        QueryInvoiceSingle,
        QueryInvoiceSingleByDate,
        QueryClientSummaryExt,
        QueryCommissionAgentSummary,
        QueryBrokerContacts,
        QuerySuppliersBranches,
        QuerySupplierBranchesPaged,
        QueryCompanyOffices,
        QueryOfficeByCompany,
        HolidaysOfficeDelete,
        QueryInvoiceItem,
        QueryVehicleModel,
        QueryVehicleColor,
        QueryBrandByVehicle,
        QueryVehicleBrand,
        QueryVehiclePhoto,
        QueryVehicleActivity,
        QueryClientSummaryExtById,
        QueryContractSummaryBasic,
        QueryVehicle,
        QueryAgentByVehicle,
        QueryVehicleMaintenance,
        QueryVehicleGroup,
        QueryVehicleOwner,
        QueryCommissionAgentPaged,
        QueryOfficeSummaryPaged,
        QueryBookingSummary,
        QueryBookingAllFields,
        QueryBooking,
        QueryBookingSummaryExt,
        QueryBookingPaged,
        QueryBookingItem,
        QueryBookingItems,
        QueryContractSummary,
        QueryContractSummaryPaged,
        QueryBookedPaged,
        QueryBank,
        QuerySuppliersContacts,
        QueryActiveFare,
        QueryCountActiveFare,
        QueryContractsByClient,
        QueryVehicleById,
        QuerySupplierType,
        QueryAccount, 
        QueryMulti,
        QueryCommissionAgentSummaryById,
        QueryClientContacts,
        QueryOrigin,
        QueryBusiness,
        QueryClientVisits,
        QueryInvoiceBlocks,
        QueryBudgetKey,
        QueryBudgetSummaryPaged,
        QueryBudgetSummary,
        QueryVehicleModelWithCount,
        QuerySupplierSummaryById,
        QueryClientSummaryById,
        QueryReseller,
        QueryReservationRequest,
        QueryReservationRequestSummaryPaged,
        QueryReservationRequestSummary,
        QueryFares,
        QueryVehicleSummaryById,
        QueryReservationRequestReason,
        QueryDeliveringFrom,
        QueryDivisa,
        QueryCurrencyValue,
        QueryDeptContable,
        QueryOfficePaged,
        QueryBrokerVisit,
        QueryBrokerContactsPaged,
        QueryFareConcept,
        QueryBudget,
        QueryBookingMedia,
        QueryBookingType,
        QueryAgencyEmployee,
        QueryPrintingType,
        QueryCityByName,
        QueryBudgetSummaryById,
        QueryDelivering,
        QueryDeliveringBy
    };
}
