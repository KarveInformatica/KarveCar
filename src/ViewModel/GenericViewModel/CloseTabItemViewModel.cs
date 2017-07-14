using KRibbon.Commands.Generic;
using KRibbon.Logic.Generic;
using KRibbon.Model.Generic;
using System.Linq;
using System.Windows.Input;
using static KRibbon.Model.Generic.RecopilatorioCollections;
using static KRibbon.Model.Generic.RecopilatorioEnumerations;

namespace KRibbon.ViewModel.GenericViewModel
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
            EOpcion tipoaux = ribbonbuttondictionary.Where(z => z.Key.ToString() == parameter.ToString()).FirstOrDefault().Key;
            TabItemLogic.RemoveTabItem(tipoaux);
        }
    }
}
