using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Dapper;
using DataAccessLayer;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Model;
using KarveCommon.Services;
using KarveDapper.Extensions;
using KarveDataServices;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace KarveTest.DAL
{
    [TestFixture]
    class TestColumnSettingsDataService: TestBase
    {
        private IDataServices _dataServices;
        private ISettingsDataService _settingsDataService;
        private IConfigurationService _configurationService;
        private ISqlExecutor _executor;
        [OneTimeSetUp]
        public void SetUp()
        {
            _dataServices = null;
            _configurationService = base.SetupConfigurationService();
            try
            {
                _executor = SetupSqlQueryExecutor();
                _dataServices = new DataServiceImplementation(_executor);
                _settingsDataService = _dataServices.GetSettingsDataService();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        private async Task<IMagnifierSettings> GetFirstMagnifier()
        {
            IMagnifierSettings mset = _settingsDataService.NewMagnifierSettings();
            await _settingsDataService.DeleteMagnifier(1);
            mset.ID = 1;
            mset.USUARIO = "CV";
            mset.LUPA = "ProviderControlViewModel";
            mset.NOMBRE = "ProviderControlViewModel";
            mset.ULTIMOD = DateTime.Now.ToLongTimeString();
            IMagnifierColumns cols = _settingsDataService.NewMagnifierColumn();
            cols.ANCHO = 300;
            cols.COLUMNA_NOMBRE = "Nombre";
            cols.ID_LUPA = 1;
            cols.POSICION = 1;
            cols.VISIBLE = 0;
            var tmp = new List<IMagnifierColumns>();
            tmp.Add(cols);
            mset.MagnifierColumns = tmp;
            bool magnifier = await _settingsDataService.SaveMagnifierSettings(mset);
            Assert.True(magnifier);
            IMagnifierSettings m = await _settingsDataService.GetMagnifierSettings(1);
            return m;
        }

        [Test]
        public async Task Should_Reatrive_All_Magnifiers()
        {
            Assert.NotNull(_settingsDataService);
            IMagnifierSettings m = await GetFirstMagnifier();
            Assert.NotNull(m);

        }
        [Test]
        public async Task Should_Retrieve_Magnifier_DataService_Not_Null()
        {
            // arrange
            Assert.NotNull(_settingsDataService);
            // excurte
            IMagnifierSettings m = await GetFirstMagnifier();
            Assert.NotNull(m);
            Assert.NotNull(m.ID);
            Assert.NotNull(m.LUPA);
            Assert.NotNull(m.MagnifierColumns);
            Assert.NotNull(m.NOMBRE);
            Assert.NotNull(m.USUARIO);
        }

        [Test]
        public async Task Should_Retreive_Magnifier_Columns()
        {
            IMagnifierSettings m = await GetFirstMagnifier();
            Assert.NotNull(m);
            // verify.
            Assert.NotNull(m.MagnifierColumns);
            Assert.Greater(m.MagnifierColumns.Count(), 0);
            int value = m.MagnifierColumns.Count();
            Assert.Greater(value, 0);
        }

        [Test]
        public async Task Should_Retrieve_Width_Greater()
        {
            IMagnifierSettings m = await GetFirstMagnifier();
            Assert.NotNull(m.MagnifierColumns);
            foreach (var column in m.MagnifierColumns)
            {
                Assert.Greater(column.ANCHO, 0);
                Assert.NotNull(column.COLUMNA_NOMBRE);
            }
        }

        private async Task<bool> UpdateMagnifierColumns(IMagnifierColumns mc)
        {
            bool value = false;
            USER_LUPAS_COLUMNAS cls = new USER_LUPAS_COLUMNAS();
            cls.ANCHO = mc.ANCHO;
            cls.COLUMNA_NOMBRE = mc.COLUMNA_NOMBRE;
            cls.ID_COL = mc.ID_COL;
            cls.ID_LUPA = mc.ID_LUPA;
            cls.POSICION = mc.POSICION;
            cls.VISIBLE = mc.VISIBLE;
            // FIME: rmemove this.
            string queryFormat =
                @"UPDATE USER_LUPAS_COLUMNAS SET ANCHO = '{0}', COLUMNA_NOMBRE = '{1}',ID_COL='{2}', ID_LUPA='{3}',POSICION='{4}', VISIBLE='{5}' WHERE USER_LUPAS_COLUMNAS.ID_LUPA='{3}'";
            var query = string.Format(queryFormat, cls.ANCHO, cls.COLUMNA_NOMBRE, cls.ID_COL, cls.ID_LUPA, cls.POSICION,
                cls.VISIBLE);
            using (IDbConnection connection = _executor.OpenNewDbConnection())
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        await connection.ExecuteAsync(query);
                        scope.Complete();
                        value = true;
                    }
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            return value;
        }
        [Test]
        public async Task Should_Update_Columns()
        {
            IMagnifierSettings m = await GetFirstMagnifier();
            IMagnifierColumns cols = _settingsDataService.NewMagnifierColumn();
            cols.ANCHO = 450;
            cols.COLUMNA_NOMBRE = "Nombre";
            cols.ID_LUPA = 1;
            cols.POSICION = 1;
            
            m.ID = 1;
            m.LUPA = "Nombre";
            m.ULTIMOD = DateTime.Now.ToLongTimeString();
            m.USUARIO = "GZ";
            m.DEFECTO = 0;
            var tmp = new List<IMagnifierColumns>();
            tmp.Add(cols);
            m.MagnifierColumns = tmp;           
            Assert.NotNull(m.MagnifierColumns);
            IDbConnection connection = _executor.OpenNewDbConnection();
            Assert.Greater(m.MagnifierColumns.Count(), 0);
            foreach (var value in m.MagnifierColumns)
            {
                

                bool retValue = await UpdateMagnifierColumns(value);
                    //connection.UpdateAsync<USER_LUPAS_COLUMNAS>(cls);
                Assert.True(retValue);
            }
            connection.Close();
            connection.Dispose();
        }
    }
    
}
