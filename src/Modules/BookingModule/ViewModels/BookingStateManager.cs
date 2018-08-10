using KarveCommonInterfaces;
using KarveDataServices;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingModule.ViewModels
{
    /// <summary>
    ///  This class has the single resposability to manage the booking state.
    /// </summary>
    class BookingStateManager: BindableBase
    {
        public BookingModule.BookingState State { set; get; }
        private IBookingDataService _dataService;
        private IDialogService _dialogService;
        private string _currentBookingCode;
        public BookingStateManager(string code, IDataServices dataServices, IDialogService dialogService)
        {
            _dataService = dataServices.GetBookingDataService();
            _dialogService = dialogService;
            _currentBookingCode = code;
        }
        public async Task<bool> ConfirmBooking(string code)
        {
            var retCode = false;
            if (_dialogService.ShowConfirmMessage("Confirm Booking", "Are you sure to confirm the booking?"))
            {
                var currentBooking = await _dataService.GetDoAsync(code).ConfigureAwait(false);
                if (currentBooking.Valid)
                {
                    var value = currentBooking.Value;
                    value.CONFIRMADA_RES2 = "1";
                    currentBooking.Value = value;
                    retCode = await _dataService.SaveAsync(currentBooking);

                }

            }
            return retCode;
        }
        public void RejectBooking(string code)
        {
            if (_dialogService.ShowConfirmMessage("Reject Booking", "Are you sure to reject the booking?"))
            {

            }
        }
        public void UnrejectBooking()
        {
            if (_dialogService.ShowConfirmMessage("Reject Booking", "Are you sure to unreject the booking?"))
            {

            }
        }

    }
}
