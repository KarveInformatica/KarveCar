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
using System.ComponentModel;
using DataAccessLayer.Logic;
using AutoMapper;

namespace KarveTest.DAL
{
    class TestClientsDataAccessLayer : TestBase
    {
        protected IClientDataServices _clientDataServices;

        /// <summary>
        /// Setup the client data
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {
            try
            {
                _clientDataServices = DataServices.GetClientDataServices();
                Assert.NotNull(SqlExecutor);
                Assert.NotNull(DataServices);
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
        public async Task Should_Load_AValid_Client()
        {
            // prepare.
            using (IDbConnection dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                // Arrange value
                IEnumerable<CLIENTES1> value = await dbConnection.GetAllAsync<CLIENTES1>();
                Assert.NotNull(value);
                var singleValue = value.FirstOrDefault();
                Assert.NotNull(singleValue);
                // Act.
                IClientData data = await _clientDataServices.GetDoAsync(singleValue.NUMERO_CLI);
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
        public async Task Should_Throws_With_An_EmptyValue()
        {
            // prepare.
           
                var singleValue = string.Empty;
                // Act.
                IClientData data = await _clientDataServices.GetDoAsync(singleValue);
                // Assert
                Assert.AreEqual(data.Valid, false);
            
        }
        /// <summary>
        ///  This test shall fail with a bad value for the client entity
        /// </summary>
        [Test]
        public async Task Should_Fail_ClientRetrieveWithABadValue()
        {
            // prepare.
            using (IDbConnection dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                // Arrange value
                IEnumerable<CLIENTES1> value = await dbConnection.GetPagedAsync<CLIENTES1>(1, 10);
                var singleValue = value.FirstOrDefault();
                Assert.NotNull(singleValue);
                singleValue.NUMERO_CLI = "-1";
                // Act.
                Assert.ThrowsAsync<ArgumentException>(async () => await _clientDataServices.GetDoAsync(singleValue.NUMERO_CLI));

            }
        }
        
        /// <summary>
        ///  This test shall save a value for the client entity.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Should_Save_AValidClientValue()
        {
            using (IDbConnection dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                // Arrange
                IEnumerable<CLIENTES1> value = await dbConnection.GetAllAsync<CLIENTES1>();
                var singleValue = value.FirstOrDefault();
                IClientData data = await _clientDataServices.GetDoAsync(singleValue.NUMERO_CLI);
                ClientDto dtoClient = data.Value;
                Assert.AreEqual(dtoClient.NUMERO_CLI, singleValue.NUMERO_CLI);
                dtoClient.APELLIDO2 = "Zoppi";
                data.Value = dtoClient;
                // Act
                bool retValue = await _clientDataServices.SaveAsync(data);
                IClientData dataValue = await _clientDataServices.GetDoAsync(dtoClient.NUMERO_CLI);
                // Assert
                Assert.IsTrue(retValue);
                Assert.AreEqual(dataValue.Value.NUMERO_CLI, data.Value.NUMERO_CLI);
                Assert.AreEqual(dataValue.Value.APELLIDO2, dtoClient.APELLIDO2);
            }
        }

        [Test]
        public async Task Should_Insert_A_NewClient()
        {
            using (IDbConnection dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                IEnumerable<CLIENTES1> value = await dbConnection.GetAllAsync<CLIENTES1>();
                var singleValue = value.FirstOrDefault();
                IClientData data = await _clientDataServices.GetDoAsync(singleValue.NUMERO_CLI);
                ClientDto dtoClient = data.Value;
                var identifier = _clientDataServices.GetNewId();
                IClientData newClient = _clientDataServices.GetNewDo(identifier);
                newClient.Value.NOMBRE = "Giorgio";
                newClient.Value.APELLIDO1 = "Zoppi";
                newClient.Value.APELLIDO2 = "Pietra";
                bool retValue = await _clientDataServices.SaveAsync(newClient);
                Assert.IsTrue(retValue);
                IClientData newClientData = await _clientDataServices.GetDoAsync(newClient.Value.NUMERO_CLI);
                // assert
                ClientDto dto = newClientData.Value;
                Assert.AreEqual(dto.NUMERO_CLI, newClient.Value.NUMERO_CLI);
                Assert.AreEqual(dto.NOMBRE, newClient.Value.NOMBRE);
                Assert.AreEqual(dto.APELLIDO1, newClient.Value.APELLIDO1);
                Assert.AreEqual(dto.APELLIDO2, newClient.Value.APELLIDO2);
            }
        }
        [Test]
        public async Task Should_Retrieve_ASortedClientPage()
        {
            Dictionary<string, ListSortDirection> direction = new Dictionary<string, ListSortDirection>
            {
                {"Name", ListSortDirection.Ascending },
                {"City", ListSortDirection.Descending }
            };

            IMapper mapper = MapperField.GetMapper();
            var sortedData = await _clientDataServices.GetSortedCollectionPagedAsync(direction, 1, 25);
            Assert.NotNull(sortedData);
            Assert.GreaterOrEqual(25, sortedData.Count());
           
          
        }
    }
}
