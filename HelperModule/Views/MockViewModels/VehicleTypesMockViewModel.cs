using Prism.Commands;
using System.Windows;
using HelperModule.ViewModels;
using KarveDataServices.DataTransferObject;
using System.Collections.ObjectModel;
using KarveCommon.Services;
using KarveDataServices;
using Prism.Regions;

namespace HelperModule.Views
{
   
    public class VehicleTypesMockViewModel: BaseHelperViewModel 
    {

        private ObservableCollection<VehicleTypeDto> listOfVehicles = new ObservableCollection<VehicleTypeDto>();
        
        public VehicleTypesMockViewModel(IDataServices dataServices, IRegionManager manager, IEventManager eventManager) : base(dataServices, manager, eventManager)
        {
            ExitCommand = new DelegateCommand<object>(OnExit);
            HelpCommand = new DelegateCommand<object>(OnHelp);
            SaveCommand = new DelegateCommand<object>(OnSave);
        }
        private void OnSave(object obj)
        {
            MessageBox.Show("Save Clicked!");

        }
        private void OnHelp(object obj)
        {
            MessageBox.Show("Save Clicked!");

        }
        private void OnExit(object obj)
        {

        }

        public override void OnExitCommand(object value)
        {
           
        }

        public override void OnHelpCommand()
        {
       
        }

        public override void OnSaveCommand(object value)
        {
       
        }
    }
}
