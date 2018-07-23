using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices.DataTransferObject;
using KarveDataServices;
using Prism.Regions;
using System.Threading.Tasks;

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
        public FaresInfoViewModel(IEventManager eventManager, 
            IConfigurationService configurationService, 
            IDataServices dataServices, 
            IDialogService dialogService, 
            IRegionManager manager, 
            IInteractionRequestController controller) : base(eventManager, configurationService, dataServices, dialogService, manager, controller)
        {
            ConfigureAssist();

        }
        /// <summary>
        ///  Receive incoming message from the event manager.
        /// </summary>
        /// <param name="payload">Payload received</param>
        public override void IncomingPayload(DataPayLoad payload)
        {      
        }

        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.Subsystem = DataSubSystem.FareSubsystem;
           
        }

        internal override Task SetClientData(ClientSummaryExtended p, VisitsDto b)
        {
            throw new System.NotImplementedException();
        }

        internal override Task SetVisitContacts(ContactsDto p, VisitsDto visitsDto)
        {
            throw new System.NotImplementedException();
        }

        internal override Task SetBranchProvince(ProvinciaDto p, BranchesDto b)
        {
            throw new System.NotImplementedException();
        }

        internal override Task SetVisitReseller(ResellerDto param, VisitsDto b)
        {
            throw new System.NotImplementedException();
        }

        public override void Dispose()
        {
            throw new System.NotImplementedException();
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
