using System.Windows.Controls;
using System.Windows.Input;
using KarveCar.Logic.Generic;
using KarveCar.Model.Generic;
using KarveCommon.Generic;
using Microsoft.Practices.Unity;
using PaymentTypeModule;
using Prism.Commands;
using System.Windows;
using ProvidersModule;
using static KarveCar.Model.Generic.RecopilatorioCollections;
using static KarveCommon.Generic.RecopilatorioEnumerations;
using ProvidersModule.Views;
using KarveCommon.Logic.Generic;

namespace KarveCar.ViewModel.MaestrosViewModel
{
    class ProvidersResolverViewModel
    {
        #region Variables
        private DelegateCommand<object> _showProvidersCommand;
        #endregion

        #region Constructor

        public ProvidersResolverViewModel()
        {
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
            var opcion = RecopilatorioEnumerations.EOpcion.rbtnProveedores;
            View.MainWindow mainWindow = Application.Current.MainWindow as View.MainWindow;
            IUnityContainer container = mainWindow.UnityContainer;
            IProvidersView providerView= container.Resolve<IProvidersView>();
            IProvidersViewModel providerViewModule = container.Resolve<IProvidersViewModel>();
            ProvidersControl view = providerView as ProvidersControl;
            view.DataContext = providerViewModule;

            if (!ribbonbuttondictionary.ContainsKey(RecopilatorioEnumerations.EOpcion.rbtnProveedores))
            {
                TemplateInfoRibbonButton ribbonTemplate = new TemplateInfoRibbonButton();
                ribbonTemplate.propertiesresources = "lrbtnProveedores";
                ribbonbuttondictionary.Add(RecopilatorioEnumerations.EOpcion.rbtnProveedores, ribbonTemplate);
            }
            //Si el param no se encuentra en la Enum EOpcion, no hace nada, sino mostraría 
            //la Tab correspondiente al primer valor de la Enum EOpcion
            if (opcion.ToString() == parameter.ToString())
            {
                TabItemLogic.CreateTabItemUserControlFromContainer(RecopilatorioEnumerations.EOpcion.rbtnProveedores, providerView);
              //  providerViewModule.Navigate("SupplierView");
            }
        }
        #endregion
    }

}
