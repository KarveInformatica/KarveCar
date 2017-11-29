using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveDataServices;
using Prism.Commands;
using Prism.Mvvm;
using AutoMapper;
using KarveCommon.Generic;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace MasterModule.ViewModels
{
    /// <summary>
    ///  UpperBarView model.
    /// </summary>
    public class UpperBarViewModel : BindableBase, IDisposable
    {
        private IDataServices _dataServices;
        private IEventManager _eventManager;
        private MailBoxMessageHandler MailBoxHandler;
        public const string Name = "MasterModule.UpperBarViewModel";
        private const string AssistQuery = "AssistQuery";
        private object _dataObject = null;
        private IEnumerable<TIPOCOMI> _tipocomis = new List<TIPOCOMI>();
        private object _sourceView = new object();
        private DataSubSystem _subsystem;
        //private string[] Tipo = 

       
        /// <summary>
        ///  Data Object
        /// </summary>
        public object DataObject
        {
            set { _dataObject = value; RaisePropertyChanged(); }
            get { return _dataObject; }
        }
        private enum UpperBarViewModelState {
            Init, Loaded
        };

        private UpperBarViewModelState _status;
        /// <summary>
        ///  Changed item
        /// </summary>
        public ICommand ChangedItem { set; get; }
        /// <summary>
        ///  Assist Command
        /// </summary>
        public ICommand AssistCommand { set; get; }
        /// <summary>
        ///  SourceView
        /// </summary>
        public object SourceView {
            set
            {
                _sourceView = value;
                RaisePropertyChanged();
            }
            get { return _sourceView; } }
        /// <summary>
        /// This is the upperBarView that it can be customized as we wish
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="services"></param>
        public UpperBarViewModel(IEventManager manager,
            IDataServices services)
        {
            _dataServices = services;
            _eventManager = manager;
            ChangedItem = new DelegateCommand<object>(OnChangedItem);
            AssistCommand = new DelegateCommand<object>(OnAssistCommand);
            MailBoxHandler += MailBoxHandlerMethod;
            _eventManager.RegisterMailBox(Name, MailBoxHandler);
            // initialize the mapper to the automap for the upper view model.
            InitMapping();
        }
        /// <summary>
        /// Init the mapping.
        /// </summary>
        private void InitMapping()
        {
            Mapper.Initialize(cfg =>
                cfg.CreateMap<TIPOCOMI, CommissionTypeDto>().ConvertUsing(src =>
            {
                var tipoComi = new CommissionTypeDto();
                tipoComi.Codigo = src.NUM_TICOMI;
                tipoComi.Nombre = src.NOMBRE;
                return tipoComi;
            })
                );
            _status=UpperBarViewModelState.Init;
        }
        /// <summary>
        ///  Each view model has a correct mailbox handler to receive the data form other forms.
        /// </summary>
        /// <param name="payLoad"></param>
        private void MailBoxHandlerMethod(DataPayLoad payLoad)
        {
            if (payLoad.HasDataObject)
            {
                DataObject = payLoad.DataObject;
                _subsystem = payLoad.Subsystem;
                NotifyTaskCompletion.Create(HandleCommission(DataObject));
            }
        }

   
        private async Task HandleCommission(object dataObject)
        {
            ICommissionAgent agent = dataObject as ICommissionAgent;
            IHelperDataServices helperDataServices = _dataServices.GetHelperDataServices();
            var agentValue = agent.CommisionTypeDto.FirstOrDefault().Codigo;
            if (agentValue != null)
            {

                string value = string.Format("SELECT NUM_TICOMI, NOMBRE FROM TIPOCOMI WHERE NUM_TICOMI='{0}'",agentValue);
                var tipoComi = await helperDataServices.GetAsyncHelper<TIPOCOMI>(value);
                 SourceView = Mapper.Map<IEnumerable<TIPOCOMI>, IEnumerable<CommissionTypeDto>>(tipoComi);
                //_status = UpperBarViewModelState.Loaded;
            }
  
        }
        private void OnChangedItem(object data)
        {
            object currentObject = data;
            if (data is IDictionary<string, object>)
            {


                IDictionary<string, object> currentData = data as IDictionary<string, object>;
                if (currentData == null)
                    return;
                currentObject = currentData["DataObject"];
            }
            object dataObject = data;
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.DataObject = currentObject;
            DataObject = currentObject;
            payLoad.PayloadType = DataPayLoad.Type.Update;
            payLoad.HasDataObject = true;
            payLoad.Subsystem = _subsystem;
            // send message to the main view model to any item.
            _eventManager.NotifyToolBar(payLoad);
        }

        private async void OnAssistCommand(object assistData)
        {
                IHelperDataServices helperDataServices = _dataServices.GetHelperDataServices();
                IDictionary<string, string> currentData = assistData as Dictionary<string, string>;
                if (currentData != null)
                {
                  
                    string assistQuery = currentData[AssistQuery] as string;
                    var tipoComi = await helperDataServices.GetAsyncHelper<TIPOCOMI>(assistQuery);
                    SourceView = Mapper.Map<IEnumerable<TIPOCOMI>, IEnumerable<CommissionTypeDto>>(tipoComi);
                    _status = UpperBarViewModelState.Loaded;

                }
            
        }

        public void Dispose()
        {
            _eventManager.DeleteMailBoxSubscription(UpperBarViewModel.Name);
        }
    }
}
