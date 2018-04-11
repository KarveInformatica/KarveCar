using System.Collections.Generic;

namespace KarveCommonInterfaces
{
    public interface IInteractionRequestController
    {
        void ShowAssistView<T>(string title, IEnumerable<T> dataObjects, string assistProperties);
        object SelectedItem { get; set; }
        SelectionState SelectionState { get; set; }
    }
}
