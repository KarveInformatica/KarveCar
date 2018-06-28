using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Crud;
using NUnit.Framework;
using KarveDataServices;
using DataAccessLayer;
using KarveDataServices.DataTransferObject;
using DataAccessLayer.DataObjects;
using KarveDapper;
using KarveDapper.Extensions;

namespace KarveTest.DAL.Crud.Office
{
    /// <summary>
    ///  TestOfficeCrud. The crud for the office.
    /// </summary>
    [TestFixture]
    class TestOfficeCrud : TestBase
    {
        private IDataServices _dataServices;
        private ISqlExecutor _sqlExecutor;
        private IDataLoader<OfficeDtos> _officeDataLoader;
        private IDataSaver<OfficeDtos> _officeDataSaver;
        private IDataDeleter<OfficeDtos> _officeDataDeleter;
        private CrudFactory _crudFactory;
        [OneTimeSetUp]
        public void SetUp()
        {
            _dataServices = null;
            try
            {
                _sqlExecutor = SetupSqlQueryExecutor();
                _crudFactory = CrudFactory.GetFactory(_sqlExecutor);
                _dataServices = new DataServiceImplementation(_sqlExecutor);
                _officeDataLoader = _crudFactory.GetOfficeLoader();
                _officeDataSaver = _crudFactory.GetOfficeSaver();
                _officeDataDeleter = _crudFactory.GetOfficeDeleter();
                Assert.NotNull(_sqlExecutor);

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        public async Task Should_Load_HolidaysDates_Correctly()
        {
            /// arrange
            var loaderOffices = await _officeDataLoader.LoadValueAtMostAsync(1,10);
            var office = loaderOffices.FirstOrDefault<OfficeDtos>();
            var entity = await _officeDataLoader.LoadValueAsync(office.Codigo);
            // act
            if (office != null)
            {
                var holidays = office.HolidayDates;
                // assert.
                Assert.Greater(holidays.Count<HolidayDto>(), 0);
            }
            else
            {
                Assert.Fail("Null office");
            }
        }

        [Test]
        public async Task Should_Save_HolidayDates_Corrently()
        {
            // arrange
            var loaderOffices = await _officeDataLoader.LoadAsyncAll();
            var office = loaderOffices.FirstOrDefault<OfficeDtos>();
            // act
            var holidays = office.HolidayDates;
            var holidaysList = holidays.ToList<HolidayDto>();
            HolidayDto holidayDto = Craft_Holiday_Date(office.Codigo);
            holidaysList.Add(holidayDto);
            office.HolidayDates = holidaysList;
            var result = await _officeDataSaver.SaveAsync(office);
            Assert.IsTrue(result);
            var entity = await _officeDataLoader.LoadValueAsync(office.Codigo);
            var value = entity.HolidayDates.FirstOrDefault<HolidayDto>(x => (
                                                               (x.FESTIVO == holidayDto.FESTIVO) 
                                                            && (x.OFICINA==holidayDto.OFICINA) &&                                                            (x.PARTE_DIA==holidayDto.PARTE_DIA) && 
                                                               (x.HORA_DESDE== holidayDto.HORA_DESDE) && 
                                                               (x.HORA_HASTA ==holidayDto.HORA_HASTA)                                                            ));
            Assert.NotNull(value);
        }
        /// <summary>
        ///  HolidayDto. This craft an holiday data transfer object.
        /// </summary>
        /// <returns></returns>
        private HolidayDto Craft_Holiday_Date(string oficina)
        {
            HolidayDto holidayDto = new HolidayDto();
            holidayDto.FESTIVO = new DateTime(2018, 12, 24);
            holidayDto.HORA_DESDE = new TimeSpan(14, 0, 0);
            holidayDto.HORA_HASTA = new TimeSpan(20, 0, 0);
            holidayDto.PARTE_DIA = 1;
            holidayDto.OFICINA = oficina;
            return holidayDto;
        }
        [Test]
        public async Task Should_Create_ANewOfficePerCompany()
        {
            // arrange: delete the office if exists
            IOfficeDataServices officeDataServices = _dataServices.GetOfficeDataServices();
            IHelperDataServices helperData = _dataServices.GetHelperDataServices();
            var asyncOffice = await _officeDataLoader.LoadAsyncAll();
            var id = officeDataServices.GetNewId();
            var dto = officeDataServices.GetNewOfficeDo(id);
                if (dto != null)
                {
                    var holiday = new List<HolidayDto> { Craft_Holiday_Date(dto.Value.Codigo) };
                    // act: now we act to receive an office.
                    dto.Value.HolidayDates = holiday;
                    var value = await _officeDataSaver.SaveAsync(dto.Value);

                    // assert: now we assert to get correctly and office.
                    var currentOffice = await officeDataServices.GetAsyncOfficeDo(dto.Value.Codigo);
                    var dates = currentOffice.Value.HolidayDates;
                    var singleDate = dates.FirstOrDefault();
                    Assert.Greater(dates.Count(), 0);
                    Assert.IsTrue(value);
                    Assert.AreEqual(singleDate.FESTIVO.ToLongDateString(), new DateTime(2018, 12, 24).ToLongDateString());

                }
                else
                {
                    Assert.Fail();
                }
        }
        [Test]
        public async Task Should_Update_An_Office_Detail()
        {
            // arrange
            var loaderOffices = await _officeDataLoader.LoadValueAtMostAsync(10);          
            var office = loaderOffices.FirstOrDefault<OfficeDtos>();
            var officeCode = office.Codigo;
            office.Nombre = "HPEnterprise";
            // act
            bool value = await _officeDataSaver.SaveAsync(office);
            Assert.IsTrue(value);
            // assert
            var item = await _officeDataLoader.LoadValueAsync(officeCode);
            Assert.AreEqual(office.Nombre, item.Nombre);
        }
        
    }
}
