using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KarveControls.UIObjects
{
    public interface IUiPageBuilder
    {
        // Return the dictionary with each observable collecton needed for each part of the page.
        // The client know the value of the keys.
        IDictionary<string, ObservableCollection<IUiObject> > BuildPageObjects(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery,
            UiDfObject.ChangedField changedField);
    }
}