using KarveCar.Commands.Generic;
using KarveCar.Logic.Maestros;
using Microsoft.Practices.Unity;
using Prism.Mvvm;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static KarveCar.Model.Generic.RecopilatorioCollections;
using static KarveCommon.Generic.RecopilatorioEnumerations;

namespace KarveCar.ViewModel.MaestrosViewModel
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
            EOpcion opcion = ribbonbuttondictionary.FirstOrDefault(z => z.Key.ToString() == parameter.ToString()).Key;
            //Si el param no se encuentra en la Enum EOpcion, no hace nada, sino mostraría 
            //la Tab correspondiente al primer valor de la Enum EOpcion
            if (opcion.ToString() == parameter.ToString())
            {
                await MaestrosAuxiliaresLogic.PrepareTabItemDataGrid(opcion);
            }           
        }
    }
} 