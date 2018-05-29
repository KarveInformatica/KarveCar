using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Regions;
using Syncfusion.UI.Xaml.Grid;

namespace KarveCommon
{
    public abstract class HeaderedLineViewModelBase<DataType, DtoType, InnerDtoType>: KarveRoutingBaseViewModel, IEventObserver where DtoType: BaseDto
    {
        protected IRegionManager RegionManager;
        protected IIdentifier IdentifierGenerator;
        protected DataSubSystem SubSystem;
        protected string EventSubSystemName;
        protected IncrementalList<InnerDtoType> SourceItems;
        public DataPayLoad.Type OperationalState { get; private set; }
        
        protected HeaderedLineViewModelBase(IDataServices dataServices,
            IDialogService dialogServices,
            IEventManager manager,
            IRegionManager regionManager,
            IIdentifier identifier,
            IInteractionRequestController controller) : base(dataServices, controller, dialogServices, manager)
        {
            RegionManager = regionManager;
            IdentifierGenerator = identifier;
        }

        protected override string GetRouteName(string name)
        {
            return string.Empty;
        }

        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
          
        }

        /// <summary>
        ///     Incoming Payload
        /// </summary>
        /// <param name="dataPayLoad">This is the incoming payload that it is working on.</param>
        public void IncomingPayload(DataPayLoad dataPayLoad)
        {
            if (dataPayLoad == null) return;
            var interpeter = new PayloadInterpeter<DataType>();
            var currentId = IdentifierGenerator.NewId();
            interpeter.Init = Init;
            interpeter.CleanUp = CleanUp;
            if (string.IsNullOrEmpty(PrimaryKeyValue)) PrimaryKeyValue = dataPayLoad.PrimaryKeyValue;

            if (string.IsNullOrEmpty(PrimaryKeyValue))
                return;

            // check if this message is for me.
            if (PrimaryKeyValue.Length > 0)
            {
                if (!(dataPayLoad.DataObject is DtoType dto))
                {
                    if (dataPayLoad.DataObject is DtoType domainObject)
                        if (domainObject.CodeId != PrimaryKeyValue)
                            return;
                }
                else
                {
                    if (dto.CodeId != PrimaryKeyValue) return;
                }
            }

            OperationalState = interpeter.CheckOperationalType(dataPayLoad);
          
            interpeter.ActionOnPayload(dataPayLoad, PrimaryKeyValue, currentId, SubSystem,
                EventSubSystemName);
        }

        protected abstract void CleanUp(string primarykey, DataSubSystem subsystem, string eventSubsystem);

        protected abstract void Init(string value, DataPayLoad payload, bool insertion);


        /// <summary>
        ///     This delete the region when there is a delete.
        /// </summary>
        protected void DeleteRegion()
        {
            var activeRegion = RegionManager.Regions[RegionName].ActiveViews.FirstOrDefault();
            switch (activeRegion)
            {
                case null:
                    return;
                case IHeaderedView _:
                    if (activeRegion is IHeaderedView headeredView)
                        RegionManager.Regions[RegionName].Remove(headeredView);
                    break;
                case FrameworkElement _:
                    var framework = activeRegion as FrameworkElement;
                    framework?.ClearValue(Prism.Regions.RegionManager.RegionManagerProperty);
                    break;
            }
        }
        protected abstract  Task<bool> DeleteAsync(DataPayLoad payLoad);

        public IncrementalList<InnerDtoType> SourceView
        {
            set { SourceItems = value; RaisePropertyChanged(); }
            get { return SourceItems; }
        }

        protected override void DeleteItem(DataPayLoad payLoad)
        {
            NotifyTaskCompletion.Create(DeleteAsync(payLoad),
                (sender, args) =>
                {

                    if (sender is INotifyTaskCompletion<bool> taskCompletion)
                    {
                        if (taskCompletion.IsFaulted)
                            DialogService?.ShowErrorMessage("Error during deleting the invoice");

                        if (!taskCompletion.IsSuccessfullyCompleted) return;
                        var dataPayLoad = new DataPayLoad
                        {
                            Sender = ViewModelUri.ToString(),
                            PayloadType = DataPayLoad.Type.UpdateView
                        };
                    }
                    EventManager.NotifyObserverSubsystem(EventSubSystemName, payLoad);
                    UnregisterToolBar(payLoad.PrimaryKey);

                    DeleteRegion();
                });
        }

        
    }
}
