using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using KarveCommonInterfaces;
using KarveCommon.Services;
using KarveDataServices;
using Microsoft.Practices.Unity;
using KarveTest.Mock;
using Prism.Regions;
using KarveDataServices.ViewObjects;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using Prism.Interactivity;
using Prism.Interactivity.InteractionRequest;
using System.Windows;

namespace KarveTest.ViewModels
{

    public class TestablePopupWindowAction : PopupWindowAction
    {
        public  Window GetWindow(IConfirmation notification)
        {
            return base.GetWindow(notification);
        }
    }

    [TestFixture]
    class TestShowDialogMagnifier: TestBase
    {
       
        private Mock<IEventManager> _eventManager;
        private Mock<IDialogService> _dialogService;
        private Mock<IDataServices> _dataServices;
        private Mock<IRegionManager> _regionManager;
        private Mock<IConfigurationService> _configurationService;
        private Mock<IHelperDataServices> _helperDataServices;
        private Mock<IAssistDataService> _assistDataServices;
        private Mock<IInteractionRequestController> _controllerRequest;
        private IUnityContainer _unityContainer;

        [OneTimeSetUp]
        public void Setup()
        {
            // add container values
            _unityContainer = new UnityContainer();
            _eventManager = new Mock<IEventManager>();
            _dialogService = new Mock<IDialogService>();
            _dataServices = new Mock<IDataServices>();
            _regionManager = new Mock<IRegionManager>();
            _configurationService = new Mock<IConfigurationService>();
            _helperDataServices = new Mock<IHelperDataServices>();
            _assistDataServices = new Mock<IAssistDataService>();
            MockSetup();
        }
        private void MockSetup()
        { 
            _dataServices.Setup(c => c.GetHelperDataServices()).Returns(
                    _helperDataServices.Object
                );
            _dataServices.Setup(a => a.GetAssistDataServices()).Returns(
                _assistDataServices.Object
                );
        }
        [Test,Apartment(ApartmentState.STA)]
        public void Should_Show_Assist_ProvinceMagnifier()
        {
            // arrange
            IInteractionRequestController controller = _unityContainer.Resolve<IInteractionRequestController>();  
            AssistMockViewModel assistMockViewModel = new AssistMockViewModel(_eventManager.Object,
                                                            _configurationService.Object,
                                                            _dataServices.Object,
                                                            _dialogService.Object,
                                                            _regionManager.Object,
                                                            controller);
            Assert.NotNull(assistMockViewModel.SelectedProvince);
            IList<ProvinceViewObject> provinciaDto = new List<ProvinceViewObject>()
            {
                new ProvinceViewObject() { Code = "192", Name="Barcelona"},
                new ProvinceViewObject() { Code = "200", Name = "Madrid"}
            };
            // act
          assistMockViewModel.LaunchBranches.Execute(provinciaDto);
          ProvinceViewObject provinceViewObject = assistMockViewModel.SelectedProvince;
            // assert
          Assert.True(provinciaDto.Contains(provinceViewObject));
        }
        [Test, Apartment(ApartmentState.STA)]
        public void Should_Show_Assist_ContactsMagnifier()
        {
            // arrange
            IInteractionRequestController service = _unityContainer.Resolve<IInteractionRequestController>();
            AssistMockViewModel assistMockViewModel = new AssistMockViewModel(_eventManager.Object,
                                                         _configurationService.Object,
                                                         _dataServices.Object,
                                                         _dialogService.Object,
                                                         _regionManager.Object, 
                                                         service);
            Assert.NotNull(assistMockViewModel.LaunchContact);

            IList<ContactsViewObject> contactsDto = new List<ContactsViewObject>()
            {
                new ContactsViewObject() { ContactId="100", ContactName="Alex"},
                new ContactsViewObject() { ContactId = "200", ContactName = "Madrid"}
            };

            assistMockViewModel.LaunchBranches.Execute(contactsDto);
           
            ContactsViewObject contactViewObject = assistMockViewModel.SelectedContact;
            // assert
            Assert.True(contactsDto.Contains(contactViewObject));
        }

    }
}
