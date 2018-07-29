using KarveDataServices.DataObjects;
namespace KarveDataServices
{
    /// <summary>
    ///  This a public interface for the API towards the database access.
    ///  It is an interface for abstracting all dataservices.
    /// <see href="http://www.shanekm.com/2016/04/29/stairway-pattern/">Stairway pattern</see>
    /// </summary>
    ///
    public interface IDataServices
    {
        /// <summary>
        /// Get th data service for managing all vehicle data operations
        /// </summary>
        /// <returns>Vehicle data service subsystem</returns>
        IVehicleDataServices GetVehicleDataServices();
        IBookingDataService GetBookingDataService();

        /// <summary>
        ///  Get the data service for managing all client data operations
        /// </summary>
        /// <returns> Client data service subsystem</returns>
        IClientDataServices GetClientDataServices();
        /// <summary>
        /// Get the data service for managing all supplier data operations
        /// </summary>
        /// <returns>Supplier data service subsystem</returns>
        ISupplierDataServices GetSupplierDataServices();
        /// <summary>
        ///  Get the data service for managing all settings data operations
        /// </summary>
        /// <returns></returns>
        ISettingsDataServices GetSettingsDataService();
        /// <summary>
        /// Get the helper data service. Helper data services all other services that might be used as helper
        /// </summary>
        /// <returns></returns>
        IHelperDataServices GetHelperDataServices();
        /// <summary>
        /// Get the commission agent for managing brokers.
        /// </summary>
        /// <returns>Commission agent data service</returns>
        ///
        ICommissionAgentDataServices GetCommissionAgentDataServices();
        /// <summary>
        /// Get the office data services.
        /// </summary>
        /// <returns></returns>
        IOfficeDataServices GetOfficeDataServices();
        /// <summary>
        ///  Company data services.
        /// </summary>
        /// <returns></returns>
        ICompanyDataServices GetCompanyDataServices();

        /// <summary>
        /// Get the data services for fetching a contract.
        /// </summary>
        /// <returns></returns>
        IContractDataServices GetContractDataServices();

        /// <summary>
        /// Get the invoice data service.
        /// </summary>
        /// <returns>The invoive data service</returns>
        IInvoiceDataServices GetInvoiceDataServices();

        /// <summary>
        ///  Return the data service.
        /// </summary>
        /// <typeparam name="T">Type the service</typeparam>
        /// <returns>Returns the data service</returns>
        T GetDataService<T>();
        /// <summary>
        ///  Start the reconfiguration of all the connections.
        ///  It reconfigure the connection string.
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        void Reconfigure(string connectionString);
       /// <summary>
       ///  Get the assist data service.
       /// </summary>
       /// <returns>Return the service for the assist get data services</returns>
       IAssistDataService GetAssistDataServices();
       /// <summary>
       ///  Get the fare data services.
       ///
       /// </summary>
       /// <returns></returns>
        IFareDataServices GetFareDataServices();
        /// <summary>
        ///  Get the reservatiobn request data service.
        /// </summary>
        /// <returns></returns>
        IReservationRequestDataService GetReservationRequestDataService();
        /// <summary>
        ///  Get the reservatiobn request data service.
        /// </summary>
        /// <returns></returns>
        I{{Name}}DataService Get{{Name}}DataService();
        ///END OF FILE
    }
}
