using DataAccessLayer;
using KarveCar.Commands.Generic;
using KarveCar.Logic.Maestros;
using Prism.Mvvm;
using System.Linq;
using System.Windows.Input;
using static KarveCar.Model.Generic.RecopilatorioCollections;
using static KarveCommon.Generic.RecopilatorioEnumerations;

namespace KarveCar.ViewModel.MaestrosViewModel
{
    public class MostrarAuxiliaresViewModel : BindableBase
    {
        private MostrarAuxiliaresCommand mostrarauxiliarescommand;
        private IDalLocator dalLocator;

        public MostrarAuxiliaresViewModel()
        {
            this.mostrarauxiliarescommand = new MostrarAuxiliaresCommand(this);
            // TODO: this is temporary. The dal locator shall be injected by prism.
            dalLocator = DalLocator.GetInstance();
        }
        public MostrarAuxiliaresViewModel(IDalLocator loc)
        {
            this.mostrarauxiliarescommand = new MostrarAuxiliaresCommand(this);
            this.dalLocator = loc;
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