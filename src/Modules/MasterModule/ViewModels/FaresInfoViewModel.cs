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
        ///  FareInfoViewModel constructor.
        /// </summary>
        /// <param name="eventManager"></param>
        /// <param name="configurationService"></param>
        /// <param name="dataServices"></param>
        /// <param name="manager"></param>
        public FaresInfoViewModel(IEventManager eventManager, IConfigurationService configurationService, 
            IDataServices dataServices, IDialogService dialogService, IRegionManager manager) : base(eventManager, configurationService, dialogService, dataServices, manager)
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
