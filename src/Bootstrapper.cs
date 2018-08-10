using Microsoft.Practices.Unity;
using Prism.Unity;
using System.Windows;
using KarveCommon.Services;
using Prism.Modularity;
using KarveDataServices;
using Prism.Mvvm;
using Prism.Regions;
using KarveCommon.Generic;
using KarveCommonInterfaces;
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
using DataAccessLayer.Logic;
using AutoMapper;
using KarveCar.Navigation;

namespace KarveCar.Boot
{
    /// <summary>
    ///  This is the application bootstrapper. It is inside the KarveCar.Boot namespace in a 
    ///  way that we can use friendly assembly to inject things. 
    ///  
    /// </summary>
    class Bootstrapper : UnityBootstrapper
    {

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        /// This is a temporary bootstrapping service string connection string.
        // private const string ConnectionString = "EngineName=DBRENT_NET16;DataBaseName=DBRENT_NET16;Uid=cv;Pwd=1929""; ///Host=172.26.0.45;";
        private const string ConnectionString = "EngineName=DBRENT_NET16;DataBaseName=DBRENT_NET16;Uid=cv;Pwd=1929;Host=172.26.0.45:5225";

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
            var catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(ToolBarModule.ToolBarModule));
            catalog.AddModule(typeof(HelperModule.HelperModule));
            catalog.AddModule(typeof(MasterModule.MasterModule));
            catalog.AddModule(typeof(InvoiceModule.InvoiceModule));
            catalog.AddModule(typeof(BookingModule.BookingModule));
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
            logger.Debug("Starting to configure Prism Container");
            base.ConfigureContainer();
            try
            {
                Container.RegisterType<IRegionNavigationContentLoader, ScopedRegionNavigationContentLoader>(new ContainerControlledLifetimeManager());
                logger.Info("Configuring the user settings");
                // construct the user settings with db access.
                Container.RegisterType<IUserSettingsLoader, UserSettingsLoader>();
                Container.RegisterType<IUserSettingsSaver, UserSettingsSaver>();
                object[] settingLoaderSaver = new object[2];
                settingLoaderSaver[0] = Container.Resolve<UserSettingsLoader>();
                settingLoaderSaver[1] = Container.Resolve<UserSettingsSaver>();
                InjectionConstructor settingsConstructor = new InjectionConstructor(settingLoaderSaver);
                Container.RegisterType<IUserSettings, UserSettings>(new ContainerControlledLifetimeManager(), settingsConstructor);

                // The dal service is used to access to the database
                logger.Info("Resolving configuration container");
                object[] configExecutor = new object[1];
                configExecutor[0] = Container.Resolve<UserSettings>();
                var configManagerParam = new InjectionConstructor(configExecutor);
                Container.RegisterType<IConfigurationService, ConfigurationService>(new ContainerControlledLifetimeManager(), configManagerParam);
               
                // FIXME: this needs to be replaced with the user settings.
                string connParams = ConnectionString;
                object[] currentValue = new object[1];
                currentValue[0] = connParams;
                InjectionConstructor injectionConstructorDb = new InjectionConstructor(currentValue);
                Container.RegisterType<ISqlExecutor, OleDbExecutor>(new ContainerControlledLifetimeManager(), injectionConstructorDb);
                object[] values = new object[1];
                values[0] = Container.Resolve<ISqlExecutor>();
                TestDBConnection(values[0] as ISqlExecutor);
                InjectionConstructor injectionConstructor = new InjectionConstructor(values);
                logger.Info("Registering types in the dependency injection...");
                Container.RegisterType<IDataServices, DataServiceImplementation>(new ContainerControlledLifetimeManager(), injectionConstructor);
                Container.RegisterType<ICareKeeperService, CareKeeper>(new ContainerControlledLifetimeManager());
                Container.RegisterType<IRegionNavigationService, Prism.Regions.RegionNavigationService>();

                logger.Info("Registering line grid view...");
                Container.RegisterType<object, KarveControls.HeaderedWindow.HeaderedWindow>("HeaderedWindow");
                Container.RegisterType<object, KarveControls.HeaderedWindow.LineGridView>("LineGridView");
                // Event dispatcher implements the mediator pattern between view models.
                /* Every communication pass through the mediator since we want to design reusable viewmodel, 
                 * but dependencies between the potentially reusable pieces demonstrates 
                 * the "spaghetti code" phenomenon.
                 * Event Dispatcher implements group communication.
                 */
                logger.Info("Starting EventDispatcher...");
                Container.RegisterType<IEventManager, KarveCommon.Services.EventDispatcher>(new ContainerControlledLifetimeManager());

                /**
                 * Dialog Service provide a way to send or display modal message error within the MVVM pattern.
                 */
                logger.Info("Starting DialogService...");
                object[] containerValue = new object[1];
                containerValue[0] = Container.Resolve<IUnityContainer>();
                InjectionConstructor injectContainer = new InjectionConstructor(containerValue);

                Container.RegisterType<KarveCommonInterfaces.IDialogService, KarveCommon.DialogService.KarveDialogService>(new ContainerControlledLifetimeManager(), injectContainer);


                logger.Info("Registering intereaction views and view model...");

                /*
                 *  Interaction request controller is kind of dialog service, but with possibility to 
                 *  extend directly using xaml.
                 */
                object[] controllerInteractParam = new object[2];
                controllerInteractParam[0] = Container.Resolve<IUnityContainer>();
                controllerInteractParam[1] = Container.Resolve<IRegionManager>();
                InjectionConstructor controllerInteract = new InjectionConstructor(controllerInteractParam);

                Container.RegisterType<IInteractionRequestController, KarveControls.Interactivity.RequestController>(new ContainerControlledLifetimeManager(), controllerInteract);

                Container.RegisterType<KarveControls.Interactivity.Views.InteractionRequestView>();
                Container.RegisterType<KarveControls.Interactivity.ViewModels.InteractionRequestViewModel>();
                Container.RegisterType<KarveControls.Interactivity.ViewModels.InteractionMailViewModel>();
                Container.RegisterType<KarveControls.Interactivity.ViewModels.InteractionReportViewModel>();

                Container.RegisterType<KarveControls.Interactivity.Views.InteractionView>();
                Container.RegisterType<KarveControls.Interactivity.Views.MailView>();
                Container.RegisterType<KarveControls.Interactivity.Views.ReportView>();



                object[] navigatorInjectionValues = new object[4]
                {
                    Container.Resolve<IDataServices>(),
                    Container.Resolve<IRegionManager>(),
                    Container.Resolve<IEventManager>(),
                    Container.Resolve<IDialogService>()
                };
                InjectionConstructor navigatorInjection = new InjectionConstructor(navigatorInjectionValues);
                Container.RegisterType<IKarveNavigator, KarveNavigator>(new ContainerControlledLifetimeManager(),
                    navigatorInjection);
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
                    Container.Resolve<ProviderInfoView>();
                   Container.Resolve<CommissionAgentInfoView>();
                 //  Container.Resolve<ClientsInfoView>();
                //  Container.Resolve<VehicleInfoView>();
                //  Container.Resolve<DriverLicenseView>();
                   Container.Resolve<BookingModule.Views.BookingInfoView>();
                   Container.Resolve<KarveControls.HeaderedWindow.LineGridView>();
                   Container.Resolve<BookingModule.Views.BookingFooterView>();
               /*
                *  Here we use a datamapper. 
                *  Automapper maps all entities to data transfer objects.
                */
                IMapper mapper = MapperField.GetMapper();
            } catch (Exception e)
            {
                logger.Error("Error during bootstrap:" + e.Message);
                MessageBox.Show("Error during bootstrap" + e.Message);
            }
        }
    }
}
