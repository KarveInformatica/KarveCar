using System.Linq;
using System.Windows.Input;
using KarveCar.Commands.Generic;
using KarveCar.Model.Generic;
using KarveCommon.Generic;
using KarveCommon.Logic.Generic;

namespace KarveCar.ViewModels
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
            string name = parameter as string;
            RecopilatorioEnumerations.EOpcion tipoaux = RecopilatorioCollections.ribbonbuttondictionary.FirstOrDefault(z => z.Key.ToString() == parameter.ToString()).Key;
            TabItemLogic.RemoveTabItem(tipoaux);
        }
    }
}
