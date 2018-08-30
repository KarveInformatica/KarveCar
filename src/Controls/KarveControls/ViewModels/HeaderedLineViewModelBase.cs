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
using KarveDataServices.ViewObjects;
using Prism.Regions;
using Syncfusion.UI.Xaml.Grid;
using KarveControls;
using KarveCommon;
using Prism.Interactivity.InteractionRequest;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace KarveControls.ViewModels
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    ///  Generic class for all the headered base model ("cabecera-linea", in spanish).
    ///  All view model in the headered base model class have to manage a viewObject 
    ///  with a list of inner type dtos as datamember.
    ///  All headered view view models have by default the composite command state.
    ///  This means that the view model shall save himself and not using the handler of the toolbar.
    /// </summary>
    /// <typeparam name="DataType">Type of the domain, used to delivered data payload</typeparam>
    /// <typeparam name="DtoType">Data transfer object</typeparam>
    /// <typeparam name="InnerDtoType">Type of the other viewObject</typeparam>
    public abstract class HeaderedLineViewModelBase<DataType, DtoType, InnerDtoType> : KarveRoutingBaseViewModel, ICreateRegionManagerScope, IEventObserver where DtoType : LineBaseViewObject<InnerDtoType> where InnerDtoType : BaseViewObject
    {

        protected IIdentifier IdentifierGenerator;
        /// <summary>
        ///  Magnifier popup window to be shown when interacting with the view model.
        /// </summary>
        protected IAssistDataService AssistDataService;
        /// <summary>
        ///  Event subsystem to be used.
        /// </summary>
        protected string EventSubSystemName;
        protected IncrementalList<InnerDtoType> SourceItems;
        private List<string> _gridView;
        private object _sourceView;
        private bool _linevisible;
        private bool _footervisible;
        private object _selectedItem;
        private InteractionRequest<INotification> _notificationRequest;
        private ObservableCollection<InnerDtoType> _collectionView;
        private object _selectedCellValue;

        protected HeaderedLineViewModelBase(IDataServices dataServices,
            IDialogService dialogServices,
            IEventManager manager,
            IRegionManager regionManager,
            IIdentifier identifier,
            IConfigurationService configurationService,
            IInteractionRequestController controller) : base(dataServices, controller, dialogServices, manager, configurationService)
        {
            RegionManager = regionManager;
            IdentifierGenerator = identifier;
            AssistDataService = DataServices.GetAssistDataServices();
            LineVisible = true;
            FooterVisible = true;
            /* This instruct the toolbar to skip its is own handlers. Avoiding complexity. 
            * It will be just the view to save itself with composite command and to alert it subsystem.
            *  This with the SetRegistrationPayLoad set properly it will permit to save itself.
            *  Each view will save itself, like in this scenario:
            *  https://prismlibrary.github.io/docs/wpf/Advanced-MVVM.html
            * It is better that all headered window will use a composite command.
            */
            CompositeCommandOnly = true;

        }

        // This is a direct command for deleting grid lines.
        public ICommand DeleteLine { set; get; }

        public IResolver Resolver { get; private set; }

        protected override string GetRouteName(string name)
        {
            return string.Empty;
        }

        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {

        }
        /*
        protected virtual void CheckAndCommitRow(BaseViewObject viewObject, 
            out ObservableCollection<InnerDtoType> collection) where InnerDtoType: class
            {
           
            var newItems = Activator.CreateInstance<InnerDtoType>();

        newItems.Concept = int.Parse(item.Code);
        newItems.Desccon = item.Name;
                    CollectionView.Add(newItems);
                    RaisePropertyChanged("CollectionView");
                    return;
                }
                */
        public InteractionRequest<INotification> NotificationRequest
        {
            get => _notificationRequest;
            set
            {
                _notificationRequest = value;
                RaisePropertyChanged("NotificationRequest");
            }

        }

        /// <summary>
        /// Set to get a selected cell value. This is used to transfer 
        /// to the line grid behaviour the selection.
        /// </summary>
        public object SelectedCellValue
        {
            get => _selectedCellValue;
            set
            {
                _selectedCellValue = value;
                RaisePropertyChanged("SelectedCellValue");
            }
        }
        public object SelectedItem
        {
            set
            {
                _selectedItem = value;
                RaisePropertyChanged();
            }
            get
            {
                return _selectedItem;
            }
        }
        /// <summary>
        /// LineVisible
        /// </summary>
        public bool LineVisible
        {
            set
            {
                _linevisible = value;
                RaisePropertyChanged();
            }
            get => _linevisible;
        }

        /// <summary>
        /// LineVisible
        /// </summary>
        public bool FooterVisible
        {
            set
            {
                _footervisible = value;
                RaisePropertyChanged();
            }
            get => _footervisible;
        }
        public List<string> GridColumns
        {
            set
            {
                _gridView = value;
                RaisePropertyChanged("GridColumns");
            }
            get => _gridView;
        }
        /// <summary>
        ///     Incoming Payload
        /// </summary>
        /// <param name="dataPayLoad">This is the incoming payload that it is working on.</param>
        public void IncomingPayload(DataPayLoad dataPayLoad)
        {
            if (dataPayLoad == null) return;
            if ((dataPayLoad.Sender != null) && (dataPayLoad.Sender.Equals(ViewModelUri)))
            {
                return;
            }
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
                        if (domainObject.Code != PrimaryKeyValue)
                            return;
                }
                else
                {
                    if (dto.Code != PrimaryKeyValue) return;
                }
            }

            OperationalState = interpeter.CheckOperationalType(dataPayLoad);

            interpeter.ActionOnPayload(dataPayLoad, PrimaryKeyValue, currentId, SubSystem,
                EventSubSystemName);
        }

        public virtual void IncomingMailBox(DataPayLoad dataPayLoad)
        {
            IncomingPayload(dataPayLoad);
        }
        /// <summary>
        ///  Cleanup method. It has been called when the view model receive a delete payload.
        /// </summary>
        /// <param name="payLoad">DataPayload to receive.</param>
        /// <param name="subsystem">DataSystem involved.</param>
        /// <param name="eventSubsystem">Event subsystem name.</param>
        protected abstract void CleanUp(DataPayLoad payLoad, DataSubSystem subsystem, string eventSubsystem);

        /// <summary>
        ///  Init method. It has been called when the view model receive an init payload.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="payload"></param>
        /// <param name="insertion"></param>
        protected abstract void Init(string value, DataPayLoad payload, bool insertion);

        /// <summary>
        ///     This delete the region when there is a delete.
        /// </summary>

        protected abstract Task<bool> DeleteAsync(DataPayLoad payLoad);



        public IncrementalList<InnerDtoType> SourceView
        {
            set
            {
                SourceItems = value;
                RaisePropertyChanged();
            }
            get { return SourceItems; }
        }

        public bool CreateRegionManagerScope => true;

        public object ControlExt { get; private set; }

        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        protected override void DeleteItem(DataPayLoad payLoad)
        {
            bool isDeleted = false;
            NotifyTaskCompletion.Create(DeleteAsync(payLoad),
                (sender, args) =>
                {

                    if (sender is INotifyTaskCompletion<bool> taskCompletion)
                    {


                        if (taskCompletion.IsFaulted)
                            DialogService?.ShowErrorMessage("Error during deleting the invoice");

                        if (!taskCompletion.IsSuccessfullyCompleted) return;
                        isDeleted = true;

                    }

                });

            if (isDeleted)
            {
                DeleteRegion();


                var dataPayLoad = new DataPayLoad
                {
                    Sender = ViewModelUri.ToString(),
                    PayloadType = DataPayLoad.Type.UpdateView
                };

                EventManager.NotifyObserverSubsystem(EventSubSystemName, dataPayLoad);
                UnregisterToolBar(payLoad.PrimaryKey);
            }
        }

        /// <summary>
        ///  Base changed command to be used.
        /// </summary>
        /// <param name="dataObject">Data object to be used.</param>
        /// <param name="eventDictionary">Event dictionary to be propagated.</param>
        /// <param name="subSystem">Data subsystem to be used.</param>
        /// <param name="subsystemName">Data subsystem name to be used.</param>

        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]

        protected void OnChangedCommand(
            DtoType dataObject,
            IDictionary<string, object> eventDictionary,
            DataSubSystem subSystem,
            string subsystemName)
        {
            if (OperationalState == DataPayLoad.Type.Raw)
            {
                return;
            }
            if (dataObject == null)
            {
                return;
            }

            var payLoad = BuildDataPayload(eventDictionary);
            payLoad.Subsystem = subSystem;
            payLoad.SubsystemName = subsystemName;

            var handlerDo = new ChangeFieldHandlerDo<DtoType>(EventManager, subSystem);
            if (OperationalState == DataPayLoad.Type.Insert)
            {
                handlerDo.OnInsert(payLoad, eventDictionary);
            }
            else
            {
                payLoad.PayloadType = DataPayLoad.Type.Update;

                handlerDo.OnUpdate(payLoad, eventDictionary);
            }
            RaisePropertyChanged("CollectionView");
        }

        /// <summary>
        /// Detect if a grid operation has been occurred.
        /// </summary>
        /// <param name="ev">
        /// Event that it is coming from the grid.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/> true if a grid has been changed.
        /// </returns>
        protected bool IsGridChanged(IDictionary<string, object> ev)
        {
            // precondition: operation shall exits.
            if (!ev.ContainsKey("Operation"))
            {
                return false;
            }

            var op = (ControlExt.GridOp)ev["Operation"];
            return (op == KarveControls.ControlExt.GridOp.Insert) ||
                    (op == KarveControls.ControlExt.GridOp.Delete) ||
                    (op == KarveControls.ControlExt.GridOp.Update);

        }

        /// <summary>
        /// The update object.
        /// </summary>
        /// <param name="dataObject">
        /// The data object.
        /// </param>
        /// <param name="ev">
        /// Event Dictionary for the object.
        /// </param>
        /// <param name="linesDto">
        /// Lines data object
        /// </param>
        /// <returns>
        /// The <see cref="DtoType"/>.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        protected DtoType UpdateObject(DtoType dataObject, IDictionary<string, object> ev, IEnumerable<InnerDtoType> linesDto)
        {
            // precond: operation shall exits.
            if (!ev.ContainsKey("Operation"))
            {
                return dataObject;
            }
            var op = (ControlExt.GridOp)ev["Operation"];
            // two cases:
            // 1. The changed value is just an item of innertype
            if (ev.ContainsKey("ChangedValue"))
            {

                //  just one row changed
                if (ev["ChangedValue"] is InnerDtoType single)
                {
                    UpdateSingleValue(op, dataObject, single, linesDto);
                }
                // multiple row changes
                else if (ev["ChangedValue"] is IEnumerable<InnerDtoType> collection)
                {
                    UpdateMultipleValues(op, dataObject, collection, linesDto);
                }

            }
            return dataObject;
        }

        /// <summary>
        /// Update multiple grid values
        /// </summary>
        /// <param name="op">
        /// The op.
        /// </param>
        /// <param name="dataObject">
        /// The data object.
        /// </param>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <param name="linesDto">
        /// The lines dto.
        /// </param>
        private void UpdateMultipleValues(ControlExt.GridOp op, DtoType dataObject, object collection, IEnumerable<InnerDtoType> linesDto)
        {
            IEnumerable<InnerDtoType> summaryDtos = new List<InnerDtoType>();
            if (collection is IEnumerable<object> changedValue)
            {
                var localDtos = new List<InnerDtoType>();
                foreach (var v in changedValue)
                {
                    InnerDtoType dto = v as InnerDtoType;
                    localDtos.Add(dto);
                }
                switch (op)
                {
                    case KarveControls.ControlExt.GridOp.Insert:
                        var currentValue = linesDto.ToList();
                        var count = currentValue.Count;
                        summaryDtos = localDtos.Union(currentValue);
                        break;
                    case KarveControls.ControlExt.GridOp.Delete:
                        summaryDtos = linesDto.Except(localDtos);
                        break;
                    case KarveControls.ControlExt.GridOp.Update:
                        var localIds = from x in localDtos select x.KeyId;
                        var toReplace = linesDto.Where(x => localIds.Contains(x.KeyId));
                        var invoiceDto = linesDto.Except(toReplace);
                        summaryDtos = invoiceDto.Union(localDtos);
                        break;
                }
            }

            if (summaryDtos.Any())
            {
                dataObject.Items = summaryDtos;
            }

        }

        private void UpdateSingleValue(ControlExt.GridOp op, DtoType dataObject, InnerDtoType single, IEnumerable<InnerDtoType> linesDto)
        {
            single.IsDirty = true;
          
            switch (op)
            {
                case KarveControls.ControlExt.GridOp.Update:
                case KarveControls.ControlExt.GridOp.Insert:
                    var currentValue = linesDto.ToList();
                    var count = currentValue.Count;
                    if (!currentValue.Contains(single))
                    {
                        single.IsNew = true;
                        currentValue.Add(single);
                        dataObject.Items = currentValue;
                    }
                    break;
                case KarveControls.ControlExt.GridOp.Delete:
                    {
                        var summaryDtos = new List<InnerDtoType>() {single};
                        dataObject.Items = linesDto.Except(summaryDtos);
                    }
                    break;
            }

        }

        public abstract DtoType ComputeTotals(DtoType aggregated = null);



    }
}
