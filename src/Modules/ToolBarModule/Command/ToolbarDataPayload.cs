﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;
using KarveCommon.Generic;
using NLog;
using KarveDataServices.ViewObjects;
using KarveCommonInterfaces;

namespace ToolBarModule.Command
{
    /// <summary>
    ///  Internal class with data payload
    /// </summary>
    public abstract class ToolbarDataPayload : IDataPayLoadHandler
    {
        protected IEventManager CurrentEventManager;
        protected DataPayLoad CurrentPayload;
        protected IDialogService DialogService;
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
            { DataSubSystem.VehicleSubsystem, EventSubsystem.VehichleSummaryVm },
            { DataSubSystem.InvoiceSubsystem, EventSubsystem.InvoiceSubsystemVm },
            { DataSubSystem.BookingSubsystem, EventSubsystem.BookingSubsystemVm }
          };

        /// <summary>
        ///  Toolbar data payload
        /// </summary>
        public ToolbarDataPayload()
        {
            ExecutedPayloadHandler += OnExecutedPayload;

        }
        public ToolbarDataPayload(IDialogService dialogService) : this()
        {
            DialogService = dialogService;
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
            INotifyTaskCompletion<DataPayLoad> value = sender as INotifyTaskCompletion<DataPayLoad>;
            if ((value != null))
            {
                string propertyName = propertyChangedEventArgs.PropertyName;
                if (propertyName.Equals("Status"))
                {
                    if (value.IsFaulted)
                    {
                        SendError(value.ErrorMessage);
                        throw new DataLayerException("Exception in the data layer", value.Exception);
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
            try
            {
                if (dtoValues != null)
                {
                    var newItems = dtoValues.Where(x =>
                    {
                        BaseViewObject baseViewObject = x as BaseViewObject;
                        return (baseViewObject.IsNew == true);
                    });
                    if (newItems.Any())
                    {
                        await gridOperationHandler.ExecuteInsertAsync<Entity>(newItems).ConfigureAwait(false);
                    }

                    var itemsToDelete = dtoValues.Where(x =>
                    {
                        BaseViewObject baseViewObject = x as BaseViewObject;
                        return (baseViewObject.IsDeleted == true);
                    });
                    if (itemsToDelete.Count() > 0)
                    {
                        await gridOperationHandler.ExecuteDeleteAsync<Entity>(itemsToDelete).ConfigureAwait(false);
                    }
                    var updateItems = dtoValues.Where(x =>
                    {
                        BaseViewObject baseViewObject = x as BaseViewObject;
                        return ((baseViewObject.IsDirty == true) && (baseViewObject.IsNew == false));
                    });
                    if (updateItems.Count() > 0)
                    {
                        await gridOperationHandler.ExecuteUpdateAsync<Entity>(updateItems).ConfigureAwait(false);
                    }
                    for (int i = 0; i < updateItems.Count(); ++i)
                    {
                        BaseViewObject baseViewObject = updateItems.ElementAt(i) as BaseViewObject;
                        if (baseViewObject != null)
                        {
                            baseViewObject.IsNew = false;
                            baseViewObject.IsDirty = false;
                        }
                    }
                }
            } catch (Exception e)
            {
                /// FIXME: in case of exception happens that gets called twice.
                var msg = "UpdateGridException " + e.Message;
               throw new DataLayerException(msg);
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
                    BaseViewObject baseViewObject = x as BaseViewObject;
                    return (baseViewObject.IsDeleted == true);
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
