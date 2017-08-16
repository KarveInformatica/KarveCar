using System.ComponentModel;

namespace KarveDataServices.DataObjects
{
    /// <summary>
    ///  Interface for giving information about suppliers.
    /// </summary>
    public interface ISupplierDataObjectInfo
    { 
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
    }
}