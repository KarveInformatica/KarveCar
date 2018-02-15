using DataAccessLayer.Crud.Clients;
using DataAccessLayer.Crud.Office;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
namespace DataAccessLayer.Crud
{
    /// <summary>
    ///  The rational for this is having a single point to create every kind of loader or saver.
    /// </summary>
    public class CrudFactory
    {
        private ISqlExecutor _executor;

        private CrudFactory(ISqlExecutor executor)
        {
            _executor = executor;
        }
        public static CrudFactory GetFactory(ISqlExecutor executor)
        {
           
            return new CrudFactory(executor);
        }
        /// <summary>
        /// Client loader.
        /// </summary>
        /// <returns>An interface for loading the entities..</returns>
        public IDataLoader<ClientDto> ClientLoader => new ClientDataLoader(_executor);

        /// <summary>
        ///  client saver
        /// </summary>
        /// <returns></returns>
        public IDataSaver<ClientDto> ClientSaver => new Clients.ClientDataSaver(_executor);

        /// <summary>
        /// Client deleter
        /// </summary>
        /// <returns></returns>
        public IDataDeleter<ClientDto> ClientDeleter => new Clients.ClientDeleter(_executor);

        /// <summary>
        ///  Office deleter
        /// </summary>
        /// <returns></returns>
        public IDataDeleter<OfficeDtos> GetOfficeDeleter() => new OfficeDataDeleter(_executor);

        /// <summary>
        /// Office loader factory
        /// </summary>
        /// <returns>Return an office loader. That has the resposability of load offices</returns>
        public IDataLoader<OfficeDtos> GetOfficeLoader()
        {
            return new OfficeDataLoader(_executor);
        }
        /// <summary>
        ///  office saver.
        /// </summary>
        /// <returns></returns>
        public IDataSaver<OfficeDtos> GetOfficeSaver()
        {
            return new OfficeDataSaver(_executor);
        }
        
    }
}
