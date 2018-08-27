using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Crud;
using NUnit.Framework;
using KarveDataServices;
using DataAccessLayer;
using KarveDataServices.ViewObjects;
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
        private IDataLoader<OfficeViewObject> _officeDataLoader;
        private IDataSaver<OfficeViewObject> _officeDataSaver;
        private IDataDeleter<OfficeViewObject> _officeDataDeleter;
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
            var loaderOffices = await _officeDataLoader.LoadValueAtMostAsync(10);
            var office = loaderOffices.FirstOrDefault<OfficeViewObject>();
            Assert.NotNull(office);
            var entity = await _officeDataLoader.LoadValueAsync(office.Codigo).ConfigureAwait(false);
            // act
            if (office != null)
            {
                var holidays = entity.HolidayDates;
                // assert.
                Assert.Greater(holidays.Count<HolidayViewObject>(), 0);
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

            var loaderOffices = await _officeDataLoader.LoadValueAtMostAsync(10);
            var office = loaderOffices.FirstOrDefault<OfficeViewObject>();

            // act
            var holidays = office.HolidayDates;
            var holidaysList = holidays.ToList<HolidayViewObject>();
            var prevList = holidaysList.Count();
            HolidayViewObject holidayViewObject = Craft_Holiday_Date(office.Codigo);
            holidaysList.Add(holidayViewObject);
            office.HolidayDates = holidaysList;
            var result = await _officeDataSaver.SaveAsync(office);
            Assert.IsTrue(result);
            var entity = await _officeDataLoader.LoadValueAsync(office.Codigo);

            var value = entity.HolidayDates.FirstOrDefault<HolidayViewObject>(x => (
                                                               (x.FESTIVO == holidayViewObject.FESTIVO) 
                                                            && (x.OFICINA==holidayViewObject.OFICINA) &&                                                            (x.PARTE_DIA==holidayViewObject.PARTE_DIA) && 
                                                               (x.HORA_DESDE== holidayViewObject.HORA_DESDE) && 
                                                               (x.HORA_HASTA ==holidayViewObject.HORA_HASTA)                                                            ));
            var nextList = entity.HolidayDates.Count();
            Assert.Greater(nextList, prevList);
            Assert.NotNull(value);
        }
        /// <summary>
        ///  HolidayViewObject. This craft an holiday data transfer object.
        /// </summary>
        /// <returns></returns>
        private HolidayViewObject Craft_Holiday_Date(string oficina)
        {
            HolidayViewObject holidayViewObject = new HolidayViewObject();
            holidayViewObject.FESTIVO = new DateTime(2018, 12, 24);
            holidayViewObject.HORA_DESDE = new TimeSpan(14, 0, 0);
            holidayViewObject.HORA_HASTA = new TimeSpan(20, 0, 0);
            holidayViewObject.PARTE_DIA = 1;
            holidayViewObject.OFICINA = oficina;
            holidayViewObject.IsDirty = true;
            holidayViewObject.IsNew = true;
            holidayViewObject.IsValid = true;
            return holidayViewObject;
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
                    var holiday = new List<HolidayViewObject> { Craft_Holiday_Date(dto.Value.Codigo) };
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
            var office = loaderOffices.FirstOrDefault<OfficeViewObject>();
            var officeCode = office.Codigo;
            office.Nombre = "JapanCarSpain SL";
            // act
            bool value = await _officeDataSaver.SaveAsync(office);
            Assert.IsTrue(value);
            // assert
            var item = await _officeDataLoader.LoadValueAsync(officeCode);
            Assert.AreEqual(office.Nombre, item.Nombre);
        }
        
    }
}
