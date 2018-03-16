using System.Windows.Interactivity;
using System.Windows;
using Syncfusion.Windows.Tools.Controls;
using Prism.Regions;
using System;
using System.Reflection;

namespace KarveCar.Behaviour
{

    public class TabItemBehaviour : Behavior<TabControlExt>
    {

      
        public TabItemBehaviour() : base()
        {
           
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.TabClosed += AssociatedObject_TabClosed;
          
        }

        

        private void AssociatedObject_TabClosed(object sender, CloseTabEventArgs e)
        {
            IRegion region = RegionManager.GetObservableRegion(this.AssociatedObject).Value;
            if (region == null)
                return;
            if (e.ClosingTabItems != null)
            {
                foreach (var tabItem in e.ClosingTabItems)
                {
                    TabItemExt tabExt = tabItem as TabItemExt;
                    if (tabExt != null)
                    {
                        RemoveItemFromRegion(tabExt.Content, region);
                    }
                }
            }
            else if (e.TargetTabItem!=null)
            {
                TabItemExt tabExt = e.TargetTabItem as TabItemExt;
                if (tabExt != null)
                {
                    RemoveItemFromRegion(tabExt.Content, region);
                }
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.TabClosed -= AssociatedObject_TabClosed;
            base.OnDetaching();
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
                if (frameworkElement != null)
                {
                    var viewModel = frameworkElement.DataContext;
                    Type viewModelType = viewModel.GetType();
                    MethodInfo methodInfo = viewModelType.GetMethod("DisposeEvents");
                    if (methodInfo != null)
                    {
                        methodInfo.Invoke(viewModel, null);
                    }
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

       

    }

}