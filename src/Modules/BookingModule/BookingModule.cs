//---------------------------------------------------------------------------------------------------------
// <copyright file="BookingModule.cs" company="KarveInformatica S.L.">
//   
// </copyright>
// <summary>
//   Bootstrap for the booking module. The booking module is a module for book stuffs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BookingModule
{
    using global::BookingModule.Service;

    using global::BookingModule.ViewModels;

    using global::BookingModule.Views;

    using Microsoft.Practices.Unity;

    using Prism.Modularity;
    using Prism.Regions;
    using Prism.Unity;

    /// <inheritdoc />
    /// <summary>
    ///     Bootstrap for the booking module. The booking module is a module for book stuffs.
    /// </summary>
    public sealed class BookingModule : IModule
    {
        /// <summary>
        /// The _container.
        /// </summary>
        private readonly IUnityContainer _container;

        /// <summary>
        /// The _region manager.
        /// </summary>
        private IRegionManager _regionManager;

        /// <summary>
        /// The booking sub system.
        /// </summary>
        public const string BookingSubSystem = "BookingSubsystem";
        internal const string RequestGroup = "ReservationRequests";
        public const string GroupBookingIncident = "BookingIncidentSubsystem";

        /// <summary>
        /// The booking state.
        /// </summary>
        internal enum BookingState { Confirmed, Cancelled, None };

        /// <summary>
        /// BookingModule is a container.
        /// </summary>
        /// <param name="container">Container to be used in the booking module</param>
        /// <param name="regionManager">Region manager to be used in the regionManager</param>
        public BookingModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        /// <summary>
        ///  Initialize the container.
        /// </summary>
        public void Initialize()
        {
            this._container.RegisterType<object, BookingControlView>("BookingSummary");
            this._container.RegisterTypeForNavigation<BookingInfoView>();
            this._container.RegisterType<object, ReservationRequests>(typeof(ReservationRequests).FullName);
            this._container.RegisterType<object, BookingMail>(typeof(BookingMail).FullName);
            this._container.RegisterType<object, BookingMailViewModel>(typeof(BookingMailViewModel).FullName);
            this._container.RegisterType<object, ReservationRequestControl>("BookingRequestSummary");
            this._container.RegisterType<object, BookingInfoViewModel>("BookingInfoViewModel");
            this._container.RegisterType<object, BookingFooterView>("BookingFooterView");
            this._container.RegisterType<object, BookingIncidentInfoView>(typeof(BookingIncidentInfoView).FullName);
            this._container.RegisterType<object, BookingDrivers>();
            this._container.RegisterType<IBookingService, BookingService>();
        }
    }
}