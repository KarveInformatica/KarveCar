using KarveDataServices.DataTransferObject;
using System;
namespace KarveCar.Navigation
{
    /// <summary>
    ///  This interface allows to navigate from a view to another view and crafting a new item of that view.
    ///  It has been used to create a new item of that view.
    /// </summary>
    public interface IKarveNavigator
    {
        /// <summary>
        ///  Navigate to a client
        /// </summary>
        /// <param name="viewModelUri">Sender view model used for communicating with the toolbar</param>
       void NewClientView(Uri viewModelUri);
        /// <summary>
        ///  Navigate to a vehicle
        /// </summary>
        /// <param name="viewModelUri">Sender view model used for communicating with the toolbar</param>
        void NewVehicleView(Uri viewModelUri);
        /// <summary>
        ///  Navigate to a fare
        /// </summary>
        /// <param name="viewModelFare">Sender view model used for communicating with the toolbar</param>
        void NewFareView(Uri viewModelFare);
        /// <summary>
        ///  Navigate and create and empty broker.
        /// </summary>
        /// <param name="viewModelUri">Sender view model used for communicating with the toolbar</param>
        void NewBrokerView(Uri viewModelUri);
        /// <summary>
        ///  Navigate a create an empty booking view.
        /// </summary>
        /// <param name="viewModelUri"></param>
        void NewBookingView(Uri viewModelUri);

        // Factory foreach generic view.
        IHelperViewFactory GetHelperViewFactory();

    }
}
