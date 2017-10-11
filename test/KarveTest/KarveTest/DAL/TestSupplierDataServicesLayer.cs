using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DataAccessLayer;
using KarveDataServices;
using KarveDataServices.DataObjects;
using NUnit.Framework;
using KarveCommon.Services;
using System.Diagnostics;
using KarveCommon.Generic;

namespace KarveTest.DAL
{
    [TestFixture]
    public class TestSupplierDataServicesLayer: TestBase
    {
        private IDataServices _dataServices;
        private ISupplierDataServices _supplierDataServices;
        private IConfigurationService _serviceConf;
       
        private const string ConnectionString = "EngineName=DBRENT_NET16;DataBaseName=DBRENT_NET16;Uid=cv;Pwd=1929;Host=172.26.0.45";

        ///// <summary>
        /////  Returns a supplierId
        ///// </summary>
        ///// <returns></returns>
        //private async Task<string> SelectFirstId()
        //{
        //    DataSet set = null;
        //    string supplierId="";
        //    try
        //    {
        //        set = await _supplierDataServices.GetAsyncAllSupplierSummary();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.StackTrace);
        //        Assert.Fail("Failed");
        //    }
        //    // ok we have the data.
        //    if (set != null)
        //    {
        //        DataTable table = set.Tables[0];
        //        // we shall see the fields.
        //        int count = table.Rows.Count;
        //        Assert.GreaterOrEqual(count, 1);
        //        DataRow row = table.Rows[0];
        //        Assert.NotNull(row["Numero"]);
        //        supplierId = row["Numero"] as string;
        //    }
        //    return supplierId;
        //}
        [OneTimeSetUp]
        public void SetUp()
        {
            _dataServices = null;
            _serviceConf = base.SetupConfigurationService();
            try
            {
                ISqlQueryExecutor executor = SetupSqlQueryExecutor();
               _dataServices = new DataServiceImplementation(executor,_serviceConf);
                _supplierDataServices = _dataServices.GetSupplierDataServices();
            }
           catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        // <summary>
        // This is an asynchronous test where for each supplier we get the information for its supplierId.
        // </summary>
        // <returns></returns>
        [Test]
        public async Task Should_Give_SupplierSummary()
        {
            DataSet set = null;
            try
            {
                set = await _supplierDataServices.GetAsyncAllSupplierSummary();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [Test]
        public void Should_Have_NewId()
        {
            // this shall be fixed.
            List<string> idList = new List<string>();
            for(int i = 0; i < 10; ++i)
            {
                string item = _supplierDataServices.GetNewId();
            }
        }

        
        private void CheckSingleSupplier(DataTableCollection tables)
        {
            Assert.Greater(tables.Count, 0);
            DataTable table = tables[0];
            Assert.Greater(table.Rows.Count, 0);
            DataRow row = table.Rows[0];
            Assert.NotNull(row["Numero"]);
        }

    }
}
