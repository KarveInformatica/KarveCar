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
        ///  Navigate to an helper.
        /// </summary>
        /// <typeparam name="Entity">Helper entity</typeparam>
        /// <typeparam name="Dto">Helper dto</typeparam>
        /// <typeparam name="ViewModelType">Type of the view modle</typeparam>
        /// <param name="name">Name to provide to the user</param>
        /// <param name="viewModelUri">Uri of the view model</param>
        /// <param name="e">Entity value</param>
        void NewHelperView<Entity, Dto>(Entity e, string viewName) where Dto : BaseDto where Entity : class;
        /// <summary>
        ///  Navigate and create and empty broker.
        /// </summary>
        /// <param name="viewModelUri">Sender view model used for communicating with the toolbar</param>
        void NewBrokerView(Uri viewModelUri);
    }
}
