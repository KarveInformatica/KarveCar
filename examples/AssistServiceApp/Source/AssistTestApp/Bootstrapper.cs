using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Windows;
using AssistModule;
using KarveCommonInterfaces;


namespace AssistTestApp
{
    class Bootstrapper: UnityBootstrapper
    {
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
            catalog.AddModule(typeof(AssistModule.AssistModule));       
        }
        /// <summary>
        ///  This method register global services provided to to the module.
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            try
            {
                // add container values
                object[] containerValue = new object[1];
                containerValue[0] = Container.Resolve<IUnityContainer>();
                InjectionConstructor injectContainer = new InjectionConstructor(containerValue);
                Container.RegisterType<IAssistService, AssistService>(new ContainerControlledLifetimeManager(), injectContainer);
                object[] assistValue = new object[1];
                assistValue[0] = Container.Resolve<IAssistService>();
                InjectionConstructor injectValue = new InjectionConstructor(assistValue);
                 Container.RegisterType< IAssistViewModel, AssistTestViewModel>(injectValue);       

                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error during the container configuration. KarveWin cannot start!", MessageBoxButton.OK);
            }
        }
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
        }
        protected override void InitializeShell()
        {
            // The main window and configuration services shall be injected just here 
            // because in the configure container are not yet available.

            try
            {

                var app = Application.Current.MainWindow as MainWindow;
                if (app != null)
                {
                    app.Container = Container;
                }
                Application.Current.MainWindow.Show();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error during bootstrap" + e.Message);
            }
        }
    }
}

