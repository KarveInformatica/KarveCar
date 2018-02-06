using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Model;
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

        public override async Task<IClientData> CreateClientAsync(ClientesDto dto)
        {
            IClientData data = await _services.GetClientDataServices().GetAsyncClientDo(dto.NUMERO_CLI);
            return data;
        }

        public override async Task<ISupplierData> CreateSupplierAsync(SupplierDto dto)
        {
            ISupplierData data = await _services.GetSupplierDataServices().GetAsyncSupplierDo(dto.NUM_PROVEE);
            data.Value = dto;
            return data;
        }

        public override async Task<ICommissionAgent> CreateCommissionAgentAsync(ComisioDto dto)
        {
            ICommissionAgent agent = await _services.GetCommissionAgentDataServices().GetCommissionAgentDo(dto.NUM_COMI);
            return agent;
        }
    }
}
