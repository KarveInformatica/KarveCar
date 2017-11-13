using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KarveControls.UIObjects
{
    /// <summary>
    /// This interface gives to the developer a way to build a collection of objects to be mapped 
    /// via a data template selector directly to a page.
    /// </summary>
    public interface IUiPageBuilder
    {
        /// <summary>
        /// Return the dictionary with each observable collection needed for each part of the page.
        /// </summary>
        /// <param name="assistQuery">Handler for the query of magnifier boxes</param>
        /// <param name="changedField">Handler for any change.</param>
        /// <returns></returns>
        IDictionary<string, ObservableCollection<IUiObject> > BuildPageObjects(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery,
            UiDfObject.ChangedField changedField);
    }
}