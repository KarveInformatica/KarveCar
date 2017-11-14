using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Dragablz;
using KarveCommon.Generic;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Prism.Regions;

namespace KarveCar.ViewModels
{
    public class MainWindowViewModel
    {
        private readonly IRegionManager _regionManager;
        private IUnityContainer _container;
        private const string _title = "KarveWin 0.9";

        public DelegateCommand<string> NavigateCommand { get; set; }
      
        public string Title
        {
            get { return _title; }
        }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        public MainWindowViewModel(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(Navigate);

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
            //var viewModel = args.DragablzItem.DataContext as HeaderedItemViewModel;
            //Debug.Assert(viewModel != null);

            var tabItem = args.DragablzItem;

            var tabControl = FindParent<TabControl>(tabItem);
            if (tabControl == null)
                return;

               IRegion region = RegionManager.GetObservableRegion(tabControl).Value;
              if (region == null)
                return;
            IViewsCollection collection =  region.ActiveViews;
            object currentView = null;
            foreach (var v in collection)
            {
                currentView = v;
                
            }
            if (currentView != null)
            {
              
                PropertyInfo parameterInfo =currentView.GetType().GetProperty("Header");
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
            get { IInterTabClient tabClient = new KarveInterTabClient();
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
                if (navigationAwareDataContext != null)
                {
                    navigationAwareDataContext.OnNavigatedFrom(navigationContext);
                }
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
        // TODO: implement a set language support.
        public void SetLanguages(object parameter)
        {
            
        }
    }

}
