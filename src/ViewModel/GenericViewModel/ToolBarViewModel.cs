using KarveCar.Commands.ToolBarCommand;
using KarveCar.Logic.ToolBar;
using KarveCar.Model.Generic;
using System.Windows;
using System.Windows.Input;
using KarveCommon.Generic;

namespace KarveCar.ViewModel.GenericViewModel
{
    public class ToolBarViewModel : GenericPropertyChanged
    {
        #region Variables
        private PreviousToolBarCommand  anteriortoolbarcommand;
        private FindToolBarCommand    buscartoolbarcommand;
        private CancelToolBarCommand  cancelartoolbarcommand;
        private EditToolBarCommand    editartoolbarcommand;
        private DeleteToolBarCommand  eliminartoolbarcommand;
        private SaveToolBarCommand   guardartoolbarcommand;
        private PrintToolBarCommand  imprimirtoolbarcommand;
        private NewToolBarCommand     nuevotoolbarcommand;
        private ExitToolBarCommand     salirtoolbarcommand;
        private NextToolBarCommand siguientetoolbarcommand;
        #endregion

        #region Constructor
        public ToolBarViewModel()
        {
            this.anteriortoolbarcommand  = new PreviousToolBarCommand(this);
            this.buscartoolbarcommand    = new FindToolBarCommand(this);
            this.cancelartoolbarcommand  = new CancelToolBarCommand(this);
            this.editartoolbarcommand    = new EditToolBarCommand(this);
            this.eliminartoolbarcommand  = new DeleteToolBarCommand(this);
            this.guardartoolbarcommand   = new SaveToolBarCommand(this);
            this.imprimirtoolbarcommand  = new PrintToolBarCommand(this);
            this.nuevotoolbarcommand     = new NewToolBarCommand(this);
            this.salirtoolbarcommand     = new ExitToolBarCommand(this);
            this.siguientetoolbarcommand = new NextToolBarCommand(this);
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