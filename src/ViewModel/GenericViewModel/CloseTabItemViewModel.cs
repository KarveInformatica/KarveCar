using KarveCar.Commands.Generic;
using KarveCar.Logic.Generic;
using KarveCommon.Generic;
using System.Linq;
using System.Windows.Input;
using static KarveCar.Model.Generic.RecopilatorioCollections;

namespace KarveCar.ViewModel.GenericViewModel
{
    public class CloseTabItemViewModel : GenericPropertyChanged
    {
        private CloseTabItemCommand closetabitemcommand;

        public CloseTabItemViewModel()
        {
            this.closetabitemcommand = new CloseTabItemCommand(this);
        }

        public ICommand CloseTabItemCommand
        {
            get
            {
                return closetabitemcommand;
            }
        }

        /// <summary>
        /// Cierra el TabItem según la EOpcion recibida por params
        /// </summary>
        /// <param name="parameter"></param>
        public void CloseTabItem(object parameter)
        {
            RecopilatorioEnumerations.EOpcion tipoaux = ribbonbuttondictionary.FirstOrDefault(z => z.Key.ToString() == parameter.ToString()).Key;
            TabItemLogic.RemoveTabItem(tipoaux);
        }
    }
}
