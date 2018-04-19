using System;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Dragablz;
using KarveCommon.Generic;
using KarveCommon.Services;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Regions;
using Prism.Mvvm;

namespace KarveCar.ViewModels
{
    public class MainWindowViewModel: BindableBase
    {
        private readonly IRegionManager _regionManager;
        private IUnityContainer _container;
        private string _title = "KarveWin 0.9 - Beta" + DateTime.Now.ToString(); 
        /// <summary>
        ///  servicio de configuracion.
        /// </summary>
        private IConfigurationService _configurationService;

        /// <summary>
        ///  CultureSwitcher 
        /// </summary>
        private CultureSwitcher _cultureSwitch;
        private ObjectDataProvider _objectDataProvider=new ObjectDataProvider();
        private string _currentDay;
        private string _subSystem;

        /// <summary>
        ///  NavigateCommand, This is the command for navigation
        /// </summary>
        public DelegateCommand<string> NavigateCommand { get; set; }
        /// <summary>
        ///  This support the change of language in the application.
        /// Some work
        /// </summary>
        public ICommand ChangeLanguageCommand { get; set; }
        /// <summary>
        ///  This command close the main window.
        /// </summary>
        public ICommand CloseWindowCommand { set; get; }

        public string Title
        {
            get { return _title; }
        }

        public string CurrentDay
        {
            get
            {
                return _currentDay;
            }
            set
            {
                _currentDay = value;
                RaisePropertyChanged();
            }
        }
        public string Subsystem
        {
            get
            {
                return _subSystem;
            }
            set
            {
                _subSystem = value;
                RaisePropertyChanged();
            }
        }
           /// <summary>
    ///  This is the main v
    /// </summary>
    /// <param name="regionManager"></param>
    public MainWindowViewModel(IRegionManager regionManager, IConfigurationService service, IEventManager eventManager)
        {
            _regionManager = regionManager;
            _configurationService = service;
            // culture switch has the single resposabilty to change the culture.
            _cultureSwitch = new CultureSwitcher(_configurationService, eventManager);
            NavigateCommand = new DelegateCommand<string>(Navigate);
            ChangeLanguageCommand = new DelegateCommand<object>(SetLanguages);
            CloseWindowCommand = new DelegateCommand(OnCloseMainWindow);
        }

        private void OnCloseMainWindow()
        {
            _configurationService.CloseApplication();
        }

        public MainWindowViewModel(IUnityContainer container, IRegionManager regionManager, IConfigurationService configurationService, IEventManager eventManager)
        {
            _container = container;
            _regionManager = regionManager;
            _configurationService = configurationService;
            _cultureSwitch = new CultureSwitcher(_configurationService, eventManager);
            NavigateCommand = new DelegateCommand<string>(Navigate);
            ChangeLanguageCommand = new DelegateCommand<object>(SetLanguages);
            CurrentDay = DateTime.Now.DayOfWeek+ " "+ DateTime.Now.ToShortDateString();
        }


        void InitVModel()
        {
           
           // _cultureSwitch.ChangeLanguageCommand(_configurationService.GetUserSettings().UserSettingsLoader.GetCurrentLocale(0))
        }
        void Navigate(string navigationPath)
        {
            _regionManager.RequestNavigate("TabRegion", navigationPath);
        }

        public ItemActionCallback ClosingTabItemHandler
        {
            get { return ClosingTabItemHandlerImpl; }
        }



        
        /// <summary>
        /// Callback to handle tab closing.
        /// </summary>        
        private void ClosingTabItemHandlerImpl(ItemActionCallbackArgs<TabablzControl> args)
        {
            //in here you can dispose stuff or cancel the close

            //here's your view model:
            var view =  args.DragablzItem.DataContext as UserControl;
            if (view != null)
            {
                var viewModel = view.DataContext;
                Type viewModelType = viewModel.GetType();
                MethodInfo methodInfo = viewModelType.GetMethod("DisposeEvents");
                if (methodInfo != null)
                {
                    methodInfo.Invoke(viewModel, null);
                }
            }

            var tabItem = args.DragablzItem;

            var tabControl = FindParent<TabControl>(tabItem);
            if (tabControl == null)
                return;

            IRegion region = RegionManager.GetObservableRegion(tabControl).Value;
            if (region == null)
                return;
            IViewsCollection collection = region.ActiveViews;
            object currentView = null;
            foreach (var v in collection)
            {
                currentView = v;

            }
            if (currentView != null)
            {

                PropertyInfo parameterInfo = currentView.GetType().GetProperty("Header");
                if (parameterInfo != null)
                {
                    string headerName = parameterInfo.GetValue(currentView, null) as string;
                    string name = args.DragablzItem.Content as string;
                    if (name != null)
                    {
                        if (headerName == args.DragablzItem.Content.ToString())
                        {
                            RemoveItemFromRegion(currentView, region);
      

                        }
                    }
                }
            }
          
            //here's how you can cancel stuff:
            //args.Cancel(); 
        }

        public IInterTabClient CustomInterTabClient
        {
            get
            {
                IInterTabClient tabClient = new KarveInterTabClient();
                return tabClient;
            }
        }

        void RemoveItemFromRegion(object item, IRegion region)
        {
            var navigationContext = new NavigationContext(region.NavigationService, null);
            if (CanRemove(item, navigationContext))
            {
                InvokeOnNavigatedFrom(item, navigationContext);
                region.Remove(item);
                
            }
        }

        void InvokeOnNavigatedFrom(object item, NavigationContext navigationContext)
        {
            var navigationAwareItem = item as INavigationAware;
            if (navigationAwareItem != null)
                navigationAwareItem.OnNavigatedFrom(navigationContext);

            var frameworkElement = item as FrameworkElement;
            if (frameworkElement != null)
            {
                INavigationAware navigationAwareDataContext = frameworkElement.DataContext as INavigationAware;
                navigationAwareDataContext?.OnNavigatedFrom(navigationContext);
                
            }
        }

        bool CanRemove(object item, NavigationContext navigationContext)
        {
            bool canRemove = true;

            var confirmRequestItem = item as IConfirmNavigationRequest;
            if (confirmRequestItem != null)
            {
                confirmRequestItem.ConfirmNavigationRequest(navigationContext, result =>
                {
                    canRemove = result;
                });
            }

            var frameworkElement = item as FrameworkElement;
            if (frameworkElement != null && canRemove)
            {
                IConfirmNavigationRequest confirmRequestDataContext = frameworkElement.DataContext as IConfirmNavigationRequest;
                if (confirmRequestDataContext != null)
                {
                    confirmRequestDataContext.ConfirmNavigationRequest(navigationContext, result =>
                    {
                        canRemove = result;
                    });
                }
            }

            return canRemove;
        }

        static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null)
                return null;

            var parent = parentObject as T;
            if (parent != null)
                return parent;

            return FindParent<T>(parentObject);
        }

        /// <summary>
        /// Devuelve el ObjectDataProvider en uso.
        /// </summary>
        public ObjectDataProvider ObjectDataProvider
        {
            get
            {
                return _objectDataProvider;
            }
           
        }
        
        /// <summary>
        /// Devuelve el ObjectDataProvider en uso
        /// </summary>
        public void SetLanguages(object parameter)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(parameter.ToString());
            _cultureSwitch.Execute(Thread.CurrentThread.CurrentUICulture);

            //ChangeCulture(Thread.CurrentThread.CurrentUICulture);
        }
    }

}
