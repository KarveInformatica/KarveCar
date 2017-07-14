using KarveCar.Commands.Generic;
using KarveCar.Model.Generic;
using System.Windows.Input;

namespace KarveCar.ViewModel.GenericViewModel
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
