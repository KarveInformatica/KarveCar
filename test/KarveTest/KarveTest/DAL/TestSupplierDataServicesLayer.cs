using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using DataAccessLayer;
using KarveDataServices;
using KarveDataServices.DataObjects;
using NUnit.Framework;
using KarveCommon.Services;
using System.Diagnostics;
using System.Threading;
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
        

        [OneTimeSetUp]
        public void SetUp()
        {
            _dataServices = null;
            _serviceConf = base.SetupConfigurationService();
            try
            {
                ISqlExecutor executor = SetupSqlQueryExecutor();
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
                for (int i = 0; i < 10; i++)
                {
                    set = await _supplierDataServices.GetAsyncAllSupplierSummary();
                    Assert.NotNull(set);
                    Assert.Greater(set.Tables.Count, 0);
                    Assert.NotNull(set.Tables[0]);
                    int rowCounts = set.Tables[0].Rows.Count;
                    Assert.Greater(set.Tables[0].Rows.Count, 0);
                    Assert.NotNull(set.Tables[0].Rows[0][0]);
                    for (int k = 0; k < rowCounts; ++k)
                    {
                        string value = set.Tables[0].Rows[k][0] as string;
                        Assert.NotNull(value);
                        Assert.LessOrEqual(value.Length, 7);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // <summary>
        // This is an asynchronous test where for each supplier we get the information for its supplierId.
        // </summary>
        // <returns></returns>
        [Test]
        public async Task Should_Give_SupplierCompleteSummary()
        {
            DataSet set = null;
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    set = await _supplierDataServices.GetAsyncSuppliers();
                    Assert.NotNull(set);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [Test]
        public void Should_Have_NewProviderId()
        {
            // the item shall be unique.
            List<string> idList = new List<string>();
            string item = "";
            for (int i = 0; i < 10; ++i)
            {
                item = _supplierDataServices.GetNewId();
                Assert.IsTrue(!idList.Contains(item));
                idList.Add(item);
            }
            Assert.AreEqual(idList.Count, 10);
        }


    }
}
