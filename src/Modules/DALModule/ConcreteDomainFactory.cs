using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer
{
    class ConcreteDomainFactory: AbstractDomainWrapperFactory
    {
        private IDataServices _services;
       
        private ConcreteDomainFactory(IDataServices services): base(services)
        {
            _services = services;
        }

        protected override AbstractDomainWrapperFactory CreateAbstractFactory(IDataServices services)
        {
                return new ConcreteDomainFactory(services);     
        }

        public override async Task<IClientData> CreateClientAsync(ClientDto dto)
        {
            IClientData data = await _services.GetClientDataServices().GetDoAsync(dto.NUMERO_CLI).ConfigureAwait(false);
            return data;
        }

        public override async Task<ISupplierData> CreateSupplierAsync(SupplierDto dto)
        {
            ISupplierData data = await _services.GetSupplierDataServices().GetAsyncSupplierDo(dto.NUM_PROVEE).ConfigureAwait(false);
            data.Value = dto;
            return data;
        }

        public override async Task<ICommissionAgent> CreateCommissionAgentAsync(ComisioDto dto)
        {
            ICommissionAgent agent = await _services.GetCommissionAgentDataServices().GetCommissionAgentDo(dto.NUM_COMI).ConfigureAwait(false);
            return agent;
        }
    }
}
