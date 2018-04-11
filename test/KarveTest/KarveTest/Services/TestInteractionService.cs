using Microsoft.Practices.Unity;
using NUnit.Framework;
using System.Threading;
using KarveControls.Interactivity;
using KarveControls.Interactivity.ViewModels;
using KarveControls.Interactivity.Views;
using KarveCommonInterfaces;

namespace KarveTest.Services
{
    [TestFixture]
    public class TestInteractionService
    {

        private IUnityContainer _unityContainer;
        private TestDtoFactory _testDtoFactory;
        
        [OneTimeSetUp]
        public void Setup()
        {
            _unityContainer = new UnityContainer();
            _testDtoFactory = new TestDtoFactory();
            _unityContainer.RegisterType<InteractionRequestView>();                  _unityContainer.RegisterType<InteractionRequestViewModel>();
            _unityContainer.RegisterType<RequestController>();
        }
        [Test, Apartment(ApartmentState.STA)]
        public void Should_Raise_An_Interaction()
        {
            RequestController requestController = new RequestController(_unityContainer);
            var testDto = _testDtoFactory.CreateDtoList();
            requestController.ShowAssistView<TestDto>("named", testDto);
            Assert.AreEqual(requestController.SelectionState, SelectionState.OK);
            var item = requestController.SelectedItem as TestDto;
            Assert.True(testDto.Contains(item));
        }
        
    }

}