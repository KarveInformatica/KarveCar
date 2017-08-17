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
using KarveDataServices.DataObjects;
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
        /// <summary>
        ///  This is an asynchronous test where for each supplier we get the information for its supplierId.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Should_Give_SupplierInfo_Given_A_SupplierId()
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
                int count = table.Rows.Count;
                Assert.GreaterOrEqual(count, 1);
                for (int i = 0; i < count; ++i)
                {
                    DataRow row = table.Rows[i];
                    Assert.NotNull(row["Numero"]);
                    string supplierId = row["Numero"] as string;
                    ISupplierDataObjectInfo dataObjectInfo =  await _supplierDataServices.GetAsyncSupplierDataObjectInfo(supplierId);
                    Assert.NotNull(dataObjectInfo);
                }
            }
           
        }

        /// <summary>
        ///  This test shall not give a provider at all.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Should_Not_Give_A_Valid_Supplier()
        {
            string supplierId = "-1";
            ISupplierDataObjectInfo dataObjectInfo = null;
            try
            {
                dataObjectInfo =
                    await _supplierDataServices.GetAsyncSupplierDataObjectInfo(supplierId);
            }
            catch (Exception e)
            {
                Assert.NotNull(e.Message);
            }
            Assert.Null(dataObjectInfo);
        }
         /// <summary>
         /// All providers shall be a table in a DataSet with all fields not null.
         /// </summary>
         /// <returns></returns>
        [Test]
        public async Task Should_Be_All_Not_Null_Fields_Suppliers()
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
                int count = table.Rows.Count;
                Assert.GreaterOrEqual(count, 1);
                for (int i = 0; i < count; ++i)
                {
                    DataRow row = table.Rows[i];
                    Assert.NotNull(row["Numero"]);
                    Assert.NotNull(row["Nombre"]);
                    Assert.NotNull(row["Nif"]);

                }
            }
            return;
        }
    }
}
