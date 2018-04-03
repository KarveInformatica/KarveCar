using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices.DataTransferObject;
using KarveDataServices;
using Prism.Regions;

namespace MasterModule.ViewModels
{
    /// <summary>
    ///  FaresInfoViewModel. The information view model has the responsability of show and retrieve data
    ///  from the data access layer. 
    /// </summary>
    internal sealed class FaresInfoViewModel : MasterInfoViewModuleBase, IEventObserver, IDisposeEvents
    {
        private FareDto _dataObject;
       
        /// <summary>
        /// Fare info view model
        /// </summary>
        /// <param name="eventManager">Event manager</param>
        /// <param name="configurationService">Configuration services</param>
        /// <param name="dataServices">Data Services</param>
        /// <param name="dialogService">Dialog services</param>
        /// <param name="assistService">Assist services</param>
        /// <param name="manager">Region manager</param>
        public FaresInfoViewModel(IEventManager eventManager, IConfigurationService configurationService, 
            IDataServices dataServices, IDialogService dialogService, IAssistService assistService, IRegionManager manager) : base(eventManager, configurationService, dataServices, dialogService, assistService, manager)
        {
            ConfigureAssist();

        }
        /// <summary>
        ///  Receive incoming message from the event manager.
        /// </summary>
        /// <param name="payload">Payload received</param>
        public void IncomingPayload(DataPayLoad payload)
        {      
        }

        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.Subsystem = DataSubSystem.FareSubsystem;
           
        }

        /// <summary>
        ///  Data object to be forwarded to the view.
        /// </summary>
        public FareDto DataObject
        {
            set
            {
                _dataObject = value;
                RaisePropertyChanged();
            }
            get { return _dataObject; }
        }
    }
}
