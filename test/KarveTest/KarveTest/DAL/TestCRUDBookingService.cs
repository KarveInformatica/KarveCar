using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Crud.Booking;
using DataAccessLayer.DataObjects;
using KarveDapper.Extensions;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using NUnit.Framework;
using AutoMapper;
using Dapper;
using DataAccessLayer.Logic;
using DataAccessLayer.SQL;
using System.Linq;
using KarveDapper;
using KarveDapper.Extensions;


namespace KarveTest.DAL
{

    public class TestCrudBookingService : TestBase
    {
        private IBookingDataService _bookingDataService;
        private IDataLoader<BookingDto> _loader;
        private IDataSaver<BookingDto> _saver;
        private IDataDeleter<BookingDto> _deleter;
        private readonly IMapper _mapper;
        public TestCrudBookingService() : base()
        {
            _bookingDataService = DataServices.GetBookingDataService();
            _mapper = MapperField.GetMapper();
        }

        [SetUp]
        public void Setup()
        {
            _loader = new BookingDataLoader(SqlExecutor, _mapper);
            _saver = new BookingDataSaver(SqlExecutor, _mapper);
            _deleter = new BookingDataDeleter(SqlExecutor, _mapper);
        }
        [Test]
        public async Task Should_Load_ABookingAtMost()
        {
           var bookingDto = await _loader.LoadValueAtMostAsync(10, 10);
           Assert.AreEqual(bookingDto.Count(), 10);
        }

        [Test]
        public async Task Should_Save_AnEntity()
        {
            // arrange
            string code = string.Empty;
            RESERVAS1 res = new RESERVAS1();
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                var reservas1 = await dbConnection.GetPagedAsync<RESERVAS1>(4, 4);
                res = reservas1.FirstOrDefault();
            }
            Assert.NotNull(res.NUMERO_RES);
            // act
            var bookingCollection = await _loader.LoadValueAtMostAsync(10, 10); 
            var firstItem = bookingCollection.FirstOrDefault();
            if (firstItem is BookingDto value)
            {
                value.NOTAS_RES1 = "Notes in a paged";
                var bookingItem = value.BookingItems.FirstOrDefault();
                bookingItem.Concept = 2;
                var myBoolean = await _saver.SaveAsync(firstItem);
                Assert.IsTrue(myBoolean);
            }
            
        }

        [Test]
        public async Task Should_Load_ABookingEntity()
        {
            // prepare
            var entityCode = string.Empty;
            var singleValue = new RESERVAS1();
            var numberOfReservations = 0;
            var simpleQuery = string.Empty;
            IEnumerable<LIRESER> liresers = new List<LIRESER>();
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                var reservas1 = await dbConnection.GetPagedAsync<RESERVAS1>(5,20);
                singleValue = reservas1.FirstOrDefault();
                if (singleValue != null)
                {
                    entityCode = singleValue.NUMERO_RES;
                
                    IQueryStore store = new QueryStore();
                    simpleQuery = store.GetCountItems("LIRESER", "NUMERO", singleValue.NUMERO_RES);
                    var intList = await dbConnection.QueryAsync<int>(simpleQuery);
                    numberOfReservations = intList.FirstOrDefault();
                }
            }
            Assert.IsNotEmpty(entityCode);
            Assert.IsNotEmpty(simpleQuery);
            var singleDto = await _loader.LoadValueAsync(entityCode);
            var itemReservation = singleDto.BookingItems;
            Assert.AreEqual(singleDto.APELLIDO1, singleDto.APELLIDO1);
            Assert.AreEqual(itemReservation.Count(), numberOfReservations);
        }
     }

}