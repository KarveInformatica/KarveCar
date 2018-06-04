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
    public class BookingModule : IModule
    {
        private readonly IUnityContainer _container;
        private IRegionManager _regionManager;
        internal const string BookingSubSystem = "BookingSubsystem";
        /// <summary>
        ///     BookingModule is a container.
        /// </summary>
        /// <param name="container">Container to be used in the booking module</param>
        /// <param name="regionManager">Region manager to be used in the regionManager</param>
        public BookingModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterType<object, BookingControlView>("BookingSummary");
            _container.RegisterTypeForNavigation<BookingInfoView>();
            _container.RegisterType<object, BookingInfoViewModel>("BookingInfoViewModel");
            _container.RegisterType<object, BookingFooterView>("BookingFooterView");
            _container.RegisterType<object, BookingDrivers>();
            _container.RegisterType<object, BookingDataView>();
        }
    }
}