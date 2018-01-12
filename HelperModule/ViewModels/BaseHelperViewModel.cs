using System.Collections.Generic;
using Prism.Mvvm;
using System.Windows.Input;
using Prism.Commands;
using System.ComponentModel;
using System.Threading.Tasks;
using DevExpress.Data.Helpers;
using KarveCommon.Services;
using Prism.Regions;
using KarveDataServices;
using KarveDataServices.DataTransferObject;

namespace HelperModule.ViewModels
{
    /// <summary>
    ///  This base helper view model.
    /// </summary>
    public abstract class BaseHelperViewModel : BindableBase, INavigationAware
    {

        /// <summary>
        ///  Load any helper window.
        /// </summary>
        protected PropertyChangedEventHandler ExecutedLoadHandler;

        protected IEventManager EventManager;
        /// <summary>
        ///  This command exit the interface
        /// </summary>
        public ICommand ExitCommand { set; get; }

        public ICommand ResetCommand { set; get; }

        public ICommand DeleteCommand { set; get; }
        /// <summary>
        /// This help command
        /// </summary>
        public ICommand HelpCommand { set; get; }
        /// <summary>
        /// This save command
        /// </summary>
        public ICommand SaveCommand { set; get; }
        /// <summary>
        ///  Save Command Param.
        /// </summary>
        public object SaveCommandParam { set; get; }
        /// <summary>
        ///  Method on exit depends on the current view model, region so this is abstract
        /// </summary>
        /// <param name="value">Value on exit command</param>
        public abstract void OnExitCommand(object value);

        /// On help command. This shows the help of the command.
        /// </summary>
        /// <param name="value"></param>
        public abstract void OnHelpCommand();
        /// <summary>
        ///  This is a on save command.
        /// </summary>
        /// <param name="value">Parameters in the save</param>
        public abstract void OnSaveCommand(object value);


     //   protected abstract Task<IEnumerable<T>> InitViewModel<T>() where T:class;

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        /// <summary>
        ///  BaseHelperViewModel. 
        /// </summary>
        protected IRegionManager RegionManager;
        protected IDataServices DataServices;

        public BaseHelperViewModel(IDataServices dataServices, IRegionManager region, IEventManager eventManager)
        {
            ExitCommand = new DelegateCommand<object>(OnExitCommand);
            HelpCommand = new DelegateCommand(OnHelpCommand);
            SaveCommand = new DelegateCommand<object>(OnSaveCommand);
            DataServices = dataServices;
            RegionManager = region;
            EventManager = eventManager;
        }
        
    }
}
