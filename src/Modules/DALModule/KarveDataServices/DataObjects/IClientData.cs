using KarveDataServices.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace KarveDataServices.DataObjects
{
    /// <summary>
    ///  This inteface specifies the interface to a model wrapper 
    ///  that allows to write, save, load all the entities related 
    ///  to a model domain element.
    ///  In this case is the client. 
    /// </summary>
    public interface IClientData
    {
        /// <summary>
        /// Load value
        /// </summary>
        /// <param name="code">Client code primary key</param>
        /// <returns></returns>
        Task<bool> LoadValue(string code);
        /// <summary>
        ///  This returns in case of saving a sigle client.
        /// </summary>
        /// <returns>true if the it has been successfully saved.</returns>
        Task<bool> SaveAll();
        /// <summary>
        /// <summary>
        /// ClientData Data.
        /// </summary>
        ClientesDto Value { set; get; }
        /// <summary>
        ///  This tells us if the data is valid or not.
        /// </summary>
        bool Valid { get; set; }
        /// <summary>
        ///  Helpers.
        /// </summary>
        /// <returns></returns>
        Task<bool> DeleteAsync();
        /// Value object related to this.
        /// <summary>
        ///  Provincia.
        /// </summary>
        ObservableCollection<ProvinciaDto> ProvinciaDto { get; }
        /// <summary>
        ///  Country.
        /// </summary>
        ObservableCollection<CountryDto> CountryDto { get; }
        /// <summary>
        /// City
        /// </summary>
        ObservableCollection<CityDto> CityDto { get; }
        /// <summary>
        /// Zone
        /// </summary>
        ObservableCollection<ClientZoneDto> ZoneDto { get; }
        /// <summary>
        ///  Origen
        /// </summary>
        ObservableCollection<OrigenDto> OrigenDto { get; }
       /// <summary>
       ///  Broker
       /// </summary>
        ObservableCollection<ComisioDto> BrokerDto { get; }
        /// <summary>
        ///  ClientMarket
        /// </summary>
        ObservableCollection<MercadoDto> ClientMarketDto { get; set; }
        ObservableCollection<ResellerDto> ResellerDto { get; }
        ObservableCollection<ClientTypeDto> ClientTypeDto { get; }
    }

}
