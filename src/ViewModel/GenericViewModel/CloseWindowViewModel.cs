using KRibbon.Commands.Generic;
using KRibbon.Model.Generic;
using System.Windows.Input;

namespace KRibbon.ViewModel.GenericViewModel
{
    class CloseWindowViewModel : GenericPropertyChanged
    {
        private CloseWindowCommand closewindowcommand;

        public CloseWindowViewModel()
        {
            this.closewindowcommand = new CloseWindowCommand(this);
        }

        public ICommand CloseWindowCommand
        {
            get
            {
                return closewindowcommand;
            }
        }

        /// <summary>
        /// Cierra la aplicación
        /// </summary>
        /// <param name="parameter"></param>
        public void CloseWindow(object parameter)
        {
            Logic.Generic.CloseWindowLogic.CloseWindowFromCommand();
        }
    }
}
