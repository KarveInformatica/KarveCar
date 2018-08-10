using BookingModule.ViewModels;
using BookingModule.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;

namespace BookingModule
{
    /// <summary>
    ///     Bootstrap for the booking module. The booking module is a module for book stuffs.
    /// </summary>
    public sealed class BookingModule : IModule
    {
        private readonly IUnityContainer _container;
        private IRegionManager _regionManager;
        public const string BookingSubSystem = "BookingSubsystem";
        internal const string RequestGroup = "ReservationRequests";
        public const string GroupBookingIncident = "BookingIncidentSubsystem";
        internal enum BookingState { CONFIRMED, CANCELLED, NONE };

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
            _container.RegisterType<object, BookingControlView>("BookingSummary");
            _container.RegisterTypeForNavigation<BookingInfoView>();
            _container.RegisterType<object, ReservationRequests>(typeof(ReservationRequests).FullName);
            _container.RegisterType<object, BookingMail>(typeof(BookingMail).FullName);
            _container.RegisterType<object, BookingMailViewModel>(typeof(BookingMailViewModel).FullName);

            _container.RegisterType<object, ReservationRequestControl>("BookingRequestSummary");
            _container.RegisterType<object, BookingInfoViewModel>("BookingInfoViewModel");
            _container.RegisterType<object, BookingFooterView>("BookingFooterView");
            _container.RegisterType<object, BookingIncidentInfoView>(typeof(BookingIncidentInfoView).FullName);
            _container.RegisterType<object, BookingDrivers>();
        }
    }
}