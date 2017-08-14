using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;

namespace KarveDataServices
{
    /// <summary>
    ///  common interface for the 
    /// </summary>
    public interface ISupplierDataServices
    {

        #region Asynchronous methods

        /// <summary>
        ///  Returns the dataset in asynchronous way for all suppliers.
        /// </summary>
        /// <returns></returns>
        Task<DataSet> GetAsyncAllSupplierSummary();
        /// <summary>
        /// This method returns a data set containing a datatable with all the suppliers.
        /// </summary>
        /// <returns></returns>
        Task<DataSet> GetAsyncAllSuppliers();
        /// <summary>
        ///  This method returns a data set containting an observable collection of supplier data object.
        /// A supplier data object maps the supplier table
        /// </summary>
        /// <returns></returns>
        Task<ObservableCollection<ISupplierDataObject>> GetAsyncAllSupplierDataObjects();
        /// <summary>
        /// This methods returns asynchrounsly the dataobjectinfo from an id.
        /// </summary>
        ///  
        Task<ISupplierDataObjectInfo> GetAsyncSupplierDataObjectInfo(string id);
        /// <summary>
        ///  Get all the provinces available in the database. 
        /// </summary>
        /// <returns></returns>
        Task<DataSet> GetAsyncAllProvinces();
        /// <summary>
        ///  Get all the provices data objects in the database.
        /// </summary>
        /// <returns></returns>
        ObservableCollection<object> GetAsyncAllProvinceDataObjects();
        #endregion 
        #region Synchronous methods
        /// <summary>
        ///  Method for retrieving all suppliers.
        /// </summary>
        DataSet GetAllSuppliers();
        /// <summary>
        /// Method for retrieving all suppliers data objects
        /// </summary>
        /// <returns></returns>
        ObservableCollection<object> GetAllSupplierDataObject();
        /// <summary>
        ///  Method for retrieving a supplier data object info from its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ISupplierDataObjectInfo GetSupplierDataObjectInfo(string id);
        /// <summary>
        ///  Method for retrieving all the supplier types
        /// </summary>
        /// <returns></returns>
        DataTable GetSupplierTypes();
        /// <summary>
        ///  Get all suppliers for country
        /// </summary>
        /// <param name="id"> Identificator for the supplier</param>
        /// <returns></returns>
        ICountryDataObject GetSupplierCountry(string id);
        /// <summary>
        ///  Method for retrieving all the countries and their codes.
        /// </summary>
        /// <returns></returns>
        DataSet GetAllCountries();
        /// <summary>
        ///  Method for retrieving all the contries data objects.
        /// </summary>
        /// <returns></returns>
        ObservableCollection<ICountryDataObject> GetAllCountriesCountryDataObjects();
        /// <summary>
        /// Get all provines 
        /// </summary>
        /// <returns>A dataset with all provinves</returns>
        DataSet GetAllProvinces();
        /// <summary>
        ///  Get all provinces data objects.
        /// </summary>
        /// <returns>An observable collection with all provices data objects</returns>
        ObservableCollection<IProvinceDataObject> GetAllProvinceDataObjects();

        #endregion
    }
}
