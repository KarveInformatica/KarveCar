using System;
using System.Collections.Generic;
using KarveDataServices.DataTransferObject;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using Prism.Commands;
using KarveDataServices;
using Prism.Regions;
using KarveDataServices.DataObjects;
using KarveDataAccessLayer.DataObjects;
using Syncfusion.Windows.PdfViewer;


namespace HelperModule.ViewModels
{
    class VehicleTypesViewModel : BaseHelperViewModel, ICreateRegionManagerScope
    {
        private ObservableCollection<VehicleTypeDto> _listOfVehicles = new ObservableCollection<VehicleTypeDto>();
        private VehicleTypeDto _vehicleType = new VehicleTypeDto();
        private ICommand _selectedDateCommand;
        private INotifyTaskCompletion<IEnumerable<VehicleTypeDto>> _initializationNotifier;

        public VehicleTypesViewModel(IDataServices dataServices, IRegionManager region, IEventManager eventManager) : base(dataServices, region, eventManager)
        {
            _selectedDateCommand = new DelegateCommand<object>(OnSelectedDate);
            _vehicleType.Code = "0";
            _vehicleType.Name = "";
            _vehicleType.OfferMargin = 0;
            _vehicleType.TerminationDate = DateTime.Now;
            _vehicleType.WebName = "";
            ExecutedLoadHandler+= ExecutedLoadHandlerMethod;
            SelectionChangedCommand = new DelegateCommand<object>(OnSelectionChangedCommand);
            _initializationNotifier = NotifyTaskCompletion.Create(InitViewModel(), ExecutedLoadHandler);
        }

        private void ExecutedLoadHandlerMethod(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            var completion = sender as INotifyTaskCompletion;
           
        }

        private void OnSelectionChangedCommand(object value)
        {
          VehicleTypeDto dto = value as VehicleTypeDto;
            VehicleType = dto;
        }
        private async Task<IEnumerable<VehicleTypeDto>> InitViewModel()
        {
            var listOfVehicles = await DataServices.GetHelperDataServices()
                .GetMappedAsyncHelper<VehicleTypeDto, CATEGO>(GenericSql.VehicleTypes);
            if (listOfVehicles == null)
            {
                return null;
            }
            HelperView = new ObservableCollection<VehicleTypeDto>(listOfVehicles);

            return listOfVehicles;
        }

        public VehicleTypeDto VehicleType
        {
            set { _vehicleType = value; RaisePropertyChanged();}
            get { return _vehicleType; }

        }
        public ObservableCollection<VehicleTypeDto> HelperView
        {
            set
            {
                _listOfVehicles = value; RaisePropertyChanged();
            }
            get
            {
                return _listOfVehicles;

            }
        }

        /// <summary>
        ///  SelectionChangedCommand
        /// </summary>
        public ICommand SelectionChangedCommand { set; get; }
        /// <summary>
        ///  OnSelectedDate
        /// </summary>
        /// <param name="var"> This is a variable in a selected date</param>
        public void OnSelectedDate(object var)
        {
        }
        /// <summary>
        /// SelectedDateCommand.
        /// </summary>
        public ICommand SelectedDateCommand { get; set; }

        public bool CreateRegionManagerScope => true;

        public override void OnSaveCommand(object obj)
        {
        }
        

        public override void OnExitCommand(object value)
        {
        }
        public override void OnHelpCommand()
        {
        }
    }
}
