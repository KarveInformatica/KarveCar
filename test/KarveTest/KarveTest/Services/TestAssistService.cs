using KarveCommonInterfaces;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using Moq;
using KarveCommon.Generic;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using KarveControls.Interactivity;
using DataAccessLayer.DataObjects;
using System;
using System.Threading.Tasks;

namespace KarveTest.Services
{
    /// <summary>
    ///  Here we test that raise event assist.
    /// </summary>
    [TestFixture]
    class TestAssistService
    {
        private IUnityContainer _unityContainer;
        private TestDtoFactory _testDtoFactory;
        private readonly Mock<IDataServices> _dataServicesMock = new Mock<IDataServices>();
        private readonly Mock<IHelperDataServices> _helperDataServices = new Mock<IHelperDataServices>();
       
        private IList<ProvinciaDto> _provinciasDto = new List<ProvinciaDto>()
        {
            new ProvinciaDto { Code = "88391", Name="Giorgio"},
            new ProvinciaDto { Code = "89348", Name="Alvaro"}
        };

        [OneTimeSetUp]
        public void Setup()
        {

            _unityContainer = new UnityContainer();
            _testDtoFactory = new TestDtoFactory();
            _helperDataServices.Setup(x => x.GetMappedAllAsyncHelper<ProvinciaDto, DataAccessLayer.DataObjects.PROVINCIA>()).ReturnsAsync(_provinciasDto);
            _dataServicesMock.Setup(x => x.GetHelperDataServices()).Returns(_helperDataServices.Object);
            object[] param = new object[1];
            param[0] = _unityContainer;
            InjectionConstructor injectContainer = new InjectionConstructor(param);
            _unityContainer.RegisterInstance<IDataServices>(_dataServicesMock.Object);
            _unityContainer.RegisterType<IInteractionRequestController, RequestController>(new ContainerControlledLifetimeManager(), injectContainer);
        }
        /// <summary>
        ///  This test should trigger the assist service
        /// </summary>
        [Test, Apartment(ApartmentState.STA)]
        public async Task Should_AssistService_TriggerNotification()
        {
            List<ProvinciaDto> receivedResult = new List<ProvinciaDto>();
            Action<ProvinciaDto> action = delegate(ProvinciaDto p)
            {
                Assert.NotNull(p);
                receivedResult.Add(p);
            };
            var controller = _unityContainer.Resolve<IInteractionRequestController>();
            var dto = new BranchesDto();
            var kvm = new KarveViewModelBase(_dataServicesMock.Object, controller);
            await kvm.OnAssistAsync<ProvinciaDto, PROVINCIA>("ListaProvincia", "Code,Name", action);
            Assert.AreEqual(1,receivedResult.Count);
        }    
    }
}
