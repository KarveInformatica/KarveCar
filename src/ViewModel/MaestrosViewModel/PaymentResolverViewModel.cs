using DataAccessLayer;
using KarveCar.Logic.Generic;
using KarveCar.Model.Generic;
using KarveCommon.Generic;
using KarveCommon.Services;
using Microsoft.Practices.Unity;
using PaymentTypeModule;
using Prism.Commands;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static KarveCar.Model.Generic.RecopilatorioCollections;

namespace KarveCar.ViewModel.MaestrosViewModel
{
    public class PaymentResolverViewModel
    {
        #region Variables
        private DelegateCommand<object> _showPaymentCommand;
        #endregion

        #region Constructor
        public PaymentResolverViewModel()
        {
            this._showPaymentCommand = new DelegateCommand<object>(showPaymentCommand);
        }
        #endregion

        #region Commands
        public ICommand ShowPaymentCommand
        {
            get
            {
                return _showPaymentCommand;
            }
        }
        #endregion
        
        #region Métodos
        /// <summary>
        /// Crea el TabItem para CRUD los Grupos de Vehículos
        /// </summary>
        /// <param name="parameter"></param>
        ///         
        public void showPaymentCommand(object parameter)
        {
            /*
            * unfournately this is a tmeporary work around for passing Unity to the main windows and view models.
            * Until a concrete refactoring is ready. Each view own its viewmodel. The main windows has multiple view models.
            */
            var opcion = RecopilatorioEnumerations.EOpcion.rbtnFormasCobroClientes;
            View.MainWindow mainWindow = Application.Current.MainWindow as View.MainWindow;
            IUnityContainer container = mainWindow.UnityContainer;
            IPaymentView paymentView = container.Resolve<IPaymentView>();
            IDalLocator dalLocator = container.Resolve<IDalLocator>();
            IConfigurationService configurationService = container.Resolve<IConfigurationService>();
            ICareKeeperService careKeeperService = container.Resolve<ICareKeeperService>();
            IPaymentViewModule paymentViewModule = container.Resolve<IPaymentViewModule>();
            //= new ClientChargeViewModel(careKeeperService, dalLocator, configurationService);   
            UserControl view = paymentView as UserControl;
            view.DataContext = paymentViewModule;

            if (!ribbonbuttondictionary.ContainsKey(RecopilatorioEnumerations.EOpcion.rbtnFormasCobroClientes))
            {
                TemplateInfoRibbonButton ribbonTemplate = new TemplateInfoRibbonButton();
                ribbonTemplate.propertiesresources = "lrbtnFormasCobroClientes"; 
                ribbonbuttondictionary.Add(RecopilatorioEnumerations.EOpcion.rbtnFormasCobroClientes, ribbonTemplate);   
            }          
            //Si el param no se encuentra en la Enum EOpcion, no hace nada, sino mostraría 
            //la Tab correspondiente al primer valor de la Enum EOpcion
            if (opcion.ToString() == parameter.ToString())
            {
                TabItemLogic.CreateTabItemUserControlFromContainer(RecopilatorioEnumerations.EOpcion.rbtnFormasCobroClientes, paymentView);
            //    var obscollection = tabitemdictionary.Where(z => z.Key.ToString() == parameter.ToString()).FirstOrDefault().Value.GenericObsCollection;
            }
        }
        #endregion
    }
}
