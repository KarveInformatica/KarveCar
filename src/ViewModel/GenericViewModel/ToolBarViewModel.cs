using System.Windows;
using System.Windows.Input;
using KarveCar.Logic.ToolBar;
using KarveCommon.Generic;
using ToolBarModule.Command;

namespace KarveCar.ViewModel.GenericViewModel
{
    public class ToolBarViewModel : GenericPropertyChanged
    {
        #region Variables
        private PreviousCommand anteriortoolbarcommand;
        private FindCommand    buscartoolbarcommand;
        private CancelCommand  cancelartoolbarcommand;
        private EditCommand    editartoolbarcommand;
        private DeleteCommand  eliminartoolbarcommand;
        private SaveCommand   guardartoolbarcommand;
        private PrintCommand  imprimirtoolbarcommand;
        private NewCommand     nuevotoolbarcommand;
        private ExitCommand     salirtoolbarcommand;
        private NextCommand siguientetoolbarcommand;
        #endregion

        #region Constructor
        // TODO: Remove this.
        public ToolBarViewModel()
        {
            this.anteriortoolbarcommand  = new PreviousCommand(null);
            this.buscartoolbarcommand    = new FindCommand(null);
            this.cancelartoolbarcommand  = new CancelCommand(null);
            this.editartoolbarcommand    = new EditCommand(null);
            this.guardartoolbarcommand   = new SaveCommand(null);
            this.imprimirtoolbarcommand  = new PrintCommand(null);
            this.nuevotoolbarcommand     = new NewCommand(null);
            this.salirtoolbarcommand     = new ExitCommand(null);
            this.siguientetoolbarcommand = new NextCommand(null);
        }
        #endregion

        #region Commands
        public ICommand AnteriorToolBarCommand  { get { return anteriortoolbarcommand; } }
        public ICommand BuscarToolBarCommand    { get { return buscartoolbarcommand; } }
        public ICommand CancelarToolBarCommand  { get { return cancelartoolbarcommand; } }
        public ICommand EditarToolBarCommand    { get { return editartoolbarcommand; } }
        public ICommand EliminarToolBarCommand  { get { return eliminartoolbarcommand; } }
        public ICommand GuardarToolBarCommand   { get { return guardartoolbarcommand; } }
        public ICommand ImprimirToolBarCommand  { get { return imprimirtoolbarcommand; } }
        public ICommand NuevoToolBarCommand     { get { return nuevotoolbarcommand; } }
        public ICommand SalirToolBarCommand     { get { return salirtoolbarcommand; } }
        public ICommand SiguienteToolBarCommand { get { return siguientetoolbarcommand; } }
        #endregion

        #region Métodos
        public void AnteriorToolBar(object parameter)
        {
            AnteriorToolBarLogic.AnteriorToolBar();
        }

        public void BuscarToolBar(object parameter)
        {
            BuscarToolBarLogic.BuscarToolBar();
        }

        public void CancelarToolBar(object parameter)
        {
            CancelarToolBarLogic.CancelarToolBar();
        }

        public void EditarToolBar(object parameter)
        {
            EditarToolBarLogic.EditarToolBar();
        }

        public void EliminarToolBar(object parameter)
        {
            EliminarToolBarLogic.EliminarToolBar();
        }

        public void GuardarToolBar(object parameter)
        {
            GuardarToolBarLogic.GuardarToolBar();
        }

        public void ImprimirToolBar(object parameter)
        {
            ImprimirToolBarLogic.ImprimirToolBar();
        }

        public void NuevoToolBar(object parameter)
        {
            NuevoToolBarLogic.NuevoToolBar();
        }

        public void SalirToolBar(object parameter)
        {
            SalirToolBarLogic.SalirToolBar();
        }

        public void SiguienteToolBar(object parameter)
        {
            SiguienteToolBarLogic.SiguienteToolBar();
        }
        #endregion
    }
}