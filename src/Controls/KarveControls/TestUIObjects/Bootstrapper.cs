using System;
using Microsoft.Practices.Unity;
using Prism.Unity;
using System.Windows;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using KarveCommon.Generic;
using System.Reflection;
using System.Globalization;
using NLog;
using KarveControls.Interactivity;
using TestUIComponents.TestingViewsModels;
using DataAccessLayer;
using DataAccessLayer.SQL;
using KarveDataServices;

namespace TestUIComponents
{    
        /// <summary>
        ///  This is the application bootstrapper. It is inside the KarveCar.Boot namespace in a 
        ///  way that we can use friendly assembly to inject things. 
        ///  
        /// </summary>
        class Bootstrapper : UnityBootstrapper
        {

        private const string ConnectionString = "EngineName=DBRENT_NET16;DataBaseName=DBRENT_NET16;Uid=cv;Pwd=1929;Host=172.26.0.45;";

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
            /// This is a temporary bootstrapping service string connection string.
            /// <summary>
            ///  This create a new Prism Shell
            /// </summary>
            /// <returns></returns>
            protected override DependencyObject CreateShell()
            {
                return Container.Resolve<TestMainWindow>();
            }

            /// <summary>
            ///  This method configure the catalog of the prism modules.
            ///  
            /// </summary>
            protected override void ConfigureModuleCatalog()
            {
                ModuleCatalog catalog = (ModuleCatalog)ModuleCatalog;
               // catalog.AddModule(typeof(InteractivityModule));

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
                /*
                 IUnityContainer unityContainer, IDataServices dataServices, IDialogService dialog, ISqlExecutor executor)
                 */

                string connParams = ConnectionString;
                object[] dbParams = new object[1];
                dbParams[0] = connParams;
                InjectionConstructor injectionConstructorDb = new InjectionConstructor(dbParams);
                Container.RegisterType<ISqlExecutor, OleDbExecutor>(new ContainerControlledLifetimeManager(), injectionConstructorDb);
                object[] values = new object[1];
                values[0] = Container.Resolve<ISqlExecutor>();
                InjectionConstructor injectionConstructor = new InjectionConstructor(values);
                logger.Debug("Registering types in the dependency injection...");
                Container.RegisterType<IDataServices, DataServiceImplementation>(new ContainerControlledLifetimeManager(), injectionConstructor);

                
                var currentValue = new object[3];
                ISqlExecutor sqlExecutor = new OleDbExecutor();
                IDataServices dataServices = new DataServiceImplementation(sqlExecutor);
                currentValue[0] = Container.Resolve<IUnityContainer>(); 
                currentValue[1] = Container.Resolve<IDataServices>(); 
                currentValue[2] = Container.Resolve<ISqlExecutor>();
                var requestControllerInjected = new object[1];
                requestControllerInjected[0] = Container;



                InjectionConstructor injectionContainer = new InjectionConstructor(requestControllerInjected);
                InjectionConstructor injectionIntoViewModel = new InjectionConstructor(currentValue);
               
                Container.RegisterType<RequestController>(new ContainerControlledLifetimeManager(), injectionContainer);
                Container.RegisterType<TestMainWindowViewModel>(injectionIntoViewModel);
                    // The dal service is used to access to the database
                    logger.Debug("Resolving configuration container");

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
                    var shell = Application.Current.MainWindow;
                    shell.DataContext = Container.Resolve<TestMainWindowViewModel>();
                    PropertyInfo info = shell.GetType().GetProperty("UnityContainer");
                    if (info != null)
                    {
                        info.SetValue(shell, Container);
                    }
                    shell.Show();
                   
                }
                catch (Exception e)
                {
                    logger.Error("Error during bootstrap:" + e.Message);
                    MessageBox.Show("Error during bootstrap" + e.Message);
                }
            }
        }
}
