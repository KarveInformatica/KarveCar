using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Assist;
using KarveDataServices;
using KarveDataServices.Assist;
using KarveDataServices.DataTransferObject;
using NUnit.Framework;

namespace KarveTest.KarveDataServices.Assist
{
    /*
     * This package is aimed to test the answer from the magnifier (lupa), 
     * so called assist. The process of an assist is the following one:
     * 1. The user press the magnifier.
     * 2. The DualFieldSourceBox raise a magnifier event to the view model, triggering an assist.
     * 3. An assist has a name, value, etc.
     * 4. The assist has the effect to raise a window with a grid.
     * 6. Each form has a composition of assist handler.
     */
     /*
    [TestFixture]
    public class AssistTests: KarveTest.DAL.TestBase
    {
        private AssistHandlerRegistry handlerRegistry;
        private IDataServices _dataServices;
        private object _serviceConf;
        private IHelperDataServices _helperDataServices;

        [OneTimeSetUp]
        public void SetUp()
        {
            _dataServices = null;
            _serviceConf = base.SetupConfigurationService();
            handlerRegistry = new AssistHandlerRegistry();
            try
            {
                ISqlExecutor executor = SetupSqlQueryExecutor();
                _dataServices = new DataServiceImplementation(executor, _serviceConf);
                
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void Should_Register_Correctly_An_Handler()
        {
            // Given an handler (arrange)
            ProvinceAssistHandler assist = new ProvinceAssistHandler();
            string provinceAssist = "ProvinceAssist";
            // act registry.
            handlerRegistry.RegisterHandler(provinceAssist,  assist);
            // assert.
            Assert.True(handlerRegistry.ContainsHandler(provinceAssist));
        }
        [Test]
        public void Should_Registry_And_Remove_An_Handler()
        {
            ProvinceAssistHandler assist = new ProvinceAssistHandler();
            string provinceAssist = "PROVINCIA";
            handlerRegistry.RegisterHandler(provinceAssist, assist);
            handlerRegistry.RemoveHandler(provinceAssist);
            Assert.False(handlerRegistry.ContainsHandler(provinceAssist));
        }

        [Test]
        public void Should_Registry_And_Resolve_And_Act()
        {
            IAssistHandler<ProvinciaDto> assistHandler = new ProvinceAssistHandler();
            string provinceAssist = "PROVINCIA";
            handlerRegistry.RegisterHandler(provinceAssist, assistHandler);
            handlerRegistry.TryResolve(provinceAssist, out assistHandler);
            _helperDataServices = _dataServices.GetHelperDataServices();
            IAssistResult<ProvinciaDto> provinciaDto = assistHandler.HandleAssist(provinceAssist, _helperDataServices);
            IEnumerable<ProvinciaDto> provincia = provinciaDto.ResultList();
            Assert.GreaterOrEqual(provincia.Count(), 1);
        }
        [OneTimeTearDown]
        public void Teardown()
        {
        }
       
    }
    */
}
