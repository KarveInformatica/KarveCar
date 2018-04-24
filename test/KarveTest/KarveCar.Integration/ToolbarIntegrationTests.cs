using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using KarveTest.DAL;
using MasterModule.ViewModels;
using Moq;
using NUnit.Framework;
using Prism.Regions;
using ToolBarModule;

namespace KarveCar.Integration
{
    /*
     * This test feature test the crud for office creation.
     */
    [TestFixture]
    internal class ToolbarIntegrationTests
    {
        private readonly Mock<IRegionManager> _regionManager = new Mock<IRegionManager>();
        private readonly Mock<IEventManager> _eventManager = new Mock<IEventManager>();
        private readonly TestBase _testBase = new TestBase();
        private readonly Mock<IDialogService> _dialogService = new Mock<IDialogService>();
        private IDataServices _dataServices;
        private ICareKeeperService _careKeeperService = new CareKeeper();
        private IConfigurationService _configurationService;
        private KarveToolBarViewModel _carveBarViewModel;
        public bool MessageErrorCalled = false;
        public bool IsNavigated = false;
        private string _subSystem = string.Empty;
        private DataPayLoad _notifiedPayLoad = new DataPayLoad();
        private DataPayLoad _receivedPayLoad = new DataPayLoad();

        /// <summary>
        ///  Helper function for getting a new id for the commission agent.
        /// </summary>
        /// <returns>A new id for commission agent</returns>
        private async Task<string> GetSampleBrokerId()
        {
            var retValue = string.Empty;
            var commissionAgent = _dataServices.GetCommissionAgentDataServices();
            var commissionList = await commissionAgent.GetCommissionAgentSummaryDo();
            var firstDefault = commissionList.FirstOrDefault();
            if (firstDefault != null)
            {
                retValue = firstDefault.Code;
            }
           
            return retValue;
        }
        /// <summary>
        ///  Create a visit duplicated id for the commission agent integration.
        /// </summary>
        /// <param name="id">Client duplicated id.</param>
        /// <returns></returns>
        public IList<VisitsDto> CreateVisitDuplicatedList(string id)
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
        /// <summary>
        ///  This fill the commission payload.
        /// </summary>
        /// <param name="dataObject"></param>
        /// <param name="visitsDto"></param>
        /// <returns></returns>
        private static DataPayLoad FillCommissionPayLoad(object dataObject, IEnumerable<VisitsDto> visitsDto)
        {
            var newPayLoad = new DataPayLoad
            {
                DataObject = dataObject,
                HasDataObject = true,
                HasRelatedObject = true,
                RelatedObject = visitsDto
            };
            return newPayLoad;
        }
        /// <summary>
        /// Setup of the toolbar.
        /// </summary>
        [OneTimeSetUp]
        public void Setup()
        {
            _careKeeperService = new CareKeeper();
            _configurationService = _testBase.SetupConfigurationService();
            var executor = _testBase.SetupSqlQueryExecutor();
            _dataServices = new DataServiceImplementation(executor);
            _dialogService.Setup(x => x.ShowErrorMessage(It.IsAny<string>())).Callback(() =>
            {
                MessageErrorCalled = true;
            });
            _regionManager.Setup(x => x.RequestNavigate(It.IsAny<string>(), It.IsAny<Uri>())).Callback(() =>
                {
                    IsNavigated = true;
                });
            _eventManager.Setup(x=>x.NotifyObserverSubsystem(It.IsAny<string>(), It.IsAny<DataPayLoad>())).Callback<string, DataPayLoad>(
                (subsystem, payload) =>
                {
                    _notifiedPayLoad = payload;
                    _subSystem = subsystem;
                });
            _eventManager.Setup(x => x.SendMessage(It.IsAny<string>(), It.IsAny<DataPayLoad>()))
                .Callback<string, DataPayLoad>(
                    (x1, x2) => { _receivedPayLoad = x2; });
            _carveBarViewModel = new KarveToolBarViewModel(_dataServices,
                 _eventManager.Object,
                 _careKeeperService,
                 _regionManager.Object,
                _dialogService.Object,
                 _configurationService);
        }
        /// <summary>
        ///  This test verify the process of saving a new supplier contact.
        /// </summary>
        /// <returns>A task or an exception</returns>
        [Test]
        public async Task WhenIntegratedShould_Save_NewSupplierContact()
        {
            // arrange
            var supplierServices = _dataServices.GetSupplierDataServices();
            var allSuppliers = await supplierServices.GetSupplierAsyncSummaryDo();
            var supplier = allSuppliers.FirstOrDefault();
            if (supplier != null)
            {
                var codeId = supplier.Codigo;
                var supplierItem = await supplierServices.GetAsyncSupplierDo(codeId);
                var dto = new ContactsDto();
                var random = new Random();
                var rand = random.Next() % 2000;
                dto.ContactId = rand.ToString();
                dto.ResponsabilitySource = new PersonalPositionDto
                {
                    Code = "1",
                    Name = "GERENTE"
                };
                dto.ContactName = "SimonLeBond" + rand;
                dto.Responsability = "1";
                dto.Movil = "657837133";
                dto.Nif = "Y167821S";
                dto.Email = "carlos@gmail.com";
                dto.IsNew = true;
                dto.IsDirty = true;
                dto.LastModification = DateTime.Now.ToString("yyyyMMddHH:mm");
                dto.User = "CV";
                var contactsDto = new List<ContactsDto>
                {
                    dto
                };
                supplierItem.ContactsDto = supplierItem.ContactsDto.Union(contactsDto);
                // we shall always send type, dataobject, subsystem to the toolbar because otherwise
                // we fail.
                var payload = new DataPayLoad
                {
                    PayloadType = DataPayLoad.Type.UpdateInsertGrid,
                    RelatedObject = supplierItem.ContactsDto,
                    DataObject = supplierItem,
                    Subsystem = DataSubSystem.SupplierSubsystem
                };
                // act
                _carveBarViewModel.IncomingPayload(payload);
                _carveBarViewModel.SaveCommand.Execute();
                // assert
                var savedSupplier = await supplierServices.GetAsyncSupplierDo(codeId);
                var value = supplierItem.ContactsDto.Count();
                Assert.AreEqual(value, savedSupplier.ContactsDto.Count());
                return;
            }
            Assert.Fail("Cannot retrieve the suppliers");
        }
        /// <summary>
        /// This test verify the throw of an exception 
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task WhenIntegratedShould_Throw_ErrorWithInvalidVisit()
        {
            // arrange
            var id = await GetSampleBrokerId();
            var commissionAgent = _dataServices.GetCommissionAgentDataServices();
            var agent = await commissionAgent.GetCommissionAgentDo(id);
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
           
            var payload = new DataPayLoad();
            var helperDataService = _dataServices.GetHelperDataServices();
            var helper = await helperDataService.GetMappedAllAsyncHelper<ComisioDto, COMISIO>().ConfigureAwait(false);
            var firstCommisionAgent = helper.FirstOrDefault();
            if (firstCommisionAgent != null)
            {
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
        }
        private async Task<OfficeDtos> SendPacketOfficeToToolbar(DataPayLoad.Type type)
        {

            var payload = new DataPayLoad();
            var helperDataService = _dataServices.GetHelperDataServices();
            var helper = await helperDataService.GetMappedAllAsyncHelper<OfficeDtos, OFICINAS>().ConfigureAwait(false);
            var officeData = helper.FirstOrDefault();
            var officeDataService = _dataServices.GetOfficeDataServices();
            if (officeData != null)
            {
                var office = await officeDataService.GetAsyncOfficeDo(officeData.Codigo);
                payload.Subsystem = DataSubSystem.OfficeSubsystem;
                payload.PayloadType = type;
                payload.HasRelatedObject = true;
                payload.DataObject = office;
            }

            _carveBarViewModel.IncomingPayload(payload);
            return officeData;
        }
        /// <summary>
        ///  Sedn packet company to toolbar.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private ICompanyData BuildCompany(DataPayLoad.Type type, string id)
        {
            var payload = new DataPayLoad
            {
                Subsystem = DataSubSystem.OfficeSubsystem,
                PayloadType = type,
                HasRelatedObject = false
            };
            var companyDataService = _dataServices.GetCompanyDataServices();
            var company = companyDataService.GetNewCompanyDo(id);
            payload.DataObject = company.Value;
            return company;

        }
        private OfficeDtos SendPacketInsertToToolbar(DataPayLoad.Type type)
        {

            var payload = new DataPayLoad();
            var officeDataService = _dataServices.GetOfficeDataServices();
            var officeId = officeDataService.GetNewId();
            var office = officeDataService.GetNewOfficeDo(officeId);
       
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
            var officeData = await SendPacketOfficeToToolbar(DataPayLoad.Type.Update);
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
        /*
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
            Assert.AreEqual(offices.Value.Codigo, officeData.Codigo);
        }
        */

        [Test]
        public async Task WhenIntegratedShould_Insert_ACompany()
        {
            _receivedPayLoad = null;
           
            var companyDataServices = _dataServices.GetCompanyDataServices();
            var viewModel = new CompanyControlViewModel(_configurationService,
                _eventManager.Object,
                _dialogService.Object,
                _dataServices,
                _regionManager.Object);

            DataPayLoad registrationPayload = new DataPayLoad
            {
                PayloadType = DataPayLoad.Type.RegistrationPayload,
                Subsystem = DataSubSystem.CompanySubsystem
            };
            _carveBarViewModel.IncomingPayload(registrationPayload);
            _carveBarViewModel.NewCommand.Execute(null);
            if (_receivedPayLoad != null)
            {
                Assert.AreEqual(_receivedPayLoad.PayloadType, DataPayLoad.Type.Insert);
            }

            viewModel.NewItem();
           
            Assert.AreEqual("CompanySystemName", this._subSystem);
            if (_notifiedPayLoad.DataObject is ICompanyData data)
            {
                var dto = data.Value;
                dto.NOMBRE = "Giorgio";
                var value = await companyDataServices.SaveAsync(data);
                Assert.AreEqual(value, true);
                var company = await companyDataServices.GetAsyncCompanyDo(data.Value.CODIGO);
                Assert.AreEqual(company.Value.NOMBRE, dto.NOMBRE);
                Assert.AreEqual(company.Value.CODIGO, dto.CODIGO);
            }
            
        }
        /// <summary>
        /// Update A Company.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task WhenIntegratedShould_Update_ACompany()
        {
            _receivedPayLoad = null;
            var companyDataServices = _dataServices.GetCompanyDataServices();
            var id = await companyDataServices.GetAsyncAllCompanySummary();
            var code = id.FirstOrDefault();
            if (code != null)
            {
                DataPayLoad registrationPayload = new DataPayLoad
                {
                    PayloadType = DataPayLoad.Type.RegistrationPayload,
                    Subsystem = DataSubSystem.CompanySubsystem
                };
                var payLoad = new DataPayLoad
                {
                    DataObject = code.Value,
                    HasDataObject = true
                };
                _carveBarViewModel.IncomingPayload(registrationPayload);
                _carveBarViewModel.IncomingPayload(payLoad);
            }
        }
        /// <summary>
        /// When integrated should delete a company.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task WhenIntegratedShould_Delete_ACompany()
        {
            _receivedPayLoad = null;
            var companyDataServices = _dataServices.GetCompanyDataServices();
            var viewModel = new CompanyControlViewModel(_configurationService,
                _eventManager.Object,
                _dialogService.Object,
                _dataServices,
                _regionManager.Object);
          
        }
        [Test]
        public async Task WhenIntegratedShould_Delete_Office()
        {
            bool sentDeleteMessage = false;
            DataPayLoad payload = new DataPayLoad();
            _eventManager.Setup(x => x.SendMessage(It.IsAny<string>(),It.IsAny<DataPayLoad>())).Callback(() => {
                sentDeleteMessage = true;
            });
            // arrange
           
            var viewModel = new OfficesControlViewModel(_configurationService, _eventManager.Object, _dataServices, _regionManager.Object);

            var helperDataService = _dataServices.GetHelperDataServices();
            var helper = await helperDataService.GetMappedAllAsyncHelper<OfficeDtos, OFICINAS>().ConfigureAwait(false);
            var officeData = helper.FirstOrDefault();
            if (officeData != null)
            {
                var officeDataService = _dataServices.GetOfficeDataServices();
                var office = await officeDataService.GetAsyncOfficeDo(officeData.Codigo);

                payload.Subsystem = DataSubSystem.OfficeSubsystem;
                payload.PayloadType = DataPayLoad.Type.Delete;
                payload.HasRelatedObject = true;
                payload.DataObject = office;



                var registrationPayLoad = new DataPayLoad
                {
                    PayloadType = DataPayLoad.Type.RegistrationPayload,
                    Subsystem = DataSubSystem.OfficeSubsystem
                };
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
                bool retValue = await viewModel.DeleteAsync(officeData.Codigo, payload);
                Assert.AreEqual(retValue, true);
                Assert.AreEqual(sentDeleteMessage, true);
            }

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
            
            var payload = new DataPayLoad();
            var companyDs = await _dataServices.GetCompanyDataServices().GetAsyncAllCompanySummary();

            var company = companyDs.FirstOrDefault();
            if (company != null)
            {
                var companyCode = company.Code;
                var officeDataService = _dataServices.GetOfficeDataServices();
                var officeId = officeDataService.GetNewId();
                var holidays = CraftGoodHolidays(officeId);
                var timeTable = CraftWeeklyTime();
                var officeDo = officeDataService.GetNewOfficeDo(officeId);
                var officeDtos = new OfficeDtos()
                {
                    HolidayDates = holidays,
                    TimeTable = timeTable,
                    SUBLICEN = companyCode,
                    CP = "08006",
                    Nombre = "KARVE",
                    EMAIL_OFI = "giorgio@gmail.com",
                    IsDirty = true,
                    IsNew = true,
                    Codigo= officeId
                };
                officeDo.Valid = true;
                officeDo.Value = officeDtos;
                var value = await officeDataService.SaveAsync(officeDo);
                Assert.IsTrue(value);
                var office = await officeDataService.GetAsyncOfficeDo(officeId);
                Assert.AreEqual(officeId, office.Value.Codigo);
                
                var expectedHolidayDtos = officeDtos.HolidayDates.OrderBy(x => x.FESTIVO);
                var realholidayDates = officeDtos.HolidayDates.OrderBy(x => x.FESTIVO);
                Assert.AreEqual(expectedHolidayDtos, realholidayDates);
                CollectionAssert.AreEqual(expectedHolidayDtos, realholidayDates);
                Assert.AreEqual(officeDtos.TimeTable.Count, timeTable.Count);
            }
        }
    }
}
