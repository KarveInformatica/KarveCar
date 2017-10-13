using System;
using KarveDataServices.DataObjects;

namespace DataAccessLayer.DataObjects
{
    class ExtendedSummaryDataObject : SupplierSummaryDataObject, ISupplierData
    {
        public object Commercial { set; get; }
        public string ProvinceCode { get; set; }

        public string Email { get; set; }

        public string Fax { get; set; }
        public string WebSite { get; set; }
        public string Notes { get; set; }
        public string Persona { get; set; }
        public string DeliveringPeriod { get; set; }
        public string DischargeDate { get; set; }
        public string LeavingDate { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        
        public string Observation { get; set; }
        public string Code { get; set; }
        public string Number { get; set; }
        public string MapDirection { get; set; }
        public string MobilePhone { get; set; }
        public string CommercialName { get; set; }
        public string Phone { set; get; }
        public object Zip { set; get; }

        
        
        public string CountryCode { get; set; }

        public string City { set; get; }
        public object Aeat { set; get; }
        public object PaymentType { set; get; }
        public string Surname1 { get; set; }
        public string Surname2 { get; set; }

        

        public string Direction { set; get; }
        public object ExpenseAccount { set; get; }
        public object SupplierPeriod1 { set; get; }
        public object SupplierPeriod2 { set; get; }
        public object SupplierPeriod3 { set; get; }
        public object SupplierDay1 { set; get; }
        public object SupplierDay2 { set; get; }
        public object SupplierDay3 { set; get; }
        public object VacationMonth1 { set; get; }
        public object VacationMonth2 { set; get; }
        public string LastChange { set; get; }
        public string ChangedByUser { set; get; }
        public ISupplierTypeData Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ISupplierAccountObjectInfo Account { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
 