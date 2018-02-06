using MasterModule.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Logic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataObjects;
using Prism.Commands;
using AutoMapper;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveControls;
using KarveDataServices.DataTransferObject;
using System.ComponentModel;
using System.Windows;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Windows.Input;

namespace MasterModule.ViewModels
{
    class UpperBarClientViewModel : UpperBarViewModelBase, IEventObserver, IDisposeEvents
    {
        private IClientData _currentClientData;
        private string _currentName;
        private INotifyTaskCompletion<ObservableCollection<ClientTypeDto>> _clientNotifyTask;
        private IEnumerable _currentView;

        public const string Name = "master://UpperBarClientViewModel";

        public UpperBarClientViewModel():base()
        {
            
        }
        /// <summary>
        /// This is the upperBarView that it can be customized as we wish
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="services"></param>
        public UpperBarClientViewModel(IEventManager manager,
            IDataServices services) : base(manager, services)
        {

            ChangedItem = new DelegateCommand<object>(OnChangedItem);
            AssistCommandUpper = new DelegateCommand<object>(OnAssistCommand);
            EventManager.RegisterObserver(this);
            RegisterEvents();    
            // initialize the mapper to the automap for the upper view model.
            InitMapping();
        }
        public ICommand AssistCommandUpper { set; get; }
        private void RegisterEvents()
        {
            MailBoxHandler += MailBoxHandlerMethod;
            EventManager.RegisterMailBox(Name, MailBoxHandler);
            EventManager.RegisterObserverSubsystem(MasterModuleConstants.ClientSubSystemName, this);
        }
        /// <summary>
        ///  Dispose events for this view model.
        /// </summary>
        public override void DisposeEvents()
        {
           EventManager.DeleteMailBoxSubscription(Name);
           EventManager.DeleteObserverSubSystem(MasterModuleConstants.ClientSubSystemName, this);
        }
        /// <summary>
        ///  This handle the command for the assist.
        /// </summary>
        /// <param name="assistData"></param>
        private async void OnAssistCommand(object assistData)
        {
            Contract.Assert(assistData != null, "OnAssistCommand: Payload shall be not a null!");
            IHelperDataServices helperDataServices = DataServices.GetHelperDataServices();
            IDictionary<string, string> currentData = assistData as Dictionary<string, string>;
            if (currentData != null)
            {
                var assistName = currentData[ControlExt.AssistName] as string;
                if (assistName == "TIPOCLI")
                {
                    SourceView = await helperDataServices.GetMappedAllAsyncHelper<ClientTypeDto, TIPOCLI>();
                }
                _status = UpperBarViewModelState.Loaded;
            }
            Contract.Ensures(SourceView != null, "Null assist!");
        }
        /// <summary>
        ///  This receives direct messages from the other view model.
        /// </summary>
        /// <param name="payLoad">Message to be received.</param>
        private void MailBoxHandlerMethod(DataPayLoad payLoad)
        {
            Contract.Assert(payLoad!=null, "MailBoxHandlerMethod: Payload shall be not a null!");            
            if (payLoad.HasDataObject)
            {
                var tmp = payLoad.DataObject as IClientData;
                if (tmp != null)
                {
                    DataObject = tmp;
                    var uuid = Guid.ToString();
                    var name = Name + "?id=" + uuid;
                    Uri value = new Uri(name);
                    _currentName = value.ToString();
                    _subsystem = payLoad.Subsystem;
                    EventManager.DeleteMailBoxSubscription(Name);
                    _currentName = Name + "." + payLoad.PrimaryKeyValue;
                    EventManager.RegisterMailBox(_currentName, MailBoxHandler);
                    _clientNotifyTask = NotifyTaskCompletion.Create(HandleUpperBar(DataObject), LoadedEventHandler);
                }
            }
        }
        /// <summary>
        ///  This load the data from the lower view model.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ev"></param>
        private void LoadedEventHandler(object sender, PropertyChangedEventArgs ev)
        {
            INotifyTaskCompletion<ObservableCollection<ClientTypeDto>> value = sender as INotifyTaskCompletion<ObservableCollection<ClientTypeDto>>;
            string propertyName = ev.PropertyName;
            if (propertyName.Equals("Status"))
            {
                if (_clientNotifyTask.IsSuccessfullyCompleted)
                {
                    if (value != null)
                    {
                        SourceView = value.Task.Result;
                    }
                    
                }
            }
            else if (propertyName.Equals("IsSuccessfullyCompleted"))
            {
                var result = value?.Task.Result;
                SourceView = result;
            }
            else
            {
                if (_clientNotifyTask.IsFaulted)
                {
                    MessageBox.Show(_clientNotifyTask.ErrorMessage);
                }
            }
            Contract.Ensures(SourceView!=null, "SourceView shall be present");
        }
        private async Task<ObservableCollection<ClientTypeDto>> HandleUpperBar(object dataObject)
        {

            IHelperDataServices helperDataServices = DataServices.GetHelperDataServices();
           ClientesDto data = dataObject as ClientesDto;
            var view = new ObservableCollection<ClientTypeDto>();

            if (data != null)
            {
                var value = await helperDataServices.GetSingleMappedAsyncHelper<ClientTypeDto,TIPOCLI>(data.NUMERO_CLI);
 
                view.Add(value);
            }
            return view;
        }


        /// <summary>
        ///  This receive the incoming paylod
        /// </summary>
        /// <param name="payload"></param>
        public void IncomingPayload(DataPayLoad payload)
        {

        }
        /// <summary>
        /// Init the mapping.
        /// </summary>
        private void InitMapping()
        {
            _status = UpperBarViewModelState.Init;
        }

      
        protected override void UpdateDataObject(object currentObject)
        {

        }
        /// <summary>
        ///  Data Object
        /// </summary>
        public IClientData DataObject
        {
            set
            {
                _currentClientData = value;
                RaisePropertyChanged();
            }
            get { return _currentClientData; }
        }
        /// <summary>
        ///  Sourceview for the searchbox
        /// </summary>
        public override IEnumerable SourceView {
            get { return _currentView; }
            set
            {
                _currentView = value;
                RaisePropertyChanged();
            }
        }

        
    }
}
