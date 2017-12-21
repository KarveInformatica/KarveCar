using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using KarveCar.Commands.Generic;
using KarveCar.Logic.Maestros;
using KarveCar.Model.Generic;
using KarveCommon.Generic;
using Prism.Mvvm;

namespace KarveCar.ViewModels
{
    public class MostrarAuxiliaresViewModel : BindableBase
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
        public async Task MostrarAuxiliares(object parameter)
        {
            Enumerations.EOpcion opcion = RecopilatorioCollections.ribbonbuttondictionary.FirstOrDefault(z => z.Key.ToString() == parameter.ToString()).Key;
            //Si el param no se encuentra en la Enum EOpcion, no hace nada, sino mostraría 
            //la Tab correspondiente al primer valor de la Enum EOpcion
            if (opcion.ToString() == parameter.ToString())
            {
                await MaestrosAuxiliaresLogic.PrepareTabItemDataGrid(opcion);
            }           
        }
    }
} 