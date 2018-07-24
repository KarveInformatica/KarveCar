using KarveCommon.Generic;
using Prism.Regions;
using System;

namespace KarveCar.Navigation
{
    public class NavigateView
    {
        static public void Navigate(IRegionManager manager, string viewName)
        {
            Navigate(manager, string.Empty, string.Empty, viewName);
        }
        static public void Navigate(IRegionManager manager, string code, string tabName, string viewName)
        {
            var navigationParameters = new NavigationParameters
            {
                {"id", code},
                {ScopedRegionNavigationContentLoader.DefaultViewName, tabName}
            };
            string navigationUri = string.Empty;
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(tabName))
            {
                navigationUri = viewName;
            }
            else
            {
                navigationUri = viewName + navigationParameters;
            }
            var uri = new Uri(navigationUri, UriKind.Relative);
            manager.RequestNavigate(RegionNames.TabRegion, uri);
        }
    }
}
