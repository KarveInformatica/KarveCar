using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDapper;
using KarveDapper.Extensions;
using NUnit.Framework;
using KarveDataServices;
using System.Data;
using DataAccessLayer.DataObjects;
using System.Diagnostics.Contracts;

namespace KarveTest.KarveDapper
{
    /// <summary>
    ///  This test extends the asynchronous karve dapper.
    /// </summary>
    [TestFixture]
    class TestKarveDapperAsync : DAL.TestBase
    {
        private ISqlExecutor _sqlExecutor;
        [OneTimeSetUp]
        public void SetUp()
        {
            try
            {
                _sqlExecutor = SetupSqlQueryExecutor();

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }

        /// <summary>
        ///  Fetch 10 entities to update the test.
        /// </summary>
        /// <returns>return a list of entities</returns>
        private async Task<IList<CLIENTES1>> FetchClientes()
        {
            IList<CLIENTES1> clientes = new List<CLIENTES1>();
            using (IDbConnection conn = _sqlExecutor.OpenNewDbConnection())
            {
                try
                {
                    var value = await conn.GetPagedAsync<CLIENTES1>(1,10);
                    for (int i = 0; i < value.Count<CLIENTES1>() && i < 10; i++)
                    {
                        clientes.Add(value.ElementAt(i));
                    }
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            return clientes;
        }
        /// <summary>
        ///  This assert the collection updated. The idea is to check a list of clientes
        ///  and match with a changed date.
        /// </summary>
        /// <param name="clientes">Collection to be updated</param>
        /// <param name="dateChanged">Date to be changed</param>
        private void AssertCollectionUpdated(IEnumerable<CLIENTES1> clientes, DateTime dateChanged)
        {
            using (IDbConnection conn = _sqlExecutor.OpenNewDbConnection())
            {
                try
                {
                    foreach (var c in clientes)
                    {
                        var client = conn.Get<CLIENTES1>(c.NUMERO_CLI);
                        Assert.AreEqual(client.BAJA, dateChanged);
                    }
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }
        /// <summary>
        ///  This provide a list of clientes deleted.
        /// </summary>
        /// <param name="clientes"></param>
        private void AssertCollectionDeleted(IEnumerable<CLIENTES1> clientes)
        {
            using (IDbConnection conn = _sqlExecutor.OpenNewDbConnection())
            {
                try
                {
                    foreach (var c in clientes)
                    {
                        Assert.AreEqual(false, conn.IsPresent<CLIENTES1>(c));
                    }
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }
        [Test]
        public async Task Should_Update_CollectionEntitiesFromDto()
        {
            IList<CLIENTES1> clientes = await FetchClientes();
            // arrange the items to update.
            // update correctly
            var dateChanged = DateTime.Now;
            foreach (var c in clientes)
            {
                c.BAJA = dateChanged;
            }
            /* ok now we have an updated vector of values.
             *  We want to try to add to the database.
             */
            // act
            // we open a database connection for the database.
            bool state = false;
            using (IDbConnection conn = _sqlExecutor.OpenNewDbConnection())
            {
                try
                {
                    state = await conn.ExecuteUpdateCollectionAsync<CLIENTES1>(clientes);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            // assert
            Assert.AreEqual(state, true);
            AssertCollectionUpdated(clientes, dateChanged);
        }
        /// <summary>
        ///  This delete all the entities for you.
        /// </summary>
        /// <param name="entities">Entities to be deleted</param>
        /// <returns>True or false in case of deleting entities</returns>
        private async Task<bool> DeleteEntities(IEnumerable<CLIENTES1> entities)
        {
            Contract.Requires(entities != null, "Null entities");
            bool state = false;
            using (IDbConnection conn = _sqlExecutor.OpenNewDbConnection())
            {
                try
                {
                    state = await conn.DeleteCollectionAsync(entities);
                } catch (Exception ex)
                {
                    throw new DataLayerException("DeleteEntities", ex);

                }
            }
            return state;
        }
        [Test]
        public async Task Should_Delete_CollectionFromDto()
        {
            bool state = false;
            // arrange
            var clientes = await FetchClientes();
            // act
            // we open a database connection and delete just the first items
            var clientForDeleting = clientes.Take(3);
            var forDeleting = clientForDeleting as CLIENTES1[] ?? clientForDeleting.ToArray();
            state = await DeleteEntities(forDeleting);
            Assert.AreEqual(state, true);
            // here we can check if the delete works well.
            AssertCollectionDeleted(forDeleting);
        }
        [Test]
        public async Task Should_Not_Delete_An_Invalid_Collection()
        {
            bool state;
            state = false;
            // arrange
            var clientes = await FetchClientes();
            for(int i =0; i < clientes.Count(); ++i)
            {
                clientes[i].NUMERO_CLI = null;
            }
            // act 
            var clientForDeleting = clientes.Take(3);
            state = await DeleteEntities(clientForDeleting);
            // assert
            Assert.AreEqual(state, false);
        }

        [Test]
        public async Task Should_Retrieve_PagedEntities()
        {

            using (var conn = _sqlExecutor.OpenNewDbConnection())
            {
                // act
                var pagedConn = await conn.GetPagedAsync<CLIENTES1>(1,25);
                // assert.
                Assert.AreEqual(pagedConn.Count(), 25);
                foreach (var page in pagedConn)
                {
                    Assert.NotNull(page.NUMERO_CLI);
                }
            }
        }

       

        private async Task GetPage()
        {
            using (var conn = _sqlExecutor.OpenNewDbConnection())
            {
                var pagedConn = await conn.GetPagedAsync<CLIENTES1>(-1, -1);
                Assert.AreEqual(pagedConn.Count(), 25);
            }
        }
        [Test]
        public void Should_Throws_WhenBadIndex()
        { 
            Assert.ThrowsAsync<System.ArgumentOutOfRangeException>(async () => await GetPage());
        }
        [Test]
        public async Task Should_Not_Update_InvalidCollection()
        {
            
            // arrange
            var clientes = await FetchClientes();
            for (int i = 0; i < clientes.Count(); ++i)
            {
                clientes[i].NUMERO_CLI = string.Empty;
                clientes[i].APELLIDO1 = null;
            }
            var clientUpdating = clientes.Take(3);

            // act 
            using (var conn = _sqlExecutor.OpenNewDbConnection())
            {
                Assert.NotNull(conn);
                var value = await conn.ExecuteUpdateCollectionAsync<CLIENTES1>(clientUpdating);
                Assert.AreEqual(value, false);
    
            }
            // assert 
           
        }

       
    }
}
