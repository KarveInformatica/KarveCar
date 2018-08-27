using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;

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

        public override async Task<IClientData> CreateClientAsync(ClientViewObject viewObject)
        {
            IClientData data = await _services.GetClientDataServices().GetDoAsync(viewObject.NUMERO_CLI).ConfigureAwait(false);
            return data;
        }

        public override async Task<ISupplierData> CreateSupplierAsync(SupplierViewObject viewObject)
        {
            ISupplierData data = await _services.GetSupplierDataServices().GetAsyncSupplierDo(viewObject.NUM_PROVEE).ConfigureAwait(false);
            data.Value = viewObject;
            return data;
        }

        public override async Task<ICommissionAgent> CreateCommissionAgentAsync(ComisioViewObject viewObject)
        {
            ICommissionAgent agent = await _services.GetCommissionAgentDataServices().GetCommissionAgentDo(viewObject.NUM_COMI).ConfigureAwait(false);
            return agent;
        }
    }
}
