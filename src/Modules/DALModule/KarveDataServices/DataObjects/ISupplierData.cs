using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using KarveDataServices.ViewObjects;

namespace KarveDataServices.DataObjects
{
    /// <summary>
    ///  Interface for giving information about suppliers.
    /// </summary>
    /// 
    public interface ISupplierData: IHelperMasterCommon, IValidDomainObject, IValueObject<SupplierViewObject>
    {
        /// <summary>
        ///  This delete all data in async way 
        /// </summary>
        /// <returns></returns>
        Task<bool> DeleteAsyncData();

        /// <summary>
        /// Save the supplierData .
        /// </summary>
        /// <returns></returns>
        Task<bool> Save();

        /// <summary>
        ///  Save all updates in the vehicle
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveChanges();

        /// <summary>
        /// Load valed
        /// </summary>
        /// <param name="fields">Dictionary of the fields</param>
        /// <param name="cCodiint">Vehicle code primary key</param>
        /// <returns></returns>
        Task<bool> LoadValue(IDictionary<string, string> fields, string cCodiint);

        /// <summary>
        ///  Return the type
        /// </summary>
        IEnumerable<SupplierTypeViewObject> Type { set; get; }

        /// <summary>
        //  Brand data trasnfer object.
        /// </summary>
        IEnumerable<AccountViewObject> AccountDtos { get; set; }

        /// <summary>
        /// Model data transfer object.
        /// </summary>
        IEnumerable<ProvinceViewObject> ProvinceDtos { get; set; }

        /// <summary>
        ///  Color data transfer object.
        /// </summary>
        IEnumerable<BanksViewObject> BanksDtos { get; set; }

        // paises of the proveedor.
        IEnumerable<CountryViewObject> CountryDtos { get; set; }

        /// <summary>
        ///  ViasDto
        /// </summary>
        IEnumerable<ViaViewObject> ViasDtos { get; set; }
        
        /// <summary>
        ///  Months viewObject.
        /// </summary>
        IEnumerable<MonthsViewObject> MonthsDtos { set; get; }
        // PaymentDto.

        IEnumerable<PaymentFormViewObject> PaymentDtos { set; get; }
        IEnumerable<LanguageViewObject> LanguageDtos { get; set; }
        IEnumerable<CurrencyViewObject> CurrencyDtos { get; set; }
        IEnumerable<OfficeViewObject> OfficeDtos { get; set; }
        IEnumerable<CompanyViewObject> CompanyDtos { get; set; }
        ObservableCollection<CityViewObject> CityDtos { get; set; }
    }
}