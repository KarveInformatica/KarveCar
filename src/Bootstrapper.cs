using Microsoft.Practices.Unity;
using Prism.Unity;
using System.Windows;
using DataAccessLayer;
using KarveCar.View;
using KarveCommon.Services;
using Prism.Modularity;

namespace KarveCar
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void ConfigureModuleCatalog()
        {
            ModuleCatalog catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(ToolBarModule.ToolBarModule));
        }

        /// <summary>
        ///  This register a services.
        /// </summary>
        protected override void ConfigureContainer()
        {
            Container.RegisterType<IDalLocator, DalLocator>();
            Container.RegisterType<ICareKeeperService, CareKeeper>();
            base.ConfigureContainer();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
    }

}
