using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karve.Interactivity
{
    public interface IInteractionRequestController
    {
       void ShowAssistView<T>(string title, IEnumerable<T> dataObjects);
    }
}
