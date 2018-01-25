using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.DataObjects;
using DataAccessLayer.DataObjects.Wrapper;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using NUnit.Framework;
using KarveDataServices.DataObjects;
using  Dapper;
using DataAccessLayer.Model;
using KarveDapper;
using KarveDapper.Extensions;
using KarveDataServices.DataTransferObject;

namespace KarveTest.DAL
{
    /// <summary>
    ///  This test feature creata an agent data service layer.
    /// </summary>
    [TestFixture]
    public class TestCommissionAgentDataServiceLayer : TestBase
    {
        private IDataServices _dataServices;
        private ICommissionAgentDataServices _commissionAgentDataServices;
        private IConfigurationService _serviceConf;
        private ISqlExecutor _sqlExecutor;
        private bool _notificationResult;
        private INotifyTaskCompletion _initializationTable;

        private const string ConnectionString =
            "EngineName=DBRENT_NET16;DataBaseName=DBRENT_NET16;Uid=cv;Pwd=1929;Host=172.26.0.45";

        /// <summary>
        /// The setup.
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {
            _dataServices = null;
            _serviceConf = base.SetupConfigurationService();
            try
            {
                _sqlExecutor = SetupSqlQueryExecutor();
                _dataServices = new DataServiceImplementation(_sqlExecutor);
                _commissionAgentDataServices = _dataServices.GetCommissionAgentDataServices();
                Assert.NotNull(_commissionAgentDataServices);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        /// <summary>
        ///  This test load a cration commission agent,
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Should_Load_A_CommissionAgent()
        {
            CommissionAgent agent = new CommissionAgent(_sqlExecutor);
            Assert.NotNull(agent);
            IDictionary<string, string> fields = new Dictionary<string, string>();
            string numComi = "0000002";
            fields.Add(CommissionAgent.Comisio, "NUM_COMI, PERSONA, NIF, TIPOCOMI, " +
                                                "VENDE_COMI, MERCADO, NEGOCIO, CANAL, CLAVEPPTO, " +
                                                "ORIGEN_COMI, ZONAOFI, direccion, cp, poblacion, " +
                                                "provincia, nacioper, telefono, fax, " +
                                                "Movil, alta_comi, baja_comi, idioma, IATA, IVASINO, " +
                                                "RETENSINO, NACIONAL, CONCEPTOS_COND, AGENCIA, TRADUCE_WS, " +
                                                "TRUCK_RENTAL_BROKER, COMBUS_PREPAGO_COMI, NO_GENERAR_AUTOFAC, " +
                                                "TODOS_EXTRAS, AUTO_ONEWAY, COT_INCLUIDOS_SIN_GRUPO, " +
                                                "NO_MAIL_RES, AUTOFAC_SIN_IVA, " +
                                                "COMISION_SIN_IVA_COM");
            bool isLoaded = await agent.LoadValue(fields, numComi);
            Assert.True(isLoaded);
        }

        /// <summary>
        /// This tests a commission agent factory.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Should_Load_Commission_Agent_ByFactory()
        {
            IDictionary<string, string> fields = new Dictionary<string, string>();
            string numComi = "0000002";
            fields.Add(CommissionAgent.Comisio, "COMISIO, NUM_COMI, PERSONA, NIF, TIPOCOMI, " +
                                                "VENDE_COMI, MERCADO, NEGOCIO, CANAL, CLAVEPPTO, " +
                                                "ORIGEN_COMI, ZONAOFI, direccion, cp, poblacion, " +
                                                "provincia, nacioper, telefono, fax, " +
                                                "Movil, alta_comi, baja_comi, idioma, IATA, IVASINO, " +
                                                "RETENSINO, NACIONAL, CONCEPTOS_COND, AGENCIA, TRADUCE_WS, " +
                                                "TRUCK_RENTAL_BROKER, COMBUS_PREPAGO_COMI, NO_GENERAR_AUTOFAC, " +
                                                "TODOS_EXTRAS, NO_GESTIONAR_CUPO, AUTO_ONEWAY, COT_INCLUIDOS_SIN_GRUPO, " +
                                                "ACCESO_PREMIUM, NO_MAIL_RES, AUTOFAC_SIN_IVA, " +
                                                "COMISION_SIN_IVA_COM");
            CommissionAgentFactory agentFactory = CommissionAgentFactory.GetFactory(_sqlExecutor);
            Assert.NotNull(agentFactory);
            ICommissionAgent createdAgent = await agentFactory.GetCommissionAgent(fields, numComi);
            Assert.NotNull(createdAgent);

        }
        /// <summary>
        ///  This load the commission agent using xml.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Should_Load_CommissionAgent_UsingXml()
        {
            string numComi = "0000002";
            ICommissionAgentDataServices commisionAgentDataServices = _dataServices.GetCommissionAgentDataServices();
            ICommissionAgent agent = await commisionAgentDataServices.GetCommissionAgentDo(numComi);
            Assert.NotNull(agent);
            COMISIO comisio = (COMISIO) agent.Value;
            Assert.AreEqual(comisio.NUM_COMI, numComi);
            var data = agent.CommisionTypeDto.FirstOrDefault(c => c.Codigo == comisio.NUM_COMI);
            Assert.NotNull(data);
        }

        /// <summary>
        ///  This create a commission agent in loop.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Should_Loop_And_Load()
        {
            IDictionary<string, string> fields = new Dictionary<string, string>();
            string numComi = "0000002";
            fields.Add(CommissionAgent.Comisio, "COMISIO, NUM_COMI, PERSONA, NIF, TIPOCOMI, " +
                                                "VENDE_COMI, MERCADO, NEGOCIO, CANAL, CLAVEPPTO, " +
                                                "ORIGEN_COMI, ZONAOFI, direccion, cp, poblacion, " +
                                                "provincia, nacioper, telefono, fax, " +
                                                "Movil, alta_comi, baja_comi, idioma, IATA, IVASINO, " +
                                                "RETENSINO, NACIONAL, CONCEPTOS_COND, AGENCIA, TRADUCE_WS, " +
                                                "TRUCK_RENTAL_BROKER, COMBUS_PREPAGO_COMI, NO_GENERAR_AUTOFAC, " +
                                                "TODOS_EXTRAS, NO_GESTIONAR_CUPO, AUTO_ONEWAY, COT_INCLUIDOS_SIN_GRUPO, " +
                                                "ACCESO_PREMIUM, NO_MAIL_RES, AUTOFAC_SIN_IVA, " +
                                                "COMISION_SIN_IVA_COM");
            for (int i = 0; i < 10; ++i)
            {
                ICommissionAgent agentDataWrapper =
                    await _commissionAgentDataServices.GetCommissionAgentDo(numComi, fields);
                Assert.NotNull(agentDataWrapper);
            }

        }

        /// <summary>
        ///  This load and notify the commission agent.
        /// </summary>
        [Test]
        public void Should_LoadAndNotify_CommissionAgent()
        {
            _notificationResult = false;
            _initializationTable =
                NotifyTaskCompletion.Create<ICommissionAgent>(TestLoadDataValueNotify(),
                    InitializationTableOnPropertyChanged);
            System.Threading.Thread.Sleep(10 * 1000);
            Assert.IsTrue(_notificationResult);
        }

        /// <summary>
        ///  This is the initialization table on property changed.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="propertyChangedEventArgs">Properties initialized.</param>
        private void InitializationTableOnPropertyChanged(object sender,
            PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (_initializationTable.IsSuccessfullyCompleted)
            {
                _notificationResult = true;
            }
            else
            {
                _notificationResult = false;
            }
        }


        /// <summary>
        /// Data value notify the commission agent data value.
        /// </summary>
        /// <returns></returns>

        public async Task<ICommissionAgent> TestLoadDataValueNotify()
        {
            IDictionary<string, string> query = new Dictionary<string, string>();
            string primaryKeyValue = "0000003";
            query["COMISIO"] =
                "NUM_COMI,PERSONA,NIF,TIPOCOMI,VENDE_COMI,MERCADO,NEGOCIO,CANAL,CLAVEPPTO,ORIGEN_COMI,ZONAOFI," +
                "direccion,cp,poblacion,provincia,nacioper,telefono,fax,Movil,alta_comi," +
                "baja_comi,idioma,IATA,IVASINO,RETENSINO,NACIONAL,CONCEPTOS_COND,AGENCIA,TRADUCE_WS," +
                "TRUCK_RENTAL_BROKER,COMBUS_PREPAGO_COMI,NO_GENERAR_AUTOFAC,TODOS_EXTRAS,AUTO_ONEWAY,COT_INCLUIDOS_SIN_GRUPO," +
                "NO_MAIL_RES,AUTOFAC_SIN_IVA,COMISION_SIN_IVA_COM";
            ICommissionAgent agent = await _commissionAgentDataServices.GetCommissionAgentDo(primaryKeyValue, query);
            await Task.Delay(1000);
            return agent;

        }

        private async Task<string> GetFirstId()
        {
            string primaryKeyValue = "0000004";
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                var brokers = await connection.GetAllAsync<COMISIO>();
                var singleBroker = brokers.FirstOrDefault();
                if (singleBroker != null)
                {
                    primaryKeyValue = singleBroker.NUM_COMI;
                }
            }
            return primaryKeyValue;
        }
        /// <summary>
        ///  This load a data value.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Should_Load_And_Have_TheSame_NumComi()
        {

            IDictionary<string, string> query = new Dictionary<string, string>();
            string primaryKeyValue = await GetFirstId();
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                var brokers = await connection.GetAllAsync<COMISIO>();
                var singleBroker = brokers.FirstOrDefault();
                if (singleBroker != null)
                {
                    primaryKeyValue = singleBroker.NUM_COMI;
                }
            }
                
            query["COMISIO"] =
                "NUM_COMI,PERSONA,NIF,TIPOCOMI,VENDE_COMI,MERCADO,NEGOCIO,CANAL,CLAVEPPTO,ORIGEN_COMI,ZONAOFI," +
                "direccion,cp,poblacion,provincia,nacioper,telefono,fax,Movil,alta_comi," +
                "baja_comi,idioma,IATA,IVASINO,RETENSINO,NACIONAL,CONCEPTOS_COND,AGENCIA,TRADUCE_WS," +
                "TRUCK_RENTAL_BROKER,COMBUS_PREPAGO_COMI,NO_GENERAR_AUTOFAC,TODOS_EXTRAS,AUTO_ONEWAY,COT_INCLUIDOS_SIN_GRUPO," +
                "NO_MAIL_RES,AUTOFAC_SIN_IVA,COMISION_SIN_IVA_COM";
            ICommissionAgent agent =
                await _commissionAgentDataServices.GetCommissionAgentDo(primaryKeyValue, query);

            Assert.NotNull(agent);
            Assert.NotNull(agent.Value);
            COMISIO comisio = (COMISIO) agent.Value;
            Assert.NotNull(comisio.NUM_COMI, primaryKeyValue);
        }

        [Test]
        public async Task Should_Create_AgentCorrectly()
        {
            IDictionary<string, string> fields = new Dictionary<string, string>();
            fields.Add(CommissionAgent.Comisio, "NUM_COMI,NOMBRE,DIRECCION,PERSONA,NIF,NACIOPER,TIPOCOMI");
            fields.Add(CommissionAgent.Tipocomi, "NUM_TICOMI, ULTMODI, USUARIO, NOMBRE");
            fields.Add(CommissionAgent.Visitas, " * ");
            fields.Add(CommissionAgent.Branches, "* ");
            string numComi = _commissionAgentDataServices.GetNewId();
            ICommissionAgent agent = _commissionAgentDataServices.GetNewCommissionAgentDo(numComi);
              
            ICommissionAgent commissionAgent = agent;
            Assert.NotNull(commissionAgent);
            COMISIO value = commissionAgent.Value as COMISIO;
            Assert.NotNull(value);
            Assert.AreEqual(value.NUM_COMI, numComi);
        }

        [Test]
        public async Task Should_Update_CommissionAgent()
        {
            IDictionary<string, string> fields = new Dictionary<string, string>();
            fields.Add(CommissionAgent.Comisio, "NUM_COMI,NOMBRE,DIRECCION,PERSONA,NIF,NACIOPER,TIPOCOMI");
            fields.Add(CommissionAgent.Tipocomi, "NUM_TICOMI, ULTMODI, USUARIO, NOMBRE");
            fields.Add(CommissionAgent.Visitas, " * ");
            fields.Add(CommissionAgent.Branches, "* ");
            string numComi = await GetFirstId();
            ICommissionAgent commissionAgent = await _commissionAgentDataServices.GetCommissionAgentDo(numComi);
            // check if the condition is valid.
            Assert.True(commissionAgent.Valid);
            COMISIO internalValue = (COMISIO) commissionAgent.Value;
            IEnumerable<BranchesDto> branchesDto = commissionAgent.DelegationDto;
            IEnumerable<ContactsDto> contactsDtos = commissionAgent.ContactsDto;
            IEnumerable<VisitsDto> visitsDtos = commissionAgent.VisitsDto;
            Assert.NotNull(branchesDto);
            Assert.NotNull(contactsDtos);
            Assert.NotNull(visitsDtos);
            Assert.NotNull(internalValue);
            internalValue.NOMBRE = "Karve2Comission";
            commissionAgent.Value = internalValue;
            bool isSaved = await _commissionAgentDataServices.SaveChangesCommissionAgent(commissionAgent);
            Assert.True(isSaved);
        }

        /// <summary>
        /// This test shall insert and modify a commissiona agent.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Should_Insert_CommissionAgent()
        {
            ICommissionAgent commissionAgent = _commissionAgentDataServices.GetNewCommissionAgentDo();
            ICommissionAgentTypeData commissionAgentTypeData = new CommissionAgentTypeData();
            commissionAgentTypeData.Code = "2";
            commissionAgentTypeData.Name = "KARVE INFORMATICA S.L";
          //  commissionAgent.Type = commissionAgentTypeData;
            ICountryData dataCountry = new CountryData();
            dataCountry.Code = "34";
            dataCountry.CountryName = "Spain";
           // commissionAgent.Country = dataCountry;
            COMISIO comisio = (COMISIO) commissionAgent.Value;
            comisio.NUM_COMI = _commissionAgentDataServices.GetNewId();
            Assert.NotNull(comisio.NUM_COMI);
            comisio.TIPOCOMI = "2";
            comisio.CP = "080012";
            comisio.NOMBRE = "Giorgio";
            comisio.DIRECCION = "Via Augusta 32";
            comisio.EMAIL = "giorgio@apache.org";
            commissionAgent.Value = comisio;
            bool cAgent = await _commissionAgentDataServices.SaveCommissionAgent(commissionAgent);
            Assert.True(cAgent);
           
        }

         /// <summary>
        ///  Test a delete commission agent.
        /// </summary>
        [Test]
        public async Task Should_DeleteCommissionAgent_ById()
        {
            IDictionary<string, string> fields = new Dictionary<string, string>();
            fields.Add(CommissionAgent.Comisio, "NUM_COMI,NOMBRE,DIRECCION,PERSONA,NIF,NACIOPER,TIPOCOMI");
            fields.Add(CommissionAgent.Tipocomi, "NUM_TICOMI, ULTMODI, USUARIO, NOMBRE");
            fields.Add(CommissionAgent.Visitas," * ");
            fields.Add(CommissionAgent.Branches," * ");
            string numComi = "0000003";
            ICommissionAgent commissionAgent = await _commissionAgentDataServices.GetCommissionAgentDo(numComi, fields);
            bool deleteSuccess = await _commissionAgentDataServices.DeleteCommissionAgent(commissionAgent);
            Assert.True(deleteSuccess);
        }
    }
}
