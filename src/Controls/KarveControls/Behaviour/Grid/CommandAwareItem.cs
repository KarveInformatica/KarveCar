// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandAwareItem.cs" company="KarveInformatica S.L.">
//   
// </copyright>
// <summary>
//   Defines the CommandAwareItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace KarveControls.Behaviour.Grid
{
    using System.Windows.Input;

    /// <summary>
    /// CommandAwareItem. Item to be used.
    /// </summary>
    public class CommandAwareItem: CellPresenterItem
    {
        /// <summary>
        /// Gets or sets the action to be executed.
        /// </summary>
        public ICommand Action { get; set; }
    }
}
