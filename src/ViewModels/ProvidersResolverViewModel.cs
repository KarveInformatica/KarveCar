using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using KarveCar.Model.Generic;
using KarveCommon.Generic;
using KarveCommon.Logic.Generic;
using MasterModule.Interfaces;
using MasterModule.Views;
using Microsoft.Practices.Unity;
using Prism.Commands;

namespace KarveCar.ViewModels
{
    class ProvidersResolverViewModel
    {
        #region Variables
        private DelegateCommand<object> _showProvidersCommand;
        #endregion

        Stopwatch start = new Stopwatch();

        #region Constructor

        public ProvidersResolverViewModel()
        {
            start.Start();
            this._showProvidersCommand = new DelegateCommand<object>(showProvidersCommand);
        }

        #endregion

        #region Commands
        public ICommand ShowProvidersCommand
        {

            get
            {
                return _showProvidersCommand;
            }

        }
        #endregion

        #region Métodos
        /// <summary>
        /// Crea el TabItem para los provveedores
        /// </summary>
        /// <param name="parameter"></param>
        ///         
        public void showProvidersCommand(object parameter)
        {
            /*
            * unfournately this is a tmeporary work around for passing Unity to the main windows and view models.
            * Until a concrete refactoring is ready. Each view own its viewmodel. The main windows has multiple view models.
            */
            RecopilatorioEnumerations.EOpcion opcion = RecopilatorioEnumerations.EOpcion.rbtnProveedores;
            Views.MainWindow mainWindow = Application.Current.MainWindow as Views.MainWindow;
           // start.Start();

            IUnityContainer container = mainWindow.UnityContainer;
            IProvidersView providerView= container.Resolve<IProvidersView>();
     
            //  IProvidersViewModel providerViewModule = container.Resolve<IProvidersViewModel>();
            ProvidersControl view = providerView as ProvidersControl;
         //   view.DataContext = providerViewModule;

            if (!RecopilatorioCollections.ribbonbuttondictionary.ContainsKey(opcion))
            {
                TemplateInfoRibbonButton ribbonTemplate = new TemplateInfoRibbonButton();
                ribbonTemplate.propertiesresources = "lrbtnProveedores";
                RecopilatorioCollections.ribbonbuttondictionary.Add(opcion, ribbonTemplate);
            }
            //Si el param no se encuentra en la Enum EOpcion, no hace nada, sino mostraría 
            //la Tab correspondiente al primer valor de la Enum EOpcion
            if (opcion.ToString() == parameter.ToString())
            {
                TabItemLogic.CreateTabItemUserControl(opcion, providerView);
              //  providerViewModule.Navigate("SupplierView");
            }
           start.Stop();
          //  MessageBox.Show(string.Format("{0}", start.ElapsedMilliseconds));

        }
        #endregion
    }

}
