using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;
using KarveCommon.Generic;
using NLog;
using KarveDataServices.DataTransferObject;

namespace ToolBarModule.Command
{
    /// <summary>
    ///  Internal class with data payload
    /// </summary>
    abstract class  ToolbarDataPayload : IDataPayLoadHandler
    {
        private IEventManager CurrentEventManager;
        protected DataPayLoad CurrentPayload;
        private IDataServices _dataServices;
        protected readonly PropertyChangedEventHandler ExecutedPayloadHandler;
        protected INotifyTaskCompletion<DataPayLoad> ToolbarInitializationNotifier;
        private Dictionary<DataSubSystem, string> _dictionary = new Dictionary<DataSubSystem, string>()
        {
            { DataSubSystem.CommissionAgentSubystem, EventSubsystem.CommissionAgentSummaryVm},
            { DataSubSystem.CompanySubsystem, EventSubsystem.CompanySummaryVm},
            { DataSubSystem.ClientSubsystem, EventSubsystem.ClientSummaryVm},
            { DataSubSystem.OfficeSubsystem, EventSubsystem.OfficeSummaryVm},
            { DataSubSystem.HelperSubsytsem, EventSubsystem.HelperSubsystem},
            { DataSubSystem.SupplierSubsystem, EventSubsystem.SuppliersSummaryVm},
            { DataSubSystem.VehicleSubsystem, EventSubsystem.VehichleSummaryVm }
          };

        /// <summary>
        ///  Toolbar data payload
        /// </summary>
        public ToolbarDataPayload()
        {
            ExecutedPayloadHandler += OnExecutedPayload;
           
        }
        /// <summary>
        ///  Set or Get the event manager.
        /// </summary>
        public IEventManager EventManager
        {
            set
            {
                CurrentEventManager= (IEventManager) value;
            }
            get { return CurrentEventManager; }
        }
        /// <summary>
        /// Get or Set data services.
        /// </summary>
        public IDataServices DataServices
        {
            set
            {
                _dataServices = (IDataServices)value;
            }
            get { return _dataServices; }
        }
        protected void ShowErrorMessage(string message)
        {
            OnErrorExecuting?.Invoke(message);
        }
        /// <summary>
        ///  Take any action during the event manager
        /// </summary>
        /// <param name="sender">Sender of the mesasge</param>
        /// <param name="propertyChangedEventArgs">Paramerts of the message</param>
        protected void OnExecutedPayload(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            // check of errors.
            INotifyTaskCompletion<IEnumerable<DataPayLoad>> value = sender as INotifyTaskCompletion<IEnumerable<DataPayLoad>>;
            if ((value != null) && (ToolbarInitializationNotifier != null))
            {
                string propertyName = propertyChangedEventArgs.PropertyName;
                if (propertyName.Equals("Status"))
                {
                    if (ToolbarInitializationNotifier.IsFaulted)
                    {
                        SendError(ToolbarInitializationNotifier.ErrorMessage);
                    }
                }
            }
            if (CurrentEventManager != null)
            {
                NotifyEventManager(EventManager, CurrentPayload);
            }
        }
        /// <summary>
        ///  Notify the behaviour of the event manager.
        /// </summary>
        /// <param name="eventManager">Event manager of the toolbar.</param>
        /// <param name="payLoad"> Kind of payload.</param>
        private void NotifyEventManager(IEventManager eventManager, DataPayLoad payLoad)
        {
            if (payLoad == null)
            {
                return;
            }
            string destinationSubsystem = "";
            _dictionary.TryGetValue(payLoad.Subsystem, out destinationSubsystem);
            if (!string.IsNullOrEmpty(destinationSubsystem))
            {
                eventManager.SendMessage(destinationSubsystem, payLoad);
            }
        }
        protected void SendError(string message)
        {
            OnErrorExecuting?.Invoke(message);
        }
        /// <summary>
        ///  Launch an error for executing
        /// </summary>
        public event ErrorExecuting OnErrorExecuting;
        /// FIXME: see if the payload can be TAP.
        /// <summary>
        /// Abstract method to override for executing the payload
        /// </summary>
        /// <param name="services">DataServices</param>
        /// <param name="manager">Event manager</param>
        /// <param name="payLoad">Payload to be filed.</param>
        public abstract void ExecutePayload(IDataServices services, IEventManager manager, ref DataPayLoad payLoad);       
        protected abstract  Task<DataPayLoad> HandleSaveOrUpdate(DataPayLoad payLoad);

        /* 
         * 
         * This method handles all the grid operations 
         */
        protected async Task UpdateGridAsync<Dto, Entity>(DataPayLoad payLoad) where Dto : class
                                                                       where Entity : class
        {
            GridOperationHandler<Dto> gridOperationHandler = new GridOperationHandler<Dto>(DataServices);
            IEnumerable<Dto> dtoValues = payLoad.RelatedObject as IEnumerable<Dto>;
            // ok now we can see if it is an insert or a delete.
            if (dtoValues != null)
            {
                var newItems = dtoValues.Where(x =>
                {
                    BaseDto baseDto = x as BaseDto;
                    return (baseDto.IsNew == true);
                });
                if (newItems.Count() > 0)
                {
                    await gridOperationHandler.ExecuteInsertAsync<Entity>(newItems);
                }

                var itemsToDelete = dtoValues.Where(x=>
                {
                    BaseDto baseDto = x as BaseDto;
                    return (baseDto.IsDeleted == true);
                });
                if (itemsToDelete.Count()>0)
                {
                    await gridOperationHandler.ExecuteDeleteAsync<Entity>(itemsToDelete);
                }
                var updateItems = dtoValues.Where(x =>
                {
                    BaseDto baseDto = x as BaseDto;
                    return ((baseDto.IsDirty == true) && (baseDto.IsNew == false));
                });
                if (updateItems.Count() > 0)
                {
                    await gridOperationHandler.ExecuteUpdateAsync<Entity>(updateItems);
                }
                for (int i = 0; i < updateItems.Count(); ++i)
                {
                    BaseDto baseDto = updateItems.ElementAt(i) as BaseDto;
                    if (baseDto != null)
                    {
                        baseDto.IsNew = false;
                        baseDto.IsDirty = false;
                    }
                }
            }
        }

        protected async Task<bool> DeleteGridAsync<Dto, Entity>(DataPayLoad payLoad) where Dto: class
                                                                                where Entity: class
        {
            bool retValue = false;
            GridOperationHandler<Dto> gridOperationHandler = new GridOperationHandler<Dto>(DataServices);
            IEnumerable<Dto> dtoValues = payLoad.RelatedObject as IEnumerable<Dto>;
            if (dtoValues!=null)
            {
                var toBeDeleted = dtoValues.Where(x=>
                {
                    BaseDto baseDto = x as BaseDto;
                    return (baseDto.IsDeleted == true);
                });
                if (toBeDeleted.Count()>0)
                {
                   retValue = await gridOperationHandler.ExecuteDeleteAsync<Dto>(toBeDeleted);
                }
            }
            return retValue;
        }
    }
}
