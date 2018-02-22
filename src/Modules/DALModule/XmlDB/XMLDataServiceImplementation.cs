using KarveDataServices;
using System;

namespace DataAccessLayer.XmlDB
{
    /// <summary>
    ///  XMLDataService is a dummy database implementation for testing.
    ///  It mocks the database with xml values.
    /// </summary>
    public class XMLDataServiceImplementation : IDataServices
    {
        public XMLDataServiceImplementation() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public IAssistDataService GetAssistDataService()
        {
            return new XmlAssistDataService();
        }

        public IClientDataServices GetClientDataServices()
        {
            return new XmlClientDataService();
        }

        public ICommissionAgentDataServices GetCommissionAgentDataServices()
        {
            return new XmlComissionAgentDataService();
        }

        public ICompanyDataService GetCompanyDataServices()
        {
            throw new XmlCompanyDataService() ;
        }

        public T GetDataService<T>()
        {
            var value = (T)Activator.CreateInstance(typeof(T));
            return value; 
        }

        public IHelperDataServices GetHelperDataServices()
        {
            return new XmlHelperDataService();
        }

        public IOfficeDataServices GetOfficeDataServices()
        {
           return new XmlOfficeDataService();
        }

        public ISettingsDataService GetSettingsDataService()
        {
           return new XmlSettingsDataService();
        }

        public ISupplierDataServices GetSupplierDataServices()
        {
            return new XmlSupplierDataService();
        }

        public IVehicleDataServices GetVehicleDataServices()
        {
            return new XmlVehicleDataServices();
        }
    }

}