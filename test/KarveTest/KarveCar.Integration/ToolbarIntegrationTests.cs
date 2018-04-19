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
using Prism.Regions;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using System.Linq;
using KarveDataServices.DataObjects;

namespace KarveCar.IntegrationTest
{
    [TestFixture]
    class ToolbarIntegrationTests
    {
        private Mock<IRegionManager> _regionManager = new Mock<IRegionManager>();
        private Mock<IEventManager> _eventManager = new Mock<IEventManager>();
        private IDataServices _dataServices;
        private ICareKeeperService _careKeeperService = new CareKeeper();
        private IConfigurationService _configurationService;
        private KarveToolBarViewModel _carveBarViewModel;
        private TestBase _testBase = new TestBase();

        private async Task<string> GetSampleId()
        {
            var retValue = string.Empty;
            var commissionAgent = _dataServices.GetCommissionAgentDataServices();
            var commissionList = await commissionAgent.GetCommissionAgentSummaryDo();
            var firstDefault = commissionList.FirstOrDefault();
            retValue = firstDefault.Code;
            return retValue;
        }
        private IList<VisitsDto> CreateVisitDuplicatedList(string id)
        {
            var visitDto = new List<VisitsDto>()
            {
                new VisitsDto() { ClientId = id,
                                  VisitId = "200100",
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
                new VisitsDto() {
                                  ClientId = id,
                                  VisitId = "200100",
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
                                    VisitType = new VisitTypeDto(){ Code = "1", Name="NotInMyName"}
                }


        };
            return visitDto;
        }

        private DataPayLoad FillCommissionPayLoad(object dataObject, IEnumerable<VisitsDto> visitsDto)
        {
            var newPayLoad = new DataPayLoad();
            newPayLoad.DataObject = dataObject;
            newPayLoad.HasDataObject = true;
            newPayLoad.HasRelatedObject = true;
            newPayLoad.RelatedObject = visitsDto;
            return newPayLoad;
        }
        [OneTimeSetUp]
        public void Setup()
        {
            _careKeeperService = new CareKeeper();
            _configurationService = _testBase.SetupConfigurationService();
            var executor = _testBase.SetupSqlQueryExecutor();
            _dataServices = new DataServiceImplementation(executor);
            _carveBarViewModel = new KarveToolBarViewModel(_dataServices,
                 _eventManager.Object,
                 _careKeeperService,
                 _regionManager.Object,
                 _configurationService);
        }

        [Test]
        public async Task WhenIntegratedShould_Save_NewSupplierContact()
        {
            // arrange
            var supplierServices = _dataServices.GetSupplierDataServices();
            var allSuppliers = await supplierServices.GetSupplierAsyncSummaryDo();
            var supplier = allSuppliers.FirstOrDefault();
            var codeId = supplier.Codigo;
            var supplierItem = await supplierServices.GetAsyncSupplierDo(codeId);
            ContactsDto dto = new ContactsDto();
            dto.ResponsabilitySource = new PersonalPositionDto();
            dto.ResponsabilitySource.Code = "1";
            dto.ResponsabilitySource.Name = "GERENTE";
            dto.Responsability = "1";
            dto.Movil = "657837133";
            dto.Nif = "Y167821S";
            dto.Email = "carlos@gmail.com";
            dto.IsNew = true;
            dto.IsDirty = true;
            dto.LastModification = DateTime.Now.ToString("yyyyMMddHH:mm");
            dto.User = "CV";
            List<ContactsDto> contactsDto = new List<ContactsDto>();
            contactsDto.Add(dto);
            supplierItem.ContactsDto = supplierItem.ContactsDto.Union(contactsDto);
            DataPayLoad payload = new DataPayLoad();
            payload.PayloadType = DataPayLoad.Type.UpdateInsertGrid;
            payload.RelatedObject = dto;
            // act
            _carveBarViewModel.IncomingPayload(payload);
            _carveBarViewModel.SaveCommand.Execute();
            // assert
            var contacts =  await supplierServices.GetAsyncContacts(codeId);
           



        }

        [Test]
        public async Task WhenIntegratedShould_Throw_ErrorWithInvalidVisit()
        {
            // arrange
            var id = await GetSampleId();
            var commissionAgent = _dataServices.GetCommissionAgentDataServices();
            ICommissionAgent agent = await commissionAgent.GetCommissionAgentDo(id);
            var visitDto = CreateVisitDuplicatedList(id);
            var payload = FillCommissionPayLoad(agent, visitDto);
            payload.Subsystem = DataSubSystem.CommissionAgentSubystem;
            payload.PayloadType = DataPayLoad.Type.UpdateInsertGrid;
            _carveBarViewModel.IncomingPayload(payload);
            Assert.GreaterOrEqual(_careKeeperService.ScheduledPayloadCount(), 1);
            // execute
            var ex = Assert.Throws<Exception>(() => _carveBarViewModel.SaveCommand.Execute());
            // Assert.Throws(_carveBarViewModel.SaveCommand.Execute();
            var message= ex.Message;
        }
       
        [Test]
        public async Task WhenIntegratedShould_Save_CommissionAgent_Visits()
        {
            DataPayLoad payload = new DataPayLoad();
           IHelperDataServices helperDataService = _dataServices.GetHelperDataServices();
            var helper = await helperDataService.GetMappedAllAsyncHelper<ComisioDto, COMISIO>().ConfigureAwait(false);
            var firstCommisionAgent = helper.FirstOrDefault();
            var commissionAgent = await _dataServices.GetCommissionAgentDataServices().GetCommissionAgentDo(firstCommisionAgent.NUM_COMI);
            payload.Subsystem = DataSubSystem.CommissionAgentSubystem;
            payload.HasRelatedObject = true;
            payload.DataObject = commissionAgent;
            
            var rand = new Random();
            var rValue = rand.Next() % 100;
            var countVisit = commissionAgent.VisitsDto.Count();
            var visitDto = new List<VisitsDto>()
            {
                new VisitsDto() { ClientId = commissionAgent.Value.NUM_COMI,
                                  VisitId = rValue.ToString(),
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
                new VisitsDto() {
                                  ClientId = commissionAgent.Value.NUM_COMI,
                                  VisitId = (rValue + 10).ToString(),
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
                                    VisitType = new VisitTypeDto(){ Code = "1", Name="NotInMyName"}
                }
            };
            // act.
            payload.RelatedObject = visitDto;
            payload.Subsystem = DataSubSystem.CommissionAgentSubystem;
            payload.PayloadType = DataPayLoad.Type.UpdateInsertGrid;
            _carveBarViewModel.IncomingPayload(payload);
            Assert.GreaterOrEqual(_careKeeperService.ScheduledPayloadCount(), 1);

            try
            {
                _carveBarViewModel.SaveCommand.Execute();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            // now i shall assert from the helper data service that is all ok.
            var commisionAgentDataService =  _dataServices.GetCommissionAgentDataServices();
            ICommissionAgent agent = await commisionAgentDataService.GetCommissionAgentDo(commissionAgent.Value.NUM_COMI);
            Assert.NotNull(agent);
            IEnumerable<VisitsDto> visit = agent.VisitsDto;
            Assert.NotNull(agent.VisitsDto);
            Assert.AreEqual(visit.Count(), countVisit+2);
        
        }
       
    }

}
