using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFDataGridExamples.DataAccessLayer
{
    public interface ICustomerDataAccessLayer
    {
        /// <summary>
        /// Return all the persistent customers
        /// </summary>
        List<CustomerDataObject> GetCustomers();

        /// <summary>
        /// Updates or adds the given customer
        /// </summary>
        void UpdateCustomer(CustomerDataObject customer);

        /// <summary>
        /// Delete the given customer
        /// </summary>
        void DeleteCustomer(CustomerDataObject customer);
    }
}
