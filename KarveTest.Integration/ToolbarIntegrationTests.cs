using DataAccessLayer;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using KarveTest.DAL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using ToolBarModule;
using Moq;

namespace KarveCar.IntegrationTest
{
    [TestFixture]
    class ToolbarIntegrationTests
    {
        private IDataServices _dataServices;
        private IMock<IRegionManager> _regionManager = new Mock<IRegionManager>();

        private KarveToolBarViewModel _carveBarViewModel;
        private TestBase _testBase = new TestBase();

        public void Setup()
        {
            IConfigurationService service = _testBase.SetupConfigurationService();
            ISqlExecutor _executor = _testBase.SetupSqlQueryExecutor();
            _dataServices = new DataServiceImplementation(_executor);
            _carveBarViewModel = new KarveToolBarViewModel(_dataServices, _eventManger, _careKeerp, _regionManager, service);


        }
        public void Should_Save_CommissionAgent_Visits()
        {
            DataPayLoad payload = new DataPayLoad();
            payload.Subsystem = DataSubSystem.CommissionAgentSubystem;
            payload.HasRelatedObject = true;
            var visitDto = new List<VisitsDto>()
            {
                new VisitsDto() { ClientId = "1",
                                  VisitId = "12",
                                  ContactsSource = new ContactsDto()
                                  {
                                     ContactName = "Giorgio",
                                     ContactId = "181928"
                                  }, Date = DateTime.Now,
                                    Email = "giorgio@apache.org",
                                    IsNew = true,
                                    IsChanged = true,
                                    IsDirty = true,
                                    IsOrder = false,
                                    LastModification = DateTime.Now.ToString("yyyMMddHHmmss"),
                                    User="cv",
                                    VisitType = new VisitTypeDto(){ Code = "1", Name="23"}
                },
                new VisitsDto() { ClientId = "2",
                                  VisitId = "15",
                                  ContactsSource = new ContactsDto()
                                  {
                                     ContactName = "Giorgio",
                                     ContactId = "181928"
                                  }, Date = DateTime.Now,
                                    Email = "giorgio@apache.org",
                                    IsNew = true,
                                    IsChanged = true,
                                    IsDirty = true,
                                    IsOrder = false,
                                    LastModification = DateTime.Now.ToString("yyyMMddHHmmss"),
                                    User="cv",
                                    VisitType = new VisitTypeDto(){ Code = "1", Name="23"}
                }
            };


            payload.RelatedObject = visitDto;
            payload.PayloadType = DataPayLoad.Type.UpdateInsertGrid;
            _carveBarViewModel.IncomingPayload(payload);
            try
            {
                _carveBarViewModel.SaveCommand.Execute(payload);
            } catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }


    }

}
