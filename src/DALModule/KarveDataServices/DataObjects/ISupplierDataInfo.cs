using System.ComponentModel;

namespace KarveDataServices.DataObjects
{
    /// <summary>
    ///  Interface for giving information about suppliers.
    /// </summary>
    /// 
    public interface ISupplierDataInfo
    { 
        string Name { set; get; }
        string Direction { set; get; }
        string CountryCode { set; get; }
        string City { set; get; }
        string ProvinceCode { set; get; }
        string Phone { set; get; }
        string Fax { set; get; }
        string WebSite { set; get; }
        string Notes { set; get; }
        string Persona { set; get; }
        string DeliveringPeriod { set; get; }
        string DischargeDate  { set; get; }
        string LeavingDate { set; get; }
        string Country { set; get; }
        string Province { set; get; }
        string Email { set; get; }
        string Observation { set; get; }
        string Nif { set; get; }
        string Code { set; get; }
        string Number { set; get; }
        string MapDirection { set;  get; }
        string MobilePhone { set; get; }
        string CommercialName { set; get; }
        object Zip { set; get; }
        object Type { set; get; }
        string LastChange { set; get; }
        string ChangedByUser { set; get; }
       

    }
}