using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Logic;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using MasterModule.Common;
using Prism.Commands;
using DataAccessLayer.Model;

namespace MasterModule.ViewModels
{

    class UpperBarViewSupplierViewModel : UpperBarViewModelBase
    {
        public const string Name = "MasterModule.UpperBarViewSupplierViewModel";
        private IEnumerable<TIPOPROVE> _tipocomis = new List<TIPOPROVE>();
        private string _currentName;
        private ISupplierData _currentSupplier;
        private ICommand _startUpCommand;
        private IMapper _mapper;

        /// <summary>
        /// This is the upperBarView that it can be customized as we wish
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="services"></param>
        public UpperBarViewSupplierViewModel(IEventManager manager,
        IDataServices services) : base(manager, services)
        {

            _startUpCommand = new DelegateCommand<object>(HandleSupplier);
            ChangedItem = new DelegateCommand<object>(OnChangedItem);
            UpperBarSupplierAssist = new DelegateCommand<object>(OnAssistCommand);
            MailBoxHandler += MailBoxHandlerMethod;
            EventManager.RegisterMailBox(Name, MailBoxHandler);
            // initialize the mapper to the automap for the upper view model.
            InitMapping();
            
        }
        /// <summary>
        /// Init the mapping.
        /// </summary>
        private void InitMapping()
        {
            _mapper = MapperField.GetMapper();

            _status = UpperBarViewModelState.Init;
        }
        /// <summary>
        ///  Each view model has a correct mailbox handler to receive the data form other forms.
        /// </summary>
        /// <param name="payLoad"></param>
        private void MailBoxHandlerMethod(DataPayLoad payLoad)
        {

            if (payLoad.HasDataObject)
            {
                ISupplierData data = payLoad.DataObject as ISupplierData;
                DataObject = null;
                DataObject = data;
               // _startUpCommand.Execute(data);
                // DataObject.Value = data.Value;
                //  RaisePropertyChanged("DataObject.Value");
                _subsystem = payLoad.Subsystem;
                EventManager.DeleteMailBoxSubscription(Name);
                if (string.IsNullOrEmpty(PrimaryKeyValue))
                {
                    PrimaryKeyValue = payLoad.PrimaryKeyValue;
                }
                if (PrimaryKeyValue == payLoad.PrimaryKeyValue)
                {
                    _currentName = Name + "." + payLoad.PrimaryKeyValue;
                    EventManager.RegisterMailBox(_currentName, MailBoxHandler);
                    _startUpCommand.Execute(data);
                }

            }
        }

        public ICommand UpperBarSupplierAssist
        {
            set;
            get;
        }

        private async void HandleSupplier(object dataObject)
        {
            ISupplierData supplier = dataObject as ISupplierData;
            //         DataObject = supplier;
            if (supplier != null)
            {
                /*
                ISupplierTypeData supplierValue = supplier.Type.FirstOrDefault();
                if (supplierValue == null)
                {
                    supplierValue = new SupplierTypeDataObject();
                    supplierValue.Number = 1;
                }
                string value = string.Format("SELECT NUM_TIPROVE, NOMBRE FROM TIPOPROVE WHERE NUM_TIPROVE='{0}'",
                    supplierValue.Number);
                IHelperDataServices helperDataServices = DataServices.GetHelperDataServices();
                var supplierType = await helperDataServices.GetAsyncHelper<TIPOPROVE>(value);
               
                var dto = _mapper.Map<IEnumerable<TIPOPROVE>, IEnumerable<SupplierTypeDto>>(supplierType);
                SourceView = dto;
                */
            }
        }
        /// <summary>
        ///  TODO: using controvariance will be useful
        /// </summary>
        /// <param name="assistData"></param>
        private async void OnAssistCommand(object assistData)
        {
            IHelperDataServices helperDataServices = DataServices.GetHelperDataServices();
            IDictionary<string, string> currentData = assistData as Dictionary<string, string>;
            if (currentData != null)
            {
                // string assistQuery = currentData[AssistQuery] as string;
                var tipoProve = await helperDataServices.GetMappedAllAsyncHelper<SupplierTypeDto, TIPOPROVE>();
                SourceView = tipoProve;
                _status = UpperBarViewModelState.Loaded;
            }

        }

        public ISupplierData DataObject
        {
            get { return _currentSupplier; }
            set { _currentSupplier = value; RaisePropertyChanged(); }
        }
        /// <summary>
        ///  This dispose the mailbox subscription.
        /// </summary>
        public void Dispose()
        {
            EventManager.DeleteMailBoxSubscription(UpperBarViewModel.Name);
        }

        protected override void UpdateDataObject(object currentObject)
        {
          //DataObject = currentObject as ISupplierData;
        }

        public override IEnumerable SourceView
        {
            get { return _sourceView; }
            set
            {
                _sourceView = value;
                RaisePropertyChanged();
            }
        }
     }
}
