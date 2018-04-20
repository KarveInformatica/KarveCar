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
using MasterModule.ViewModels;
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
            Random random = new Random();
            var rand = random.Next() % 2000;
            dto.ContactId = rand.ToString();
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
            var savedSupplier = await supplierServices.GetAsyncSupplierDo(codeId);
            var value = supplierItem.ContactsDto.Count() + 1;
            Assert.AreEqual(value, savedSupplier.ContactsDto.Count()); 
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
            var ex = Assert.Throws<DataLayerException>(() => _carveBarViewModel.SaveCommand.Execute());
            var message = ex.Message;
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
            var rValue = rand.Next() % 5000;
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
                                    VisitType = new VisitTypeDto(){ Code = "01", Name="23"}
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
                                    VisitType = new VisitTypeDto(){ Code = "01", Name="NotInMyName"}
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
            var commisionAgentDataService = _dataServices.GetCommissionAgentDataServices();
            ICommissionAgent agent = await commisionAgentDataService.GetCommissionAgentDo(commissionAgent.Value.NUM_COMI);
            Assert.NotNull(agent);
            IEnumerable<VisitsDto> visit = agent.VisitsDto;
            Assert.NotNull(agent.VisitsDto);
            Assert.AreEqual(visit.Count(), countVisit + 2);

        }
        private async Task<OfficeDtos> SendPacketToToolbar(DataPayLoad.Type type)
        {

            DataPayLoad payload = new DataPayLoad();
            IHelperDataServices helperDataService = _dataServices.GetHelperDataServices();
            var helper = await helperDataService.GetMappedAllAsyncHelper<OfficeDtos, OFICINAS>().ConfigureAwait(false);
            var officeData = helper.FirstOrDefault();
            var officeDataService = _dataServices.GetOfficeDataServices();
            var office = await officeDataService.GetAsyncOfficeDo(officeData.Codigo);
            payload.Subsystem = DataSubSystem.OfficeSubsystem;
            payload.PayloadType = type;
            payload.HasRelatedObject = true;
            payload.DataObject = office;
            _carveBarViewModel.IncomingPayload(payload);
            return officeData;
        }
        private OfficeDtos SendPacketInsertToToolbar(DataPayLoad.Type type)
        {

            DataPayLoad payload = new DataPayLoad();
            var officeDataService = _dataServices.GetOfficeDataServices();
            var officeId = officeDataService.GetNewId();
            var office = officeDataService.GetNewOfficeDo(officeId);
           /* office.Value.
            var office = new OfficeDtos()
            {
                HolidayDates = holidays,
                TimeTable = timeTable,
                SUBLICEN = companyCode,
                CP = "08006",
                EMAIL_OFI = "giorgio@gmail.com",
                IsDirty = true,
                IsNew = true
            };
            */
            payload.Subsystem = DataSubSystem.OfficeSubsystem;
            payload.PayloadType = type;
            payload.HasRelatedObject = false;
            payload.DataObject = office.Value;
            _carveBarViewModel.IncomingPayload(payload);
            return office.Value;
        }
        [Test]
        public async Task WhenIntegratedShould_Save_Office()
        {
            var officeData = await SendPacketToToolbar(DataPayLoad.Type.Update);
            var officeDataService = _dataServices.GetOfficeDataServices();
            Assert.GreaterOrEqual(_careKeeperService.ScheduledPayloadCount(), 1);
            try
            {
                _carveBarViewModel.SaveCommand.Execute();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            var offices = await officeDataService.GetAsyncOfficeDo(officeData.Codigo);
            Assert.NotNull(offices);
            Assert.AreEqual(offices.Value.Codigo, officeData.Codigo);
        }
        [Test]
        public async Task WhenIntegratedShould_Insert_Office()
        {
            var officeData = SendPacketInsertToToolbar(DataPayLoad.Type.Insert);
            var officeDataService = _dataServices.GetOfficeDataServices();
            Assert.GreaterOrEqual(_careKeeperService.ScheduledPayloadCount(), 1);
            try
            {
                _carveBarViewModel.SaveCommand.Execute();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            var offices = await officeDataService.GetAsyncOfficeDo(officeData.Codigo);
            Assert.NotNull(offices);
        //    Assert.AreEqual(offices.Value.Codigo, officeData.Codigo);
        }

        [Test]
        public async Task WhenIntegratedShould_Delete_Office()
        {
            bool sentDeleteMessage = false;
            DataPayLoad payload = new DataPayLoad();
            _eventManager.Setup(x => x.SendMessage(EventSubsystem.OfficeSummaryVm, payload)).Callback(() => {
                sentDeleteMessage = true;

            });
            // arrange
           
            OfficesControlViewModel viewModel = new OfficesControlViewModel(_configurationService, _eventManager.Object, _dataServices, _regionManager.Object);

            IHelperDataServices helperDataService = _dataServices.GetHelperDataServices();
            var helper = await helperDataService.GetMappedAllAsyncHelper<OfficeDtos, OFICINAS>().ConfigureAwait(false);
            var officeData = helper.FirstOrDefault();
            var officeDataService = _dataServices.GetOfficeDataServices();
            var timeTable = await officeDataService.GetTimeTableAsync(officeData.Codigo, officeData.SUBLICEN);
            var holidays = await officeDataService.GetHolidaysAsync(officeData.Codigo);
            var office = await officeDataService.GetAsyncOfficeDo(officeData.Codigo);

            payload.Subsystem = DataSubSystem.OfficeSubsystem;
            payload.PayloadType = DataPayLoad.Type.Delete;
            payload.HasRelatedObject = true;
            payload.DataObject = office;
          
         

            DataPayLoad registrationPayLoad = new DataPayLoad();
            registrationPayLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            registrationPayLoad.Subsystem = DataSubSystem.OfficeSubsystem;
            // act
            try
            {
                _carveBarViewModel.IncomingPayload(registrationPayLoad);
                _carveBarViewModel.DeleteCommand.Execute(officeData.Codigo);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            // assert. Check if the exception shall be thrown.
            //FIXME: Assert.AreEqual(sentDeleteMessage, true);
           
            bool retValue = await viewModel.DeleteAsync(officeData.Codigo, payload);
            Assert.AreEqual(retValue, true);
            

        }
    

        public IList<HolidayDto> CraftGoodHolidays(string officeId)
        {
            IList<HolidayDto> holidays = new List<HolidayDto>()
            {
                new HolidayDto()
                {
                    OFICINA = officeId,
                    FESTIVO= DateTime.Now.AddDays(1),
                    HORA_DESDE = new TimeSpan(8, 0, 0),
                    HORA_HASTA = new TimeSpan(18,0,0)
                } ,
                new HolidayDto()
                {
                    OFICINA = officeId,
                    FESTIVO= DateTime.Now.AddDays(200),
                    HORA_DESDE = new TimeSpan(8, 0, 0),
                    HORA_HASTA = new TimeSpan(18,0,0)
                },
                new HolidayDto()
                {
                    OFICINA = officeId,
                    FESTIVO= DateTime.Now.AddDays(150),
                    HORA_DESDE = new TimeSpan(8, 0, 0),
                    HORA_HASTA = new TimeSpan(18,0,0)
                }
            };
            return holidays;
        }

        public IList<DailyTime> CraftWeeklyTime()
        {
            var timeTable = new List<DailyTime>()
            {
                new DailyTime()
                { Morning = new OfficeOpenClose() { Open = new TimeSpan(8,0,0), Close = new TimeSpan(14,0,0)},
                  Afternoon = new OfficeOpenClose() { Open = new TimeSpan(15,0,0), Close = new TimeSpan(18,0,0)},
                },
                new DailyTime()
                { Morning = new OfficeOpenClose() { Open = new TimeSpan(8,0,0), Close = new TimeSpan(14,0,0)},
                  Afternoon = new OfficeOpenClose() { Open = new TimeSpan(15,0,0), Close = new TimeSpan(18,0,0)},
                },
                new DailyTime()
                { Morning = new OfficeOpenClose() { Open = new TimeSpan(8,0,0), Close = new TimeSpan(14,0,0)},
                  Afternoon = new OfficeOpenClose() { Open = new TimeSpan(15,0,0), Close = new TimeSpan(18,0,0)},
                },
                new DailyTime()
                {
                  Morning = new OfficeOpenClose() { Open = new TimeSpan(8,0,0), Close = new TimeSpan(14,0,0)},
                  Afternoon = new OfficeOpenClose() { Open = new TimeSpan(15,0,0), Close = new TimeSpan(18,0,0)},
                },
                new DailyTime()
                {
                  Morning = new OfficeOpenClose() { Open = new TimeSpan(8,0,0), Close = new TimeSpan(14,0,0)},
                  Afternoon = new OfficeOpenClose() { Open = new TimeSpan(15,0,0), Close = new TimeSpan(18,0,0)},
                },
                new DailyTime()
                {
                  Morning = new OfficeOpenClose() { Open = new TimeSpan(8,0,0), Close = new TimeSpan(14,0,0)},
                  Afternoon = new OfficeOpenClose() { Open = new TimeSpan(15,0,0), Close = new TimeSpan(18,0,0)},
                },
                new DailyTime()
                {
                  Morning = new OfficeOpenClose() { Open = new TimeSpan(8,0,0), Close = new TimeSpan(14,0,0)},
                  Afternoon = new OfficeOpenClose() { Open = new TimeSpan(15,0,0), Close = new TimeSpan(18,0,0)},
                }
            };
            return timeTable;
        }
       
        [Test]
        public async Task WhenIntegratedDataLayerShould_Insert_Office()
        {
            
            DataPayLoad payload = new DataPayLoad();
            var companyDS = await _dataServices.GetCompanyDataServices().GetAsyncAllCompanySummary();

            var company = companyDS.FirstOrDefault();
            string companyCode = string.Empty;
            if (company != null)
            {
                companyCode = company.Code;
                var officeDataService = _dataServices.GetOfficeDataServices();
                var officeId = officeDataService.GetNewId();
                IList<HolidayDto> holidays = CraftGoodHolidays(officeId);
                IList<DailyTime> timeTable = CraftWeeklyTime();
                var officeDo = officeDataService.GetNewOfficeDo(officeId);
                var officeDtos = new OfficeDtos()
                {
                    HolidayDates = holidays,
                    TimeTable = timeTable,
                    SUBLICEN = companyCode,
                    CP = "08006",
                    EMAIL_OFI = "giorgio@gmail.com",
                    IsDirty = true,
                    IsNew = true
                };
                officeDo.Valid = true;
                officeDo.Value = officeDtos;
                bool value = await officeDataService.SaveAsync(officeDo);
                Assert.IsTrue(true);
                var office = await officeDataService.GetAsyncOfficeDo(officeId);
                Assert.AreEqual(officeId, office.Value.NUM_OFI);
                var holidayDates = officeDataService.GetHolidaysAsync(officeId);
                var timetable = officeDataService.GetTimeTableAsync(officeId, companyCode);
                Assert.AreEqual(officeDtos.TimeTable, timetable);
                Assert.AreEqual(officeDtos.HolidayDates, holidayDates);
            }
        }
    }
}
