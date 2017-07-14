using KRibbon.Commands.ToolBarCommand;
using KRibbon.Logic.ToolBar;
using KRibbon.Model.Generic;
using System.Windows;
using System.Windows.Input;

namespace KRibbon.ViewModel.GenericViewModel
{
    public class ToolBarViewModel : GenericPropertyChanged
    {
        #region Variables
        private AnteriorToolBarCommand  anteriortoolbarcommand;
        private BuscarToolBarCommand    buscartoolbarcommand;
        private CancelarToolBarCommand  cancelartoolbarcommand;
        private EditarToolBarCommand    editartoolbarcommand;
        private EliminarToolBarCommand  eliminartoolbarcommand;
        private GuardarToolBarCommand   guardartoolbarcommand;
        private ImprimirToolBarCommand  imprimirtoolbarcommand;
        private NuevoToolBarCommand     nuevotoolbarcommand;
        private SalirToolBarCommand     salirtoolbarcommand;
        private SiguienteToolBarCommand siguientetoolbarcommand;
        #endregion

        #region Constructor
        public ToolBarViewModel()
        {
            this.anteriortoolbarcommand  = new AnteriorToolBarCommand(this);
            this.buscartoolbarcommand    = new BuscarToolBarCommand(this);
            this.cancelartoolbarcommand  = new CancelarToolBarCommand(this);
            this.editartoolbarcommand    = new EditarToolBarCommand(this);
            this.eliminartoolbarcommand  = new EliminarToolBarCommand(this);
            this.guardartoolbarcommand   = new GuardarToolBarCommand(this);
            this.imprimirtoolbarcommand  = new ImprimirToolBarCommand(this);
            this.nuevotoolbarcommand     = new NuevoToolBarCommand(this);
            this.salirtoolbarcommand     = new SalirToolBarCommand(this);
            this.siguientetoolbarcommand = new SiguienteToolBarCommand(this);
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
            //MessageBox.Show("public void AnteriorToolBar(object parameter) -> " + parameter.ToString());
            AnteriorToolBarLogic.AnteriorToolBar();
        }

        public void BuscarToolBar(object parameter)
        {
            //MessageBox.Show("public void BuscarToolBar(object parameter) -> " + parameter.ToString());
            BuscarToolBarLogic.BuscarToolBar();
        }

        public void CancelarToolBar(object parameter)
        {
            //MessageBox.Show("public void CancelarToolBar(object parameter) -> " + parameter.ToString());
            CancelarToolBarLogic.CancelarToolBar();
        }

        public void EditarToolBar(object parameter)
        {
            //MessageBox.Show("public void EditarToolBar(object parameter) -> " + parameter.ToString());
            EditarToolBarLogic.EditarToolBar();
        }

        public void EliminarToolBar(object parameter)
        {
            //MessageBox.Show("public void EliminarToolBar(object parameter) -> " + parameter.ToString());
            EliminarToolBarLogic.EliminarToolBar();
        }

        public void GuardarToolBar(object parameter)
        {
            //MessageBox.Show("public void GuardarToolBar(object parameter) -> " + parameter.ToString());
            GuardarToolBarLogic.GuardarToolBar();
        }
        public void ImprimirToolBar(object parameter)
        {
            //MessageBox.Show("public void ImprimirToolBar(object parameter) -> " + parameter.ToString());
            ImprimirToolBarLogic.ImprimirToolBar();
        }
        public void NuevoToolBar(object parameter)
        {
            //MessageBox.Show("public void NuevoToolBar(object parameter) -> " + parameter.ToString());
            NuevoToolBarLogic.NuevoToolBar();
        }
        public void SalirToolBar(object parameter)
        {
            //MessageBox.Show("public void SalirToolBar(object parameter) -> " + parameter.ToString());
            SalirToolBarLogic.SalirToolBar();
        }
        public void SiguienteToolBar(object parameter)
        {
            //MessageBox.Show("public void SiguienteToolBar(object parameter) -> " + parameter.ToString());
            SiguienteToolBarLogic.SiguienteToolBar();
        }
        #endregion
    }
}