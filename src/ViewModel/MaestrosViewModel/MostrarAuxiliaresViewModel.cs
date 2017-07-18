using KarveCar.Commands.Generic;
using KarveCar.Logic.Maestros;
using KarveCar.Model.Generic;
using System.Linq;
using System.Windows.Input;
using KarveCommon.Generic;
using static KarveCar.Model.Generic.RecopilatorioCollections;
using static KarveCar.Model.Generic.RecopilatorioEnumerations;

namespace KarveCar.ViewModel.MaestrosViewModel
{
    public class MostrarAuxiliaresViewModel : GenericPropertyChanged
    {
        private MostrarAuxiliaresCommand mostrarauxiliarescommand;

        public MostrarAuxiliaresViewModel()
        {
            this.mostrarauxiliarescommand = new MostrarAuxiliaresCommand(this);
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