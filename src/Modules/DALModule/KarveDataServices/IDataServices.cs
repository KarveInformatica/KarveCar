
using KarveDataServices.DataObjects;

namespace KarveDataServices
{
    /// <summary>
    ///  This a public interface for the API towards the database access.
    ///  It is an interface for abstracting all dataservices.
    /// <see href="http://www.shanekm.com/2016/04/29/stairway-pattern/">Stairway pattern</see>
    /// </summary>
   
    public interface IDataServices
    {
        /// <summary>
        /// Returns the vehicle data services.
        /// </summary>
        /// <returns>Vehicle data service subsystem</returns>       
        IVehicleDataServices GetVehicleDataServices();
        /// <summary>
        ///  Client data service.
        /// </summary>
        /// <returns></returns>
        IClientDataServices GetClientDataServices();

        /// <summary>
        ///  Returns the interface that is needed for the suppliers.
        /// </summary>
        /// <returns>Supplier data service subsystem</returns>
        ISupplierDataServices GetSupplierDataServices();
        /// <summary>
        ///  GetSettings data service.
        /// </summary>
        /// <returns></returns>
        ISettingsDataService GetSettingsDataService();
        /// <summary>
        /// Returns the Helper data services. Helper data services all other services that might be used as helper 
        /// </summary>
        /// <returns></returns>
        IHelperDataServices GetHelperDataServices();
        /// <summary>
        ///  Returns the commission agent data services. 
        /// </summary>
        /// <returns></returns>
        /// 
        ICommissionAgentDataServices GetCommissionAgentDataServices();
        /// <summary>
        ///  This will deprecate the above interfaces.
        /// </summary>
        /// <typeparam name="T">Type the service</typeparam>
        /// <returns></returns>
        T GetDataService<T>();
        /// <summary>
        ///  This returns a data service.
        /// </summary>
        /// <returns></returns>
        IAssistDataService GetAssistDataService();

    }

}
