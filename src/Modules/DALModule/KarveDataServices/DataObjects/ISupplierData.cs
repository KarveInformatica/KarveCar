using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using KarveDataServices.DataTransferObject;

namespace KarveDataServices.DataObjects
{
    /// <summary>
    ///  Interface for giving information about suppliers.
    /// </summary>
    /// 
    public interface ISupplierData
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
        /// Vehicle Data.
        /// </summary>
        SupplierDto Value { set; get; }

        /// <summary>
        ///  This tells us if the data is valid or not.
        /// </summary>
        bool Valid { get; set; }

        IEnumerable<ISupplierTypeData> Type { set; get; }

        /// <summary>
        //  Brand data trasnfer object.
        /// </summary>
        IEnumerable<AccountDto> AccountDtos { get; set; }

        /// <summary>
        /// Model data transfer object.
        /// </summary>
        IEnumerable<ProvinciaDto> ProvinciaDtos { get; set; }

        /// <summary>
        ///  Color data transfer object.
        /// </summary>
        IEnumerable<BanksDto> BanksDtos { get; set; }

        // paises of the proveedor.
        IEnumerable<CountryDto> CountryDtos { get; set; }

        /// <summary>
        ///  ViasDto
        /// </summary>
        IEnumerable<ViaDto> ViasDtos { get; set; }

        /// <summary>
        ///  Branches
        /// </summary>
        IEnumerable<BranchesDto> BranchesDtos { set; get; }

        /// <summary>
        ///  Contacts
        /// </summary>
        IEnumerable<ContactsDto> ContactsDtos { set; get; }

        /// <summary>
        ///  Months dto.
        /// </summary>
        IEnumerable<MonthsDto> MonthsDtos { set; get; }
        // PaymentDto.

        IEnumerable<PaymentFormDto> PaymentDtos { set; get; }
        IEnumerable<VisitsDto> VisitsDtos { get; set; }
        IEnumerable<LanguageDto> LanguageDtos { get; set; }
        IEnumerable<CurrencyDto> CurrencyDtos { get; set; }
        IEnumerable<OfficeDtos> OfficeDtos { get; set; }
        IEnumerable<CompanyDto> CompanyDtos { get; set; }
        ObservableCollection<CityDto> CityDtos { get; set; }
    }
}