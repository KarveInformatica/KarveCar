using KarveDataServices.DataObjects;
using System.Threading.Tasks;
using KarveDataServices.DataTransferObject;
using System.Collections.ObjectModel;

namespace DataAccessLayer.Model
{
    /// <summary>
    ///  Null client is an empty object.
    /// </summary>
    public class NullClient : DomainObject, IClientData
    {
       private ClientesDto _clientesDto = new ClientesDto();
        /// <summary>
        ///  Null client.s
        /// </summary>
        public NullClient()
        {
            Valid = false;
        }
        /// <summary>
        ///  Value is the value of the clients.
        /// </summary>
        public ClientesDto Value
        {
            get => _clientesDto;
            set { _clientesDto = value; }
        }
        /// <summary>
        ///  Valid
        /// </summary>
        public bool Valid
        {
            get; set;
        }

        public ObservableCollection<ProvinciaDto> ProvinciaDto => throw new System.NotImplementedException();

        public ObservableCollection<CountryDto> CountryDto => throw new System.NotImplementedException();

        public ObservableCollection<CityDto> CityDto => throw new System.NotImplementedException();

        public ObservableCollection<ClientZoneDto> ZoneDto => throw new System.NotImplementedException();

        public ObservableCollection<OrigenDto> OrigenDto => throw new System.NotImplementedException();

        public ObservableCollection<ComisioDto> BrokerDto => throw new System.NotImplementedException();

        public ObservableCollection<MercadoDto> ClientMarketDto { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public ObservableCollection<ResellerDto> ResellerDto => throw new System.NotImplementedException();

        public ObservableCollection<ClientTypeDto> ClientTypeDto => throw new System.NotImplementedException();

        /// <summary>
        ///  Delete asynchronous value.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DeleteAsync()
        {
            await Task.Delay(1);
            return false; 
        }
        /// <summary>
        ///  Load codigo desde il valore
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<bool> LoadValue(string code)
        {
            await Task.Delay(1);
            return false;
        }
        /// <summary>
        // Save the data.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveAll()
        {
            await Task.Delay(1);
            return false;
        }
    }
}
