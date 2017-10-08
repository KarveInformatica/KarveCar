using System;
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
        private Stopwatch _currentStopWatch;

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

        //{
        //    DataSet set = null;
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
        //        for (int i = 0; i < count; ++i)
        //        {
        //            DataRow row = table.Rows[i];
        //            Assert.NotNull(row["Numero"]);
        //            string supplierId = row["Numero"] as string;
        //            ISupplierDataInfo dataObjectInfo = await _supplierDataServices.GetAsyncSupplierDataObjectInfo(supplierId);
        //            Assert.NotNull(dataObjectInfo);
        //        }
        //    }
      /*      catch (Exception e)
            {
                Assert.NotNull(e.Message);
            }
            Assert.NotNull(supplierTypes);
            _currentStopWatch.Stop();
            TestContext.Out.WriteLine("Elapsed={0}", _currentStopWatch.Elapsed);
            */
        //}
        ///// <summary>
        /////  This test shall not give a provider at all.
        ///// </summary>
        ///// <returns></returns>
        //[Test]
        //public async Task Should_Not_Give_A_Valid_Supplier()
        //{
        //    string supplierId = "-1";
        //    ISupplierDataInfo dataObjectInfo = null;
        //    try
        //    {
        //        dataObjectInfo =
        //            await _supplierDataServices.GetAsyncSupplierDataObjectInfo(supplierId);
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.NotNull(e.Message);
        //    }
        //    Assert.Null(dataObjectInfo);
        //}
        ///// <summary>
        ///// Given a provider it shall return the type information for that supplier.
        ///// </summary>
        ///// <returns></returns>
        //[Test]
        
        //public async Task Should_Give_SuppliersTypes()
        //{
        //    ISupplierTypeData supplierTypes = null;
        //    DataSet set = null;
        //    try
        //    {
        //        set = await _supplierDataServices.GetAsyncAllSupplierSummary();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.StackTrace);
        //        Assert.Fail("Failed");
        //    }
        //    Assert.NotNull(set);
        //    try
        //    {
        //        Assert.Equals(set.Tables.Count, 1);
        //        DataTable table = set.Tables[0];
        //        Assert.Greater(table.Rows.Count, 0);
        //        DataRow row = table.Rows[0];
        //        Assert.NotNull(row["Numero"]);
        //        string supplierId = row["Numero"] as string;
        //        supplierTypes = await _supplierDataServices.GetAsyncSupplierTypesDataObject(supplierId);
        //        Assert.NotNull(supplierTypes);
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.NotNull(e.Message);
        //    }
        //    Assert.NotNull(supplierTypes);
        //}
        ///// <summary>
        /////  It should load the evalution note from the supplier.
        ///// </summary>
        ///// <returns></returns>
        //[Test]
        //public async Task Should_LoadEvaluationNote_By_SupplierId()
        //{
        //    DataSet set = null;
        //    try
        //    {
        //        set = await _supplierDataServices.GetAsyncAllSupplierSummary();
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.Fail("Failed");
        //    }
        //    Assert.NotNull(set);
        //    try
        //    {
        //        Assert.Equals(set.Tables.Count, 1);
        //        DataTable table = set.Tables[0];
        //        Assert.Greater(table.Rows.Count, 0);
        //        DataRow row = table.Rows[0];
        //        Assert.NotNull(row["Numero"]);
        //        string supplierId = row["Numero"] as string;
        //        ISupplierEvaluationNoteData note = await _supplierDataServices.GetAsyncSupplierEvaluationNoteDataObject(supplierId);
        //        Assert.NotNull(note);
        //    } catch (Exception e)
        //    {
        //        Assert.Fail(e.Message);
        //    }

        //}

        ///// <summary>
        ///// It shall return a valid supplier by its if. 
        ///// </summary>
        ///// <returns></returns>
        //[Test]
        //public async Task Should_Return_A_Valid_Supplier_ById()
        //{
        //    string id = await SelectFirstId().ConfigureAwait(false);
        //    Assert.IsEmpty(id);
        //    try
        //    {
        //        ISupplierTypeData typeData = _supplierDataServices.GetAsyncSupplierTypeById(id);
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.Fail(e.Message);
        //    }
        //}
        //[Test]
        //public async Task Should_Return_Full_Supplier_Paged()
        //{
        //    DataSet set = null;
        //    try
        //    {
        //        set = await _supplierDataServices.GetAsyncSuppliersSummaryPaged();
        //    } catch (Exception e)
        //    {
        //        Assert.Fail(e.Message);
        //    }
        //}


        ///// <summary>
        ///// It shall return the evaluation by a supplier from its id.
        ///// </summary>
        //[Test]
        //public async Task Should_Return_A_Valid_Monitoring()
        //{

        //    string id = await SelectFirstId().ConfigureAwait(false);
        //    Assert.IsEmpty(id);
        //    // ok now it is ready we should have a valid monitoring.
        //    try
        //    {
        //        ISupplierMonitoringData data = await _supplierDataServices.GetAsyncMonitoringSupplierById(id);
        //        Assert.NotNull(data);
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.NotNull(e);
        //    }
            // ok we have the data.
            /*if (set != null)
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
        */


        //}
       

        ///// <summary>
        ///// All providers shall be a table in a DataSet with all fields not null.
        ///// </summary>
        ///// <returns></returns>
        //[Test]
        //public async Task Should_Be_All_Not_Null_Fields_Suppliers()
        //{
        //    DataSet set = null;

        //    try
        //    {
        //        set = await _supplierDataServices.GetAsyncAllSupplierSummary();
        //    }
        //    catch (Exception e)
        //    {
        //       Console.WriteLine(e.StackTrace);
        //        Assert.Fail("Failed");
        //    }
        //   // ok we have the data.
        //    if (set != null)
        //    {
        //        DataTable table = set.Tables[0];
        //        // we shall see the fields.
        //        int count = table.Rows.Count;
        //        Assert.GreaterOrEqual(count, 1);
        //        for (int i = 0; i < count; ++i)
        //        {
        //            DataRow row = table.Rows[i];
        //            Assert.NotNull(row["Numero"]);
        //            Assert.NotNull(row["Nombre"]);
        //            Assert.NotNull(row["Nif"]);

        //        }
        //    }
        //    return;
        //}
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
