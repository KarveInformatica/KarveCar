using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using KarveCommon.Services;
using KarveDataServices;
using Prism.Regions;
using NUnit.Framework;
using MasterModule.ViewModels;
using KarveDataServices.DataTransferObject;

namespace KarveTest.ViewModels
{
    class TestCommissionAgentInfoViewModel: TestViewModelBase
    {
        
        private CommissionAgentInfoViewModel _commissionAgentInfoViewModel = null;

        public TestCommissionAgentInfoViewModel() : base()
        {

        }
        [OneTimeSetUp]
        public void Setup()
        {

            _commissionAgentInfoViewModel = new CommissionAgentInfoViewModel(this._mockConfigurationService.Object,
                this._mockEventManager.Object,
                this._mockDataServices.Object,
                this._mockDialogService.Object,
                this._mockRegionManager.Object,
                this._mockRequestController.Object);

                
      
        }
        /// <summary>
        ///  This tests assure that a reseller is good.
        /// </summary>
        [Test]
        public void Should_Execute_CommandSeller()
        {

            var param = new VisitsDto();
            bool raisedOnceChange = false;
            // arrange
           // var param 
          _commissionAgentInfoViewModel.ResellerMagnifierCommand.Execute(param);
          _commissionAgentInfoViewModel.PropertyChanged += delegate (object sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
                raisedOnceChange = true;
            };
            Assert.NotNull(_commissionAgentInfoViewModel.DataObject);
            Assert.IsTrue(raisedOnceChange);
            Assert.NotNull(_commissionAgentInfoViewModel.DataObject.ProvinceDto);
            Assert.GreaterOrEqual(_commissionAgentInfoViewModel.DataObject.ProvinceDto.Count(), 0);

        }
        /// <summary>
        ///  This test the retrieving of the province in the commission agent.
        /// </summary>
        [Test]
        public void Should_Execute_ProvinceMagnifier()
        {
            // arrange
            var param = new BranchesDto();
            var raisedOnceChange = false;
            // act
            _commissionAgentInfoViewModel.DelegationProvinceMagnifierCommand.Execute(param);
            _commissionAgentInfoViewModel.PropertyChanged += delegate(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
                raisedOnceChange = true;
            };
            // assert.
            Assert.NotNull(_commissionAgentInfoViewModel.DataObject);
            Assert.IsTrue(raisedOnceChange);
            Assert.NotNull(_commissionAgentInfoViewModel.DataObject.ProvinceDto);
            Assert.GreaterOrEqual(_commissionAgentInfoViewModel.DataObject.ProvinceDto.Count(), 0);
        }
        
        [Test]
        public void Should_Execute_ContactMagnifier()
        {
            // arrange
            var param = new VisitsDto();
            // act
            _commissionAgentInfoViewModel.ContactMagnifierCommand.Execute(param);
            // assert
            Assert.NotNull(_commissionAgentInfoViewModel.DataObject);
            Assert.NotNull(_commissionAgentInfoViewModel.DataObject.ContactsDto);
            Assert.GreaterOrEqual(_commissionAgentInfoViewModel.DataObject.ContactsDto.Count(), 0);

        }

       
    }
}
