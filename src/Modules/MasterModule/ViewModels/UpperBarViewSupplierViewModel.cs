using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using MasterModule.Common;
using Prism.Commands;

namespace MasterModule.ViewModels
{

    class UpperBarViewSupplierViewModel : UpperBarViewModelBase
    {
        public const string Name = "MasterModule.UpperBarViewSupplierViewModel";
        private IEnumerable<TIPOPROVE> _tipocomis = new List<TIPOPROVE>();
        private string _currentName;

        /// <summary>
        /// This is the upperBarView that it can be customized as we wish
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="services"></param>
        public UpperBarViewSupplierViewModel(IEventManager manager,
        IDataServices services) : base(manager, services)
        {

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
            Mapper.Initialize(cfg =>
            cfg.CreateMap<TIPOPROVE, KarveDataServices.DataTransferObject.SupplierTypeDto>().ConvertUsing(src =>
            {
                var tipoProvee = new SupplierTypeDto();
                tipoProvee.Codigo = src.NUM_TIPROVE;
                tipoProvee.Nombre = src.NOMBRE;
                tipoProvee.Usuario = src.USUARIO;
                tipoProvee.UltimaModifica = src.ULTMODI;
                return tipoProvee;
            })
            );
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
                DataObject = data;
                _subsystem = payLoad.Subsystem;
                EventManager.DeleteMailBoxSubscription(Name);
               
                _currentName = Name + "." + payLoad.PrimaryKeyValue;
                EventManager.RegisterMailBox(_currentName, MailBoxHandler);
                               
            }
        }

        public ICommand UpperBarSupplierAssist
        {
            set;
            get;
        }
        private async Task HandleSupplier(object dataObject)
        {
            ISupplierData supplier = dataObject as ISupplierData;
            DataObject = supplier;
            
            var supplierValue = supplier.Type.FirstOrDefault().Number;
            string value = string.Format("SELECT NUM_TIPROVE, NOMBRE FROM TIPOPROVE WHERE NUM_TIPROVE='{0}'", supplierValue);
            IHelperDataServices helperDataServices = DataServices.GetHelperDataServices();
            var supplierType = await helperDataServices.GetAsyncHelper<TIPOPROVE>(value);
            SourceView = Mapper.Map<IEnumerable<TIPOPROVE>, IEnumerable<SupplierTypeDto>>(supplierType);

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

                string assistQuery = currentData[AssistQuery] as string;
                var tipoProve = await helperDataServices.GetAsyncHelper<TIPOPROVE>(assistQuery);
                SourceView = Mapper.Map<IEnumerable<TIPOPROVE>, IEnumerable<SupplierTypeDto>>(tipoProve);
                _status = UpperBarViewModelState.Loaded;
            }

        }
        /// <summary>
        ///  This dispose the mailbox subscription.
        /// </summary>
        public void Dispose()
        {
            EventManager.DeleteMailBoxSubscription(UpperBarViewModel.Name);
        }
    }
}
