using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.DataObjects;
using KarveDapper.Extensions;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using NUnit.Framework;
using Moq;

namespace KarveTest.DAL
{
    class TestClientsDataAccessLayer : TestBase
    {
        private ISqlExecutor _sqlExecutor;
        private IDataServices _dataServices;
        private IDataServices _mockedDataService;
        private IClientDataServices _clientDataServices;
        private Mock<ISqlExecutor> _mockSqlExecutor;
        /// <summary>
        /// Setup the client data
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {
            _dataServices = null;
            try
            {
                _sqlExecutor = SetupSqlQueryExecutor();
                _mockSqlExecutor = new Mock<ISqlExecutor>();
                _mockedDataService = new DataServiceImplementation(_mockSqlExecutor.Object);
                _dataServices = new DataServiceImplementation(_sqlExecutor);
                _clientDataServices = _dataServices.GetClientDataServices();
                Assert.NotNull(_sqlExecutor);
                Assert.NotNull(_dataServices);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        ///  This test load a valid client.
        /// </summary>
       
        [Test]
        public async Task Should_Load_A_Valid_Client()
        {
            // prepare.
            using (IDbConnection dbConnection = _sqlExecutor.OpenNewDbConnection())
            {
                // Arrange value
                IEnumerable<CLIENTES1> value = await dbConnection.GetAllAsync<CLIENTES1>();
                Assert.NotNull(value);
                var singleValue = value.FirstOrDefault();
                Assert.NotNull(singleValue);
                // Act.
                IClientData data = await _clientDataServices.GetAsyncClientDo(singleValue.NUMERO_CLI);
                // Assert
                Assert.NotNull(data.Value);
                Assert.NotNull(data.Value.NUMERO_CLI);
                Assert.AreEqual(data.Value.NUMERO_CLI, singleValue.NUMERO_CLI);
            }
        }
        /// <summary>
        ///  This test shall fail with an empty value
        /// </summary>
        [Test]
        public async Task Should_Fail_With_An_EmptyValue()
        {
            // prepare.
           
                var singleValue = string.Empty;
                // Act.
                IClientData data = await _clientDataServices.GetAsyncClientDo(singleValue);
                // Assert
                Assert.AreEqual(data.Valid, false);
            
        }
        /// <summary>
        ///  This test shall fail with a bad value for the client entity
        /// </summary>
        [Test]
        public async Task Should_Fail_With_A_Bad_Value()
        {
            // prepare.
            using (IDbConnection dbConnection = _sqlExecutor.OpenNewDbConnection())
            {
                // Arrange value
                IEnumerable<CLIENTES1> value = await dbConnection.GetAllAsync<CLIENTES1>();
                var singleValue = value.FirstOrDefault();
                Assert.NotNull(singleValue);
                singleValue.NUMERO_CLI = "-1";
                // Act.
                IClientData data = await _clientDataServices.GetAsyncClientDo(singleValue.NUMERO_CLI);
                // Assert
                Assert.AreEqual(data.Valid, false);
            }
        }
        /// <summary>
        ///  This test shall save a value for the client entity.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Should_Save_A_Valid_Value()
        {
            using (IDbConnection dbConnection = _sqlExecutor.OpenNewDbConnection())
            {
                // Arrange
                IEnumerable<CLIENTES1> value = await dbConnection.GetAllAsync<CLIENTES1>();
                var singleValue = value.FirstOrDefault();
                IClientData data = await _clientDataServices.GetAsyncClientDo(singleValue.NUMERO_CLI);
                ClientDto dtoClient = data.Value;
                Assert.AreEqual(dtoClient.NUMERO_CLI, singleValue.NUMERO_CLI);
                dtoClient.APELLIDO2 = "Zoppi";
                data.Value = dtoClient;
                // Act
                bool retValue = await _clientDataServices.SaveAsync(data);
                IClientData dataValue = await _clientDataServices.GetAsyncClientDo(dtoClient.NUMERO_CLI);
                // Assert
                Assert.IsTrue(retValue);
                Assert.AreEqual(dataValue.Value.NUMERO_CLI, data.Value.NUMERO_CLI);
                Assert.AreEqual(dataValue.Value.APELLIDO2, dtoClient.APELLIDO2);
            }
        }

        [Test]
        public async Task Should_Insert_A_NewClient()
        {
            using (IDbConnection dbConnection = _sqlExecutor.OpenNewDbConnection())
            {
                IEnumerable<CLIENTES1> value = await dbConnection.GetAllAsync<CLIENTES1>();
                var singleValue = value.FirstOrDefault();
                IClientData data = await _clientDataServices.GetAsyncClientDo(singleValue.NUMERO_CLI);
                ClientDto dtoClient = data.Value;
                var identifier = _clientDataServices.GetNewId();
                IClientData newClient = _clientDataServices.GetNewClientAgentDo(identifier);
                newClient.Value.NOMBRE = "Giorgio";
                newClient.Value.APELLIDO1 = "Zoppi";
                newClient.Value.APELLIDO2 = "Pietra";
                bool retValue = await _clientDataServices.SaveAsync(newClient);
                Assert.IsTrue(retValue);
                IClientData newClientData = await _clientDataServices.GetAsyncClientDo(newClient.Value.NUMERO_CLI);
                // assert
                ClientDto dto = newClientData.Value;
                Assert.AreEqual(dto.NUMERO_CLI, newClient.Value.NUMERO_CLI);
                Assert.AreEqual(dto.NOMBRE, newClient.Value.NOMBRE);
                Assert.AreEqual(dto.APELLIDO1, newClient.Value.APELLIDO1);
                Assert.AreEqual(dto.APELLIDO2, newClient.Value.APELLIDO2);
            }
        }
    }
}
