using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Logic;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveControls;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using MasterModule.Common;
using Prism.Commands;
using Prism.Mvvm;

namespace MasterModule.ViewModels
{


    public class UpperBarViewVehicleViewModel : BindableBase, IDisposable, IEventObserver
    {
        private readonly IDataServices _dataServices;
        private readonly IEventManager _eventManager;
        private readonly MailBoxMessageHandler MailBoxHandler;
        public const string Name = "MasterModule.UpperBarViewVehicleViewModel";
        private const string AssistQuery = "AssistQuery";
        private IVehicleData _dataObject = null;


        private object _sourceView = new object();
        private DataSubSystem _subsystem;
        private IVehicleData _currentVehicleData;

        private const string VehicleBrandQuery = "SELECT CODIGO, NOMBRE FROM MARCAS WHERE CODIGO='{0}'";
        private const string VehicleBrandQueryByName = "SELECT CODIGO, NOMBRE FROM MARCAS WHERE NOMBRE='{0}'";
        private const string VehicleModel = "SELECT CODIGO, NOMBRE, VARIANTE FROM MODELO WHERE CODIGO='{0}'";
        private const string VehicleColor = "SELECT CODIGO, NOMBRE FROM COLORFL WHERE CODIGO='{0}'";
        private const string VehicleGroup = "SELECT CODIGO, NOMBRE FROM GRUPOS WHERE CODIGO='{0}'";
        private string _currentName = Name;

        /// <summary>
        ///  Data Object
        /// </summary>
        public IVehicleData DataObject
        {
            set
            {
                _dataObject = (IVehicleData) value;


                RaisePropertyChanged();
            }
            get { return _dataObject; }
        }



        /// <summary>
        ///  Changed item
        /// </summary>
        public ICommand ItemUpperChangedCommand { set; get; }

        /// <summary>
        ///  Changed item
        /// </summary>
        public ICommand ItemChangedHandler { set; get; }

        /// <summary>
        ///  Assist Command
        /// </summary>
        public ICommand AssistUpperCommand { set; get; }

        /// <summary>
        ///  SourceView
        /// </summary>
        public object SourceView
        {
            set
            {
                _sourceView = value;
                RaisePropertyChanged();
            }
            get => _sourceView;
        }

        /// <summary>
        ///  Vehicle group data transfer object
        /// </summary>
        public IEnumerable<VehicleGroupDto> GroupVehicleDto { get; set; }

        /// <summary>
        ///  Model vehicle data transfer object
        /// </summary>
        public IEnumerable<ModelVehicleDto> ModelVehicleDto { get; set; }

        /// <summary>
        ///  Brand vehicle data transfer object.
        /// </summary>
        public IEnumerable<BrandVehicleDto> BrandVehicleDto { get; set; }

        private string _uniqueValue = "UpperBarViewVehicle." + Guid.NewGuid().ToString();
        private string _assistQueryModel;
        private IMapper _mapper;

        public string UniqueId
        {
            get => _uniqueValue;
            set => _uniqueValue = value;
        }


        /// <summary>
        /// This is the upperBarView that it can be customized as we wish
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="services"></param>
        public UpperBarViewVehicleViewModel(IEventManager manager,
            IDataServices services)
        {
            _dataServices = services;
            _eventManager = manager;
            ItemUpperChangedCommand = new DelegateCommand<object>(OnChangedItem);
            ItemChangedHandler = new DelegateCommand<object>(OnChangedItem);
            AssistUpperCommand = new DelegateCommand<object>(OnAssistCommand);
            MailBoxHandler += MailBoxHandlerMethod;
            _eventManager.RegisterMailBox(Name, MailBoxHandler);
            _eventManager.RegisterObserverSubsystem(MasterModuleConstants.VehiclesSystemName, this);
            // initialize the mapper to the automap for the upper view model.
            Stopwatch startStopwatch = new Stopwatch();
            startStopwatch.Start();
            InitMapping();
            startStopwatch.Stop();
            var value = startStopwatch.ElapsedMilliseconds;
        }

        /// <summary>
        /// Init the mapping.
        /// </summary>
        private void InitMapping()
        {
            _mapper = MapperField.GetMapper();
          

        }

        /// <summary>
        ///  Each view model has a correct mailbox handler to receive the data form other forms.
        ///  When this view model comes up the first time changes its name to the name of the primary key.
        /// </summary>
        /// <param name="payLoad"></param>
        private void MailBoxHandlerMethod(DataPayLoad payLoad)
        {
            if (payLoad.HasDataObject)
            {
                var tmp = payLoad.DataObject as IVehicleData;
                if (tmp != null)
                {
                    DataObject = tmp;
                    AssistQueryModel = DataObject.AssistModelQuery;
                    _subsystem = payLoad.Subsystem;
                    _currentVehicleData = tmp;
                    _eventManager.DeleteMailBoxSubscription(Name);
                    _currentName = Name + "." + payLoad.PrimaryKeyValue;
                    _eventManager.RegisterMailBox(_currentName, MailBoxHandler);
                    NotifyTaskCompletion.Create(HandleVehicleUpperBar(DataObject));
                }
            }
        }

        public string AssistQueryModel
        {
            set { _assistQueryModel = value; RaisePropertyChanged(); }
            get { return _assistQueryModel; }
        }
    

    /// <summary>
        /// Handle vehicle upper bar.
        /// </summary>
        /// <param name="dataObject"></param>
        /// <returns></returns>
        private async Task HandleVehicleUpperBar(object dataObject)
        {
            _currentVehicleData = dataObject as IVehicleData;
            IHelperDataServices helperDataServices = _dataServices.GetHelperDataServices();
            if (_currentVehicleData != null)
            {
                // brand code.
                string brandCode =  _currentVehicleData.Value.MAR;
                /* 
                 * massive fuck up on the database. The table is not coherent. 
                 */
                Stopwatch startStopwatch = new Stopwatch();
                startStopwatch.Start();
                string brandQuery = "";
                if ((brandCode == null) && (!string.IsNullOrEmpty(_currentVehicleData.Value.MARCA)))
                {
                    brandQuery = string.Format(VehicleBrandQueryByName, _currentVehicleData.Value.MARCA);
                }
                else
                {
                    brandQuery = string.Format(VehicleBrandQuery, brandCode);
                }
                var marcas = await helperDataServices.GetAsyncHelper<MARCAS>(brandQuery);
                // color code
                string colorCode = _currentVehicleData.Value.COLOR;
                string colorQuery = string.Format(VehicleColor, colorCode);
                var color = await helperDataServices.GetAsyncHelper<COLORFL>(colorQuery);
                // model code
                string modelCode = _currentVehicleData.Value.MODELO;
                string modelQuery = string.Format(VehicleModel, modelCode);
                var model = await helperDataServices.GetAsyncHelper<MODELO>(modelQuery);
                _currentVehicleData.BrandDtos = _mapper.Map<IEnumerable<MARCAS>, IEnumerable<BrandVehicleDto>>(marcas);
                _currentVehicleData.ColorDtos = _mapper.Map<IEnumerable<COLORFL>, IEnumerable<ColorDto>>(color);
                _currentVehicleData.ModelDtos = _mapper.Map<IEnumerable<MODELO>, IEnumerable<ModelVehicleDto>>(model);
                string query = string.Format(VehicleGroup, _currentVehicleData.Value.GRUPO);
                var grupos = await helperDataServices.GetAsyncHelper<GRUPOS>(query);
                _currentVehicleData.VehicleGroupDtos = _mapper.Map<IEnumerable<GRUPOS>, IEnumerable<VehicleGroupDto>>(grupos);
                DataObject = _currentVehicleData;
                DataObject.BrandDtos = _currentVehicleData.BrandDtos;
                DataObject.ColorDtos = _currentVehicleData.ColorDtos;
                DataObject.ModelDtos = _currentVehicleData.ModelDtos;
                DataObject.VehicleGroupDtos = _currentVehicleData.VehicleGroupDtos;
                startStopwatch.Stop();
                var stopWatch = startStopwatch.ElapsedMilliseconds;
            }

        }

        private async Task HandleAssist(string assistQuery, string tableName)
        {
            IHelperDataServices helperDataServices = _dataServices.GetHelperDataServices();
            if (_currentVehicleData == null)
            {
                return;
            }
            switch (tableName)
            {
                case "COLORFL":
                {
                       var colos =
                  _currentVehicleData.ColorDtos = await helperDataServices.GetMappedAsyncHelper<ColorDto, COLORFL>(assistQuery);
                  break;
                }
                case "MARCAS":
                {
                        var brands = await helperDataServices.GetMappedAsyncHelper<BrandVehicleDto, MARCAS>(assistQuery);
                    _currentVehicleData.BrandDtos = brands;
                    break;
                }
                case "MODELO":
                {
                        var models = await helperDataServices.GetMappedAsyncHelper<ModelVehicleDto, MODELO>(assistQuery);
                    _currentVehicleData.ModelDtos = models;
                    break;
                }
                case "GRUPOS":
                {
                        var vehicles = await helperDataServices
                            .GetMappedAsyncHelper<VehicleGroupDto, GRUPOS>(assistQuery);
                    _currentVehicleData.VehicleGroupDtos = vehicles;
                         
                    break;
                }
                
                   
            }
          DataObject = _currentVehicleData;

        }
        private void OnChangedItem(object data)
        {
            object currentObject = data;
            if (data == null)
            {
                return;
            }
            if (data is IDictionary<string, object>)
            {


                IDictionary<string, object> currentData = data as IDictionary<string, object>;
                currentObject = currentData["DataObject"];
            }
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.DataObject = currentObject as IVehicleData;
            DataObject = currentObject as IVehicleData;
            payLoad.PayloadType = DataPayLoad.Type.Update;
            payLoad.HasDataObject = true;
            payLoad.Subsystem = _subsystem;
            _eventManager.NotifyToolBar(payLoad);
            // notify the current subsystem.
            DataPayLoad payLoadView = new DataPayLoad();
            payLoadView.DataObject = DataObject;
            payLoadView.PayloadType = DataPayLoad.Type.UpdateData;
            payLoadView.HasDataObject = true;
            payLoadView.Subsystem = _subsystem;
            _eventManager.NotifyObserverSubsystem(MasterModuleConstants.VehiclesSystemName, payLoadView);

        }

        private async void OnAssistCommand(object assistData)
        {
            IDictionary<string, string> currentData = assistData as Dictionary<string, string>;
            if (currentData != null)
            {
                string assistQuery = currentData[AssistQuery] as string;
                string tableName = "";
                if (currentData.ContainsKey("AssistTable"))
                {
                   tableName = currentData["AssistTable"] as string;
                }
                if (!string.IsNullOrEmpty(tableName))
                {
                    await HandleAssist(assistQuery, tableName);
                }
                else
                {
                    await Task.Delay(1);
                }
            }

        }
        /// <summary>
        ///  This dispose the current bar.
        /// </summary>
        public void Dispose()
        {
            _eventManager.DeleteMailBoxSubscription(UpperBarViewModel.Name);
        }

        public void IncomingPayload(DataPayLoad payload)
        {
            if (payload.Sender != _currentName)
            {
                DataPayLoad.Type type = payload.PayloadType;
                switch (type)
                {
                       case DataPayLoad.Type.UpdateData:
                        {
                            // here merge or replace the current data object.
                            DataObject = payload.DataObject as IVehicleData;
                            break;
                        }

                }
            }
        }
    }
}

