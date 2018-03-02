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
using DataAccessLayer.SQL;
using KarveCar.Logic.Generic;
using KarveCar.Views;
using NLog;
using System.Data;
using MasterModule.Views;
using DataAccessLayer;

namespace KarveCar.Boot
{
    /// <summary>
    ///  This is the application bootstrapper. It is inside the KarveCar.Boot namespace in a 
    ///  way that we can use friendly assembly to inject things. 
    /// </summary>
    class Bootstrapper : UnityBootstrapper
    {

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
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

        private void TestDBConnection(ISqlExecutor executor)
        {
            if (executor == null)
            {
                return;
            }
            logger.Info("Testing connection string");
            IDbConnection conn = null;
            try
            {
                conn = executor.OpenNewDbConnection();
            
            }
            catch (Exception e)
            {
                MessageBox.Show("Database connection failed: " + e.Message);
            }
            finally
            {
                conn?.Close();
                conn?.Dispose();
            }
        }
        /// <summary>
        ///  This method configure the catalog of the prism modules.
        ///  
        /// </summary>
        protected override void ConfigureModuleCatalog()
        {
            ModuleCatalog catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(ToolBarModule.ToolBarModule));
            catalog.AddModule(typeof(HelperModule.HelperModule));
            catalog.AddModule(typeof(MasterModule.MasterModule));
           // catalog.AddModule(typeof(NavigationBarM.TreeViewModule));
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
            logger.Debug("Configure Prism Container");
            base.ConfigureContainer();
            try
            {
                Container.RegisterType<IRegionNavigationContentLoader, ScopedRegionNavigationContentLoader>(new ContainerControlledLifetimeManager());
                // The dal service is used to access to the database
                logger.Debug("Resolving configuration container");
                Container.RegisterType<IUserSettingsLoader,UserSettingsLoader>();
                Container.RegisterType<IUserSettingsSaver,UserSettingsSaver>();
                Container.RegisterType<IUserSettings, UserSettings>(new ContainerControlledLifetimeManager());
                Container.RegisterType<IConfigurationService, ConfigurationService>(new ContainerControlledLifetimeManager());
                string connParams = ConnectionString;
                object[] currentValue = new object[1];
                currentValue[0] = connParams;
                InjectionConstructor injectionConstructorDb = new InjectionConstructor(currentValue);
                Container.RegisterType<ISqlExecutor, OleDbExecutor>(new ContainerControlledLifetimeManager(), injectionConstructorDb);
                object[] values = new object[1];
                values[0] = Container.Resolve<ISqlExecutor>();
                TestDBConnection(values[0] as ISqlExecutor);
                InjectionConstructor injectionConstructor = new InjectionConstructor(values);
                logger.Debug("Registering types in the dependency injection");
                Container.RegisterType<IDataServices, DataServiceImplementation>(new ContainerControlledLifetimeManager(), injectionConstructor);
                Container.RegisterType<ICareKeeperService, CareKeeper>(new ContainerControlledLifetimeManager());
                Container.RegisterType<IRegionNavigationService, Prism.Regions.RegionNavigationService>();
                // Event dispatcher is the resposible for the mediator between view models.
                Container.RegisterType<IEventManager, KarveCommon.Services.EventDispatcher>(new ContainerControlledLifetimeManager());
              
               
            }
            catch (Exception e)
            {
                logger.Error("Error during the container configuration. KarveWin cannot start! Reason:" + e.Message);
                MessageBox.Show(e.Message, "Error during the container configuration. KarveWin cannot start!", MessageBoxButton.OK);
            }
        }
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(x =>
            {
                
                var viewName = string.IsNullOrEmpty(x.FullName) ? "": x.FullName;
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
                PropertyInfo info = shell.Shell.GetType().GetProperty("UnityContainer");
                if (info != null)
                {
                    info.SetValue(shell.Shell, Container);
                }
                Application.Current.MainWindow.Show();
                // we preload some heavy modules.
                // this is a trick to speed up further creations and load prism.
                Container.Resolve<ClientsInfoView>();
                Container.Resolve<VehicleInfoView>();
            } catch (Exception e)
            {
                logger.Error("Error during bootstrap:" + e.Message);
                MessageBox.Show("Error during bootstrap" + e.Message);
            }
        }
    }
}
