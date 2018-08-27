using System;
using System.Collections.Generic;
using KarveDataServices.DataObjects;

namespace KarveCar.Model
{
    public class Booking
    {

        public Booking()
        {
            Amount = 0;
            TaxVat = 21;
        }
        public Booking(IBookingData data) : this()
        {
            var viewObject = data.Value;
            Number = viewObject.NUMERO_RES;
            Locator = viewObject.LOCALIZA_RES1;
            Flight = new Flight();
            Flight.Number = viewObject.VUELO_RES1;
            BookingCreationOffice = new Office();
            BookingArrivalOffice = new Office();
            BookingDepartureOffice = new Office();
        }
        // Set or Get the booking number
        public string Number { set; get; }
        /// <summary>
        ///  Set or Get the booking locator
        /// </summary>
        public string Locator { set; get; }
        /// <summary>
        /// Set or Get the flight
        /// </summary>
        public Flight Flight { set; get; }
        /// <summary>
        ///  Set or Get the Booking creation office
        /// </summary>
        public Office BookingCreationOffice { set; get; }
        /// <summary>
        ///  Set or get the booking departure office
        /// </summary>
        public Office BookingDepartureOffice { set; get; }
        /// <summary>
        /// Set or get the booking arrival office.
        /// </summary>
        public Office BookingArrivalOffice { set; get; }
        /// <summary>
        ///  Set or get the departure place
        /// </summary>
        public string DeparturePlace { set; get; }
        /// <summary>
        ///  set or get the arrival place
        /// </summary>
        public string ArrivalPlace { set; get; }
        /// <summary>
        ///  Set or Get the starting date
        /// </summary>
        public DateTime StartingDate { set; get; }
        /// <summary>
        ///  Set or Get the creation date
        /// </summary>
        public DateTime CreationDate { set; get; }
        /// <summary>
        ///  Set or Get the end date
        /// </summary>
        public DateTime EndDate { set; get; }
        /// <summary>
        /// Set or get the driver
        /// </summary>
        public Driver Driver { set; get; }
        /// <summary>
        ///  Set or get the client
        /// </summary>
        public Client Client { set; get; }
        // Set or get the items.

        public List<BookingItems> Items { set; get; }
        /// <summary>
        ///  set or get the to
        /// </summary>
        public decimal Amount { set; get; }

        /// <summary>
        ///  Set or Get the base.
        /// </summary>
        public decimal Base { set; get; }
        /// <summary>
        ///  Set or Get the tax vat.
        /// </summary>
        public decimal TaxVat { set; get; }

        public decimal VatAmount { set; get; }
        
        /// <summary>
        ///  Set or Get the compute total.
        /// </summary>
        public void ComputeTotal()
        {
            decimal subTotal = 0;
            foreach (var x in Items)
            {
                if (!x.Included)
                {
                    continue;
                }
                if (x.Subtotal.HasValue)
                {
                    subTotal += x.Subtotal.Value;
                }
            }
            Base = decimal.Round(subTotal, 2, MidpointRounding.AwayFromZero);
            var computeIva = (subTotal * VatAmount * (decimal)0.01);
            VatAmount = decimal.Round(computeIva, 2, MidpointRounding.AwayFromZero);
            var total = subTotal + TaxVat;
            Amount= decimal.Round(total, 2, MidpointRounding.AwayFromZero);
        }
        public void ValidateChanges()
        {
        }
    }
}
