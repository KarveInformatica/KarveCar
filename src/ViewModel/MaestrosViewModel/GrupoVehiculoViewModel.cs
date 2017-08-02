using KarveCar.Commands.MaestrosCommand;
using KarveCar.Logic.Generic;
using KarveCommon.Generic;
using System.Linq;
using System.Windows.Input;
using static KarveCar.Model.Generic.RecopilatorioCollections;

namespace KarveCar.ViewModel.MaestrosViewModel
{
    public class GrupoVehiculoViewModel : GenericPropertyChanged
    {
        #region Variables
        private GrupoVehiculoCommand grupovehiculocommand;
        #endregion

        #region Constructor
        public GrupoVehiculoViewModel()
        {
            this.grupovehiculocommand = new GrupoVehiculoCommand(this);
        }
        #endregion

        #region Commands
        public ICommand GrupoVehiculoCommand
        {
            get
            {
                return grupovehiculocommand;
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Crea el TabItem para CRUD los Grupos de Vehículos
        /// </summary>
        /// <param name="parameter"></param>
        public void GrupoVehiculo(object parameter)
        {
            RecopilatorioEnumerations.EOpcion opcion = ribbonbuttondictionary.Where(z => z.Key.ToString() == parameter.ToString()).FirstOrDefault().Key;

            //Si el param no se encuentra en la Enum EOpcion, no hace nada, sino mostraría 
            //la Tab correspondiente al primer valor de la Enum EOpcion
            if (opcion.ToString() == parameter.ToString())
            {
                TabItemLogic.CreateTabItemUserControl(opcion);
                var obscollection = tabitemdictionary.Where(z => z.Key.ToString() == parameter.ToString()).FirstOrDefault().Value.GenericObsCollection;
            }
        }
        #endregion
    }
}