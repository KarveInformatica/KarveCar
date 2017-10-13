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
        private INotifyTaskCompletion<DataSet> _initializationNotifier;
        private bool _notificationResult = false;

        private const string ConnectionString = "EngineName=DBRENT_NET16;DataBaseName=DBRENT_NET16;Uid=cv;Pwd=1929;Host=172.26.0.45";
        

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

        [Test]
        public void LoadAndNotify()
        {
            _notificationResult = false;

            //_initializationNotifier = NotifyTaskCompletion.Create<DataSet>(_supplierDataServices.GetAsyncAllSupplierSu);
            
            _initializationNotifier.PropertyChanged += InitializationNotifierOnPropertyChanged;
            Assert.IsTrue(_notificationResult);
        }

        private void InitializationNotifierOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (_initializationNotifier.IsSuccessfullyCompleted)
            {
                _notificationResult = true;
            
            }
            else
            {
                _notificationResult = false;
            
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
