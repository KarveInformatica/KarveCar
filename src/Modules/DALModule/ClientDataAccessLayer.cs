using System.Collections.Generic;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;


namespace DataAccessLayer
{
    /*
     *  This class has the responsability of loading and delting, creating a new client.
     *  It use interface segregation principle for decoupling the delete from the load.
     */
    internal class ClientDataAccessLayer : IClientDataServices
    {
        private ISqlExecutor sqlExecutor;
        private IDataDeleter<IClientData> _dataDeleter;
        private IDataLoader<IClientData> dataLoader;

        public ClientDataAccessLayer(ISqlExecutor sqlExecutor)
        {
            this.sqlExecutor = sqlExecutor;
          
        }

        public async Task<bool> DeleteClient(IClientData commissionAgent)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<IClientData>> GetClientAsyncSummaryDo()
        {
            throw new System.NotImplementedException();
        }

        public IClientData GetNewClientAgentDo()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Save(IClientData clientData)
        {
            throw new System.NotImplementedException();
        }
    }
}