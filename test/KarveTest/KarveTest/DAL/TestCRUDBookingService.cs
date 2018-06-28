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
using DataAccessLayer.Crud;

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
                var bookingItem = value.Items.FirstOrDefault();
                bookingItem.Concept = 2;
                var myBoolean = await _saver.SaveAsync(firstItem);
                Assert.IsTrue(myBoolean);
            }
            
        }

        private async Task<Entity> FetchSingleEntityCode<Entity>() where Entity: class
        {
            Entity value;
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                value= await dbConnection.GetRandomEntityAsync<Entity>();
            }
            return value;
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
            var itemReservation = singleDto.Items;
            Assert.AreEqual(singleDto.APELLIDO1, singleDto.APELLIDO1);
            Assert.AreEqual(itemReservation.Count(), numberOfReservations);
        }
        [Test]
        public async Task Should_Load_AReservationRequest()
        {
            // arrange
            var reserve = await FetchSingleEntityCode<PETICION>().ConfigureAwait(false);
            var dataLoader = new DataLoader<PETICION, ReservationRequestDto>(SqlExecutor);
            var singleValue = await dataLoader.LoadValueAsync(reserve.NUMERO).ConfigureAwait(false);
            Assert.AreEqual(singleValue.NUMERO, reserve.NUMERO);
            Assert.AreEqual(singleValue.NOMCLI, reserve.NOMCLI);
            Assert.AreEqual(singleValue.OFICINA, reserve.OFICINA);
            Assert.AreEqual(singleValue.OBS1, reserve.OBS1);
            Assert.AreEqual(singleValue.SUBLICEN, reserve.SUBLICEN);
            Assert.AreEqual(singleValue.CATEGO, reserve.CATEGO);
        }
        [Test]
        public async Task Should_Save_AReservationRequest()
        {
            var dataSaver = new DataSaver<PETICION, ReservationRequestDto>(SqlExecutor);
            var reserve = await FetchSingleEntityCode<PETICION>().ConfigureAwait(false);
            var dataLoader = new DataLoader<PETICION, ReservationRequestDto>(SqlExecutor);
            var reservationDto = await dataLoader.LoadValueAsync(reserve.NUMERO).ConfigureAwait(false);
            reservationDto.MOPETI = reserve.MOPETI;
            var retValue = await dataSaver.SaveAsync(reservationDto);
            Assert.AreEqual(retValue, true);
            // now we want to see if it has been saved.
            var reservationDto2 = await dataLoader.LoadValueAsync(reserve.NUMERO).ConfigureAwait(false);
            Assert.AreEqual(reservationDto.MOPETI, reservationDto2.MOPETI);
        }
    }

}