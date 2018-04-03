using KarveCommonInterfaces;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using AssistModule;
using System.Linq;
using System.Collections.Generic;

namespace KarveTest.Services
{
    [TestFixture]
    class TestAssistService
    {
        private IUnityContainer _unityContainer;
        private TestDtoFactory _testDtoFactory;
        [OneTimeSetUp]
        public void Setup()
        {
            _unityContainer = new UnityContainer();
            _testDtoFactory = new TestDtoFactory();
            object[] param = new object[1];
            param[0] = _unityContainer;
            InjectionConstructor injectContainer = new InjectionConstructor(param);

            _unityContainer.RegisterType<IAssistService, AssistService>(new ContainerControlledLifetimeManager(), injectContainer);
        }
        
        /// <summary>
        ///  This test should trigger the assist service
        /// </summary>
        [Test]
        public void ShouldTrigger_Assist_Notification()
        {
            // arrange
            var assistService = _unityContainer.Resolve<IAssistService>();
            var dtoList = _testDtoFactory.CreateDtoList();
            // act
            assistService.ShowAssistView<TestDto>("TestDto",dtoList);
            // assert
            TestDto returnValue = assistService.SelectedItem as TestDto;
            List<TestDto> qList = new List<TestDto>();               
            Assert.NotNull(returnValue);
            qList.Add(returnValue);
            // this return the list of items
            var count = dtoList.Intersect(qList).Count();
            Assert.Greater(count, 0);
        }
        
    }
}
