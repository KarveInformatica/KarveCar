using Microsoft.Practices.Unity;
using Prism.Unity;
using System.Windows;
using KarveCommon.Services;
using Prism.Modularity;
using KarveDataServices;
using Prism.Mvvm;
using Prism.Regions;
using KarveCommon.Generic;
using System.Reflection;
using System.Globalization;
using System;
using DataAccessLayer;
using DataAccessLayer.SQL;
using KarveCar.Views;
using MasterModule.Common;


namespace KarveCar
{
    class Bootstrapper : UnityBootstrapper
    {

        /// This is a temporary bootstrapping service string connection string.
        private const string ConnectionString = "EngineName=DBRENT_NET16;DataBaseName=DBRENT_NET16;Uid=cv;Pwd=1929;Host=172.26.0.45";
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
            catalog.AddModule(typeof(MasterModule.MasterModule));
            //catalog.AddModule(typeof(AgentsModule.AgentModule));
            catalog.AddModule(typeof(ToolBarModule.ToolBarModule));
          //  catalog.AddModule(typeof(PaymentTypeModule.PaymentTypeModule));
           
        }
        protected override IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        {
            IRegionBehaviorFactory behaviors = base.ConfigureDefaultRegionBehaviors();
            behaviors.AddIfMissing(RegionManagerBehavior.BehaviorKey, typeof(RegionManagerBehavior));
            return behaviors;
        }
        /// <summary>
        ///  This method register global services provided to to the module.
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            try
            {
                Container.RegisterType<IRegionNavigationContentLoader, ScopedRegionNavigationContentLoader>(new ContainerControlledLifetimeManager());
                // The dal service is used to access to the database


                Container.RegisterType<IConfigurationService, KarveCar.Logic.ConfigurationService>(new ContainerControlledLifetimeManager());
                string connParams = ConnectionString;
                object[] currentValue = new object[1];
                currentValue[0] = connParams;
                InjectionConstructor injectionConstructorDB = new InjectionConstructor(currentValue);
                Container.RegisterType<ISqlQueryExecutor, OleDbQueryExecutor>(new ContainerControlledLifetimeManager(), injectionConstructorDB);
                object[] values = new object[2];
                values[0] = Container.Resolve<ISqlQueryExecutor>();
                values[1] = Container.Resolve<IConfigurationService>();

                InjectionConstructor injectionConstructor = new InjectionConstructor(values);
                Container.RegisterType<IDataServices, DataServiceImplementation>(new ContainerControlledLifetimeManager(), injectionConstructor);
                Container.RegisterType<ICareKeeperService, CareKeeper>(new ContainerControlledLifetimeManager());
                Container.RegisterType<IRegionNavigationService, Prism.Regions.RegionNavigationService>();
                Container.RegisterType<IEventManager, KarveCommon.Services.EventDispatcher>(new ContainerControlledLifetimeManager());
                //Container.RegisterType(typeof(ViewModel.MaestrosViewModel.GrupoVehiculoViewModel), "GrupoVehiculoViewModel");
               
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error during the container configuration. KarveWin cannot start!", MessageBoxButton.OK);
            }
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
                IConfigurationService shell = Container.Resolve<IConfigurationService>();
                shell.Shell = Application.Current.MainWindow;
                KarveCar.Views.MainWindow window = Application.Current.MainWindow as KarveCar.Views.MainWindow;
                window.UnityContainer = Container;
                Application.Current.MainWindow.Show();
            } catch (Exception e)
            {
                MessageBox.Show("Error during bootstrap" + e.Message);
            }
        }
    }
}
