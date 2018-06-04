using System.Threading.Tasks;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using System.Collections.Generic;

namespace KarveDataServices
{
    /// <summary>
    ///  Abstract Domain Wrapper Factory. It is a factory for crafting and converting data transfer object 
    ///  in object that are able to be saved in the database.
    /// </summary>
    public class AbstractDomainWrapperFactory
    {
        private readonly IDataServices _services;
        private IClientDataServices _clientDataServices;
        private static AbstractDomainWrapperFactory value = null;
        // singleton factory for the domain.
        
        protected AbstractDomainWrapperFactory(IDataServices services)
        {
           BuildFactory(services);
            _services = services;
            _clientDataServices = _services.GetClientDataServices();
        }
        private void BuildFactory(IDataServices services)
        {

            if (value != null)
            {
                value = CreateAbstractFactory(services);
            }
        }
        /// <summary>
        ///  Returns the domain factory
        /// </summary>
        /// <param name="services">Services to be loaded.</param>
        /// <returns></returns>
        public static AbstractDomainWrapperFactory GetFactory(IDataServices services)
        {
            if (value == null)
            {
                value = new AbstractDomainWrapperFactory(services);
            }
            return value;
        }

        protected virtual AbstractDomainWrapperFactory CreateAbstractFactory(IDataServices services)
        {
            return new AbstractDomainWrapperFactory(services);
        }

        /// <summary>
        ///  Create a domain wrapper from a data transfer object. A domain wrapper has the responsability to handle ///thelifecycle of 
        /// a data transfer object.
        /// </summary>
        /// <param name="dto">Data transfer object for clients</param>
        /// <returns></returns>
        public virtual async Task<IClientData> CreateClientAsync(ClientDto dto)
        {
            IClientData data = await _services.GetClientDataServices().GetDoAsync(dto.NUMERO_CLI);
            return data;
        }
        /// <summary>
        ///  Create a domain wrapper for the supplier data transfer object.
        /// </summary>
        /// <param name="dto">Data Transfer object</param>
        /// <returns></returns>
        public virtual async Task<ISupplierData> CreateSupplierAsync(SupplierDto dto)
        {
            ISupplierData data = await _services.GetSupplierDataServices().GetAsyncSupplierDo(dto.NUM_PROVEE);
          
            return data;
        }
        /// <summary>
        ///  Create a client summary.
        /// </summary>
        /// <returns>A list of client summary extended.</returns>
        public virtual async Task<IEnumerable<ClientSummaryExtended>> CreateClientSummary()
        {
            return await _clientDataServices.GetSummaryAllAsync();
        }

        /// <summary>
        ///  Create a domain wrapper for the commission agent transfer object
        /// </summary>
        /// <param name="dto">Data Transfer Object.</param>
        /// <returns></returns>
        public virtual async Task<ICommissionAgent> CreateCommissionAgentAsync(ComisioDto dto)
        {
            ICommissionAgent data = await _services.GetCommissionAgentDataServices().GetCommissionAgentDo(dto.NUM_COMI);
            data.Value = dto;
            return data;
        }

        public IInvoiceData CreateInvoice(string s)
        {
            var services = _services.GetInvoiceDataServices();
            return services.GetNewDo(s);
        }
    }
}
