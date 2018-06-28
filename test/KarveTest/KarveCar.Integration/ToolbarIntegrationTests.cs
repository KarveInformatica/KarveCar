using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Model;
using InvoiceModule.ViewModels;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDapper.Extensions;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using KarveTest.DAL;
using MasterModule.ViewModels;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Prism.Regions;
using ToolBarModule;
using BookingModule.ViewModels;

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
        private readonly Mock<IInteractionRequestController> _interactionRequestController = new Mock<IInteractionRequestController>();
        private readonly Mock<IUnityContainer> _unityContainer = new Mock<IUnityContainer>();
        private IDataServices _dataServices;
        private ICareKeeperService _careKeeperService = new CareKeeper();
        private IConfigurationService _configurationService;
        private KarveToolBarViewModel _carveBarViewModel;
        public bool MessageErrorCalled = false;
        public bool IsNavigated = false;
        private string _subSystem = string.Empty;
        private DataPayLoad _notifiedPayLoad = new DataPayLoad();
        private DataPayLoad _receivedPayLoad = new DataPayLoad();
        private DataPayloadFactory _factory = DataPayloadFactory.GetInstance();


        /// <summary>
        ///  Helper function for getting a new id for the commission agent.
        /// </summary>
        /// <returns>A new id for commission agent</returns>
        private async Task<string> GetSampleBrokerId()
        {
            var retValue = string.Empty;
            var commissionAgent = _dataServices.GetCommissionAgentDataServices();
            var commissionList = await commissionAgent.GetPagedSummaryDoAsync(2, 2);
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
                new VisitsDto()
                {
                    ClientId = id,
                    VisitId = "200100",
                    ContactsSource = new ContactsDto()
                    {
                        ContactName = "Giorgio",
                        ContactId = "181928"
                    },
                    Date = DateTime.Now,
                    Email = "giorgio@apache.org",
                    IsNew = true,
                    IsChanged = true,
                    IsDirty = true,
                    IsOrder = false,
                    LastModification = DateTime.Now.ToString("yyyMMddHHmmss"),
                    User = "cv",
                    VisitType = new VisitTypeDto() {Code = "1", Name = "23"}
                },
                new VisitsDto()
                {
                    ClientId = id,
                    VisitId = "200100",
                    ContactsSource = new ContactsDto()
                    {
                        ContactName = "Giorgio",
                        ContactId = "181928"
                    },
                    Date = DateTime.Now,
                    Email = "giorgio@apache.org",
                    IsNew = true,
                    IsChanged = true,
                    IsDirty = true,
                    IsOrder = false,
                    LastModification = DateTime.Now.ToString("yyyMMddHHmmss"),
                    User = "cv",
                    VisitType = new VisitTypeDto() {Code = "1", Name = "NotInMyName"}
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
                ObjectPath = new Uri("karve://commission/viewmodel/id/839328"),
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
            _dialogService.Setup(x => x.ShowErrorMessage(It.IsAny<string>()))
                .Callback(() => { MessageErrorCalled = true; });
            _regionManager.Setup(x => x.RequestNavigate(It.IsAny<string>(), It.IsAny<Uri>()))
                .Callback(() => { IsNavigated = true; });
            _eventManager.Setup(x => x.NotifyObserverSubsystem(It.IsAny<string>(), It.IsAny<DataPayLoad>()))
                .Callback<string, DataPayLoad>(
                    (subsystem, payload) =>
                    {
                        _notifiedPayLoad = payload;
                        _subSystem = subsystem;
                    });
            // _eventManager.No
            _eventManager.Setup(x => x.SendMessage(It.IsAny<string>(), It.IsAny<DataPayLoad>()))
                .Callback<string, DataPayLoad>(
                    (x1, x2) =>
                    {
                        _receivedPayLoad = x2;
                        _eventManager.Object.NotifyObserverSubsystem(_receivedPayLoad.SubsystemName, _receivedPayLoad);
                    });


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
            var allSuppliers = await supplierServices.GetPagedSummaryDoAsync(1, 2);
            var supplier = allSuppliers.FirstOrDefault();
            if (supplier != null)
            {
                var codeId = supplier.Codigo;
                var supplierItem = await supplierServices.GetAsyncSupplierDo(codeId);
                var dto = new ContactsDto();
                var random = new Random();
                var rand = random.Next() % 2000;
                dto.ContactId = rand.ToString();
                dto.ContactsKeyId = codeId;
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
                    HasRelatedObject = true,
                    PayloadType = DataPayLoad.Type.UpdateInsertGrid,
                    RelatedObject = supplierItem.ContactsDto,
                    DataObject = supplierItem,
                    ObjectPath = new Uri("office://supplier/viewmodel/id/28928"),
                    Subsystem = DataSubSystem.SupplierSubsystem
                };
                // act
                _carveBarViewModel.IncomingPayload(payload);
                _carveBarViewModel.SaveCommand.Execute();
                // assert
                var savedSupplier = await supplierServices.GetAsyncSupplierDo(codeId);
                var supplierItemContactsDto =
                    supplierItem.ContactsDto as ContactsDto[] ?? supplierItem.ContactsDto.ToArray();
                var value = supplierItemContactsDto.Count();
                var currentContact = supplierItemContactsDto.FirstOrDefault(x => x.ContactId == dto.ContactId);


                Assert.AreEqual(value, savedSupplier.ContactsDto.Count());
                Assert.NotNull(currentContact);
                Assert.AreEqual(currentContact.ContactId, dto.ContactId);
                Assert.AreEqual(currentContact.ContactsKeyId, dto.ContactsKeyId);
                Assert.AreEqual(currentContact.Email, dto.Email);
                Assert.AreEqual(currentContact.Nif, dto.Nif);
                Assert.AreEqual(currentContact.Movil, dto.Movil);
                Assert.AreEqual(currentContact.User, dto.User);


                return;
            }

            Assert.Fail("Cannot retrieve the suppliers");
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
                var commissionAgent = await _dataServices.GetCommissionAgentDataServices()
                    .GetCommissionAgentDo(firstCommisionAgent.NUM_COMI);
                payload.Subsystem = DataSubSystem.CommissionAgentSubystem;
                payload.HasRelatedObject = true;
                payload.DataObject = commissionAgent;

                var rand = new Random();
                var rValue = rand.Next() % 5000;
                var countVisit = commissionAgent.VisitsDto.Count();
                var visitDto = new List<VisitsDto>()
                {
                    new VisitsDto()
                    {
                        ClientId = commissionAgent.Value.NUM_COMI,
                        VisitId = rValue.ToString(),
                        ContactsSource = new ContactsDto()
                        {
                            ContactName = "Giorgio",
                            ContactId = "181928"
                        },
                        Date = DateTime.Now,
                        Email = "giorgio@apache.org",
                        IsNew = true,
                        IsChanged = true,
                        IsDirty = true,
                        IsOrder = false,
                        LastModification = DateTime.Now.ToString("yyyMMddHHmmss"),
                        User = "cv",
                        VisitType = new VisitTypeDto() {Code = "01", Name = "23"}
                    },
                    new VisitsDto()
                    {
                        ClientId = commissionAgent.Value.NUM_COMI,
                        VisitId = (rValue + 10).ToString(),
                        ContactsSource = new ContactsDto()
                        {
                            ContactName = "Giorgio",
                            ContactId = "181928"
                        },
                        Date = DateTime.Now,
                        Email = "giorgio@apache.org",
                        IsNew = true,
                        IsChanged = true,
                        IsDirty = true,
                        IsOrder = false,
                        LastModification = DateTime.Now.ToString("yyyMMddHHmmss"),
                        User = "cv",
                        VisitType = new VisitTypeDto() {Code = "01", Name = "NotInMyName"}
                    }
                };
                // act.
                payload.ObjectPath = new Uri("office://identifier");
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
                ICommissionAgent agent =
                    await commisionAgentDataService.GetCommissionAgentDo(commissionAgent.Value.NUM_COMI);
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
                payload.DataObject = officeData;
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

            var officeDataService = _dataServices.GetOfficeDataServices();
            var officeId = officeDataService.GetNewId();
            var office = officeDataService.GetNewOfficeDo(officeId);
            // mandatory for the payload are the following fields.
            var payload = new DataPayLoad
            {
                ObjectPath = new Uri("office://identifier"),
                Subsystem = DataSubSystem.OfficeSubsystem,
                PayloadType = type,
                HasRelatedObject = false,
                DataObject = office.Value
            };
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

            //  viewModel.

            // Assert.AreEqual("CompanySystemName", this._subSystem);
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
                    HasDataObject = true,
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
            var helperDataService = _dataServices.GetHelperDataServices();
            var viewModel = new CompanyControlViewModel(_configurationService,
                _eventManager.Object,
                _dialogService.Object,
                _dataServices,
                _regionManager.Object);
            var helper = await helperDataService.GetMappedAllAsyncHelper<CompanyDto, SUBLICEN>().ConfigureAwait(false);
            var companyData = helper.FirstOrDefault();
            if (companyData != null)
            {

            }

        }



        [Test]
        public async Task WhenIntegratedShould_Delete_Office()
        {
            bool sentDeleteMessage = false;
            DataPayLoad payload = new DataPayLoad();
            _eventManager.Setup(x => x.SendMessage(It.IsAny<string>(), It.IsAny<DataPayLoad>()))
                .Callback(() => { sentDeleteMessage = true; });
            // arrange

            var viewModel = new OfficesControlViewModel(_configurationService, _eventManager.Object, _dataServices, null, null,
                _regionManager.Object);

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
                    FESTIVO = DateTime.Now.AddDays(1),
                    HORA_DESDE = new TimeSpan(8, 0, 0),
                    HORA_HASTA = new TimeSpan(18, 0, 0)
                },
                new HolidayDto()
                {
                    OFICINA = officeId,
                    FESTIVO = DateTime.Now.AddDays(200),
                    HORA_DESDE = new TimeSpan(8, 0, 0),
                    HORA_HASTA = new TimeSpan(18, 0, 0)
                },
                new HolidayDto()
                {
                    OFICINA = officeId,
                    FESTIVO = DateTime.Now.AddDays(150),
                    HORA_DESDE = new TimeSpan(8, 0, 0),
                    HORA_HASTA = new TimeSpan(18, 0, 0)
                }
            };
            return holidays;
        }

        public IList<DailyTime> CraftWeeklyTime()
        {
            var timeTable = new List<DailyTime>()
            {
                new DailyTime()
                {
                    Morning = new OfficeOpenClose() {Open = new TimeSpan(8, 0, 0), Close = new TimeSpan(14, 0, 0)},
                    Afternoon = new OfficeOpenClose() {Open = new TimeSpan(15, 0, 0), Close = new TimeSpan(18, 0, 0)},
                },
                new DailyTime()
                {
                    Morning = new OfficeOpenClose() {Open = new TimeSpan(8, 0, 0), Close = new TimeSpan(14, 0, 0)},
                    Afternoon = new OfficeOpenClose() {Open = new TimeSpan(15, 0, 0), Close = new TimeSpan(18, 0, 0)},
                },
                new DailyTime()
                {
                    Morning = new OfficeOpenClose() {Open = new TimeSpan(8, 0, 0), Close = new TimeSpan(14, 0, 0)},
                    Afternoon = new OfficeOpenClose() {Open = new TimeSpan(15, 0, 0), Close = new TimeSpan(18, 0, 0)},
                },
                new DailyTime()
                {
                    Morning = new OfficeOpenClose() {Open = new TimeSpan(8, 0, 0), Close = new TimeSpan(14, 0, 0)},
                    Afternoon = new OfficeOpenClose() {Open = new TimeSpan(15, 0, 0), Close = new TimeSpan(18, 0, 0)},
                },
                new DailyTime()
                {
                    Morning = new OfficeOpenClose() {Open = new TimeSpan(8, 0, 0), Close = new TimeSpan(14, 0, 0)},
                    Afternoon = new OfficeOpenClose() {Open = new TimeSpan(15, 0, 0), Close = new TimeSpan(18, 0, 0)},
                },
                new DailyTime()
                {
                    Morning = new OfficeOpenClose() {Open = new TimeSpan(8, 0, 0), Close = new TimeSpan(14, 0, 0)},
                    Afternoon = new OfficeOpenClose() {Open = new TimeSpan(15, 0, 0), Close = new TimeSpan(18, 0, 0)},
                },
                new DailyTime()
                {
                    Morning = new OfficeOpenClose() {Open = new TimeSpan(8, 0, 0), Close = new TimeSpan(14, 0, 0)},
                    Afternoon = new OfficeOpenClose() {Open = new TimeSpan(15, 0, 0), Close = new TimeSpan(18, 0, 0)},
                }
            };
            return timeTable;
        }



        [Test]
        public async Task WhenIntegratedShould_Insert_Office()
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
                    DIRECCION = "Calle Roma 233",
                    IsDirty = true,
                    IsNew = true,
                    Codigo = officeId
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

        [Test]
        public async Task WhenIntegratedShould_Save_AnInvoice()
        {
            /*
             * 1. Get the invoice.
             * 2. Get his lines.
             * 3. Add new lines.
             * 4. Compute the invoice.
             * 5. Save the invoice.
             */
            TestBase testBase = new TestBase();
            var invoiceDs = await _dataServices.GetInvoiceDataServices().GetPagedSummaryDoAsync(1, 2);
            var singleInvoice = invoiceDs.FirstOrDefault();

            var registrationPayLoad = new DataPayLoad
            {
                ObjectPath = new Uri("invoice://viewmodel/id/invoice/1892892"),
                DataObject = singleInvoice,
                Subsystem = DataSubSystem.InvoiceSubsystem,
                HasDataObject = false,
                PayloadType = DataPayLoad.Type.RegistrationPayload,
                HasRelatedObject = false
            };
            Assert.NotNull(singleInvoice);

            var executor = testBase.SetupSqlQueryExecutor();
            var invoiceItem =
                    await _dataServices.GetInvoiceDataServices().GetDoAsync(singleInvoice.InvoiceName);
            var claveLinea = new Random();

            Assert.IsNotInstanceOf<NullInvoice>(invoiceItem);
            // get an unique key called lifac
            string numberLifac;
            using (var dbConnection = executor.OpenNewDbConnection())
            {
                var lifac = new LIFAC();

                numberLifac = dbConnection.UniqueId<LIFAC>(lifac);
            }

            var invoiceComponent = new InvoiceSummaryDto
            {
                Iva = 20,
                Description = "ZoppiTest",
                VehicleCode = "29209",
                Price = 666,
                Subtotal = 700,
                Quantity = 1,
                Number = singleInvoice.InvoiceName,
                IsNew = true,
                IsDirty = true,
                KeyId = numberLifac
            };
            var list = new List<InvoiceSummaryDto> { invoiceComponent };
            invoiceItem.InvoiceItems = invoiceItem.InvoiceItems != null ? invoiceItem.InvoiceItems.Union(list) : list;

            var payload = new DataPayLoad
            {
                ObjectPath = new Uri("invoice://viewmodel/id/invoice/1892891"),
                DataObject = invoiceItem,
                HasDataObject = true,
                Subsystem = DataSubSystem.InvoiceSubsystem,
                HasRelatedObject = false,
                PayloadType = DataPayLoad.Type.Update
            };
            // act
            try
            {
                // incoming payload.
                _carveBarViewModel.IncomingPayload(registrationPayLoad);
                // incoming payload.
                _carveBarViewModel.IncomingPayload(payload);
                _carveBarViewModel.SaveCommand.Execute();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            // get the daved invoice.
            var savedInvoice =
                await _dataServices.GetInvoiceDataServices().GetDoAsync(singleInvoice.InvoiceName);
            var item = savedInvoice.InvoiceItems.FirstOrDefault(x => x.Price == invoiceComponent.Price);
            Assert.NotNull(item);
            Assert.AreEqual(invoiceComponent.Iva, item.Iva);
            Assert.AreEqual(invoiceComponent.Subtotal, item.Subtotal);
            Assert.AreEqual(invoiceComponent.Quantity, item.Quantity);
        }

        /// <summary>
        ///  Generate an invoice line key.
        /// </summary>
        /// <returns></returns>
        private string GenerateInvoiceLineKey()
        {
            string value = string.Empty;
            TestBase testValue = new TestBase();
            ISqlExecutor executor = testValue.SetupSqlQueryExecutor();
            using (var dbConnection = executor.OpenNewDbConnection())
            {
                var lifac = new LIFAC();
                value = dbConnection.UniqueId<LIFAC>(lifac);
                return value;
            }

        }
        /// <summary>
        ///  The invoice should be integrated.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task WhenIntegratedShould_Insert_InvoiceLine()
        {
            // preconditions.
            var invoiceDs = _dataServices.GetInvoiceDataServices();
            var summary = await invoiceDs.GetPagedSummaryDoAsync(2,10);
            var singleInvoice = summary.FirstOrDefault();
            if (singleInvoice != null)
            {
                var invoiceId = singleInvoice.InvoiceName;
                var item = await invoiceDs.GetDoAsync(invoiceId);
                var items = item.Value.InvoiceItems;
                var count = items.Count();
                var invoiceNum = GenerateInvoiceLineKey();
                var dataPayLoad = new DataPayLoad
                {
                    ObjectPath = new Uri("invoice://viewmodel/id/invoice/1892892"),
                    HasRelatedObject = true,
                    HasDataObject = true,
                    DataObject = item,
                    PayloadType = DataPayLoad.Type.UpdateInsertGrid,
                    Subsystem = DataSubSystem.InvoiceSubsystem,
                    RelatedObject = new InvoiceSummaryDto()
                    {
                        Iva = 25,
                        Price = 24,
                        Subtotal = 39,
                        Number = invoiceId,
                        Description = "depositofactura",
                        Quantity = 23,
                        KeyId = invoiceNum,
                        AgreementCode = "12",
                        Discount = 23,
                        IsNew = true
                    }

                };
                try
                {
                    var factory = DataPayloadFactory.GetInstance();
                    var registrationPayLoad = factory.BuildRegistrationPayLoad("invoice://viewmodel/id/invoice/21829",
                        singleInvoice, DataSubSystem.InvoiceSubsystem);
                    var payload = dataPayLoad;
                    // incoming payload.
                    _carveBarViewModel.IncomingPayload(registrationPayLoad);
                    // incoming payload.
                    _carveBarViewModel.IncomingPayload(payload);
                    _carveBarViewModel.SaveCommand.Execute();
                    var savedItem = await invoiceDs.GetDoAsync(invoiceId);
                    var savedItems = savedItem.Value.InvoiceItems;
                    var receivedCount = savedItems.Count();
                    Assert.AreEqual(count + 1, receivedCount);
                }
                catch (Exception e)
                {
                    Assert.Fail(e.Message);
                }
            }
        }
        /// <summary>
        ///  When the integrated should insert an invoice.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task WhenIntegratedShould_Insert_AnInvoice()
        {

            //readonly object syncPrimitive = new object(); 
            var invoiceDs = _dataServices.GetInvoiceDataServices();
            _receivedPayLoad = null;
            var notifiedPayload = new DataPayLoad();
            var manager = new Mock<IEventManager>();
            manager.Setup(x => x.NotifyObserverSubsystem(It.IsAny<string>(), It.IsAny<DataPayLoad>()))
                .Callback((string value, DataPayLoad p) => { _receivedPayLoad = p; _receivedPayLoad.IsTest = true; });
            manager.Setup(x => x.NotifyToolBar(It.IsAny<DataPayLoad>()))
                .Callback((DataPayLoad p) => { notifiedPayload = p; });

            var viewModel = new InvoiceControlViewModel(_dataServices,
                _unityContainer.Object,
                _dialogService.Object,
                _regionManager.Object,
                null,
                manager.Object);

            var registrationPayload = new DataPayLoad
            {
                PayloadType = DataPayLoad.Type.RegistrationPayload,
                Subsystem = DataSubSystem.InvoiceSubsystem
            };
            _carveBarViewModel.IncomingPayload(registrationPayload);
            _carveBarViewModel.NewCommand.Execute(null);
            _receivedPayLoad.IsTest = true;
            viewModel.IncomingPayload(_receivedPayLoad);
            if (_receivedPayLoad != null)
            {
                Assert.AreEqual(DataPayLoad.Type.Insert, _receivedPayLoad.PayloadType);
            }
            // now we can save the payload.
            var pagedSummary = await invoiceDs.GetPagedSummaryDoAsync(1, 25);
            var singleInvoice = pagedSummary.FirstOrDefault();
            var singleObject = await invoiceDs.GetDoAsync(singleInvoice.InvoiceName);
            var invoiceDto = _receivedPayLoad.DataObject as IInvoiceData;

            // now i can try to add the value to the data layer
            singleObject.Value.NUMERO_FAC = invoiceDto.Value.NUMERO_FAC;
            // ok this is the invoice data object to be used.
            invoiceDto.Value = singleObject.Value;
            var newLines = new List<InvoiceSummaryDto>();
            foreach (var lines in invoiceDto.InvoiceItems)
            {
                lines.Number = singleObject.Value.NUMERO_FAC;
                newLines.Add(lines);
            }
            invoiceDto.InvoiceItems = newLines;
            bool retValue = await invoiceDs.SaveAsync(invoiceDto);
            Assert.IsTrue(retValue);
            Assert.NotNull(invoiceDto.ContractSummary);
            Assert.NotNull(invoiceDto.ClientSummary);
            Assert.NotNull(invoiceDto.Value);
            Assert.AreNotEqual(string.Empty, invoiceDto.Value.Code);
            Assert.AreNotEqual(string.Empty, invoiceDto.Value.NUMERO_FAC);
            Assert.NotNull(notifiedPayload);
            Assert.AreEqual(DataSubSystem.InvoiceSubsystem, _receivedPayLoad.Subsystem);
            Assert.AreEqual(DataPayLoad.Type.Insert, _receivedPayLoad.PayloadType);
            Assert.NotNull(_receivedPayLoad.PrimaryKeyValue);
            Assert.AreNotEqual(string.Empty, _receivedPayLoad);
        }

        [Test]
        public async Task WhenIntegratedShould_Delete_AnInvoiceLine()
        {
            var invoiceDataService = _dataServices.GetInvoiceDataServices();
            var invoiceDs = await invoiceDataService.GetPagedSummaryDoAsync(1,10).ConfigureAwait(false);
            var invoiceDo = invoiceDs.FirstOrDefault();

        }

        [Test]
        public async Task WhenIntegratedShould_Delete_AnInvoice()
        {
            // arrange
            _receivedPayLoad = null;
            var invoiceDataService = _dataServices.GetInvoiceDataServices();
            var invoiceDs = await invoiceDataService.GetPagedSummaryDoAsync(1, 20).ConfigureAwait(false);
            var invoiceDo = invoiceDs.FirstOrDefault();
            Assert.NotNull(invoiceDo);
            var code = invoiceDo.InvoiceCode;
            var registrationPayLoad = new DataPayLoad
            {
                PayloadType = DataPayLoad.Type.RegistrationPayload,
                Subsystem = DataSubSystem.InvoiceSubsystem
            };
            _carveBarViewModel.IncomingPayload(registrationPayLoad);
            var payload = new DataPayLoad()
            {
                PayloadType = DataPayLoad.Type.Delete,
                Subsystem = DataSubSystem.InvoiceSubsystem,
                DataObject = invoiceDo,
                ObjectPath = new Uri("invoice://viewmodel/id/2920290")
            };
            Assert.NotNull(invoiceDo);
            // act
            _carveBarViewModel.IncomingPayload(registrationPayLoad);
            _carveBarViewModel.IncomingPayload(payload);
            _carveBarViewModel.DeleteCommand.Execute(null);
            // assert.
            try
            {
                var resultedDs = await invoiceDataService.GetDoAsync(code);
                Assert.IsInstanceOf(typeof(NullInvoice), resultedDs);

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        private void RegisterABookingPayload()
        {
            var registrationPayLoad = new DataPayLoad
            {
                PayloadType = DataPayLoad.Type.RegistrationPayload,
                Subsystem = DataSubSystem.BookingSubsystem
            };
            _carveBarViewModel.IncomingPayload(registrationPayLoad);
        }
        /// <summary>
        ///  Get a client code
        /// </summary>
        /// <returns></returns>
        private async Task<string> GetAClientCode()
        {
            var testBase = new TestBase();
            var sqlExecutor = testBase.SetupSqlQueryExecutor();
            var simpleCode = string.Empty;
            using (var dbConnection = sqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection == null)
                {
                    throw new DataLayerException();
                }
                var items = await dbConnection.GetPagedAsync<CLIENTES1>(1, 2).ConfigureAwait(false);
                var singleItem = items.FirstOrDefault();
                simpleCode = singleItem.NUMERO_CLI;
            }
            return simpleCode;
        }
        // <summary>
        ///  Registration of the payload.
        /// </summary>
        /// <returns></returns>
        public async Task WhenIntegratedShould_Save_ABooking()
        {
            RegisterABookingPayload();
            var bookingDs = _dataServices.GetBookingDataService();
            var simpleBook = await bookingDs.GetPagedSummaryDoAsync(1, 2).ConfigureAwait(false);
            var firstDefault = simpleBook.FirstOrDefault();
            var bookingNumber = firstDefault.BookingNumber;
            var bookingValue = await bookingDs.GetDoAsync(bookingNumber).ConfigureAwait(false);
            var clientDs = _dataServices.GetClientDataServices();
            var singleClient = await GetAClientCode();
            bookingValue.Value.CLIENTE_RES1 = singleClient;
            Assert.AreEqual(bookingValue.IsValid, true);
            var payload = new DataPayLoad()
            {
                PayloadType = DataPayLoad.Type.Delete,
                Subsystem = DataSubSystem.BookingSubsystem,
                DataObject = bookingValue,
                HasDataObject = true,
                HasRelatedObject = false,
                Sender = new Uri("booking://viewmodel/id/2920290").ToString(),
                ObjectPath = new Uri("booking://viewmodel/id/2920290")
            };
            Assert.NotNull(bookingValue);
            // act
            _carveBarViewModel.IncomingPayload(payload);
            _carveBarViewModel.SaveCommand.Execute();
            // assert
            var savedItem = await bookingDs.GetDoAsync(bookingNumber).ConfigureAwait(false);
            Assert.AreEqual(savedItem.IsValid, true);
            Assert.AreEqual(savedItem.Value.CLIENTE_RES1, singleClient);
        }

        public async Task<IBookingData> FetchASingleBooking()
        {
            var bookingDs = _dataServices.GetBookingDataService();
            var bookingSummary = await bookingDs.GetPagedSummaryDoAsync(1, 2).ConfigureAwait(false);
            var singleBook = await bookingDs.GetDoAsync(bookingSummary.FirstOrDefault().BookingNumber).ConfigureAwait(false);
            return singleBook;
        }
        public async Task WhenIntegratedShould_Save_BookingLines()
        {
            RegisterABookingPayload();
            var bookingDs = _dataServices.GetBookingDataService();
            var singleBook = await FetchASingleBooking();
            var maxCountItems = await bookingDs.GetBookingItemsCount(singleBook.Value.NUMERO_RES) + 1;
            var keyId = maxCountItems.ToString();
            var bookingItem = new BookingItemsDto()
            {
                Number = singleBook.Value.NUMERO_RES,
                IsValid = true,
                IsNew = true,
                KeyId = keyId,
                Price = 102,
                Desccon = "ALQUILER",
                Group = "C10",
                Concept = 2,
                Unity = "DIA",
                Subtotal = 205
            };
            var payload = new DataPayLoad()
            {
                PayloadType = DataPayLoad.Type.UpdateInsertGrid,
                Subsystem = DataSubSystem.BookingSubsystem,
                DataObject = singleBook,
                RelatedObject = bookingItem,
                HasDataObject = true,
                HasRelatedObject = true,
                Sender = new Uri("booking://viewmodel/id/2920290").ToString(),
                ObjectPath = new Uri("booking://viewmodel/id/2920290")
            };
        }
        public async Task WhenIntegratedShould_Save_ABookingWithLines()
        {
            RegisterABookingPayload();
            var bookingDs = _dataServices.GetBookingDataService();
            var bookingSummary = await bookingDs.GetPagedSummaryDoAsync(1, 2).ConfigureAwait(false);
            var singleBook = await bookingDs.GetDoAsync(bookingSummary.FirstOrDefault().BookingNumber).ConfigureAwait(false);
            var maxCountItems = await bookingDs.GetBookingItemsCount(singleBook.Value.NUMERO_RES) + 1;

            var bookingItem = new BookingItemsDto()
            {
                Number = singleBook.Value.NUMERO_RES,
                IsValid = true,
                IsNew = true,
                KeyId = maxCountItems.ToString(),
                Price = 102,
                Desccon = "ALQUILER",
                Group = "C10",
                Concept = 1,
                Unity = "DIA",
                Subtotal = 204
            };
            var bookingItemList = new List<BookingItemsDto>()
            {
                bookingItem
            };

            singleBook.ItemsDtos = singleBook.ItemsDtos.Union<BookingItemsDto>(bookingItemList);

            var payload = new DataPayLoad()
            {
                PayloadType = DataPayLoad.Type.Update,
                Subsystem = DataSubSystem.BookingSubsystem,
                DataObject = singleBook,
                HasDataObject = true,
                HasRelatedObject = false,
                Sender = new Uri("booking://viewmodel/id/2920290").ToString(),
                ObjectPath = new Uri("booking://viewmodel/id/2920290")
            };
            // act
            _carveBarViewModel.IncomingPayload(payload);
            _carveBarViewModel.SaveCommand.Execute();
            // assert
            var toBeSavedItem = await bookingDs.GetDoAsync(singleBook.Value.NUMERO_RES).ConfigureAwait(false);
            Assert.AreEqual(toBeSavedItem.IsValid, true);
            var lines = toBeSavedItem.ItemsDtos.Where(x => x.KeyId == maxCountItems.ToString());
            Assert.Equals(1, lines.Count());
            var value = lines.FirstOrDefault();
            Assert.AreEqual(bookingItem.Number, value.Number);
            Assert.AreEqual(bookingItem.IsValid, value.IsValid);
            Assert.AreEqual(bookingItem.IsNew, value.IsNew);
            Assert.AreEqual(bookingItem.KeyId, value.KeyId);
            Assert.AreEqual(bookingItem.Price, value.Price);
            Assert.AreEqual(bookingItem.Desccon, value.Desccon);
            Assert.AreEqual(bookingItem.Group, value.Group);
            Assert.AreEqual(bookingItem.Concept, value.Concept);
            Assert.AreEqual(bookingItem.Unity, value.Unity);
            Assert.AreEqual(bookingItem.Subtotal, value.Subtotal);
        }

        [Test]
        public void WhenIntegratedShould_Insert_ABookinWithLines()
        {
            RegisterABookingPayload();
            var karveViewModel = new BookingControlViewModel(_regionManager.Object, _dataServices, _unityContainer.Object, _interactionRequestController.Object, _dialogService.Object, _eventManager.Object);
            _carveBarViewModel.NewCommand.Execute(null);
            Assert.NotNull(_notifiedPayLoad);
            Assert.AreEqual(_notifiedPayLoad.Subsystem, DataSubSystem.BookingSubsystem);
            Assert.AreEqual(_notifiedPayLoad.PayloadType, DataPayLoad.Type.Insert);
            karveViewModel.IncomingPayload(_notifiedPayLoad);

        }
        [Test]
        public async Task WhenIntegratedShould_Delete_ABookingWithLines()
        {
            RegisterABookingPayload();
            var bookingDs = _dataServices.GetBookingDataService();
            var bookingSummary = await bookingDs.GetPagedSummaryDoAsync(1, 2).ConfigureAwait(false);
            var bookingCode = bookingSummary.FirstOrDefault().BookingNumber;
            var singleBook = await bookingDs.GetDoAsync(bookingSummary.FirstOrDefault().BookingNumber).ConfigureAwait(false);
            var payload = new DataPayLoad()
            {
                PayloadType = DataPayLoad.Type.Delete,
                Subsystem = DataSubSystem.BookingSubsystem,
                DataObject = singleBook,
                HasDataObject = true,
                HasRelatedObject = false,
                Sender = new Uri("booking://viewmodel/id/2920290").ToString(),
                ObjectPath = new Uri("booking://viewmodel/id/2920290")
            };
            // act
            _carveBarViewModel.DeleteCommand.Execute(bookingCode);

            var karveViewModel = new BookingControlViewModel(_regionManager.Object, _dataServices, _unityContainer.Object, _interactionRequestController.Object, _dialogService.Object, _eventManager.Object);

            var currentPayLoadToDelete = _notifiedPayLoad;

           // _carveBarViewModel.DeleteCommand.Execute(null);
            // assert.
            try
            {
                var resultedDs = await bookingDs.GetDoAsync(singleBook.Value.NUMERO_RES);
                Assert.IsInstanceOf(typeof(NullReservation), resultedDs);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }
        [Test]
        public async Task WhenIntegratedShould_Update_ReservationRequest()
        {
            // 1. Register the view in the payload.

        }


    }
}
