using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveDapper.Extensions;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using NUnit.Framework;
using NUnit.Framework.Internal;
using DataAccessLayer.Model;
using DataAccessLayer.Exception;

namespace KarveTest.DAL
{
    /*
     *  This tests thes the booking data service .
     */
    [TestFixture]
    public class TestBookingDataService : TestBase
    {
        private readonly IBookingDataService _bookingDataServices;

        public TestBookingDataService() : base()
        {
            _bookingDataServices = DataServices.GetBookingDataService();

        }
        private async Task<RESERVAS1> FetchValidBooking()
        {
            var item = new RESERVAS1();
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                var connection = await dbConnection.GetPagedAsync<RESERVAS1>(9, 10).ConfigureAwait(false);
                item = connection.FirstOrDefault<RESERVAS1>();
            }
            return item;
        }
        [Test]
        public async Task Should_Load_AValidReservation()
        {
            var codigo = string.Empty;
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                var connection = await dbConnection.GetPagedAsync<RESERVAS1>(1, 2).ConfigureAwait(false);
                var item = connection.FirstOrDefault<RESERVAS1>();
                codigo = item.NUMERO_RES;
            }
            var booking = await _bookingDataServices.GetDoAsync(codigo).ConfigureAwait(false);
            Assert.IsTrue(booking.Valid);
            Assert.NotNull(booking.Value);
            var count = booking.Value.Items.Count();
            Assert.AreEqual(booking.Value.NUMERO_RES, codigo);
            Assert.Greater(booking.Drivers.Count(), 0);
            Assert.Greater(booking.Clients.Count(), 0);
          

        }
        [Test]
        public async Task Should_Save_AValidReservation()
        {
            var value = await FetchValidBooking().ConfigureAwait(false);
            var code = value.NUMERO_RES;
            var booking = await _bookingDataServices.GetDoAsync(code).ConfigureAwait(false);
            booking.Value.OFICINA_RES1 = "98";
            var bookValue = await _bookingDataServices.SaveAsync(booking).ConfigureAwait(false);
            var codeValue = await _bookingDataServices.GetDoAsync(code).ConfigureAwait(false);
            Assert.AreEqual(codeValue.Value.OFICINA_RES1, "98");
        }
        [Test]
        public async Task Should_Delete_AValidReservation()
        {
            var value = await FetchValidBooking().ConfigureAwait(false);
            var code = value.NUMERO_RES;
            var booking = await _bookingDataServices.GetDoAsync(code).ConfigureAwait(false);
            var deleteAsync = await _bookingDataServices.DeleteAsync(booking);
            Assert.True(deleteAsync);
            //   var bookingData = await _bookingDataServices.GetDoAsync(code);
            //  Assert.IsNotInstanceOf<NullReservation>(bookingData);

        }
        [Test]
        public async Task Should_Throw_WhenSavedInvalidData()
        {
            var value = await FetchValidBooking().ConfigureAwait(false);
            var code = value.NUMERO_RES;
            var booking = await _bookingDataServices.GetDoAsync(code).ConfigureAwait(false);
            booking.Value.NUMERO_RES = string.Empty;
            Assert.ThrowsAsync<DataAccessLayerException>(async () => await _bookingDataServices.SaveAsync(booking));

        }
        [Test]
        public async Task Should_Throw_WhenInvalidLinesPresent()
        {
            var value = await FetchValidBooking().ConfigureAwait(false);
            var bookingNow = await _bookingDataServices.GetDoAsync(value.NUMERO_RES);
            bookingNow.Value.Items = null;
            Assert.ThrowsAsync<System.ArgumentNullException > (async () => await _bookingDataServices.SaveAsync(bookingNow));
        }
        [Test]
        public async Task Should_Load_PagedReservationSummary()
        {
            var numberOfItems = 0;
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                var connection = await dbConnection.GetPagedAsync<RESERVAS1>(1, 25);
                numberOfItems = connection.Count();
            }
            for (var i = 1; i < numberOfItems; i += 25)
            {
                var pagedItems = await _bookingDataServices.GetPagedSummaryDoAsync(i, 25);
                var numPages = pagedItems.Count();

                Assert.AreEqual(numPages, 25);
                foreach (var item in pagedItems)
                {
                    Assert.NotNull(item.BookingNumber);
                }
            }
        }
        [Test]
        public void Should_Throw_WhenInvalidIndex()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await _bookingDataServices.GetPagedSummaryDoAsync(-1, -1));
        }

        [Test]
        public async Task Should_LoadBookingAsyncSummary()
        {
            var numberOfItems = 0;
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                var connection = await dbConnection.GetAsyncAll<RESERVAS1>();
                numberOfItems = connection.Count();
            }
            var summary = await _bookingDataServices.GetSummaryAllAsync();
            Assert.AreEqual(numberOfItems, summary.Count());
        }

        [Test]
        public async Task Should_Load_BookingNumberPagedCorrectly()
        {
            var booking = await _bookingDataServices.GetPagedSummaryDoAsync(1, 20);
            foreach (var book in booking)
            {
                Assert.IsNotEmpty(book.BookingNumber);
            }
        }
        [Test]
        public async Task Should_Insert_ANewReservation()
        {   var code = _bookingDataServices.NewId();
            var bookingData = _bookingDataServices.GetNewDo(code);
            var booking = await _bookingDataServices.GetPagedSummaryDoAsync(1, 2);
            var item = booking.FirstOrDefault();
            Assert.NotNull(item);
            Assert.NotNull(bookingData.Value);
            if (item != null)
            {
                var asyncValue = await _bookingDataServices.GetDoAsync(item.BookingNumber);
                var dto = bookingData.Value;
                bookingData.Value = asyncValue.Value;
                bookingData.Value.NUMERO_RES = dto.NUMERO_RES;
                bookingData.Value.Items = new List<BookingItemsDto>();
                var outValue = await _bookingDataServices.SaveAsync(bookingData);
                Assert.IsTrue(outValue);
            }
        }
        [Test]
        public async Task Should_Save_Reservation()
        {
            var booking = await _bookingDataServices.GetPagedSummaryDoAsync(1,10);
            var item = booking.FirstOrDefault();
            var bookingKey = string.Empty;
            var bKey = await _bookingDataServices.GetBookingItemsCount(item.BookingNumber);
            Assert.NotNull(item);
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                var linRes = new LIRESER();
               bookingKey = dbConnection.UniqueId(linRes);
            }
            var reservationNumber = item.BookingNumber;
            var bookingNow = await _bookingDataServices.GetDoAsync(reservationNumber);
            bookingNow.Value.APELLIDO1 = "GiorgioZoppi";
            var currentList = new List<BookingItemsDto>()
            {
                  new BookingItemsDto()
                  {
                      Bill = 1,
                      BookingKey = bKey,
                      Number = bookingNow.Value.NUMERO_RES,
                      Concept = 1,
                      Cost = 1282,
                      Days = "123"
                  }
                   
            };
            bookingNow.Value.Items = bookingNow.Value.Items.Union(currentList);
            var result = await _bookingDataServices.SaveAsync(bookingNow);
            var changed = await _bookingDataServices.GetDoAsync(reservationNumber);
            Assert.AreEqual(result, true);
            Assert.AreEqual(changed.Value.APELLIDO1, bookingNow.Value.APELLIDO1);
            var listOfValues = changed.Value.Items;
            var bookedItem = listOfValues.Where(x => x.BookingKey == Convert.ToUInt32(bookingKey));
            var bItem = bookedItem.FirstOrDefault();
            if (bItem != null)
            {
                Assert.AreEqual(bItem.BookingKey, bKey);
                Assert.AreEqual(bItem.Days, "123");
                Assert.AreEqual(bItem.Concept, 1);
                Assert.AreEqual(bItem.Cost, 1282);
                Assert.AreEqual(bItem.Bill, 1);
                Assert.AreEqual(bItem.Number, bookingNow.Value.NUMERO_RES);
            }
        }

        List<BookingItemsDto> CreateABookingList(long bookingKey, string bookingNumber)
        {
            var currentList = new List<BookingItemsDto>()
            {
                new BookingItemsDto()
                {
                    Bill = 0,
                    BookingKey = bookingKey,
                    Number = bookingNumber,
                    Concept =-1 ,
                    Cost = 1282,
                    Days = "23019021092109210921029019201291092019201910"
                }

            };
            return currentList;
        }
      

    }
}
