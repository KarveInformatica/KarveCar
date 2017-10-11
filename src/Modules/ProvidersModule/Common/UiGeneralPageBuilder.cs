using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveControls.UIObjects;

namespace ProvidersModule.Common
{
    class UiGeneralPageBuilder: IUiPageBuilder
    {
        public IDictionary<string, ObservableCollection<IUiObject>> BuildPageObjects(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery, UiDfObject.ChangedField changedField)
        {
            throw new NotImplementedException();
        }

    }
}
