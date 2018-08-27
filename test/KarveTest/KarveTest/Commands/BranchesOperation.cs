﻿using KarveDataServices.ViewObjects;
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

        public override void Dispose()
        {
        }
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {  
        }

        internal override Task SetBranchProvince(ProvinceViewObject p, BranchesViewObject b)
        {
            throw new NotImplementedException();
        }

        internal override Task SetClientData(ClientSummaryExtended p, VisitsViewObject b)
        {
            throw new NotImplementedException();
        }

        internal override Task SetVisitContacts(ContactsViewObject p, VisitsViewObject visitsViewObject)
        {
            throw new NotImplementedException();
        }

        internal override Task SetVisitReseller(ResellerViewObject param, VisitsViewObject b)
        {
            throw new NotImplementedException();
        }
    }
    [TestFixture]
    public class BranchesOperation
    {
        private readonly Mock<IEventManager> _mockEventManager = new Mock<IEventManager>();
        private readonly Mock<IConfigurationService> _mockConfigurationService = new Mock<IConfigurationService>();
        private readonly Mock<IDataServices> mockDataServices = new Mock<IDataServices>();
        private readonly Mock<IDialogService> mockDialogService = new Mock<IDialogService>();
        private readonly Mock<IRegionManager> mockRegionManager = new Mock<IRegionManager>();
        private readonly Mock<IInteractionRequestController> mockController = new Mock<IInteractionRequestController>();


        private TestInfoViewModel viewModel;
        
        [OneTimeSetUp]
        public void SetUp()
        {
            viewModel = new TestInfoViewModel(_mockEventManager.Object,
           _mockConfigurationService.Object,
           mockDataServices.Object,
           mockDialogService.Object,
           mockRegionManager.Object,
           mockController.Object);

        }
        [Test, ]
        public void Should_Answer_OnProvince_Assist_Correctly()
        {
            var dto = new BranchesViewObject();
            viewModel.DelegationProvinceMagnifierCommand.Execute(dto);
            var branches = viewModel.BranchesDto;
            var b = branches.Where(x => x.BranchId == dto.BranchId);
            Assert.AreEqual(b, dto);
        }
        [Test]
        public void Should_Answer_OnContact_Assist()
        {
            var dto = new ContactsViewObject();
            viewModel.ContactChargeMagnifierCommand.Execute(dto);
            var contacts = viewModel.ContactsDto;
            var b = contacts.Where(x => x.ContactId == dto.ContactId);
            Assert.AreEqual(b, dto);
        }

    }

}