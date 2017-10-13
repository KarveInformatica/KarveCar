
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
        /// Returns the payment data services.
        /// </summary>
        /// <returns>Payment data service subsystem</returns>
        IPaymentDataServices GetPaymentDataService();
        /// <summary>
        /// Returns the vehicle data services.
        /// </summary>
        /// <returns>Vehicle data service subsystem</returns>       
        IVehicleDataServices GetVehicleDataServices();
        /// <summary>
        ///  Returns the interface that is needed for the suppliers.
        /// </summary>
        /// <returns>Supplier data service subsystem</returns>
        ISupplierDataServices GetSupplierDataServices();
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
    }

}
