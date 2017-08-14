using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataAccessLayer;
using KarveCar.View;
using KarveDataServices;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using Prism.Unity;

namespace KarveTest.DAL
{
    [TestFixture]
    public class TestProvidersDataLayer
    {
        private IDataServices _dataServices;
        private ISupplierDataServices _supplierDataServices;

        [OneTimeSetUp]
        public void SetUp()
        {
            _dataServices = null;
            try
            {
                _dataServices = new DataServiceImplementation();
                _supplierDataServices = _dataServices.GetSupplierDataServices();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public async Task Should_Be_More_Than_OneSupplier()
        {
            DataSet set = null;
            
            try
            {
                set = await _supplierDataServices.GetAsyncAllSupplierSummary();
            }
            catch (Exception e)
            {
               Console.WriteLine(e.StackTrace);
                Assert.Fail("Failed");
            }
           // ok we have the data.
            if (set != null)
            {
                DataTable table = set.Tables[0];
                // we shall see the fields.
                int count = table.DefaultView.Count;
                Assert.GreaterOrEqual(count, 1);
                DataColumnCollection cols = table.Columns;
                foreach (DataColumnCollection col in cols)
                {
                  
                }
            }
            return;
        }
    }
}
