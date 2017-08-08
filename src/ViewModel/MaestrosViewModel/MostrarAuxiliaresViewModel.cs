using KarveCar.Commands.Generic;
using KarveCar.Logic.Maestros;
using Microsoft.Practices.Unity;
using Prism.Mvvm;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using static KarveCar.Model.Generic.RecopilatorioCollections;
using static KarveCommon.Generic.RecopilatorioEnumerations;

namespace KarveCar.ViewModel.MaestrosViewModel
{
    public class MostrarAuxiliaresViewModel : BindableBase
    {
        private MostrarAuxiliaresCommand mostrarauxiliarescommand;
        private IUnityContainer _unityContainer;

        public MostrarAuxiliaresViewModel()
        {
            this.mostrarauxiliarescommand = new MostrarAuxiliaresCommand(this);
            // TODO: this is temporary. Unity shall be injected 
            KarveCar.View.MainWindow window = Application.Current.MainWindow as KarveCar.View.MainWindow;
            this._unityContainer = window.UnityContainer;
            
        }
        public ICommand MostrarAuxCommand
        {
            get
            {
                return mostrarauxiliarescommand;
            }
        }
 
        /// <summary>
        /// Añade/pone foco en la Tab correspondiente según el param recibido desde el xaml, del cual se recupera su EOpcion
        /// </summary>
        /// <param name="parameter"></param>
        public void MostrarAuxiliares(object parameter)
        {
            EOpcion opcion = ribbonbuttondictionary.Where(z => z.Key.ToString() == parameter.ToString()).FirstOrDefault().Key;
            //Si el param no se encuentra en la Enum EOpcion, no hace nada, sino mostraría 
            //la Tab correspondiente al primer valor de la Enum EOpcion
            if (opcion.ToString() == parameter.ToString())
            {
                MaestrosAuxiliaresLogic.PrepareTabItemDataGrid(opcion);
            }           
        }
    }
} 