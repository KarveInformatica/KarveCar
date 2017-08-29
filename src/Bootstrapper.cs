using Microsoft.Practices.Unity;
using Prism.Unity;
using System.Windows;
using DataAccessLayer;
using KarveCar.View;
using KarveCommon.Services;
using Prism.Modularity;
using KarveDataServices;
using Prism.Mvvm;
using Prism.Regions;
using KarveCommon.Generic;
using System.Reflection;
using System.Globalization;
using System;

namespace KarveCar
{
    class Bootstrapper : UnityBootstrapper
    {
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
            catalog.AddModule(typeof(ProvidersModule.ProviderModule));
            catalog.AddModule(typeof(ToolBarModule.ToolBarModule));
            catalog.AddModule(typeof(PaymentTypeModule.PaymentTypeModule));
           
        }

        /// <summary>
        ///  This method register global services provided to to the module.
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            // The dal service is used to access to the database
            Container.RegisterType<IKarveDataMapper, DataAccessLayer.BaseDataMapper>(new ContainerControlledLifetimeManager());
            object[] values = new object[1];
            values[0] = Container.Resolve<IKarveDataMapper>();
            InjectionConstructor injectionConstructor = new InjectionConstructor(values);
            Container.RegisterType<IDataServices, DataServiceImplementation>(new ContainerControlledLifetimeManager(), injectionConstructor);
            Container.RegisterType<ICareKeeperService, CareKeeper>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IRegionNavigationService, Prism.Regions.RegionNavigationService>();
            Container.RegisterType<IEventManager, KarveCommon.Services.EventManager>(new ContainerControlledLifetimeManager());



        }
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(x =>
            {
                var viewName = x.FullName;
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


                object[] values = new object[1];
                values[0] = Application.Current.MainWindow;
                InjectionConstructor injectionConstructor = new InjectionConstructor(values);
                Container.RegisterType<IConfigurationService, KarveCar.Logic.ConfigurationService>(new ContainerControlledLifetimeManager(),injectionConstructor);

                /*
                 * unfournately this is a tmeporary work around for passing Unity to the main windows and view models.
                 * Until a concrete refactoring is ready. Each view own its viewmodel. The main windows has multiple view models.
                 */
                KarveCar.View.MainWindow window = Application.Current.MainWindow as KarveCar.View.MainWindow;
                window.UnityContainer = Container;

                Application.Current.MainWindow.Show();
            } catch (Exception e)
            {
                MessageBox.Show("Error");
            }
        }
    }
}
