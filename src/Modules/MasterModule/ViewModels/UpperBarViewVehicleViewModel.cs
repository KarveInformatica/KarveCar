using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AutoMapper;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using Prism.Commands;
using Prism.Mvvm;

namespace MasterModule.ViewModels
{

   
    public class UpperBarViewVehicleViewModel: BindableBase, IDisposable
    {
        private IDataServices _dataServices;
        private IEventManager _eventManager;
        private MailBoxMessageHandler MailBoxHandler;
        public const string Name = "MasterModule.UpperBarViewVehicleViewModel";
        private const string AssistQuery = "AssistQuery";
        private object _dataObject = null;
        private object _sourceView = new object();
        private DataSubSystem _subsystem;
        private IVehicleData _currentVehicleData;

        private const string VehicleBrandQuery = "SELECT CODIGO, NOMBRE FROM MARCAS WHERE CODIGO='{0}'";
        private const string VehicleModel = "SELECT CODIGO, NOMBRE, VARIANTE FROM MODELO WHERE CODIGO='{0}'";
        private const string VehicleColor = "SELECT CODIGO, NOMBRE FROM MARCAS WHERE CODIGO='{0}'";


        /// <summary>
        ///  Data Object
        /// </summary>
        public object DataObject
        {
            set { _dataObject = value; RaisePropertyChanged(); }
            get { return _dataObject; }
        }
       
        /// <summary>
        ///  Changed item
        /// </summary>
        public ICommand ItemChangedHandler { set; get; }
        /// <summary>
        ///  Assist Command
        /// </summary>
        public ICommand AssistCommand { set; get; }
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
            get { return _sourceView; }
        }

        public UpperBarViewVehicleViewModel()
        {
            
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
            ItemChangedHandler = new DelegateCommand<object>(OnChangedItem);
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
            {
                cfg.CreateMap<MODELO, ModelVehicleDto>().ConvertUsing(src =>
                {
                    var vehicle = new ModelVehicleDto();
                    vehicle.Codigo = src.CODIGO;
                    vehicle.Variante = src.VARIANTE;
                    vehicle.Nombre = src.NOMBRE;
                    return vehicle;
                });
                cfg.CreateMap<MARCAS, BrandVehicleDto>().ConvertUsing(src=>
                {
                    var marcas = new BrandVehicleDto();
                    marcas.Codigo = src.CODIGO;
                    marcas.Nombre = src.NOMBRE;
                    return marcas;
                });
                cfg.CreateMap<COLORFL, ColorDto>().ConvertUsing(src =>
                {
                    var color = new ColorDto();
                    color.Codigo = src.CODIGO;
                    color.Nombre = src.NOMBRE;
                    return color;
                });
            });
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
                NotifyTaskCompletion.Create(HandleVehicleUpperBar(DataObject));
            }
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
                string brandCode = _currentVehicleData.Value.MAR;
                string value = string.Format(VehicleBrandQuery,brandCode);
                var marcas = await helperDataServices.GetAsyncHelper<MARCAS>(value);
                // color code
                string colorCode = _currentVehicleData.Value.COLOR;
                string colorQuery = string.Format(VehicleColor, colorCode);
                var color = await helperDataServices.GetAsyncHelper<COLORFL>(colorQuery);
                // model code
                string modelCode = _currentVehicleData.Value.MODELO;
                string modelQuery = string.Format(VehicleModel, modelCode);
                var model = await helperDataServices.GetAsyncHelper<MODELO>(modelQuery);
                _currentVehicleData.BrandDtos = Mapper.Map<IEnumerable<MARCAS>, IEnumerable<BrandVehicleDto>>(marcas);
                _currentVehicleData.ColorDtos = Mapper.Map<IEnumerable<COLORFL>, IEnumerable<ColorDto>>(color);
                _currentVehicleData.ModelDtos = Mapper.Map<IEnumerable<MODELO>, IEnumerable<ModelVehicleDto>>(model);  
            }

        }

        private async Task HandleAssist(string assistQuery, string tableName)
        {
            IHelperDataServices helperDataServices = _dataServices.GetHelperDataServices();
            switch (tableName)
            {
                case "COLORFL":
                {
                  var colors = await helperDataServices.GetAsyncHelper<COLORFL>(assistQuery);
                  _currentVehicleData.ColorDtos = Mapper.Map<IEnumerable<COLORFL>, IEnumerable<ColorDto>>(colors); ;
                  break;
                }
                case "MARCAS":
                {
                    var marcas = await helperDataServices.GetAsyncHelper<MARCAS>(assistQuery);
                    _currentVehicleData.BrandDtos = Mapper.Map<IEnumerable<MARCAS>, IEnumerable<BrandVehicleDto>>(marcas);
                    break;
                }
                case "MODELO":
                {
                    var modelo = await helperDataServices.GetAsyncHelper<MODELO>(assistQuery);
                    _currentVehicleData.ModelDtos = Mapper.Map<IEnumerable<MODELO>, IEnumerable<ModelVehicleDto>>(modelo);
                    break;
                }
                
            }

        }
        private void OnChangedItem(object data)
        {
            var currentData = data;
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.DataObject = currentData;
            DataObject = currentData;
            payLoad.PayloadType = DataPayLoad.Type.Update;
            payLoad.HasDataObject = true;
            payLoad.Subsystem = _subsystem;
            _eventManager.NotifyToolBar(payLoad);
        }

        private async void OnAssistCommand(object assistData)
        {
            IDictionary<string, string> currentData = assistData as Dictionary<string, string>;
            if (currentData != null)
            {
                string assistQuery = currentData[AssistQuery] as string;
                string tableName = currentData["TableName"] as string;
                await HandleAssist(assistQuery, tableName);
            }

        }
        /// <summary>
        ///  This dispose the current bar.
        /// </summary>
        public void Dispose()
        {
            _eventManager.DeleteMailBoxSubscription(UpperBarViewModel.Name);
        }
    }
}
