using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveControls.UIObjects;

namespace ProvidersModule.Common
{
    internal class UiGeneralPageBuilder: IUiPageBuilder
    {
        IList<IUiPageBuilder> _pageBuilders = new List<IUiPageBuilder>();
        private UiEmailDataField.EmailCheckHandler _emailCheckHandler;

        public UiEmailDataField.EmailCheckHandler EmailCheckHandler
        {
            get { return _emailCheckHandler; }
            set { _emailCheckHandler = value; }
        }
        public UiGeneralPageBuilder()
        {
            _pageBuilders.Add(new UiUpperPartPageBuilder());
            _pageBuilders.Add(new UiMiddlePartPageBuilder(EmailCheckHandler));
        }
        public IDictionary<string, ObservableCollection<IUiObject>> BuildPageObjects(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery, UiDfObject.ChangedField changedField)
        {
            IDictionary<string, ObservableCollection<IUiObject>> dictionary = new Dictionary<string, ObservableCollection<IUiObject>>();

            foreach (IUiPageBuilder builder in _pageBuilders)
            {
                IDictionary<string, ObservableCollection<IUiObject>> tmpDictionary = builder.BuildPageObjects(assistQuery, changedField);
                tmpDictionary.ToList().ForEach(x => dictionary.Add(x.Key, x.Value));
            }
            return dictionary;
        }

    }
}
