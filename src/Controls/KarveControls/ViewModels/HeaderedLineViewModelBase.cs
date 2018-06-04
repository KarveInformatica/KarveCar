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
using KarveControls;
using KarveCommon;

namespace KarveControls.ViewModels
{
    /// <summary>
    ///  Generic class for all the headered base model ("cabecera-linea", in spanish).
    ///  All view model in the headered base model class have to manage a dto with a list of inner type dtos as datamember.
    /// </summary>
    /// <typeparam name="DataType">Type of the domain, used to delivered data payload</typeparam>
    /// <typeparam name="DtoType">Data transfer object</typeparam>
    /// <typeparam name="InnerDtoType">Type of the other dto</typeparam>
    public abstract class HeaderedLineViewModelBase<DataType, DtoType, InnerDtoType>: KarveRoutingBaseViewModel, ICreateRegionManagerScope,IEventObserver where DtoType: LineBaseDto<InnerDtoType> where InnerDtoType: BaseDto
    {
        /// <summary>
        ///  Region Manager
        /// </summary>
        protected IRegionManager RegionManager;
        /// <summary>
        ///  New id interface
        /// </summary>
        protected IIdentifier IdentifierGenerator;
        protected DataSubSystem SubSystem;
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
            AssistDataService = DataServices.GetAssistDataServices();
        }

        protected override string GetRouteName(string name)
        {
            return string.Empty;
        }

        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
          
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
        protected void DeleteRegion()
        {
           
            if ((RegionManager == null) || (RegionManager.Regions == null))
            {
                return;
            }
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

        public bool CreateRegionManagerScope => true;

        public object ControlExt { get; private set; }

        protected  override void DeleteItem(DataPayLoad payLoad)
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
        /// 
        /// </summary>
        /// <param name="dataObject"></param>
        /// <param name="eventDictionary"></param>
        /// <param name="subSystem"></param>
        /// <param name="subsystemName"></param>
        /// <param name="objectPath"></param>
        protected void OnChangedCommand(DtoType dataObject, 
            IDictionary<string, object> eventDictionary, DataSubSystem subSystem, string subsystemName,string objectPath)
        {

            var evDictionary = eventDictionary as IDictionary<string, object>;
            var changedDataObject = evDictionary["DataObject"] as DtoType;
            var payLoad = BuildDataPayload(eventDictionary);
            payLoad.Subsystem = subSystem;
            payLoad.SubsystemName = subsystemName;
            var data = dataObject;
            /*
             * when we change one line.
             * 1. Update the object
             */
            if (changedDataObject is IEnumerable<InnerDtoType> innerData)
            {

                var aggregateRows = UpdateObject(changedDataObject, evDictionary, innerData);
                data = ComputeTotals(aggregateRows);
                data.Items = innerData;
                payLoad.DataObject = data;
                payLoad.Subsystem = subSystem;
            }
            else
            {

                payLoad.PayloadType = DataPayLoad.Type.Update;
                payLoad.PrimaryKeyValue = PrimaryKeyValue;
                payLoad.HasDataObject = true;
                data.Items = SourceView as IEnumerable<InnerDtoType>;
                payLoad.DataObject = data;
                payLoad.ObjectPath = new Uri(objectPath);
                payLoad.Sender = objectPath;
            }
           payLoad.Sender = ViewModelUri.ToString();
           payLoad.ObjectPath = ViewModelUri;
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

        }

        DtoType UpdateObject(DtoType dataObject, IDictionary<string, object> ev, IEnumerable<InnerDtoType> linesDto) 
        {
            // precond: operation shall exits.
            if (!ev.ContainsKey("Operation"))
            {
                return dataObject;
            }

            var op = (ControlExt.GridOp)ev["Operation"];
           
            if (ev.ContainsKey("ChangedValue"))
            {
                IEnumerable<InnerDtoType> summaryDtos = new List<InnerDtoType>();
                if (ev["ChangedValue"] is IEnumerable<object> changedValue)
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
            return dataObject;
        }

        public abstract DtoType ComputeTotals(DtoType aggregated);
        


    }
}
