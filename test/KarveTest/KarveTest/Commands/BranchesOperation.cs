using KarveDataServices.DataTransferObject;
using MasterModule.Common;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using KarveCommon.Services;
using System.Data;
using KarveCommonInterfaces;
using KarveDataServices;
using Prism.Regions;
using MasterModule.ViewModels;
using Moq;
using System.Linq;
using System.Collections.Generic;

namespace KarveTest.Commands
{
    /*
     *  Ok. This is a test info view model.
     */
    public class TestInfoViewModel : MasterInfoViewModuleBase
    {
        public TestInfoViewModel(IEventManager eventManager, IConfigurationService configurationService, IDataServices dataServices, IDialogService dialogService, IRegionManager manager, IInteractionRequestController controller) : base(eventManager, configurationService, dataServices, dialogService, manager, controller)
        {
        }
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
           
        }  
    }
    [TestFixture]
    public class BranchesOperation
    {
        private Mock<IEventManager> mockEventManager = new Mock<IEventManager>();
        private Mock<IConfigurationService> mockConfigurationService = new Mock<IConfigurationService>();
        private Mock<IDataServices> mockDataServices = new Mock<IDataServices>();
        private Mock<IDialogService> mockDialogService = new Mock<IDialogService>();
        private Mock<IRegionManager> mockRegionManager = new Mock<IRegionManager>();
        private Mock<IInteractionRequestController> mockController = new Mock<IInteractionRequestController>();


        private TestInfoViewModel viewModel;
        
        [OneTimeSetUp]
        public void SetUp()
        {
            viewModel = new TestInfoViewModel(mockEventManager.Object,
           mockConfigurationService.Object,
           mockDataServices.Object,
           mockDialogService.Object,
           mockRegionManager.Object,
           mockController.Object);

        }
        [Test, ]
        public void Should_Answer_OnProvince_Assist_Correctly()
        {
            BranchesDto dto = new BranchesDto();
            viewModel.DelegationProvinceMagnifierCommand.Execute(dto);
            var branches = viewModel.BranchesDto;
            var b = branches.Where(x => x.BranchId == dto.BranchId);
            Assert.AreEqual(b, dto);
        }
        [Test]
        public void Should_Answer_OnContact_Assist()
        {
            ContactsDto dto = new ContactsDto();
            viewModel.ContactChargeMagnifierCommand.Execute(dto);
            var contacts = viewModel.ContactsDto;
            var b = contacts.Where(x => x.ContactId == dto.ContactId);
            Assert.AreEqual(b, dto);
        }

    }

}