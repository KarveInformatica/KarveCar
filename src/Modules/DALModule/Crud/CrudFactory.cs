using AutoMapper;
using DataAccessLayer.Crud.Clients;
using DataAccessLayer.Crud.Office;
using DataAccessLayer.Logic;
using KarveDataServices;
using KarveDataServices.ViewObjects;
namespace DataAccessLayer.Crud
{
    /// <summary>
    ///  The rational for this is having a single point to create every kind of loader or saver.
    /// </summary>
    public class CrudFactory
    {
        private ISqlExecutor _executor;
        private IMapper _mapper;

        private CrudFactory(ISqlExecutor executor)
        {
            _mapper = MapperField.GetMapper();
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
        public IDataLoader<ClientViewObject> ClientLoader => new ClientDataLoader(_executor);
        /// <summary>
        ///  client saver
        /// </summary>
        /// <returns></returns>
        public IDataSaver<ClientViewObject> ClientSaver => new Clients.ClientDataSaver(_executor);

        /// <summary>
        /// Client deleter
        /// </summary>
        /// <returns></returns>
        public IDataDeleter<ClientViewObject> ClientDeleter => new Clients.ClientDeleter(_executor);

        /// <summary>
        ///  Office deleter
        /// </summary>
        /// <returns></returns>
        public IDataDeleter<OfficeViewObject> GetOfficeDeleter() => new OfficeDataDeleter(_executor, _mapper);

        /// <summary>
        /// Office loader factory
        /// </summary>
        /// <returns>Return an office loader. That has the resposability of load offices</returns>
        public IDataLoader<OfficeViewObject> GetOfficeLoader() => new OfficeDataLoader(_executor, _mapper);
        /// <summary>
        ///  office saver.
        /// </summary>
        /// <returns></returns>
        public IDataSaver<OfficeViewObject> GetOfficeSaver() => new OfficeDataSaver(_executor, _mapper);
        
    }
}
