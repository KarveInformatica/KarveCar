using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCommonInterfaces
{
    /// <summary>
    ///  This interface is service for showing a grid with a list of objects.
    ///  It gets used when you do an "assist" clicking the magnifier.
    ///  The grid will be used to show and select the item from the end user.
    /// </summary>
    public interface IAssistService
    {
        /// <summary>
        ///  Show an assist view
        /// </summary>
        /// <typeparam name="T">Type of the data transfer object</typeparam>
        /// <param name="title">Title of the grid</param>
        /// <param name="dataObjects">List of object to be shown</param>
        void ShowAssistView<T>(string title, IEnumerable<T> dataObjects);
        /// <summary>
        ///  This is the selected item.
        /// </summary>
        object SelectedItem { set; get; }
    }
}
