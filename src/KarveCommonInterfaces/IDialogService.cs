using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCommonInterfaces
{
    /// <summary>
    ///  Dialog service used for dialog in the model view view model pattern.
    /// </summary>
    public interface IDialogService
    {
        /// <summary>
        ///  This inteface is used to register a dialog.
        /// </summary>
        /// <param name="dialogID"></param>
        /// <param name="type"></param>
      void RegisterDialog(string dialogID, Type type);
      bool? ShowDialog(string dialogID);  
    }
}
