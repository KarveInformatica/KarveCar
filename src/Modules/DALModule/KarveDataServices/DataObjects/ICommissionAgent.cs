using System.Collections.Generic;
using System.Threading.Tasks;
using KarveDataServices.ViewObjects;

namespace KarveDataServices.DataObjects
{
    /// <summary>
    /// The commission interface. It is a wrapper over the pocos.
    /// 
    /// </summary>
    public interface ICommissionAgent: IHelperMasterCommon, IValidDomainObject,  IValueObject<ComisioViewObject>
    {
        /// <summary>
        ///  Data transfer object for province
        /// </summary>
        IEnumerable<ProvinceViewObject> ProvinceDto { set; get; }

        /// A commission agent can be in one city. City data transfer object.
        IEnumerable<CityViewObject> CityDtos { get; set; }

        /// <summary>
        /// Country Data Transfer Object
        /// </summary>
        IEnumerable<CountryViewObject> CountryDto { get; set; }
        /// <summary>
        /// Products Data Transfer Object
        /// </summary>
        IEnumerable<ProductsViewObject> ProductsDto { get; set; }
        /// <summary>
        ///  Language Data Transfer Object
        /// </summary>
        IEnumerable<LanguageViewObject> LanguageDto { get; set; }
        /// <summary>
        /// Commission Type Data Transfer Object.
        /// </summary>
        IEnumerable<CommissionTypeViewObject> CommisionTypeDto { get; set; }
        /// <summary>
        /// Clients Data Transfer Object.
        /// </summary>
        IEnumerable<ResellerViewObject> VendedorDto { get; set; }
        /// <summary>
        /// Mercado Data Transfer Object
        /// </summary>
        IEnumerable<MarketViewObject> MercadoDto { get; set; }
        /// <summary>
        ///  Negocio Data Transfer Object
        /// </summary>
        IEnumerable<BusinessViewObject> NegocioDto { get; set; }
        /// <summary>
        ///  Canal Data Transfer Object
        /// </summary>
        IEnumerable<ChannelViewObject> CanalDto { get; set; }
        /// <summary>
        ///  Clave Data Transfer Object
        /// </summary>
        IEnumerable<BudgetKeyViewObject> ClavePptoDto { get; set; }
        /// <summary>
        /// Clientes data transfer object.
        /// </summary>
        IEnumerable<ClientViewObject> ClientsDto { get; set; }
        
        /// <summary>
        /// Origen data transfer object.
        /// </summary>
        IEnumerable<OrigenViewObject> OrigenDto { get; set; }
        /// <summary>
        /// Cliente data transfer object.
        /// </summary>
        IEnumerable<ZonaOfiViewObject> ZonaOfiDto { get; set; }

        /// <summary>
        /// Visit type viewObject.
        /// </summary>
        IEnumerable<VisitTypeViewObject> VisitTypeDto { get; set; }
        /// <summary>
        ///  This load the value for the current commission agent.
        /// </summary>
        /// <param name="commissionDictionary">Fields to be loaded</param>
        /// <param name="commissionId">Identifier to be loaded. Primary Key</param>
        /// <returns>Returns the result of loading.</returns>
        Task<bool> LoadValue(IDictionary<string, string> commissionDictionary, string commissionId);
        /// <summary>
        ///  This save a new generated item.
        /// </summary>
        /// <returns>Return true if the new generated item a fresh one is saved.</returns>
        Task<bool> Save();
        /// <summary>
        /// This saves the changes of a commission item. Use this method if it is appropriate to do an update. 
        /// </summary>
        Task<bool> SaveChanges();
        /// <summary>
        ///  This method deletes all data asynchronous for the commission agent.
        /// </summary>
        /// <returns>Return delete or an exception if the data are deleted correctly</returns>
        Task<bool> DeleteAsyncData();
    }
}