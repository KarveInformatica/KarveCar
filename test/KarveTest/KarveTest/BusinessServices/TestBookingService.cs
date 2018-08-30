// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestBookingService.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the TestBookingService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using BookingModule.Service;
using DataAccessLayer;
using DataAccessLayer.DataObjects;
using DataAccessLayer.DtoWrapper;
using KarveCommon.Services;
using KarveDapper.Extensions;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;
using NUnit.Framework;

namespace KarveTest.BusinessServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Text fixture for the booking service.
    /// </summary>
    internal class TestBookingService : KarveTest.DAL.TestBase
    {
        /// <summary>
        /// Query executor
        /// </summary>
        private ISqlExecutor sqlExecutor;
        // Query data services.
        private IDataServices dataService;
        private IBookingService bookingService;

        [OneTimeSetUp]
        public void Setup()
        {
            sqlExecutor = base.SetupSqlQueryExecutor();
            dataService = new DataServiceImplementation(sqlExecutor);
            bookingService = new BookingService(dataService);
        }

        private async Task<string> GetFareNameAsync()
        {
            var fare = string.Empty;
            using (var connection = sqlExecutor.OpenNewDbConnection())
            {
                var fareValue = await connection.GetRandomEntityAsync<NTARI>();
                fare = fareValue.CODIGO;
            }

            return fare;
        }

        private IDictionary<string, object> CraftANewFareChange(IBookingData data)
        {
            IDictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary["DataObject"] = data.Value;
            dictionary["Field"] = "TARIFA_RES1";
            dictionary["ChangedValue"] = data.Value.TARIFA_RES1;
            return dictionary;
        }

        [Test]
        public async Task Should_Quote_WhenFareChanges()
        {
            var bookingDataService = this.dataService.GetBookingDataService();
            var pagedSummary = await bookingDataService.GetPagedSummaryDoAsync(1, 2);
            var firstDefault = pagedSummary.FirstOrDefault();
            if (firstDefault != null)
            {
                var bookingData = await bookingDataService.GetDoAsync(firstDefault.Code);
                var dictionary = this.CraftANewFareChange(bookingData);
                var book = await this.bookingService.TiggerAReservationQuotation(dictionary, bookingData);
                if (book)
                {
                    var items = bookingData.Value.Items;
                    Assert.NotNull(items);
                }
            }
        }

        [Test]
        public async Task Should_Quote_WhenDaysChange()
        {

        }
        [Test]
        public async Task Should_Quote_WhenGroupChange()
        {

        }

    }
}
