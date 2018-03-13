using System;
using Prism.Unity;
using System.Windows;
using Prism.Mvvm;
using System.Reflection;
using Prism.Modularity;
using Prism.Regions;
using Microsoft.Practices.Unity;
using System.Globalization;

namespace NavigationDrawerExercise
{
    /// <summary>
    ///  This is the application bootstrapper. It is inside the KarveCar.Boot namespace in a 
    ///  way that we can use friendly assembly to inject things. 
    ///  
    /// </summary>
    class Bootstrapper : UnityBootstrapper
    {
        public object RegionManagerBehavior { get; private set; }

        /// This is a temporary bootstrapping service string connection string.
        /// <summary>
        ///  This create a new Prism Shell
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
        /// <summary>
        ///  This method configure the catalog of the prism modules.
        ///  
        /// </summary>
        protected override void ConfigureModuleCatalog()
        {
            ModuleCatalog catalog = (ModuleCatalog)ModuleCatalog;
         
            //            catalog.AddModule(typeof(CarModelModule.CarModelModule));
            // catalog.AddModule(typeof(NavigationBarM.TreeViewModule));
        }
        protected override IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        {
            IRegionBehaviorFactory behaviors = base.ConfigureDefaultRegionBehaviors();
           // behaviors.AddIfMissing(RegionManagerBehavior.BehaviorKey, typeof(RegionManagerBehavior));
            return behaviors;
        }
        /// <summary>
        ///  This method register global services provided to to the module.
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
         
        }
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(x =>
            {

                var viewName = string.IsNullOrEmpty(x.FullName) ? "" : x.FullName;
                viewName = viewName.Replace(".Views.", ".ViewModels.");
                var viewAssemblyName = x.GetTypeInfo().Assembly.FullName;
                var suffix = viewName.EndsWith("View") ? "Model" : "ViewModel";
                var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}{1}, {2}", viewName, suffix, viewAssemblyName);
                return Type.GetType(viewModelName);
            });
            ViewModelLocationProvider.SetDefaultViewModelFactory(type => Container.Resolve(type));

        }


        protected override void InitializeShell()
        {
            // The main window and configuration services shall be injected just here 
            // because in the configure container are not yet available.

            try
            {
                
                Application.Current.MainWindow.Show();
            }
            catch (Exception e)
            {
                
            }
        }
    }

    
}
