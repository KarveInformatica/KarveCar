using Microsoft.Practices.Unity;
using Prism.Unity;
using System.Windows;
using DataAccessLayer;
using KarveCar.View;
using KarveCommon.Services;
using Prism.Modularity;
using KarveDataServices;
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
            catalog.AddModule(typeof(ToolBarModule.ToolBarModule));
            catalog.AddModule(typeof(PaymentTypeModule.PaymentTypeModule));
            catalog.AddModule(typeof(ProvidersModule.ProviderModule));
        }

        /// <summary>
        ///  This method register global services provided to to the module.
        /// </summary>
        protected override void ConfigureContainer()
        {
            // The dal service is used to access to the database
            Container.RegisterType<IDataServices, DataServiceImplementation>(new ContainerControlledLifetimeManager());
            // The carekeeper or undo service is used to store the last action and do/redo an action
            Container.RegisterType<ICareKeeperService, CareKeeper>(new ContainerControlledLifetimeManager());
            // the configuraion service is used to do all the global actions: saving the app config, exiting, etc.
            base.ConfigureContainer();
        }

        protected override void InitializeShell()
        {
            // The main window and configuration services shall be injected just here 
            // because in the configure container are not yet available.
            object[] values = new object[1];
            values[0] = Application.Current.MainWindow;
            InjectionConstructor injectionConstructor = new InjectionConstructor(values);
            Container.RegisterType<IConfigurationService, ConfigurationService>(injectionConstructor);

            /*
             * unfournately this is a tmeporary work around for passing Unity to the main windows and view models.
             * Until a concrete refactoring is ready. Each view own its viewmodel. The main windows has multiple view models.
             */
            KarveCar.View.MainWindow window = Application.Current.MainWindow as KarveCar.View.MainWindow;
            window.UnityContainer = Container;

            Application.Current.MainWindow.Show();
        }
    }
}
