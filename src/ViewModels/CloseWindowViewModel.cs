using System.Windows.Input;
using KarveCar.Commands.Generic;
using KarveCommon.Generic;

namespace KarveCar.ViewModels
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
            ///Logic.Generic.CloseWindowLogic.CloseWindowFromCommand();
        }
    }
}
