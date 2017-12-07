using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataAccessLayer;
using DataAccessLayer.SQL;
using KarveCar.Views;
using KarveCommon.Services;
using KarveDataServices;
using MasterModule.Common;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Unity;

namespace KarveTest
{
    /**/

    class TestBootStrapper : UnityBootstrapper
    {

        /// This is a temporary bootstrapping service string connection string.
        private const string ConnectionString = "EngineName=DBRENT_NET16;DataBaseName=DBRENT_NET16;Uid=cv;Pwd=1929;Host=172.26.0.45";
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
                PropertyInfo info = shell.Shell.GetType().GetProperty("UnityContainer");
                if (info != null)
                {
                    info.SetValue(shell.Shell, Container);
                }
            
            }
            catch (Exception e)
            {
                MessageBox.Show("Error during bootstrap" + e.Message);
            }
        }
    }

}
