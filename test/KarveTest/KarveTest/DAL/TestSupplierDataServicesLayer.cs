using System;
using System.Data;
using System.Threading.Tasks;
using DataAccessLayer;
using KarveDataServices;
using KarveDataServices.DataObjects;
using NUnit.Framework;
using KarveCommon.Services;
using System.Diagnostics;

namespace KarveTest.DAL
{
    [TestFixture]
    public class TestSupplierDataServicesLayer
    {
        private IDataServices _dataServices;
        private ISupplierDataServices _supplierDataServices;
        private IConfigurationService _serviceConf;
        private Stopwatch _currentStopWatch;
        private string _baseSupplierId = "";
        /// <summary>
        ///  Returns a supplierId
        /// </summary>
        /// <returns></returns>

        [OneTimeSetUp]
        public void SetUp()
        {
            _dataServices = null;
            _currentStopWatch = new Stopwatch();
            try
            {
                IKarveDataMapper mapper = new BaseDataMapper();
                IConfigurationService configService = new KarveCar.Logic.ConfigurationService();
                _dataServices = new DataServiceImplementation(mapper, configService);
                _supplierDataServices = _dataServices.GetSupplierDataServices();
                _baseSupplierId = GetSingleSupplierId(_supplierDataServices);
                _serviceConf = new KarveCar.Logic.ConfigurationService();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        private string GetSingleSupplierId(ISupplierDataServices dataService)
        {
            string supplierId = "";
            long paged = 2;
            DataSet ds = dataService.GetSuppliersSummaryPaged(paged);
            DataTable table = ds.Tables[0];
            supplierId = GetSupplierIdFromRows(table.Rows);
            return supplierId;
        }
        private string GetSupplierIdFromRows(DataRowCollection rows)
        {
            DataRow row = rows[0];
            Assert.NotNull(row["Numero"]);
            string supplierId = row["Numero"] as string;
            return supplierId;
        }
        ///
        ///  <summary> This return the complete async command summary </summary>
        ///  
        [Test]
        public async Task Should_Give_CompleteSummary()
        {
            _currentStopWatch.Start();
            try
            {
                DataSet set = await _supplierDataServices.GetAsyncCompleteSummary();

                CheckSingleSupplier(set.Tables);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            _currentStopWatch.Stop();
            TestContext.Out.WriteLine("Elapsed={0}", _currentStopWatch.Elapsed);
        }
        /// <summary>
        ///  This returns the all suppliers.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Should_Give_AllSuppliers()
        {
            _currentStopWatch.Start();
            DataSet set = await _supplierDataServices.GetAsyncAllSupplierSummary();
            _currentStopWatch.Stop();
            CheckSingleSupplier(set.Tables);
            TestContext.Out.WriteLine("Elapsed={0}", _currentStopWatch.Elapsed);
        }

        /// <summary>
        /// Given a provider it shall return the type information for that supplier.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Should_Give_SuppliersTypes()
        {

            ISupplierTypeData supplierTypes = null;
            DataSet set = null;
            _currentStopWatch.Start();

            try
            {
                set = await _supplierDataServices.GetAsyncAllSupplierSummary();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Assert.Fail("Failed");
            }
            Assert.NotNull(set);
            try
            {
                CheckSingleSupplier(set.Tables);
                string supplierId = GetSupplierIdFromRows(set.Tables[0].Rows);
                supplierTypes = await _supplierDataServices.GetAsyncSupplierTypesDataObject(supplierId);
                Assert.NotNull(supplierTypes);
            }
            catch (Exception e)
            {
                Assert.NotNull(e.Message);
            }
            Assert.NotNull(supplierTypes);
            _currentStopWatch.Stop();
            TestContext.Out.WriteLine("Elapsed={0}", _currentStopWatch.Elapsed);

        }
        /// <summary>
        /// This returns the supplier async provider type
        /// </summary>
        [Test]
        public async Task Should_Return_A_SupplierTipoComp()
        {
            DataSet set = null;
            _currentStopWatch.Start();
            set = await _supplierDataServices.GetAsyncProviderType(_baseSupplierId);
            _currentStopWatch.Stop();
            TestContext.Out.WriteLine("Elapsed={0}", _currentStopWatch.Elapsed);
            CheckSingleSupplier(set.Tables);
        }
        [Test]
        public async Task Should_Return_Delegations()
        {
            DataSet set = null;
            _currentStopWatch.Start();
            try
            {
                set = await _supplierDataServices.GetAsyncDelegations(_baseSupplierId);
            }
            catch (Exception e)
            {
                TestContext.Out.WriteLine(e.StackTrace);
                Assert.Fail("Failed");
            }
            _currentStopWatch.Stop();
            TestContext.Out.WriteLine("Elapsed={0}", _currentStopWatch.Elapsed);
            if (set != null)
            {
                CheckSingleSupplier(set.Tables);
            }
        }
        [Test]
        public async Task Should_Not_Return_Delegations()
        {
            DataSet set = null;
            _currentStopWatch.Start();
            try
            {
                set = await _supplierDataServices.GetAsyncDelegations("X");
                Assert.Greater(set.Tables.Count, 0);
            }
            catch (Exception e)
            {
                TestContext.Out.WriteLine(e.StackTrace);
            }
            _currentStopWatch.Stop();
            if (set != null)
            {
                Assert.Fail();
            }
            TestContext.Out.WriteLine("Elapsed={0}", _currentStopWatch.Elapsed);
        }
        /// <summary>
        ///  This returns the visits.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Should_Return_Visits()
        {
            DataSet set = null;
            _currentStopWatch.Start();
            try
            {
                set = await _supplierDataServices.GetAsyncVisits(_baseSupplierId);
                Assert.Greater(set.Tables.Count, 0);
            }
            catch (Exception e)
            {
                TestContext.Out.WriteLine(e.StackTrace);
            }
            _currentStopWatch.Stop();
            TestContext.Out.WriteLine("Elapsed={0}", _currentStopWatch.Elapsed);
        }
        /// <summary>
        /// This return the evaluation notes for a given supplier.
        /// </summary>
        [Test]
        public async Task Should_Return_An_EvaluatioNote()
        {
            DataSet note = null;
            _currentStopWatch.Start();
            try
            {
                note = await _supplierDataServices.GetEvaluationNote(_baseSupplierId);
                Assert.Greater(note.Tables.Count, 0);
            }
            catch (Exception e)
            {
                TestContext.Out.WriteLine(e.StackTrace);
            }
            _currentStopWatch.Stop();
            TestContext.Out.WriteLine("Elapsed={0}", _currentStopWatch.Elapsed);
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
                TestContext.Out.WriteLine(e.StackTrace);
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
                    ISupplierDataInfo dataObjectInfo = await _supplierDataServices.GetAsyncSupplierDataObjectInfo(supplierId);
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
            ISupplierDataInfo dataObjectInfo = null;
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
        /// It shall return a valid supplier by its if. 
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Should_Return_A_Valid_Supplier_ById()
        {
            string id = await SelectFirstId().ConfigureAwait(false);
            Assert.IsEmpty(id);
            try
            {
                ISupplierTypeData typeData = await _supplierDataServices.GetAsyncSupplierTypeById(id);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        public async Task Should_Retrieve_And_Update_Simple()
        {
            // retreived dataInfo from base_id;
            IEnviromentVariables env = _serviceConf.GetEnviromentVariables();
            ISupplierDataInfo dataInfo = await _supplierDataServices.GetAsyncSupplierDataObjectInfo(_baseSupplierId).ConfigureAwait(false);
            ISupplierTypeData dataType = await _supplierDataServices.GetAsyncSupplierTypeById(_baseSupplierId).ConfigureAwait(false);
            ISupplierAccountObjectInfo ao = await _supplierDataServices.GetAsyncSupplierAccountInfo(_baseSupplierId, env).ConfigureAwait(false);
            DataSet monitoringData = await _supplierDataServices.GetAsyncMonitoring(_baseSupplierId).ConfigureAwait(false);
            DataSet delegationData = await _supplierDataServices.GetAsyncDelegations(_baseSupplierId).ConfigureAwait(false);
            DataSet evaluationData = await _supplierDataServices.GetAsyncEvaluationNote(_baseSupplierId).ConfigureAwait(false);
            DataSet transportProviderData = await _supplierDataServices.GetAsyncTransportProviderData(_baseSupplierId).ConfigureAwait(false);
            DataSet assuranceProviderData = await _supplierDataServices.GetAsyncSupplierAssuranceData(_baseSupplierId).ConfigureAwait(false);
            DataSet contactsProviderData = await _supplierDataServices.GetAsyncSupplierContacts(_baseSupplierId).ConfigureAwait(false);
            DataSet visitsProviderData = await _supplierDataServices.GetAsyncVisits(_baseSupplierId).ConfigureAwait(false);
            bool result = false;
            try
            {
                result = await _supplierDataServices.Update(dataInfo,
                                                   dataType,
                                                    ao,
                                                monitoringData,
                               evaluationData,
                               transportProviderData,
                                assuranceProviderData,
                                contactsProviderData,
                                visitsProviderData,
                                true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        public async Task Should_Return_Full_Supplier_Paged()
        {
            DataSet set = null;
            try
            {
                set = await _supplierDataServices.GetAsyncSuppliersSummaryPaged();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }


        /// <summary>
        [Test]
        private async Task<string> SelectFirstId()
        {
            DataSet set = null;
            string supplierId = "";
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
                DataRow row = table.Rows[0];
                Assert.NotNull(row["Numero"]);
                supplierId = row["Numero"] as string;
            }
            return supplierId;
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
