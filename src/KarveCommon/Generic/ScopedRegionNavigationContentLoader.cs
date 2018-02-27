using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using KarveCommonInterfaces;
using Microsoft.Practices.ServiceLocation;
using Prism.Common;
using Prism.Regions;

namespace KarveCommon.Generic
{
    public class ScopedRegionNavigationContentLoader: IRegionNavigationContentLoader
    {
        public const string DefaultViewName = "ViewName";
        private readonly IServiceLocator serviceLocator;
        private HashSet<string> tabNames = new HashSet<string>(); 



        /// <summary>
        /// Initializes a new instance of the <see cref="RegionNavigationContentLoader"/> class with a service locator.
        /// </summary>
        /// <param name="serviceLocator">The service locator.</param>
        public ScopedRegionNavigationContentLoader(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        /// <summary>
        /// Gets the view to which the navigation request represented by <paramref name="navigationContext"/> applies.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="navigationContext">The context representing the navigation request.</param>
        /// <returns>
        /// The view to be the target of the navigation request.
        /// </returns>
        /// <remarks>
        /// If none of the views in the region can be the target of the navigation request, a new view
        /// is created and added to the region.
        /// </remarks>
        /// <exception cref="ArgumentException">when a new view cannot be created for the navigation request.</exception>
        public object LoadContent(IRegion region, NavigationContext navigationContext)
        {
            if (region == null) throw new ArgumentNullException("region");
            if (navigationContext == null) throw new ArgumentNullException("navigationContext");

            string candidateTargetContract = this.GetContractFromNavigationContext(navigationContext);

            var candidates = this.GetCandidatesFromRegion(region, candidateTargetContract);

            var acceptingCandidates =
                candidates.Where(
                    v =>
                    {
                        var navigationAware = v as INavigationAware;
                        if (navigationAware != null && !navigationAware.IsNavigationTarget(navigationContext))
                        {
                            return false;
                        }

                        var frameworkElement = v as FrameworkElement;
                        if (frameworkElement == null)
                        {
                            return true;
                        }

                        navigationAware = frameworkElement.DataContext as INavigationAware;

                        return navigationAware == null || navigationAware.IsNavigationTarget(navigationContext);
                    });

            var view = acceptingCandidates.FirstOrDefault();
            PropertyInfo currentProperty = null;
            string viewName = navigationContext.Parameters[DefaultViewName] as string;
            IViewsCollection collection = region.Views;
            bool oldView = false;
            if (view != null)
            {
                Type currentType = view.GetType();
                currentProperty = currentType.GetProperty("Header");
                if (currentProperty != null)
                {
                    string value = currentProperty.GetValue(view) as string;
                    if (value != null)
                    {
                        oldView = viewName == value;
                    }
                }
            }

            if (oldView)
            {
                return view;
            }

         
            Stopwatch valueStopwatch = new Stopwatch();
            valueStopwatch.Start();

            view = this.CreateNewRegionItem(candidateTargetContract);
            valueStopwatch.Stop();
            var milliseconds = valueStopwatch.ElapsedMilliseconds;

            if (!string.IsNullOrEmpty(viewName))
            {
                if (view != null)
                {
                    Type currentType = view.GetType();
                    
                    currentProperty = currentType.GetProperty("Header");
                    if (currentProperty != null)
                    {
                       currentProperty.SetValue(view, viewName);
                    }
                    PropertyInfo context = currentType.GetProperty("DataContext");
                    if (context != null)
                    {
                        var dataContext = context.GetValue(view);
                        PropertyInfo info = dataContext.GetType().GetProperty("Header");
                        if (info != null)
                        {
                            info.SetValue(dataContext, viewName);
                        }

                    }

                }
            }

            if (string.IsNullOrEmpty(viewName))
            {
                try
                {
                    region.Add(view);
                } catch (Exception e)
                {
                    Exception e2 = e.GetRootException();

                    MessageBox.Show(e.Message);
                    
                }
            }
            else
            {
             region.Add(view, viewName);
            }

            if (view is UserControl)
            {
              ((UserControl) view).Focus();
            }
           
            return view;
        }

        private bool CreateRegionManagerScope(object view)
        {
            bool createRegionManagerScope = false;

            var viewHasScopedRegions = view as ICreateRegionManagerScope;
            if (viewHasScopedRegions != null)
                createRegionManagerScope = viewHasScopedRegions.CreateRegionManagerScope;

            return createRegionManagerScope;
        }

        /// <summary>
        /// Provides a new item for the region based on the supplied candidate target contract name.
        /// </summary>
        /// <param name="candidateTargetContract">The target contract to build.</param>
        /// <returns>An instance of an item to put into the <see cref="IRegion"/>.</returns>
        protected virtual object CreateNewRegionItem(string candidateTargetContract)
        {
            object newRegionItem;
            try
            {           
                newRegionItem = this.serviceLocator.GetInstance<object>(candidateTargetContract);
            }
            catch (ActivationException e)
            {
                throw new InvalidOperationException(
                    string.Format(CultureInfo.CurrentCulture, "Cannot create navigation target", candidateTargetContract),
                    e);
            }
            return newRegionItem;
        }

        /// <summary>
        /// Returns the candidate TargetContract based on the <see cref="NavigationContext"/>.
        /// </summary>
        /// <param name="navigationContext">The navigation contract.</param>
        /// <returns>The candidate contract to seek within the <see cref="IRegion"/> and to use, if not found, when resolving from the container.</returns>
        protected virtual string GetContractFromNavigationContext(NavigationContext navigationContext)
        {
            if (navigationContext == null) throw new ArgumentNullException("navigationContext");

            var candidateTargetContract = UriParsingHelper.GetAbsolutePath(navigationContext.Uri);
            candidateTargetContract = candidateTargetContract.TrimStart('/');
            return candidateTargetContract;
        }

        /// <summary>
        /// Returns the set of candidates that may satisfiy this navigation request.
        /// </summary>
        /// <param name="region">The region containing items that may satisfy the navigation request.</param>
        /// <param name="candidateNavigationContract">The candidate navigation target as determined by <see cref="GetContractFromNavigationContext"/></param>
        /// <returns>An enumerable of candidate objects from the <see cref="IRegion"/></returns>
        protected virtual IEnumerable<object> GetCandidatesFromRegion(IRegion region, string candidateNavigationContract)
        {
            if (region == null) throw new ArgumentNullException("region");
            int numViews = region.Views.Count();

            return region.Views.Where(v =>
                string.Equals(v.GetType().Name, candidateNavigationContract, StringComparison.Ordinal) ||
                string.Equals(v.GetType().FullName, candidateNavigationContract, StringComparison.Ordinal));
        }
    }
}
